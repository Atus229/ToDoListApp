using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ToDoListApp.Helper
{
    internal class DatabaseHelper
    {
        // Chuỗi kết nối dùng chung cho toàn dự án
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=TodoGameDB;Integrated Security=True;TrustServerCertificate=True;";

        // Mở kết nối
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Trả về DataTable cho các câu SELECT
        public static DataTable GetData(string sql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiện thông báo lỗi nhưng không ném để tránh crash giao diện trực tiếp
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        // Thực thi các câu lệnh INSERT/UPDATE/DELETE, trả về số dòng bị tác động
        public static int ExecuteQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Thực thi câu lệnh trả về 1 giá trị đơn lẻ
        public static object ExecuteScalar(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ExecuteScalar: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Load player stats into static Player class
        public static void LoadPlayerStats()
        {
            try
            {
                string q = "SELECT TotalExp, TotalCoin, IsDoubleExpActive, IsShieldActive FROM PlayerStats WHERE Id = 1";
                DataTable dt = GetData(q);
                if (dt.Rows.Count > 0)
                {
                    // Fully qualify Player to avoid missing using
                    ToDoListApp.Models.Player.TotalExp = dt.Rows[0]["TotalExp"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TotalExp"]) : 0;
                    ToDoListApp.Models.Player.TotalCoin = dt.Rows[0]["TotalCoin"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TotalCoin"]) : 0;
                    ToDoListApp.Models.Player.IsDoubleExpActive = dt.Rows[0]["IsDoubleExpActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsDoubleExpActive"]) : false;
                    ToDoListApp.Models.Player.IsShieldActive = dt.Rows[0]["IsShieldActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsShieldActive"]) : false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadPlayerStats: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
