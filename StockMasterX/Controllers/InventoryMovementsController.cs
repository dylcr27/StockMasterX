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
    public class InventoryMovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryMovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InventoryMovements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InventoryMovements.Include(i => i.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InventoryMovements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryMovement = await _context.InventoryMovements
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryMovement == null)
            {
                return NotFound();
            }

            return View(inventoryMovement);
        }

        // GET: InventoryMovements/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: InventoryMovements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Type,Quantity,Reason,MovementDate,UserId")] InventoryMovement inventoryMovement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", inventoryMovement.ProductId);
            return View(inventoryMovement);
        }

        // GET: InventoryMovements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryMovement = await _context.InventoryMovements.FindAsync(id);
            if (inventoryMovement == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", inventoryMovement.ProductId);
            return View(inventoryMovement);
        }

        // POST: InventoryMovements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Type,Quantity,Reason,MovementDate,UserId")] InventoryMovement inventoryMovement)
        {
            if (id != inventoryMovement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryMovementExists(inventoryMovement.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", inventoryMovement.ProductId);
            return View(inventoryMovement);
        }

        // GET: InventoryMovements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryMovement = await _context.InventoryMovements
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryMovement == null)
            {
                return NotFound();
            }

            return View(inventoryMovement);
        }

        // POST: InventoryMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryMovement = await _context.InventoryMovements.FindAsync(id);
            if (inventoryMovement != null)
            {
                _context.InventoryMovements.Remove(inventoryMovement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> CreateMovement([FromBody] InventoryMovement movement)
        {
            try
            {
                _context.InventoryMovements.Add(movement);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Movimiento registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovement([FromBody] InventoryMovement movement)
        {
            try
            {
                var existingMovement = await _context.InventoryMovements.FindAsync(movement.Id);
                if (existingMovement == null)
                {
                    return Json(new { success = false, message = "Movimiento no encontrado" });
                }

                existingMovement.ProductId = movement.ProductId;
                existingMovement.Type = movement.Type;
                existingMovement.Quantity = movement.Quantity;
                existingMovement.Reason = movement.Reason;
                existingMovement.MovementDate = movement.MovementDate;

                _context.Update(existingMovement);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Movimiento actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteMovement([FromBody] int id)
        {
            try
            {
                var movement = await _context.InventoryMovements.FindAsync(id);
                if (movement == null)
                {
                    return Json(new { success = false, message = "Movimiento no encontrado" });
                }

                _context.InventoryMovements.Remove(movement);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Movimiento eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar: " + ex.Message });
            }
        }



        private bool InventoryMovementExists(int id)
        {
            return _context.InventoryMovements.Any(e => e.Id == id);
        }
    }
}
