using StockMasterX.Models;

namespace StockMasterX.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Verificar si ya hay datos
            if (context.Categories.Any())
            {
                return; // Ya hay datos, no hacer nada
            }

            // Crear Categorías
            var categories = new List<Category>
            {
                new Category { Name = "Electrónica", Description = "Dispositivos y componentes electrónicos", IsActive = true },
                new Category { Name = "Alimentos", Description = "Productos alimenticios y bebidas", IsActive = true },
                new Category { Name = "Ropa", Description = "Vestimenta y accesorios", IsActive = true },
                new Category { Name = "Hogar", Description = "Artículos para el hogar", IsActive = true },
                new Category { Name = "Deportes", Description = "Equipamiento deportivo", IsActive = true }
            };
            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            // Crear Proveedores
            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Name = "TechSupply S.A.",
                    ContactPerson = "Juan Pérez",
                    Email = "juan@techsupply.com",
                    Phone = "2222-3333",
                    Address = "San José, Costa Rica",
                    IsActive = true
                },
                new Supplier
                {
                    Name = "Distribuidora Nacional",
                    ContactPerson = "María González",
                    Email = "maria@disnac.com",
                    Phone = "2333-4444",
                    Address = "Heredia, Costa Rica",
                    IsActive = true
                },
                new Supplier
                {
                    Name = "Import Global CR",
                    ContactPerson = "Carlos Rodríguez",
                    Email = "carlos@importglobal.com",
                    Phone = "2444-5555",
                    Address = "Cartago, Costa Rica",
                    IsActive = true
                }
            };
            await context.Suppliers.AddRangeAsync(suppliers);
            await context.SaveChangesAsync();

            // Crear Productos
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Laptop Dell Inspiron",
                    SKU = "LAPTOP-001",
                    Description = "Laptop 15 pulgadas, 8GB RAM, 256GB SSD",
                    PurchasePrice = 450000,
                    SalePrice = 650000,
                    CurrentStock = 15,
                    MinimumStock = 5,
                    CategoryId = categories[0].Id,
                    SupplierId = suppliers[0].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Mouse Inalámbrico Logitech",
                    SKU = "MOUSE-001",
                    Description = "Mouse inalámbrico ergonómico",
                    PurchasePrice = 8000,
                    SalePrice = 15000,
                    CurrentStock = 3,
                    MinimumStock = 10,
                    CategoryId = categories[0].Id,
                    SupplierId = suppliers[0].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Teclado Mecánico RGB",
                    SKU = "KEYB-001",
                    Description = "Teclado mecánico con luces RGB",
                    PurchasePrice = 25000,
                    SalePrice = 45000,
                    CurrentStock = 8,
                    MinimumStock = 5,
                    CategoryId = categories[0].Id,
                    SupplierId = suppliers[0].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Arroz Premium 1kg",
                    SKU = "ARROZ-001",
                    Description = "Arroz blanco premium",
                    PurchasePrice = 800,
                    SalePrice = 1500,
                    CurrentStock = 2,
                    MinimumStock = 20,
                    CategoryId = categories[1].Id,
                    SupplierId = suppliers[1].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Frijoles Negros 500g",
                    SKU = "FRIJ-001",
                    Description = "Frijoles negros empacados",
                    PurchasePrice = 600,
                    SalePrice = 1200,
                    CurrentStock = 50,
                    MinimumStock = 30,
                    CategoryId = categories[1].Id,
                    SupplierId = suppliers[1].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Camiseta Deportiva",
                    SKU = "CAM-001",
                    Description = "Camiseta para ejercicio, talla M",
                    PurchasePrice = 5000,
                    SalePrice = 12000,
                    CurrentStock = 25,
                    MinimumStock = 10,
                    CategoryId = categories[2].Id,
                    SupplierId = suppliers[2].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Lámpara LED",
                    SKU = "LAMP-001",
                    Description = "Lámpara LED de escritorio",
                    PurchasePrice = 8000,
                    SalePrice = 15000,
                    CurrentStock = 12,
                    MinimumStock = 8,
                    CategoryId = categories[3].Id,
                    SupplierId = suppliers[2].Id,
                    IsActive = true
                },
                new Product
                {
                    Name = "Balón de Fútbol",
                    SKU = "BAL-001",
                    Description = "Balón profesional tamaño 5",
                    PurchasePrice = 12000,
                    SalePrice = 22000,
                    CurrentStock = 4,
                    MinimumStock = 6,
                    CategoryId = categories[4].Id,
                    SupplierId = suppliers[2].Id,
                    IsActive = true
                }
            };
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Crear Movimientos de Inventario
            var movements = new List<InventoryMovement>
            {
                new InventoryMovement
                {
                    ProductId = products[0].Id,
                    Type = MovementType.Entry,
                    Quantity = 10,
                    Reason = "Compra inicial de inventario",
                    MovementDate = DateTime.Now.AddDays(-5)
                },
                new InventoryMovement
                {
                    ProductId = products[0].Id,
                    Type = MovementType.Exit,
                    Quantity = 2,
                    Reason = "Venta a cliente",
                    MovementDate = DateTime.Now.AddDays(-3)
                },
                new InventoryMovement
                {
                    ProductId = products[1].Id,
                    Type = MovementType.Entry,
                    Quantity = 15,
                    Reason = "Reposición de stock",
                    MovementDate = DateTime.Now.AddDays(-7)
                },
                new InventoryMovement
                {
                    ProductId = products[3].Id,
                    Type = MovementType.Exit,
                    Quantity = 5,
                    Reason = "Venta mayorista",
                    MovementDate = DateTime.Now.AddDays(-2)
                },
                new InventoryMovement
                {
                    ProductId = products[5].Id,
                    Type = MovementType.Adjustment,
                    Quantity = 3,
                    Reason = "Ajuste por inventario físico",
                    MovementDate = DateTime.Now.AddDays(-1)
                }
            };
            await context.InventoryMovements.AddRangeAsync(movements);
            await context.SaveChangesAsync();
        }
    }
}