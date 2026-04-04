namespace ToDoListApp.Models
{
    public class StoreItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } // Lưu tên file ảnh hoặc đường dẫn
    }
}