namespace StockMasterX.Models
{
    public enum MovementType
    {
        Entry,      // Entrada
        Exit,       // Salida
        Adjustment  // Ajuste
    }

    public class InventoryMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public MovementType Type { get; set; }
        public int Quantity { get; set; }
        public string? Reason { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public string? UserId { get; set; }

        // Navigation
        public Product Product { get; set; } = null!;
    }
}