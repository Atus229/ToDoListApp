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

            // Tạo hiệu ứng chờ một chút rồi xóa
            System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer { Interval = 500 };
            delay.Tick += (s, args) =>
            {
                flpTasks.Controls.Remove(item);
                UpdateTotalPotentialRewards(); // Tính lại tổng điểm sau khi xóa
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


    }
}