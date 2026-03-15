using ToDoListApp.Models;

namespace ToDoListApp.Helper
{
    internal class DataService
    {
        public static List<Quest> GetSampleQuests()
        {
            // Trả về danh sách tương tự như trên
            return new List<Quest> {
                new Quest {
            Id = 1,
            Name = "Học lập trình C# nâng cao",
            BaseExp = 100,
            BaseCoin = 20,
            PriorityColor = Color.Red,
            Deadline = DateTime.Now.AddDays(-1),
            IsDone = false
        },
        new Quest {
            Id = 2,
            Name = "Làm đồ án WinForms",
            BaseExp = 200,
            BaseCoin = 50,
            PriorityColor = Color.Orange,
            Deadline = DateTime.Now,
            IsDone = false
        },
        new Quest {
            Id = 3,
            Name = "Nấu cơm giúp mẹ",
            BaseExp = 20,
            BaseCoin = 5,
            PriorityColor = Color.Green,
            Deadline = DateTime.Now.AddDays(1),
            IsDone = false
        } };
        }
    }
}