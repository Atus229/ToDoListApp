using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    internal class Player
    {
        public static int TotalExp { get; set; } = 0;
        public static int TotalCoin { get; set; } = 0;
        public static int CurrentLevel => (TotalExp / 500) + 1; // Cứ 500 EXP lên 1 Level
        public static int ExpToNextLevel => 500;
        public static int CurrentExpProgress => TotalExp % 500; // Số dư EXP ở level hiện tại
    }
}
