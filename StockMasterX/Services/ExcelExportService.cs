using OfficeOpenXml;
using OfficeOpenXml.Style;
using StockMasterX.Models;
using System.Drawing;

namespace StockMasterX.Services
{
    public class ExcelExportService
    {
        public byte[] ExportProductsToExcel(IEnumerable<Product> products)
        {
            // Configurar licencia
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Productos");

                // Encabezados
                worksheet.Cells[1, 1].Value = "SKU";
                worksheet.Cells[1, 2].Value = "Nombre";
                worksheet.Cells[1, 3].Value = "Descripción";
                worksheet.Cells[1, 4].Value = "Categoría";
                worksheet.Cells[1, 5].Value = "Proveedor";
                worksheet.Cells[1, 6].Value = "Precio Compra";
                worksheet.Cells[1, 7].Value = "Precio Venta";
                worksheet.Cells[1, 8].Value = "Stock Actual";
                worksheet.Cells[1, 9].Value = "Stock Mínimo";
                worksheet.Cells[1, 10].Value = "Estado";

                // Estilo de encabezados
                using (var range = worksheet.Cells[1, 1, 1, 10])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                    range.Style.Font.Color.SetColor(Color.White);
                }

                // Datos
                int row = 2;
                foreach (var product in products)
                {
                    worksheet.Cells[row, 1].Value = product.SKU;
                    worksheet.Cells[row, 2].Value = product.Name;
                    worksheet.Cells[row, 3].Value = product.Description;
                    worksheet.Cells[row, 4].Value = product.Category?.Name;
                    worksheet.Cells[row, 5].Value = product.Supplier?.Name;
                    worksheet.Cells[row, 6].Value = product.PurchasePrice;
                    worksheet.Cells[row, 7].Value = product.SalePrice;
                    worksheet.Cells[row, 8].Value = product.CurrentStock;
                    worksheet.Cells[row, 9].Value = product.MinimumStock;
                    worksheet.Cells[row, 10].Value = product.IsActive ? "Activo" : "Inactivo";

                    // Resaltar productos con stock bajo
                    if (product.CurrentStock <= product.MinimumStock)
                    {
                        using (var range = worksheet.Cells[row, 1, row, 10])
                        {
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 199, 206));
                        }
                    }

                    row++;
                }

                // Formatear columnas de precios
                worksheet.Cells[2, 6, row - 1, 7].Style.Numberformat.Format = "₡#,##0.00";

                // Autoajustar columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }

        public byte[] ExportInventoryMovementsToExcel(IEnumerable<InventoryMovement> movements)
        {
            // Configurar licencia
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Movimientos");

                // Encabezados
                worksheet.Cells[1, 1].Value = "Fecha";
                worksheet.Cells[1, 2].Value = "Producto";
                worksheet.Cells[1, 3].Value = "Tipo";
                worksheet.Cells[1, 4].Value = "Cantidad";
                worksheet.Cells[1, 5].Value = "Razón";

                // Estilo de encabezados
                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                    range.Style.Font.Color.SetColor(Color.White);
                }

                // Datos
                int row = 2;
                foreach (var movement in movements)
                {
                    worksheet.Cells[row, 1].Value = movement.MovementDate.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[row, 2].Value = movement.Product?.Name;
                    worksheet.Cells[row, 3].Value = movement.Type.ToString();
                    worksheet.Cells[row, 4].Value = movement.Quantity;
                    worksheet.Cells[row, 5].Value = movement.Reason;

                    row++;
                }

                // Autoajustar columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}