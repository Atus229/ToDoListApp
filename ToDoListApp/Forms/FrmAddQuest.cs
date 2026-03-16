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
        public Quest NewQuest { get; private set; }
        public FrmAddQuest()
        {
            InitializeComponent();

            // Thiết lập mục chọn mặc định (Vị trí số 0 là "Normal")
            cboPriority.SelectedIndex = 0;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có bỏ trống tên nhiệm vụ không
            if (string.IsNullOrWhiteSpace(txtQuestName.Text))
            {
                MessageBox.Show("Nhiệm vụ phải có tên chứ bạn ơi!", "Thông báo");
                return;
            }

            // 2. Lấy dữ liệu điểm và màu sắc dựa trên những gì đang hiển thị trên Label
            // (Vì máy đã tính ở hàm SelectedIndexChanged rồi, ta chỉ việc lấy lại thôi)
            int exp = (cboPriority.SelectedIndex == 0) ? 100 : (cboPriority.SelectedIndex == 2 ? 20 : 50);
            int coin = (cboPriority.SelectedIndex == 0) ? 50 : (cboPriority.SelectedIndex == 2 ? 5 : 20);

            Color pColor = Color.Yellow; // Mặc định là Thường
            if (cboPriority.SelectedIndex == 2) pColor = Color.Red;
            else if (cboPriority.SelectedIndex == 0) pColor = Color.Green;

            // 3. Đóng gói vào đối tượng NewQuest
            NewQuest = new Quest
            {
                Name = txtQuestName.Text,
                BaseExp = exp,
                BaseCoin = coin,
                Deadline = dtpDeadline.Value,
                PriorityColor = pColor,
                IsDone = false
            };

            // 4. Báo hiệu thành công và đóng Form
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

                default: // Important
                    lblExpValue.Text = "50 EXP";
                    lblCoinValue.Text = "20 COINS";
                    break;
            }
        }
    }
}
