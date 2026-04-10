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
    public partial class UC_InventoryItem : UserControl
    {
        // 1. Khai báo một biến để lưu trữ dữ liệu món đồ
        private InventoryItem _item;

        // 2. SỬA TẠI ĐÂY: Thêm tham số (InventoryItem item) vào constructor
        public UC_InventoryItem(InventoryItem item)
        {
            InitializeComponent(); // Dòng này luôn phải ở đầu tiên nhé!

            this._item = item;

            // 3. Hiển thị dữ liệu lên giao diện
            lblItemName.Text = item.Name;
            lblQuantity.Text = "x" + item.Quantity.ToString();

            // Load ảnh (giống logic bên Store)
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "Items", item.ImagePath);
            if (File.Exists(imagePath))
            {
                picItem.Image = Image.FromFile(imagePath);
            }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            string itemName = _item.Name; // Ví dụ: "X2 EXP", "Shield"...
            bool isSuccess = false;

            switch (itemName)
            {
                case "X2 EXP":
                    int r1 = Helper.DatabaseHelper.ExecuteQuery("UPDATE PlayerStats SET IsDoubleExpActive = 1 WHERE Id = 1");
                    isSuccess = r1 > 0;
                    if (isSuccess) MessageBox.Show("Kích hoạt X2 EXP cho nhiệm vụ tiếp theo!");
                    if (isSuccess) Player.IsDoubleExpActive = true;
                    break;

                case "Shield":
                    int r2 = Helper.DatabaseHelper.ExecuteQuery("UPDATE PlayerStats SET IsShieldActive = 1 WHERE Id = 1");
                    isSuccess = r2 > 0;
                    if (isSuccess) MessageBox.Show("Khiên bảo vệ đã bật! Bạn sẽ không bị trừ điểm nếu trễ hạn.");
                    if (isSuccess) Player.IsShieldActive = true;
                    break;

                case "Blind Box":
                    isSuccess = OpenBlindBox(); // Hàm mở hộp quà ngẫu nhiên
                    break;
            }

            if (isSuccess)
            {
                // Trừ 1 số lượng trong túi đồ
                UpdateInventoryQuantity();
            }
        }

        private bool OpenBlindBox()
        {
            Random rand = new Random();
            int rate = rand.Next(1, 101); // Quay số từ 1 đến 100
            string message = "";
            string query = "";

            // --- LOGIC PHẦN THƯỞNG MỚI ---
            if (rate <= 25) // 25% May mắn lần sau
            {
                message = "Chúc bạn may mắn lần sau! Hộp này rỗng tuếch...";
                // Không cần update DB, chỉ hiện thông báo
            }
            else if (rate <= 45) // 20% Bị trừ tiền (Xui xẻo)
            {
                int loss = 50;
                Player.TotalCoin = Math.Max(0, Player.TotalCoin - loss); // Không để tiền âm
                message = $"Ôi không! Hộp quỷ ám đã lấy mất {loss} Coins của bạn.";
                query = $"UPDATE PlayerStats SET TotalCoin = {Player.TotalCoin} WHERE Id = 1";
            }
            else if (rate <= 65) // 20% Nhận Buff X2 EXP
            {
                Player.IsDoubleExpActive = true;
                message = "Tuyệt vời! Bạn nhận được một chiếc Thẻ X2 EXP.";
                query = "UPDATE PlayerStats SET IsDoubleExpActive = 1 WHERE Id = 1";
            }
            else if (rate <= 85) // 20% Nhận Buff Shield
            {
                Player.IsShieldActive = true;
                message = "Bạn nhận được Khiên Bảo Vệ! Trễ hạn sẽ không còn là nỗi lo.";
                query = "UPDATE PlayerStats SET IsShieldActive = 1 WHERE Id = 1";
            }
            else // 15% Trúng hũ lớn (Phần thưởng an ủi cho đại gia)
            {
                int win = 150;
                Player.TotalCoin += win;
                message = $"TRÚNG HŨ! Bạn nhận được {win} Coins từ hộp bí ẩn.";
                query = $"UPDATE PlayerStats SET TotalCoin = {Player.TotalCoin} WHERE Id = 1";
            }

            // --- THỰC THI VÀ CẬP NHẬT GIAO DIỆN ---
            if (!string.IsNullOrEmpty(query))
            {
                Helper.DatabaseHelper.ExecuteQuery(query);
            }

            // CẬP NHẬT SIDEBAR NGAY LẬP TỨC
            if (this.FindForm() is FrmMain mainForm)
            {
                mainForm.UpdateSidebarStats();
            }

            MessageBox.Show(message, "Kết quả Blind Box");
            return true; // Trả về true để hàm UseItem trừ số lượng hộp trong túi
        }

        private void UpdateInventoryQuantity()
        {
            // Trừ 1 trong DB
            string query = $"UPDATE Inventory SET Quantity = Quantity - 1 WHERE Id = {_item.InventoryId}";
            if (Helper.DatabaseHelper.ExecuteQuery(query) > 0)
            {
                // Xóa nếu bằng 0
                Helper.DatabaseHelper.ExecuteQuery("DELETE FROM Inventory WHERE Quantity <= 0");

                // LÀM MỚI GIAO DIỆN: Tìm trang Inventory cha để gọi hàm Load lại
                Control parent = this.Parent;
                while (parent != null && !(parent is UC_Inventory))
                {
                    parent = parent.Parent;
                }

                if (parent is UC_Inventory inventoryPage)
                {
                    inventoryPage.LoadInventory(); // Vẽ lại toàn bộ túi đồ
                }
            }
        }
    }

}
