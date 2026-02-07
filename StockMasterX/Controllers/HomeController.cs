using Microsoft.AspNetCore.Mvc;
using StockMasterX.Models;
using System.Diagnostics;
using StockMasterX.Data;
using Microsoft.EntityFrameworkCore;

namespace StockMasterX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Estadísticas para el dashboard
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalCategories = await _context.Categories.CountAsync();
            ViewBag.TotalSuppliers = await _context.Suppliers.CountAsync();
            ViewBag.LowStockProducts = await _context.Products
                .Where(p => p.CurrentStock <= p.MinimumStock)
                .CountAsync();

            // Productos con stock bajo
            var lowStockProducts = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CurrentStock <= p.MinimumStock)
                .Take(5)
                .ToListAsync();

            // Movimientos recientes
            var recentMovements = await _context.InventoryMovements
                .Include(m => m.Product)
                .OrderByDescending(m => m.MovementDate)
                .Take(5)
                .ToListAsync();

            ViewBag.LowStockProducts = lowStockProducts;
            ViewBag.RecentMovements = recentMovements;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}