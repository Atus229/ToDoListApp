using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    internal class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TargetCount { get; set; }
        public string Type { get; set; }
        public string RewardType { get; set; }
        public int RewardValue { get; set; }
        public int? RewardItemId { get; set; }
    }
}
