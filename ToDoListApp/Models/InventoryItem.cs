namespace ToDoListApp.Models
{
    public class InventoryItem
    {
        public int InventoryId { get; set; }
        // Legacy fields kept for compatibility with UI
        public string Name { get; set; }
        public string ImagePath { get; set; }

        // DB-aligned fields (report)
        public string ItemName { get => Name; set => Name = value; }
        public string ImageName { get => ImagePath; set => ImagePath = value; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }

        public int UserId { get; set; }
        
       public DateTime PurchasedAt { get; set; }
    }
}