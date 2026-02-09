using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockMasterX.Data;
using StockMasterX.Models;
using StockMasterX.Services;
using StockMasterX.ViewModels;
using StockMasterX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMasterX.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelExportService _excelService;

        public ProductsController(ApplicationDbContext context, ExcelExportService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SKU,Description,PurchasePrice,SalePrice,CurrentStock,MinimumStock,ImageUrl,CategoryId,SupplierId,IsActive")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Producto creado exitosamente";

                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, volver a cargar los dropdowns
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] CreateProductViewModel model)
        {
            try
            {
                var product = await _context.Products.FindAsync(model.Id);

                if (product == null)
                {
                    return Json(new { success = false, message = "Producto no encontrado" });
                }

                product.Name = model.Name;
                product.SKU = model.SKU;
                product.Description = model.Description;
                product.PurchasePrice = model.PurchasePrice;
                product.SalePrice = model.SalePrice;
                product.CurrentStock = model.CurrentStock;
                product.MinimumStock = model.MinimumStock;
                product.ImageUrl = model.ImageUrl;
                product.CategoryId = model.CategoryId;
                product.SupplierId = model.SupplierId;
                product.IsActive = model.IsActive;

                _context.Update(product);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Producto actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromBody] int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return Json(new { success = false, message = "Producto no encontrado" });
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Producto eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar: " + ex.Message });
            }
        }






        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductViewModel model)
        {
            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    SKU = model.SKU,
                    Description = model.Description,
                    PurchasePrice = model.PurchasePrice,
                    SalePrice = model.SalePrice,
                    CurrentStock = model.CurrentStock,
                    MinimumStock = model.MinimumStock,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId,
                    SupplierId = model.SupplierId,
                    IsActive = model.IsActive,
                    CreatedAt = DateTime.Now
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Producto creado exitosamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }










        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SKU,Description,PurchasePrice,SalePrice,CurrentStock,MinimumStock,ImageUrl,CreatedAt,IsActive,CategoryId,SupplierId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // GET: Products/ExportToExcel
        public async Task<IActionResult> ExportToExcel()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();

            var fileBytes = _excelService.ExportProductsToExcel(products);
            var fileName = $"Productos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}