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
    public partial class UC_StoreItem : UserControl
    {
        private StoreItem _item;
        public UC_StoreItem(StoreItem item)
        {
            InitializeComponent();
            this._item = item;

            lblItemName.Text = item.ItemName;
            lblPrice.Text = item.Price.ToString();

            // 1. Xác định đường dẫn đến thư mục chứa ảnh
            // Application.StartupPath sẽ trỏ đến thư mục chứa file .exe của bạn
            string imageFolder = Path.Combine(Application.StartupPath, "Resources", "Items");
            string fullPath = Path.Combine(imageFolder, item.ImagePath);

            // 2. Kiểm tra file có tồn tại không trước khi Load để tránh crash App
            if (File.Exists(fullPath))
            {
                // Giải phóng file sau khi load để tránh lỗi "file đang bị sử dụng" khi bạn muốn xóa ảnh
                using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    picItem.Image = Image.FromStream(fs);
                }
            }
            else
            {
                // Nếu không tìm thấy, có thể hiện một ảnh mặc định (Placeholder)
                // picItem.Image = Properties.Resources.default_item; 
            }
        }
    }
}
