namespace ToDoListApp.Models
{
    public class StoreItem
    {
        // Legacy Id
        public int Id { get; set; }

        // DB aligned
        public int StoreItemId { get => Id; set => Id = value; }

        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        // In report image field named ImageName
        public string ImagePath { get; set; } // legacy
        public string ImageName { get => ImagePath; set => ImagePath = value; }
        public string Category { get; set; }
    }
}