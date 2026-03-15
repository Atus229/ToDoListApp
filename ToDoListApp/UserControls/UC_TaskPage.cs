using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

            // 1. Giả lập danh sách dữ liệu từ Database (Sau này bạn sẽ thay bằng gọi hàm từ DB)
            var allData = new List<dynamic>
            {
                new { Name = "Học C# nâng cao", Exp = 100, Coin = 20, Color = Color.Red, Deadline = DateTime.Now.AddDays(-1), IsDone = false }, // Trễ hạn
                new { Name = "Làm đồ án WinForms", Exp = 200, Coin = 50, Color = Color.Orange, Deadline = DateTime.Now, IsDone = false },     // Hôm nay
                new { Name = "Quét dọn nhà cửa", Exp = 20, Coin = 5, Color = Color.Green, Deadline = DateTime.Now.AddDays(2), IsDone = false }, // Tương lai
                new { Name = "Ăn sáng đúng giờ", Exp = 10, Coin = 2, Color = Color.Blue, Deadline = DateTime.Now.AddDays(-2), IsDone = true }   // Đã xong
            };

            // 2. Lọc và hiển thị dựa trên CurrentType
            foreach (var data in allData)
            {
                bool shouldAdd = false;

                switch (_currentType)
                {
                    case TaskType.All:
                        // Hiện tất cả trừ những cái đã hoàn thành (hoặc hiện hết tùy bạn)
                        if (!data.IsDone) shouldAdd = true;
                        break;

                    case TaskType.Today:
                        // Chỉ lấy task có ngày hôm nay và chưa xong
                        if (data.Deadline.Date == DateTime.Today && !data.IsDone) shouldAdd = true;
                        break;

                    case TaskType.Pending:
                        // Chỉ lấy task đã quá hạn và chưa xong
                        if (data.Deadline < DateTime.Now && !data.IsDone) shouldAdd = true;
                        break;

                    case TaskType.Completed:
                        // Chỉ lấy task đã đánh dấu hoàn thành
                        if (data.IsDone) shouldAdd = true;
                        break;
                }

                if (shouldAdd)
                {
                    UC_TaskItem item = new UC_TaskItem(data.Name, data.Exp, data.Coin, data.Color, data.Deadline);
                    // Đăng ký sự kiện
                    item.TaskCompleted += (s, args) => {
                        // 1. Thực hiện cộng EXP/Coin vào thanh Progress ở Sidebar (thông qua FrmMain)
                        // 2. Xóa task này khỏi flpTasks sau một khoảng trễ nhỏ (để người dùng kịp thấy hiệu ứng)
                        var t = (UC_TaskItem)s;
                        System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer { Interval = 500 }; // Đợi 0.5s cho đẹp
                        delay.Tick += (st, et) => {
                            flpTasks.Controls.Remove(t);
                            UpdateTotalPotentialRewards(); // Cập nhật lại con số tổng ở dưới
                            delay.Stop();
                        };
                        delay.Start();
                    };
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
        private void UpdateTotalPotentialRewards()
        {
            int totalEXP = 0;
            int totalCoin = 0;

            foreach (UC_TaskItem item in flpTasks.Controls)
            {
                // Nếu trễ thì tính theo điểm phạt, nếu không thì tính điểm gốc
                if (item.IsOverdue)
                {
                    totalEXP += item.OriginalEXP / 2;
                    totalCoin += item.OriginalCoin / 2;
                }
                else
                {
                    totalEXP += item.OriginalEXP;
                    totalCoin += item.OriginalCoin;
                }
            }

            lblTotalEXP.Text = totalEXP.ToString();
            lblTotalCoin.Text = totalCoin.ToString();
        }

       
    }
}
