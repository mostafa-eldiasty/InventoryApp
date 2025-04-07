namespace InventoryApp.Common.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
