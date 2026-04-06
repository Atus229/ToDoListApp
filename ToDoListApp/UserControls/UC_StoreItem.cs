using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToDoListApp.Forms;
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

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA TÀI KHOẢN (Sử dụng biến static Player đã tạo ở các bài trước)
            if (Player.TotalCoin < _item.Price)
            {
                MessageBox.Show("Bạn không đủ Coin để mua món đồ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. XÁC NHẬN MUA
            DialogResult result = MessageBox.Show($"Bạn có muốn mua {_item.ItemName} với giá {_item.Price} Coins không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // 3. THỰC HIỆN THANH TOÁN (Trừ tiền trong DB)
            string queryUpdateCoin = $"UPDATE PlayerStats SET TotalCoin -= {_item.Price} WHERE Id = 1";
            bool isPaid = Helper.DatabaseHelper.ExecuteQuery(queryUpdateCoin);

            if (isPaid)
            {
                // Cập nhật lại biến static và giao diện Sidebar ngay lập tức
                Player.TotalCoin -= _item.Price;
                if (this.ParentForm is FrmMain mainForm)
                {
                    mainForm.UpdateSidebarStats();
                }

                // 4. GIAO HÀNG (Thêm vào Inventory)
                AddToInventory(_item.Id);

                MessageBox.Show($"Chúc mừng! Bạn đã mua thành công {_item.ItemName}.", "Thành công");
            }
        }

        private void AddToInventory(int itemId)
        {
            // Bước A: Kiểm tra xem món đồ này đã có trong túi chưa
            string checkQuery = $"SELECT Quantity FROM Inventory WHERE ItemId = {itemId}";
            DataTable dt = Helper.DatabaseHelper.GetData(checkQuery);

            if (dt != null && dt.Rows.Count > 0)
            {
                // ĐÃ CÓ: Tăng số lượng lên 1
                string updateQty = $"UPDATE Inventory SET Quantity += 1 WHERE ItemId = {itemId}";
                Helper.DatabaseHelper.ExecuteQuery(updateQty);
            }
            else
            {
                // CHƯA CÓ: Thêm mới một dòng vào bảng
                // Lưu ý: Cấu trúc bảng của bạn gồm [ItemId], [Quantity], [PurchasedAt]
                string insertQuery = $"INSERT INTO Inventory (ItemId, Quantity, PurchasedAt) " +
                                     $"VALUES ({itemId}, 1, GETDATE())";
                Helper.DatabaseHelper.ExecuteQuery(insertQuery);
            }
        }
    }
}
