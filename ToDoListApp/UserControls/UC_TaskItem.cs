using System.ComponentModel;
using System.Data;
using ToDoListApp.Models;
namespace ToDoListApp
{
    public partial class UC_TaskItem : UserControl
    {
        private Quest _currentQuest;
        public Quest TaskData => _currentQuest;
        // Constructor mặc định (WinForms cần cái này để hiện trong Designer)
        public UC_TaskItem()
        {
            InitializeComponent();
        }

        public UC_TaskItem(Quest q)
        {
            InitializeComponent();
            this._currentQuest = q; // Lưu lại để dùng cho các hàm khác (như CheckBox Click)

            // Đổ dữ liệu từ Model vào giao diện
            lblTaskName.Text = q.Name;
            pnlPriority.BackColor = q.PriorityColor;
            lblDeadline.Text = q.Deadline.ToString("dd/MM/yyyy");

            // Sử dụng các hàm thông minh từ Model để hiển thị điểm
            int exp = q.GetCalculatedExp();
            int coin = q.GetCalculatedCoin();

            lblReward.Text = $"+{exp} EXP | {coin} Coins" + (q.IsOverdue ? " (TRỄ HẠN!)" : "");

            if (q.IsOverdue)
            {
                lblDeadline.ForeColor = Color.Red;
            }
        }


        // Tạo một sự kiện để báo cho trang cha khi task hoàn thành
        public event EventHandler TaskCompleted;

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDone.Checked)
            {
                // Hiệu ứng chữ gạch ngang
                lblTaskName.Font = new Font(lblTaskName.Font, FontStyle.Strikeout);
                lblTaskName.ForeColor = Color.Gray;

                // Kích hoạt sự kiện để báo cho UC_TaskPage
                TaskCompleted?.Invoke(this, EventArgs.Empty);
                CheckAchievements();
            }
        }

        public event EventHandler TaskDeleted;


        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            // Hỏi lại cho chắc
            DialogResult result = MessageBox.Show("Bạn muốn xóa nhiệm vụ này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // 2. Kích hoạt event để UC_TaskPage xử lý
                TaskDeleted?.Invoke(this, EventArgs.Empty);
            }
        }

        private void lblReward_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler TaskEdited;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TaskEdited?.Invoke(this, EventArgs.Empty);
        }

        // Thêm hàm này vào bên trong class UC_TaskItem
        public void DisableEditing()
        {
            btnEdit.Visible = false;    // Ẩn nút sửa
            chkDone.Visible = false;    // Ẩn luôn ô tích hoàn thành (Đây là dòng bạn cần thêm)

            lblTaskName.Left = 20;
            lblTaskName.Font = new Font(lblTaskName.Font.FontFamily, 13f);
            // Đổi màu nền sang xám tối để báo hiệu đây là task cũ
            this.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void chkDone_Click(object sender, EventArgs e)
        {

        }

        public void CheckAchievements()
        {
            // 1. Lấy tất cả thành tựu mà user CHƯA đạt được (chưa có trong UserAchievements)
            string queryAch = @"SELECT * FROM Achievements 
                        WHERE Id NOT IN (SELECT AchievementId FROM UserAchievements)";
            DataTable dtAch = ToDoListApp.Helper.DatabaseHelper.GetData(queryAch);

            foreach (DataRow row in dtAch.Rows)
            {
                int achId = (int)row["Id"];
                int target = (int)row["TargetCount"];
                string type = row["Type"].ToString();
                bool isUnlocked = false;

                // 2. Kiểm tra điều kiện theo loại (Type)
                if (type == "DAILY_RED")
                {
                    string sql = "SELECT COUNT(*) FROM Quests WHERE IsDone = 1 AND PriorityColor = 'Red' AND CAST(CompletionDate AS DATE) = CAST(GETDATE() AS DATE)";
                    int count = (int)ToDoListApp.Helper.DatabaseHelper.ExecuteScalar(sql);
                    if (count >= target) isUnlocked = true;
                }
                else if (type == "TOTAL_TASK")
                {
                    string sql = "SELECT COUNT(*) FROM Quests WHERE IsDone = 1";
                    int count = (int)ToDoListApp.Helper.DatabaseHelper.ExecuteScalar(sql);
                    if (count >= target) isUnlocked = true;
                }

                // 3. Nếu đủ điều kiện thì "Mở khóa" (Chưa cho quà, mới chỉ cho hiện nút Claim)
                if (isUnlocked)
                {
                    string insertSql = $"INSERT INTO UserAchievements (UserId, AchievementId, IsClaimed) VALUES (1, {achId}, 0)";
                    ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(insertSql);

                    // Thông báo nhỏ cho người dùng hưng phấn
                    MessageBox.Show($"Bạn vừa mở khóa thành tựu: {row["Title"]}! Hãy vào mục Thành tựu để nhận quà.", "Thành tựu mới!");
                }
            }
        }
    }
}