using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockMasterX.Data;
using StockMasterX.Models;

namespace StockMasterX.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            // ARREGLADO: Agregado .Include() para cargar productos
            return View(await _context.Suppliers
                .Include(s => s.Products)
                .ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Products)
                    .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContactPerson,Email,Phone,Address,CreatedAt,IsActive")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactPerson,Email,Phone,Address,CreatedAt,IsActive")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                supplier.CreatedAt = DateTime.Now;
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Proveedor creado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                var existingSupplier = await _context.Suppliers.FindAsync(supplier.Id);
                if (existingSupplier == null)
                {
                    return Json(new { success = false, message = "Proveedor no encontrado" });
                }

                existingSupplier.Name = supplier.Name;
                existingSupplier.ContactPerson = supplier.ContactPerson;
                existingSupplier.Email = supplier.Email;
                existingSupplier.Phone = supplier.Phone;
                existingSupplier.Address = supplier.Address;
                existingSupplier.IsActive = supplier.IsActive;

                _context.Update(existingSupplier);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Proveedor actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSupplier([FromBody] int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return Json(new { success = false, message = "Proveedor no encontrado" });
                }

                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Proveedor eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar: " + ex.Message });
            }
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}