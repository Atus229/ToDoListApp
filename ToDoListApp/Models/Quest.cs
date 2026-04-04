using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ToDoListApp.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseExp { get; set; }  // Lưu con số thực tế
        public int BaseCoin { get; set; } // Lưu con số thực tế
        public DateTime Deadline { get; set; }
        public Color PriorityColor { get; set; }
        public bool IsDone { get; set; }

        // Sửa hàm này thành: Trả về chính nó luôn
        public int GetCalculatedExp()
        {
            // 1. Ưu tiên hàng đầu: Nếu BaseExp đã có giá trị từ DB (khác 0), lấy luôn giá trị đó
            int originalExp = this.BaseExp;

            // Nếu quá hạn, giảm 50% điểm (chia 2)
            if (IsOverdue)
            {
                return originalExp / 2;
            }

            return originalExp;
        }
        public int GetCalculatedCoin()
        {
            int originalCoin = this.BaseCoin;

            // Nếu quá hạn, giảm 50% coin (chia 2)
            if (IsOverdue)
            {
                return originalCoin / 2;
            }

            return originalCoin;
        }

        // Sử dụng .Date để chỉ so sánh Ngày/Tháng/Năm
        public bool IsOverdue => !IsDone && DateTime.Today > Deadline.Date;
    }
}