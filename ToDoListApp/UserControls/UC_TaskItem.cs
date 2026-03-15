using System.ComponentModel;
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
            }
        }
    }
}