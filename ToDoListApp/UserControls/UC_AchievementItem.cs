using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToDoListApp.Forms;

namespace ToDoListApp.UserControls
{
    public partial class UC_AchievementItem : UserControl
    {
        private int achievementId;
        private string rewardType;
        private int rewardValue;
        private int rewardItemId;

        public UC_AchievementItem()
        {
            InitializeComponent();
        }

        // Hàm đổ dữ liệu vào Item
        public void SetData(int id, string desc, int current, int target, int reward, string type, bool isClaimed, object itemIdFromDB)
        {
            achievementId = id;
            rewardType = type;
            rewardValue = reward;

            // GÁN GIÁ TRỊ: Quan trọng để không bị cộng sai Item
            if (itemIdFromDB != DBNull.Value && itemIdFromDB != null)
                rewardItemId = Convert.ToInt32(itemIdFromDB);

            lblDesc.Text = desc;
            lblRW.Text = $" {reward} {type.ToLower()}";

            // Cấu hình Progress Bar
            if (target > 0)
            {
                int percent = (current * 100) / target;
                if (percent > 100) percent = 100;
                prgProgress.ValueNumber = percent;
            }
            else
            {
                prgProgress.ValueNumber = 0;
            }

            // Logic hiển thị nút và Huy chương
            if (current >= target)
            {
                picMedal.ForeColor = Color.Gold;
                if (isClaimed)
                {
                    btnClaim.Visible = false;
                    this.BackColor = Color.FromArgb(45, 45, 45);
                }
                else
                {
                    btnClaim.Enabled = true;
                    btnClaim.Visible = true;
                    btnClaim.BackColor = Color.LimeGreen; // Thêm màu cho nổi bật khi được nhận
                }
            }
            else
            {
                picMedal.ForeColor = Color.DimGray;
                btnClaim.Enabled = false;
                // Nếu muốn "xịn" hơn, bạn có thể ẩn nút Claim nếu chưa đạt
                // btnClaim.Visible = false; 
            }
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đánh dấu đã nhận quà
                string updateClaim = $"UPDATE UserAchievements SET IsClaimed = 1 WHERE AchievementId = {achievementId}";
                ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(updateClaim);

                // 2. Trao thưởng
                if (rewardType == "COIN")
                {
                    string sql = $"UPDATE PlayerStats SET TotalCoin = TotalCoin + {rewardValue} WHERE Id = 1";
                    ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(sql);
                }
                else if (rewardType == "EXP")
                {
                    string sql = $"UPDATE PlayerStats SET TotalExp = TotalExp + {rewardValue} WHERE Id = 1";
                    ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(sql);
                }
                else if (rewardType == "ITEM")
                {
                    string checkInv = $"SELECT COUNT(*) FROM Inventory WHERE ItemId = {rewardItemId}";

                    // SỬA LỖI: Dùng Convert.ToInt32 để an toàn hơn (int)
                    int exists = Convert.ToInt32(ToDoListApp.Helper.DatabaseHelper.ExecuteScalar(checkInv));

                    if (exists > 0)
                        ToDoListApp.Helper.DatabaseHelper.ExecuteQuery($"UPDATE Inventory SET Quantity = Quantity + 1 WHERE ItemId = {rewardItemId}");
                    else
                        ToDoListApp.Helper.DatabaseHelper.ExecuteQuery($"INSERT INTO Inventory (ItemId, Quantity) VALUES ({rewardItemId}, 1)");
                }

                // 3. Cập nhật giao diện
                MessageBox.Show($"Chúc mừng! Bạn đã nhận được {rewardValue} {rewardType}!", "Thành tựu");
                btnClaim.Visible = false;
                FrmMain.Instance.RefreshPlayerStats();

                foreach (Control ctrl in FrmMain.Instance.pnlContainer.Controls)
                {
                    if (ctrl is UC_Statistics statsPage)
                    {
                        statsPage.LoadTotalSummary(); // Gọi hàm load lại bảng tổng kết
                        break;
                    }
                }
                this.BackColor = Color.FromArgb(45, 45, 45);



                // GỢI Ý: Gọi hàm cập nhật lại Dashboard/Statistics nếu cần
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận thưởng: " + ex.Message);
            }
        }

        
    }
}
