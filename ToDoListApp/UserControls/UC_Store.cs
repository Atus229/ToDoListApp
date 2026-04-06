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
    public partial class UC_Store : UserControl
    {
        public UC_Store()
        {
            InitializeComponent();
            LoadStoreItems();
        }

        private void LoadStoreItems()
        {
            flpStore.Controls.Clear();

            // 1. Lấy dữ liệu từ bảng StoreItems
            string query = "SELECT * FROM StoreItems";
            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // 2. Map dữ liệu vào Model
                    StoreItem item = new StoreItem
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        ItemName = row["ItemName"].ToString(),
                        Price = Convert.ToInt32(row["Price"]),
                        ImagePath = row["ImageName"].ToString()
                    };

                    // 3. Tạo UserControl và add vào Panel
                    UC_StoreItem ucItem = new UC_StoreItem(item);
                    flpStore.Controls.Add(ucItem);
                }
            }
        }
    }
}
