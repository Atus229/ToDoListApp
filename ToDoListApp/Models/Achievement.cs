using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.Models
{
    public class Achievement
    {
        // Legacy id kept for compatibility
        public int Id { get; set; }

        // DB-aligned property
        public int AchievementId { get => Id; set => Id = value; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TargetCount { get; set; }

        // RewardType and RewardValue as required by report
        public string RewardType { get; set; }
        public int RewardValue { get; set; }
    }
}
