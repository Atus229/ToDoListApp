using System.Data;
using ToDoListApp.Forms;
using ToDoListApp.Models;

namespace ToDoListApp
{
    public enum TaskType { All, Today, Pending, Completed }

    public partial class UC_TaskPage : UserControl
    {
        private TaskType _currentType;
        public UC_TaskPage(TaskType type)
        {
            InitializeComponent();
            this._currentType = type;

            // Tùy biến tiêu đề dựa trên loại trang
            UpdateTitle();
        }

        private void UC_TaskPage_Load(object sender, EventArgs e)
        {
            // Đảm bảo ComboBox đã có các Items: All, Today, Pending, Done
            // Chọn "All" làm mặc định
            int indexAll = cboFilter.FindStringExact("All");
            if (indexAll != -1)
            {
                cboFilter.SelectedIndex = indexAll;
            }

            LoadTasks();
        }

        private void UpdateTitle()
        {
            switch (_currentType)
            {
                case TaskType.All: lblTitle.Text = "MY QUESTS"; break;
                case TaskType.Today: lblTitle.Text = "TODAY'S QUESTS"; break;
                case TaskType.Pending: lblTitle.Text = "PENDING QUESTS"; break;
                case TaskType.Completed: lblTitle.Text = "COMPLETED QUESTS"; break;
            }
        }
        private void Item_TaskCompleted(object sender, EventArgs e)
        {
            UC_TaskItem item = (UC_TaskItem)sender;
            int taskId = item.TaskData.Id;

            // 1. LẤY ĐIỂM GỐC TỪ QUEST
            int expGain = item.TaskData.BaseExp;
            int coinGain = item.TaskData.BaseCoin;

            // 2. KIỂM TRA TRẠNG THÁI TRỄ HẠN (Overdue)
            bool isOverdue = DateTime.Now.Date > item.TaskData.Deadline.Date;

            // 3. LOGIC BUFF 1: SHIELD (KHIÊN CHỐNG TRỪ ĐIỂM)
            if (isOverdue)
            {
                if (Player.IsShieldActive) // Nếu đang bật khiên
                {
                    // Giữ nguyên điểm gốc, không bị chia đôi
                    // Shield chỉ dùng 1 lần nên ta sẽ tắt nó sau khi update DB
                }
                else
                {
                    // Không có khiên -> Phạt trễ hạn 50%
                    expGain /= 2;
                    coinGain /= 2;
                }
            }

            // 4. LOGIC BUFF 2: X2 EXP
            if (Player.IsDoubleExpActive)
            {
                expGain *= 2;
            }

            // --- BƯỚC 1: CẬP NHẬT DATABASE ---

            // 1.1 Cập nhật trạng thái nhiệm vụ
            string queryTask = $"UPDATE Quests SET IsDone = 1, CompletionDate = GETDATE() WHERE Id = {taskId}";

            // 1.2 Cập nhật điểm và TẮT CÁC BUFF ĐÃ SỬ DỤNG
            string updateBuffsSql = "";
            if (Player.IsDoubleExpActive) updateBuffsSql += ", IsDoubleExpActive = 0";
            if (Player.IsShieldActive && isOverdue) updateBuffsSql += ", IsShieldActive = 0";

            string queryPlayer = $"UPDATE PlayerStats SET TotalExp += {expGain}, TotalCoin += {coinGain} {updateBuffsSql} WHERE Id = 1";

            bool taskUpdated = ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(queryTask);
            bool playerUpdated = ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(queryPlayer);

            if (taskUpdated && playerUpdated)
            {
                // --- BƯỚC 2: CẬP NHẬT GIAO DIỆN & STATIC CLASS ---

                Player.TotalExp += expGain;
                Player.TotalCoin += coinGain;

                // Cập nhật lại trạng thái Buff trong code sau khi đã dùng xong
                if (Player.IsDoubleExpActive) Player.IsDoubleExpActive = false;
                if (Player.IsShieldActive && isOverdue) Player.IsShieldActive = false;

                if (this.ParentForm is FrmMain mainForm)
                {
                    mainForm.UpdateSidebarStats();
                }

                // Hiệu ứng xóa task (giữ nguyên của bạn)
                System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer { Interval = 500 };
                delay.Tick += (s, args) => {
                    flpTasks.Controls.Remove(item);
                    UpdateTotalPotentialRewards();
                    delay.Stop();
                    delay.Dispose();
                };
                delay.Start();

                // Thông báo cho người chơi biết họ đã được Buff
                if (Player.IsDoubleExpActive) MessageBox.Show("X2 EXP đã được áp dụng!");
            }
        }
        private void UpdateTotalPotentialRewards()
        {
            int totalEXP = 0;
            int totalCoin = 0;

            foreach (UC_TaskItem item in flpTasks.Controls)
            {
                // Sử dụng hàm tính toán thông minh từ Model Quest
                totalEXP += item.TaskData.GetCalculatedExp();
                totalCoin += item.TaskData.GetCalculatedCoin();
            }

            lblTotalEXP.Text = totalEXP.ToString();
            lblTotalCoin.Text = totalCoin.ToString();
        }

