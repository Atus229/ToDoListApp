using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    internal class Player
    {
        public static int TotalExp { get; set; } = 0;
        public static int TotalCoin { get; set; } = 0;

        // Định nghĩa các cột mốc EXP để đạt Level tiếp theo
        // Lv1: 0, Lv2: 100, Lv3: 300, Lv4: 700, Lv5: 1500
        private static readonly int[] LevelThresholds = { 0, 100, 300, 700, 1500 };

        public static int MaxLevel => 5;

        // Tính Level hiện tại dựa trên TotalExp
        public static int CurrentLevel
        {
            get
            {
                for (int i = LevelThresholds.Length - 1; i >= 0; i--)
                {
                    if (TotalExp >= LevelThresholds[i]) return i + 1;
                }
                return 1;
            }
        }

        // EXP cần có ĐỂ ĐẠT ĐƯỢC Level hiện tại (Điểm đáy)
        public static int ExpAtCurrentLevel => LevelThresholds[CurrentLevel - 1];

        // EXP cần có ĐỂ LÊN Level tiếp theo (Điểm đỉnh)
        public static int ExpToNextLevel
        {
            get
            {
                if (CurrentLevel >= MaxLevel) return LevelThresholds[MaxLevel - 1]; // Giữ nguyên ở mức cuối
                return LevelThresholds[CurrentLevel];
            }
        }

        // EXP đã tích lũy được TRONG RIÊNG Level này (Để chạy Progress Bar)
        // Đổi tên từ CurrentProgressExp thành CurrentExpProgress
public static int CurrentExpProgress => TotalExp - ExpAtCurrentLevel;

        // Tổng EXP cần thiết của riêng Level này
        public static int RequiredExpForThisLevel => ExpToNextLevel - ExpAtCurrentLevel;
    }
}
