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
        public int BaseExp { get; set; }
        public int BaseCoin { get; set; }
        public DateTime Deadline { get; set; }
        public System.Drawing.Color PriorityColor { get; set; }
        public bool IsDone { get; set; }

        // Logic kiểm tra trễ hạn(Chuyển từ UI sang Model)
        public bool IsOverdue => DateTime.Now > Deadline && !IsDone;

        // Hàm tính EXP thực tế nhận được (đã trừ phạt nếu trễ)
        public int GetCalculatedExp()
        {
            if (IsOverdue) return BaseExp / 2;
            return BaseExp;
        }

        // Hàm tính Coin thực tế nhận được
        public int GetCalculatedCoin()
        {
            if (IsOverdue) return BaseCoin / 2;
            return BaseCoin;
        }
    }
}