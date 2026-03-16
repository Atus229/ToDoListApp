using ToDoListApp.Models;

namespace ToDoListApp.Forms
{
    public partial class FrmMain : System.Windows.Forms.Form
    {
        public FrmMain()
        {
            InitializeComponent();

        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Tạo mới trang All Tasks và hiển thị nó
            UC_TaskPage uc = new UC_TaskPage(TaskType.All);
            ShowUserControl(uc);
        }

        private void btnAllTasks_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TaskPage(TaskType.All));
        }
        private void btnPending_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TaskPage(TaskType.Pending));
        }
        private void btnToday_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TaskPage(TaskType.Today));
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TaskPage(TaskType.Completed));
        }



        // Hàm dùng để hiển thị các UserControl lên Panel chính
        public void ShowUserControl(UserControl uc)
        {
            // 1. Xóa sạch các trang cũ đang nằm trong khay
            pnlContainer.Controls.Clear();

            // 2. Chỉnh trang mới cho tràn đầy cái khay
            uc.Dock = DockStyle.Fill;

            // 3. Đưa trang mới vào khay
            pnlContainer.Controls.Add(uc);
        }
        public void UpdateSidebarStats()
        {
            // Cập nhật Label Level (ví dụ: label1 của bạn)
            label1.Text = $"LEVEL {Player.CurrentLevel:D2}";

            // Cập nhật Thanh kinh nghiệm (pbExp)
            pbExp.Maximum = Player.ExpToNextLevel;
            pbExp.Value = Player.CurrentExpProgress;

            
            lblSidebarCoin.Text = ("Coins: " + Player.TotalCoin.ToString());
        }

    }
}
