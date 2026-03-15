using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    internal class Player
    {
        public int TotalExp { get; set; }
        public int TotalCoin { get; set; }
        public int Level => (TotalExp / 1000) + 1; // Ví dụ: cứ 1000 EXP lên 1 cấp

        // Danh sách các vật phẩm đã mua (ID của các món đồ trong Store)
        public List<int> OwnedItemIds { get; set; } = new List<int>();
    }
}
