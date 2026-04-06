using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToDoListApp.UserControls
{
    public partial class UC_Achievement : UserControl
    {
        public UC_Achievement()
        {
            InitializeComponent();
        }

        public void LoadAllAchievements()
        {
            flpAchievements.Controls.Clear();

            // Lấy danh sách thành tựu và trạng thái đã đạt được/đã nhận quà chưa
            string query = @"
        SELECT a.*, 
        ISNULL(ua.IsClaimed, 0) as IsClaimed,
        (SELECT COUNT(*) FROM Quests WHERE IsDone = 1 AND PriorityColor = 'Red' AND CAST(CompletionDate AS DATE) = CAST(GETDATE() AS DATE)) as DailyRedCount,
        (SELECT COUNT(*) FROM Quests WHERE IsDone = 1) as TotalTaskCount
        FROM Achievements a
        LEFT JOIN UserAchievements ua ON a.Id = ua.AchievementId";

            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                UC_AchievementItem item = new UC_AchievementItem();

                int target = (int)row["TargetCount"];
                int current = 0;

                // Phân loại để lấy tiến độ tương ứng
                string type = row["Type"].ToString();
                if (type == "DAILY_RED") current = (int)row["DailyRedCount"];
                else if (type == "TOTAL_TASK") current = (int)row["TotalTaskCount"];

                item.SetData(
                (int)row["Id"],
                row["Description"].ToString(),
                current,
                target,
                (int)row["RewardValue"],
                row["RewardType"].ToString(),
                Convert.ToBoolean(row["IsClaimed"]),
                row["RewardItemId"] // <--- THÊM DÒNG NÀY VÀO CUỐI CÙNG
            );

                flpAchievements.Controls.Add(item);
            }
        }



        private void UC_Achievement_Load(object sender, EventArgs e)
        {
            // Gọi hàm load để đổ dữ liệu vào FlowLayoutPanel
            LoadAllAchievements();
        }
    }
}
