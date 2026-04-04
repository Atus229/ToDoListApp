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
            flpTasks.Controls.Clear();

            // 1. Viết câu lệnh SQL lấy danh sách (Ví dụ lấy All)
            string query = "SELECT * FROM Quests";

            // 2. Lấy dữ liệu qua DatabaseHelper
            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            // 3. Duyệt từng dòng trong DataTable để tạo TaskItem
            foreach (DataRow row in dt.Rows)
            {
                Quest q = new Quest
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["TaskName"].ToString(),

                    // CỰC KỲ QUAN TRỌNG: Phải nạp 2 dòng này từ Database
                    BaseExp = Convert.ToInt32(row["BaseExp"]),
                    BaseCoin = Convert.ToInt32(row["BaseCoin"]),

                    Deadline = Convert.ToDateTime(row["Deadline"]),
                    PriorityColor = Color.FromName(row["PriorityColor"].ToString()),
                    IsDone = Convert.ToBoolean(row["IsDone"])
                };

                // Lọc theo loại trang (Today, Pending...)
                bool isMatched = false;
                switch (_currentType)
                {
                    case TaskType.All: isMatched = !q.IsDone; break;
                    case TaskType.Today: isMatched = q.Deadline.Date == DateTime.Today && !q.IsDone; break;
                    case TaskType.Pending: isMatched = q.IsOverdue && !q.IsDone; break;
                    case TaskType.Completed: isMatched = q.IsDone; break;
                }

                if (isMatched)
                {
                    UC_TaskItem item = new UC_TaskItem(q);
                    item.TaskCompleted += Item_TaskCompleted;
                    item.TaskDeleted += Item_TaskDeleted;
                    item.TaskEdited += Item_TaskEdited;
                    flpTasks.Controls.Add(item);
                }
            }
            UpdateTotalPotentialRewards();
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
            int expGain = item.TaskData.GetCalculatedExp();
            int coinGain = item.TaskData.GetCalculatedCoin();

            // --- BƯỚC 1: CẬP NHẬT DATABASE ---

            // 1.1 Cập nhật trạng thái IsDone cho nhiệm vụ
            string queryTask = $"UPDATE Quests SET IsDone = 1 WHERE Id = {taskId}";

            // 1.2 Cập nhật điểm tích lũy cho người chơi trong DB
            string queryPlayer = $"UPDATE PlayerStats SET TotalExp += {expGain}, TotalCoin += {coinGain} WHERE Id = 1";

            // Thực thi lệnh SQL qua DatabaseHelper
            bool taskUpdated = ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(queryTask);
            bool playerUpdated = ToDoListApp.Helper.DatabaseHelper.ExecuteQuery(queryPlayer);

            if (taskUpdated && playerUpdated)
            {
                // --- BƯỚC 2: CẬP NHẬT GIAO DIỆN (Chỉ chạy khi DB đã lưu xong) ---

                // Cập nhật biến static để Sidebar thay đổi ngay lập tức
                Player.TotalExp += expGain;
                Player.TotalCoin += coinGain;

                if (this.ParentForm is FrmMain mainForm)
                {
                    mainForm.UpdateSidebarStats();
                }

                // Hiệu ứng xóa task khỏi danh sách
                System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer { Interval = 500 };
                delay.Tick += (s, args) => {
                    flpTasks.Controls.Remove(item);
                    UpdateTotalPotentialRewards();
                    delay.Stop();
                    delay.Dispose();
                };
                delay.Start();
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
    }
}