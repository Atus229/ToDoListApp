using System.ComponentModel;
namespace ToDoListApp
{
    public partial class UC_TaskItem : UserControl
    {
        // Constructor mặc định (WinForms cần cái này để hiện trong Designer)
        public UC_TaskItem()
        {
            InitializeComponent();
        }
        // Các biến lưu trữ thông tin gốc
        [Browsable(false)] // Không hiển thị trong bảng Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Không lưu vào Designer
        public int OriginalEXP { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OriginalCoin { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Deadline { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOverdue { get; set; }


        public UC_TaskItem(string taskName, int exp, int coin, Color priorityColor, DateTime deadline)
        {
            InitializeComponent();

            lblTaskName.Text = taskName;
            this.OriginalEXP = exp;
            this.OriginalCoin = coin;
            this.Deadline = deadline;
            pnlPriority.BackColor = priorityColor;

            // Định dạng ngày tháng năm
            lblDeadline.Text = deadline.ToString("dd/MM/yyyy");

            CheckDeadline();
        }

        private void CheckDeadline()
        {
            // Nếu thời gian hiện tại đã vượt quá Deadline
            if (DateTime.Now > Deadline)
            {
                IsOverdue = true;
                lblDeadline.ForeColor = Color.Red; // Chuyển màu đỏ cảnh báo

                // Logic giảm 50% điểm nếu trễ hạn (tùy bạn chỉnh số này)
                int penaltyEXP = OriginalEXP / 2;
                int penaltyCoin = OriginalCoin / 2;
                lblReward.Text = $"+{penaltyEXP} EXP | {penaltyCoin} Coins (TRỄ HẠN!)";
            }
            else
            {
                IsOverdue = false;
                lblReward.Text = $"+{OriginalEXP} EXP | {OriginalCoin} Coins";
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