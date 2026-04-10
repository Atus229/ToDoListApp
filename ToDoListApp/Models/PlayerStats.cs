namespace ToDoListApp.Models
{
    public class PlayerStats
    {
        public int PlayerId { get; set; }
        public int TotalExp { get; set; }
        public int TotalCoin { get; set; }
        public int CurrentLevel { get; set; }
        public bool IsDoubleExpActive { get; set; }
        public bool IsShieldActive { get; set; }
    }
}