using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    internal class StoreItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; } // Đường dẫn ảnh vật phẩm
        public bool IsLimited { get; set; }    // Đồ giới hạn hay đồ thường
    }
}
