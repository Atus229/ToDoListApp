using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToDoListApp.Models;

namespace ToDoListApp.UserControls
{
    public partial class UC_Inventory : UserControl
    {
        public UC_Inventory()
        {
            InitializeComponent();
        }
        private void UC_Inventory_Load(object sender, EventArgs e)
        {
            // CỰC KỲ QUAN TRỌNG: Phải gọi hàm này ở đây!
            LoadInventory();
        }


        public void LoadInventory()
        {
            // 1. Dọn dẹp túi đồ cũ trên giao diện
            flpInventory.Controls.Clear();

            // 2. Câu lệnh SQL lấy món đồ + số lượng + ảnh
            // Chúng ta JOIN bảng Inventory với bảng StoreItems để lấy được ImagePath và ItemName
            string query = @"SELECT i.Id, s.ItemName, s.ImageName, i.Quantity 
                     FROM Inventory i
                     JOIN StoreItems s ON i.ItemId = s.Id";

            DataTable dt = Helper.DatabaseHelper.GetData(query);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Tạo một đối tượng chứa thông tin món đồ trong túi
                    InventoryItem invItem = new InventoryItem
                    {
                        InventoryId = Convert.ToInt32(row["Id"]),
                        Name = row["ItemName"].ToString(),
                        ImagePath = row["ImageName"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"])
                    };

                    // Tạo thẻ hiển thị (UserControl con)
                    UC_InventoryItem itemUI = new UC_InventoryItem(invItem);

                    // Thêm vào FlowLayoutPanel của trang Inventory
                    flpInventory.Controls.Add(itemUI);
                }
            }
        }
    }
}
