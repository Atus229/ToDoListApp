using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToDoListApp.Models;

namespace ToDoListApp.Forms
{
    public partial class FrmAddQuest : Form
    {
        // Tạo một biến để đánh dấu
        private bool isEditMode = false;
        public Quest NewQuest { get; private set; }
        public FrmAddQuest()
        {
            InitializeComponent();
            this.Text = "ADD NEW QUEST";

            // Thiết lập mục chọn mặc định (Vị trí số 0 là "Normal")
            cboPriority.SelectedIndex = 0;
        }

        // Constructor mới dành cho việc SỬA
        public FrmAddQuest(Quest existingQuest)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "EDIT QUEST";

            // Đổ dữ liệu cũ vào các ô nhập liệu
            txtQuestName.Text = existingQuest.Name;
            dtpDeadline.Value = existingQuest.Deadline;

            // Chọn lại đúng độ ưu tiên trong ComboBox
            if (existingQuest.BaseExp == 100) cboPriority.SelectedIndex = 0; // Urgent
            else if (existingQuest.BaseExp == 50) cboPriority.SelectedIndex = 1; // Important
            else cboPriority.SelectedIndex = 2; // Normal

            // Lưu lại cái Quest đang sửa để lát nữa nút Save dùng
            this.NewQuest = existingQuest;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhiệm vụ!");
                return;
            }

            // Khai báo mặc định
            int exp = 20; int coin = 5; Color pColor = Color.Green;
            string selected = cboPriority.Text.Trim(); // Cắt bỏ khoảng trắng thừa

            switch (selected)
            {
                case "Urgent":
                    exp = 100; coin = 50; pColor = Color.Red;
                    break;

                case "Important":
                    exp = 50; coin = 20; pColor = Color.Yellow;
                    break;

                case "Normal":
                    // SỬA TẠI ĐÂY: Đảm bảo số điểm khác với Important để dễ phân biệt
                    exp = 20;
                    coin = 5;
                    pColor = Color.Green;
                    break;

                default: // Mặc định là Low/Thấp
                    exp = 20; coin = 5; pColor = Color.Green;
                    break;
            }

            // Gán vào NewQuest
            NewQuest = new Quest
            {
                Id = (this.NewQuest != null) ? this.NewQuest.Id : 0,
                Name = txtQuestName.Text,
                BaseExp = exp,
                BaseCoin = coin,
                PriorityColor = pColor,
                Deadline = dtpDeadline.Value,
                IsDone = false
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cấu hình điểm số theo lựa chọn
            switch (cboPriority.SelectedIndex)
            {
                case 2: // Urgent
                    lblExpValue.Text = "100 EXP";
                    lblCoinValue.Text = "50 COINS";
                    break;

                case 0: // Normal
                    lblExpValue.Text = "20 EXP";
                    lblCoinValue.Text = "5 COINS";
                    break;

                case 1: // Important
                    lblExpValue.Text = "50 EXP";
                    lblCoinValue.Text = "20 COINS";
                    break;
                default:
                    lblExpValue.Text = "20 EXP";
                    lblCoinValue.Text = "5 COINS";
                    break;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 1. Gán kết quả trả về là Cancel
            this.DialogResult = DialogResult.Cancel;

            // 2. Đóng Form ngay lập tức
            this.Close();
        }
    }
}
