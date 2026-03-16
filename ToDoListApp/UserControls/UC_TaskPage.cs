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
            List<Quest> quests = Helper.DataService.GetSampleQuests();

            foreach (var q in quests)
            {
                bool isMatched = false;
                switch (_currentType)
                {
                    case TaskType.All: isMatched = !q.IsDone; break;
                    case TaskType.Today: isMatched = q.Deadline.Date == DateTime.Today && !q.IsDone; break;
                    case TaskType.Pending: isMatched = q.IsOverdue; break;
                    case TaskType.Completed: isMatched = q.IsDone; break;
                }

                if (isMatched)
                {
                    UC_TaskItem item = new UC_TaskItem(q);

                    // QUAN TRỌNG: Phải đăng ký sự kiện ở đây!
                    item.TaskCompleted += Item_TaskCompleted;

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

            // 1. Cộng điểm vào "Bộ não" Player
            Player.TotalExp += item.TaskData.GetCalculatedExp();
            Player.TotalCoin += item.TaskData.GetCalculatedCoin();

            // 2. Tìm về Form chính (FrmMain) để yêu cầu cập nhật Sidebar
            if (this.ParentForm is FrmMain mainForm)
            {
                mainForm.UpdateSidebarStats();
            }

            // 3. Hiệu ứng xóa task (giữ nguyên như cũ)
            System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer { Interval = 500 };
            delay.Tick += (s, args) => {
                flpTasks.Controls.Remove(item);
                UpdateTotalPotentialRewards();
                delay.Stop();
                delay.Dispose();
            };
            delay.Start();
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
            // Tạo một phiên làm việc với Form Add Quest
            using (FrmAddQuest frm = new FrmAddQuest())
            {
                // Nếu người dùng nhấn nút "Lưu" (DialogResult.OK)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy cái Quest mới vừa được tạo ra
                    Quest q = frm.NewQuest;

                    // Tạo một thẻ nhiệm vụ (UC_TaskItem) mới từ Quest đó
                    UC_TaskItem item = new UC_TaskItem(q);

                    // Đừng quên kết nối sự kiện hoàn thành nhiệm vụ!
                    item.TaskCompleted += Item_TaskCompleted;

                    // Thêm vào bảng hiển thị
                    flpTasks.Controls.Add(item);

                    // Đưa nhiệm vụ mới nhất lên đầu danh sách
                    flpTasks.Controls.SetChildIndex(item, 0);

                    // Cập nhật lại tổng EXP/Coin hiển thị ở dưới đáy trang
                    UpdateTotalPotentialRewards();
                }
            }
        }
    }
}