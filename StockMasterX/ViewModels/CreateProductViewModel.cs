namespace StockMasterX.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public bool IsActive { get; set; } = true;
    }






}