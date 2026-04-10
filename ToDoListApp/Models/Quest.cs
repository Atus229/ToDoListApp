using System;
using System.Text;

namespace ToDoListApp.Models
{
    public class Quest
    {
        // Legacy properties kept for compatibility
        public int Id { get; set; }
        public string Name { get; set; }

        // New properties matching database schema (report)
        public int QuestId { get => Id; set => Id = value; }
        public string QuestName { get => Name; set => Name = value; }

        public int BaseExp { get; set; }  // Lưu con số thực tế
        public int BaseCoin { get; set; } // Lưu con số thực tế
        public DateTime Deadline { get; set; }

        // Report expects PriorityColor as textual value ("Red","Yellow","Green").
        // Keep a Color-compatible property for UI and expose a string-backed property for DB mapping.
        public System.Drawing.Color PriorityColor { get; set; }
        public string PriorityColorName
        {
            get => PriorityColor.Name;
            set
            {
                try
                {
                    PriorityColor = System.Drawing.Color.FromName(value ?? string.Empty);
                }
                catch
                {
                    PriorityColor = System.Drawing.Color.Empty;
                }
            }
        }

        public DateTime? CompletionDate { get; set; }
        public bool IsDone { get; set; }

        // Tính EXP thực nhận từ quest, giảm 50% nếu quá hạn
        public int GetCalculatedExp()
        {
            int originalExp = this.BaseExp;
            if (IsOverdue)
            {
                return originalExp / 2;
            }
            return originalExp;
        }

        public int GetCalculatedCoin()
        {
            int originalCoin = this.BaseCoin;
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
