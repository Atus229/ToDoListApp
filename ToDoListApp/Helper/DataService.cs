using System;
using System.Collections.Generic;
using System.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Helper
{
    internal class DataService
    {
        // Trả về danh sách mẫu phục vụ UI (giữ để testing/preview)
        public static List<Quest> GetSampleQuests()
        {
            return new List<Quest> {
                new Quest {
                    Id = 1,
                    Name = "Học lập trình C# nâng cao",
                    BaseExp = 100,
                    BaseCoin = 20,
                    PriorityColor = System.Drawing.Color.Red,
                    Deadline = DateTime.Now.AddDays(-1),
                    IsDone = false
                },
                new Quest {
                    Id = 2,
                    Name = "Làm đồ án WinForms",
                    BaseExp = 200,
                    BaseCoin = 50,
                    PriorityColor = System.Drawing.Color.Orange,
                    Deadline = DateTime.Now,
                    IsDone = false
                },
                new Quest {
                    Id = 3,
                    Name = "Nấu cơm giúp mẹ",
                    BaseExp = 20,
                    BaseCoin = 5,
                    PriorityColor = System.Drawing.Color.Green,
                    Deadline = DateTime.Now.AddDays(1),
                    IsDone = false
                }
            };
        }

        // Load player stats vào Player (static) từ DB
        public static void LoadPlayerStats()
        {
            string query = "SELECT TotalExp, TotalCoin FROM PlayerStats WHERE Id = 1";
            DataTable dt = DatabaseHelper.GetData(query);

            if (dt.Rows.Count > 0)
            {
                Player.TotalExp = Convert.ToInt32(dt.Rows[0]["TotalExp"]);
                Player.TotalCoin = Convert.ToInt32(dt.Rows[0]["TotalCoin"]);
            }
        }

        // Khi hoàn thành nhiệm vụ
        public static void CompletedTask(int taskId)
        {
            // 1) Cập nhật trạng thái trong bảng Quests
            string sqlUpdate = $"UPDATE Quests SET IsDone = 1, CompletionDate = GETDATE() WHERE Id = {taskId}";
            int rows = DatabaseHelper.ExecuteQuery(sqlUpdate);

            if (rows <= 0) return;

            // 2) Lấy thông tin quest để tính thưởng
            string sqlSelect = $"SELECT BaseExp, BaseCoin, PriorityColor FROM Quests WHERE Id = {taskId}";
            DataTable dt = DatabaseHelper.GetData(sqlSelect);
            if (dt.Rows.Count == 0) return;

            int baseExp = dt.Rows[0]["BaseExp"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["BaseExp"]) : 0;
            int baseCoin = dt.Rows[0]["BaseCoin"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["BaseCoin"]) : 0;
            string priority = dt.Rows[0]["PriorityColor"] != DBNull.Value ? dt.Rows[0]["PriorityColor"].ToString() : string.Empty;

            // Áp hệ số theo PriorityColor (report yêu cầu logic thưởng)
            double multiplier = 1.0;
            switch (priority.ToLower())
            {
                case "red":
                    multiplier = 1.5; break;
                case "yellow":
                case "orange":
                    multiplier = 1.25; break;
                case "green":
                default:
                    multiplier = 1.0; break;
            }

            int gainedExp = (int)Math.Round(baseExp * multiplier);
            int gainedCoin = (int)Math.Round(baseCoin * multiplier);

            // 3) Cộng thưởng cho người chơi (Player static)
            Player.TotalExp += gainedExp;
            Player.TotalCoin += gainedCoin;

            // 4) Cập nhật bảng PlayerStats
            string updatePlayer = $"UPDATE PlayerStats SET TotalExp = {Player.TotalExp}, TotalCoin = {Player.TotalCoin} WHERE Id = 1";
            DatabaseHelper.ExecuteQuery(updatePlayer);
        }

        // Chuyển EXP tổng thành Level (thresholds đơn giản)
        public static int CalculateLevel(int exp)
        {
            int[] thresholds = { 0, 100, 300, 700, 1500 };
            for (int i = thresholds.Length - 1; i >= 0; i--)
            {
                if (exp >= thresholds[i]) return i + 1;
            }
            return 1;
        }

        // Kiểm tra và cập nhật Level nếu cần
        public static void CheckLevelUp()
        {
            // Lấy total exp từ DB để đảm bảo đồng bộ
            object obj = DatabaseHelper.ExecuteScalar("SELECT TotalExp FROM PlayerStats WHERE Id = 1");
            if (obj == null || obj == DBNull.Value) return;

            int totalExp = Convert.ToInt32(obj);
            int calculatedLevel = CalculateLevel(totalExp);

            // Cập nhật nếu khác
            object currentLevelObj = DatabaseHelper.ExecuteScalar("SELECT CurrentLevel FROM PlayerStats WHERE Id = 1");
            int currentLevel = currentLevelObj != null && currentLevelObj != DBNull.Value ? Convert.ToInt32(currentLevelObj) : 1;
            if (calculatedLevel != currentLevel)
            {
                DatabaseHelper.ExecuteQuery($"UPDATE PlayerStats SET CurrentLevel = {calculatedLevel} WHERE Id = 1");
            }
        }

        // Mua vật phẩm từ cửa hàng
        public static bool BuyItem(int itemId, int userId = 1)
        {
            // Lấy giá
            string q = $"SELECT Price FROM StoreItems WHERE Id = {itemId}";
            object priceObj = DatabaseHelper.ExecuteScalar(q);
            if (priceObj == null || priceObj == DBNull.Value) return false;
            int price = Convert.ToInt32(priceObj);

            // Lấy tiền hiện có
            object coinObj = DatabaseHelper.ExecuteScalar("SELECT TotalCoin FROM PlayerStats WHERE Id = 1");
            int coin = coinObj != null && coinObj != DBNull.Value ? Convert.ToInt32(coinObj) : 0;

            if (coin < price) return false; // không đủ tiền

            // Trừ tiền
            int r1 = DatabaseHelper.ExecuteQuery($"UPDATE PlayerStats SET TotalCoin = TotalCoin - {price} WHERE Id = 1");
            if (r1 <= 0) return false;

            // Thêm vào Inventory (nếu đã có thì tăng số lượng)
            string checkInv = $"SELECT InventoryId, Quantity FROM Inventory WHERE ItemId = {itemId} AND UserId = {userId}";
            DataTable inv = DatabaseHelper.GetData(checkInv);
            if (inv.Rows.Count > 0)
            {
                int invId = Convert.ToInt32(inv.Rows[0]["InventoryId"]);
                int qty = Convert.ToInt32(inv.Rows[0]["Quantity"]);
                DatabaseHelper.ExecuteQuery($"UPDATE Inventory SET Quantity = {qty + 1} WHERE InventoryId = {invId}");
            }
            else
            {
                DatabaseHelper.ExecuteQuery($"INSERT INTO Inventory (ItemId, UserId, Quantity, PurchasedAt) VALUES ({itemId}, {userId}, 1, GETDATE())");
            }

            return true;
        }

        // Nhận thưởng thành tựu
        public static bool ClaimAchievement(int achievementId, int userId = 1)
        {
            // Kiểm tra điều kiện: ví dụ TargetCount và tiến độ người chơi
            string q = $"SELECT TargetCount, RewardType, RewardValue FROM Achievements WHERE Id = {achievementId}";
            DataTable dt = DatabaseHelper.GetData(q);
            if (dt.Rows.Count == 0) return false;

            int target = dt.Rows[0]["TargetCount"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TargetCount"]) : 0;
            string rewardType = dt.Rows[0]["RewardType"]?.ToString();
            int rewardValue = dt.Rows[0]["RewardValue"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["RewardValue"]) : 0;

            // Trong ví dụ đơn giản: nếu TotalExp >= target thì cho nhận
            object objExp = DatabaseHelper.ExecuteScalar("SELECT TotalExp FROM PlayerStats WHERE Id = 1");
            int totalExp = objExp != null && objExp != DBNull.Value ? Convert.ToInt32(objExp) : 0;
            if (totalExp < target) return false;

            // Cập nhật trạng thái Claim (nếu có cột IsClaimed)
            DatabaseHelper.ExecuteQuery($"UPDATE Achievements SET IsClaimed = 1 WHERE Id = {achievementId}");

            // Áp reward
            if (rewardType?.ToLower() == "coin")
            {
                DatabaseHelper.ExecuteQuery($"UPDATE PlayerStats SET TotalCoin = TotalCoin + {rewardValue} WHERE Id = 1");
            }
            else if (rewardType?.ToLower() == "exp")
            {
                DatabaseHelper.ExecuteQuery($"UPDATE PlayerStats SET TotalExp = TotalExp + {rewardValue} WHERE Id = 1");
            }

            return true;
        }
    }
}
