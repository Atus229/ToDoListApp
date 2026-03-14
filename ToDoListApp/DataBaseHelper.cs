using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Text;


namespace ToDoListApp
{
    internal class DatabaseHelper
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=ToDoAppDB;Intergrated Security=True;TrustServerCertificate=True;";

        // Ham mo cong ket noi
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        //Hàm lấy/ hiển thị bảng dữ liệu
        public static DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        //Hàm chỉnh sửa dữ liệu
        public static bool ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
