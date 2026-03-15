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
            // 1. Kiểm tra hợp lệ (Validation)
            if (string.IsNullOrWhiteSpace(txtQuestName.Text))
            {
                MessageBox.Show("Bạn chưa đặt tên cho thử thách mà!", "Nhắc nhở nhẹ");
                return;
            }

            // 2. Máy tự tính điểm dựa trên Priority (như bạn đã yêu cầu)
            int exp = 0;
            int coin = 0;
            Color pColor = Color.Gray;

            switch (cboPriority.SelectedIndex)
            {
                case 0: // Gấp
                    exp = 100; coin = 50; pColor = Color.Red;
                    break;
                case 2: // Thấp
                    exp = 20; coin = 5; pColor = Color.Green;
                    break;
                default: // Thường
                    exp = 50; coin = 20; pColor = Color.Yellow;
                    break;
            }

            // 3. Đóng gói vào Model
            NewQuest = new Quest
            {
                Name = txtQuestName.Text,
                BaseExp = exp,
                BaseCoin = coin,
                Deadline = dtpDeadline.Value,
                PriorityColor = pColor,
                IsDone = false
            };

            // 4. Trả về kết quả thành công và đóng Form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
