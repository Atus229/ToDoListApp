using ToDoListApp.Models;
using ToDoListApp.UserControls;

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
            // 1. Nạp dữ liệu từ DB vào "bộ não" Player
            ToDoListApp.Helper.DatabaseHelper.LoadPlayerStats();

            // 2. Cập nhật các Label và Progress Bar trên Sidebar
            UpdateSidebarStats();

            // 3. Mặc định mở trang All Tasks khi vừa vào App
            ShowUserControl(new UC_TaskPage(TaskType.All));
        }

        private void btnAllTasks_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_TaskPage(TaskType.All));
            HighlightButton((Control)sender); // (Button)sender chính là cái nút bạn vừa nhấn
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Store());
            HighlightButton((Control)sender);
        }



        // Hàm dùng để hiển thị các UserControl lên Panel chính
        public void ShowUserControl(UserControl uc)
        {
            // 0. Kiểm tra an toàn: Nếu truyền vào null thì không làm gì cả
            if (uc == null) return;

            // 1. Giải phóng bộ nhớ của các trang cũ (Rất quan trọng!)
            // Thay vì chỉ Clear, ta nên Dispose để máy không bị lag sau nhiều lần chuyển trang
            foreach (Control ctrl in pnlContainer.Controls)
            {
                ctrl.Dispose();
            }
            pnlContainer.Controls.Clear();

            // 2. Chỉnh trang mới cho tràn đầy cái khay
            uc.Dock = DockStyle.Fill;

            // 3. Đưa trang mới vào khay
            pnlContainer.Controls.Add(uc);

            // 4. BỔ SUNG: Đưa trang này lên lớp trên cùng để đảm bảo nó không bị che khuất
            uc.BringToFront();

            // 5. BỔ SUNG: Ép Panel vẽ lại giao diện ngay lập tức cho mượt
            pnlContainer.Invalidate();
        }

        private void HighlightButton(Control activeBtn) // Đổi Button thành Control ở đây
        {
            // 1. Danh sách các nút (Hãy kiểm tra lại tên nút trong Designer nhé)
            var sidebarButtons = new List<Control> { btnAllTasks, btnStore, btnAchievements, btnStatistics };

            foreach (var btn in sidebarButtons)
            {
                // 2. Trả về màu nền tối ban đầu của Sidebar (ví dụ màu đen hoặc xám đậm)
                // Bạn hãy lấy mã màu từ bảng Properties của Sidebar nhé
                btn.BackColor = Color.FromArgb(23, 23, 23);
                btn.ForeColor = Color.White;

                // Ép kiểu về ParrotButton để chỉnh màu phần "ruột"
                if (btn is ReaLTaiizor.Controls.ParrotButton pb)
                {
                    pb.BackgroundColor = Color.FromArgb(23, 23, 23); // Màu tối ban đầu
                }
            }

            // 3. Nhuộm hồng nút được nhấn
            activeBtn.BackColor = Color.FromArgb(219, 87, 106); // Màu hồng bạn đang dùng
            activeBtn.ForeColor = Color.White;

            if (activeBtn is ReaLTaiizor.Controls.ParrotButton activePb)
            {
                activePb.BackgroundColor = Color.FromArgb(219, 87, 106);
            }
        }


        public void UpdateSidebarStats()
        {
            // Cập nhật Level
            lblLevel.Text = $"LEVEL {Player.CurrentLevel:D2}";

            // Cập nhật Coin (lblCoins trong ảnh của bạn)
            lblSidebarCoin.Text = $"Coins: {Player.TotalCoin}";

            // Cập nhật Progress Bar (Thanh EXP)
            if (Player.CurrentLevel >= Player.MaxLevel)
            {
                pbExp.Maximum = 100;
                pbExp.Value = 100;
            }
            else
            {
                pbExp.Maximum = Player.RequiredExpForThisLevel;
                pbExp.Value = Math.Min(Player.CurrentExpProgress, pbExp.Maximum);
            }

            // Nếu bạn có hiện số % trên ProgressBar (số 70 trong ảnh)
            // Hãy đảm bảo nó cũng được cập nhật dựa trên Value
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát cho chuyên nghiệp
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAchievements_Click(object sender, EventArgs e)
        {
            //ShowUserControl(new UC_Achievements());
            HighlightButton((Control)sender);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            // ShowUserControl(new UC_Statistics());
            HighlightButton((Control)sender);
        }
    }
}