        private void btnAddQuest_Click(object sender, EventArgs e)
        {
            using (FrmAddQuest frm = new FrmAddQuest())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Quest q = frm.NewQuest;

                    // 1. Tạo câu lệnh INSERT
                    string query = $"INSERT INTO Quests (TaskName, BaseExp, BaseCoin, Deadline, PriorityColor, IsDone) " +
                    $"VALUES (N'{q.Name}', {q.BaseExp}, {q.BaseCoin}, '{q.Deadline:yyyy-MM-dd HH:mm:ss}', '{q.PriorityColor.Name}', 0)";

                    // 2. Thực thi qua DatabaseHelper
                    if (Helper.DatabaseHelper.ExecuteQuery(query))
                    {
                        // Load lại trang để cập nhật danh sách mới từ DB
                        UC_TaskPage_Load(null, null);
                    }
                }
        }
        }

        private void Item_TaskDeleted(object sender, EventArgs e)
        {
            // 1. Xác định đối tượng đang bị xóa
            UC_TaskItem item = (UC_TaskItem)sender;
            int taskId = item.TaskData.Id; // Lấy Id của nhiệm vụ

            // 2. Tạo câu lệnh SQL xóa theo Id
            string query = $"DELETE FROM Quests WHERE Id = {taskId}";

            // 3. Thực thi xóa trong Database trước
            if (ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(query))
            {
                // 4. Nếu DB xóa thành công thì mới xóa trên UI cho đồng bộ
                flpTasks.Controls.Remove(item);
                item.Dispose();

                // Cập nhật lại tổng điểm hiển thị ở dưới đáy trang
                UpdateTotalPotentialRewards();
            }
            else
            {
                MessageBox.Show("Lỗi: Không thể xóa dữ liệu trong Database!");
            }
        }

        private void Item_TaskEdited(object sender, EventArgs e)
        {
            UC_TaskItem item = (UC_TaskItem)sender;

            using (FrmAddQuest frm = new FrmAddQuest(item.TaskData))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Quest q = frm.NewQuest;

                    // Câu lệnh UPDATE cực kỳ chi tiết
                    string query = $@"UPDATE Quests 
                             SET TaskName = N'{q.Name}', 
                                 BaseExp = {q.BaseExp}, 
                                 BaseCoin = {q.BaseCoin}, 
                                 Deadline = '{q.Deadline:yyyy-MM-dd HH:mm:ss}', 
                                 PriorityColor = '{q.PriorityColor.Name}' 
                             WHERE Id = {q.Id}";

                    if (ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(query))
                    {
                        // SAU KHI LƯU XONG: Phải gọi hàm Load để vẽ lại danh sách trên màn hình
                        UC_TaskPage_Load(null, null);
                        MessageBox.Show("Đã cập nhật nhiệm vụ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thể lưu thay đổi vào Database!");
                    }
                }
            }
        }
        public void LoadTasks()
        {
            flpTasks.Controls.Clear();

            // Lấy giá trị lọc (Mặc định là All nếu chưa chọn)
            string keyword = txtSearch.Text.Trim();
            string filter = cboFilter.SelectedItem?.ToString().Trim() ?? "All";

            // 1. Gốc câu lệnh SQL
            string query = "SELECT * FROM Quests WHERE 1=1";

            // 2. Lọc theo từ khóa tìm kiếm (nếu có)
            if (!string.IsNullOrEmpty(keyword))
                query += $" AND TaskName LIKE N'%{keyword}%'";

            // 3. Logic lọc nâng cao theo yêu cầu của bạn
            switch (filter)
            {
                case "All":
                    // Hiển thị tất cả công việc chưa xong
                    query += " AND IsDone = 0";
                    break;

                case "Today":
                    // Công việc của ngày hôm nay và chưa xong
                    query += " AND CAST(Deadline AS DATE) = CAST(GETDATE() AS DATE) AND IsDone = 0";
                    break;

                case "Pending":
                    // CÔNG VIỆC TRỄ HẠN: Đã quá ngày deadline mà chưa xong
                    query += " AND IsDone = 0 AND CAST(Deadline AS DATE) < CAST(GETDATE() AS DATE)";
                    break;

                case "Done":
                    // Công việc đã hoàn thành
                    query += " AND IsDone = 1";
                    break;
            }

            // 4. Thực thi và đổ dữ liệu
            DataTable dt = Helper.DatabaseHelper.GetData(query);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Quest q = new Quest
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["TaskName"].ToString(),
                        BaseExp = Convert.ToInt32(row["BaseExp"]),
                        BaseCoin = Convert.ToInt32(row["BaseCoin"]),
                        Deadline = Convert.ToDateTime(row["Deadline"]),
                        PriorityColor = Color.FromName(row["PriorityColor"].ToString()),
                        IsDone = Convert.ToBoolean(row["IsDone"])
                    };

                    UC_TaskItem item = new UC_TaskItem(q);

                    // Đăng ký các sự kiện cho nút Sửa/Xóa/Xong
                    item.TaskCompleted += Item_TaskCompleted;
                    item.TaskDeleted += Item_TaskDeleted;
                    item.TaskEdited += Item_TaskEdited;

                    // Nếu task đã xong (hoặc đang xem tab Done), ẩn checkbox và nút sửa
                    if (q.IsDone)
                    {
                        item.DisableEditing();
                    }

                    flpTasks.Controls.Add(item);
                }
            }

            // Cập nhật lại tổng điểm dự kiến ở thanh trạng thái dưới cùng
            UpdateTotalPotentialRewards();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTasks(); // Gõ đến đâu, lọc đến đó
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasks(); // Chọn xong là lọc luôn
        }
    }
}