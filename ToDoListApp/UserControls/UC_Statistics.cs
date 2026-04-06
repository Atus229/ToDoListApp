using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ToDoListApp.UserControls
{
    public partial class UC_Statistics : UserControl
    {
        public UC_Statistics()
        {
            InitializeComponent();
        }

        public void LoadProductivityChart()
        {
            // 1. Lấy dữ liệu từ Database (Giữ nguyên Query cũ)
            string query = @"SELECT CAST(CompletionDate AS DATE) as Day, COUNT(*) as Total 
                     FROM Quests 
                     WHERE IsDone = 1 AND CompletionDate >= DATEADD(day, -7, GETDATE())
                     GROUP BY CAST(CompletionDate AS DATE)
                     ORDER BY Day ASC";

            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                double[] values = new double[dt.Rows.Count];
                string[] labels = new string[dt.Rows.Count];
                double[] positions = new double[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    values[i] = Convert.ToDouble(dt.Rows[i]["Total"]);
                    labels[i] = Convert.ToDateTime(dt.Rows[i]["Day"]).ToString("dd/MM");
                    positions[i] = i;
                }

                chartProductivity.Plot.Clear();

                // 2. THAY THẾ Add.Bars THÀNH Add.Scatter (Vẽ đường nối các điểm)
                var sp = chartProductivity.Plot.Add.Scatter(positions, values);

                // 3. TÙY CHỈNH CHO GIỐNG HÌNH MẪU
                sp.LineWidth = 3;                   // Độ dày của đường nối
                sp.Color = ScottPlot.Color.FromHex("#0078D4"); // Màu xanh dương chuyên nghiệp
                sp.MarkerSize = 10;                 // Độ lớn của các điểm nút
                sp.MarkerShape = MarkerShape.FilledCircle; // Hình dáng điểm nút (tròn đặc)
                sp.FillY = true;
                sp.FillYColor = sp.Color.WithAlpha(0.2f); // Đổ màu nhạt 20% bên dưới đường kẻ
                // 4. Hiệu ứng làm mượt (Nếu bạn thích đường cong thay vì đường gấp khúc)
                // sp.Smooth = true; 
                chartProductivity.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#EEEEEE");
                // 5. Cấu hình trục và tiêu đề
                chartProductivity.Plot.Title("Xu Hướng Năng Suất 7 Ngày Qua");
                chartProductivity.Plot.Axes.Bottom.SetTicks(positions, labels);

                // Đảm bảo trục Y bắt đầu từ 0 cho trung thực
                chartProductivity.Plot.Axes.SetLimitsY(0, values.Max() + 2);

                // 6. Làm đẹp Layout
                chartProductivity.Plot.Layout.Fixed(new ScottPlot.PixelPadding(50, 20, 50, 20));

                chartProductivity.Refresh();
            }
        }

        public void LoadRatioChart()
        {
            string query = @"SELECT 
        SUM(CASE WHEN CompletionDate <= Deadline THEN 1 ELSE 0 END) as OnTime,
        SUM(CASE WHEN CompletionDate > Deadline THEN 1 ELSE 0 END) as Overdue
        FROM Quests WHERE IsDone = 1";

            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                double onTime = dt.Rows[0]["OnTime"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["OnTime"]) : 0;
                double overdue = dt.Rows[0]["Overdue"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["Overdue"]) : 0;

                if (onTime == 0 && overdue == 0) return;

                formsPlotRatio.Plot.Clear();

                // --- SỬA LỖI CS0029: PieSlice trong SP5 ---
                List<ScottPlot.PieSlice> slices = new List<ScottPlot.PieSlice>()
        {
            new ScottPlot.PieSlice() { Value = onTime, Label = "On time" },
            new ScottPlot.PieSlice() { Value = overdue, Label = "Overdue" }
        };

                // Gán màu riêng (Cách này tránh lỗi FillStyle)
                slices[0].Fill.Color = ScottPlot.Color.FromColor(System.Drawing.Color.LightGreen);
                slices[1].Fill.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Salmon);

                // Thêm biểu đồ tròn
                var pie = formsPlotRatio.Plot.Add.Pie(slices);
                pie.SliceLabelDistance = 1.4;

                formsPlotRatio.Plot.FigureBackground.Color = ScottPlot.Colors.Transparent;
                // Thiết lập màu nền của khu vực chứa dữ liệu (vùng vẽ biểu đồ)
                formsPlotRatio.Plot.DataBackground.Color = ScottPlot.Colors.Transparent;
                formsPlotRatio.BackColor = System.Drawing.Color.Transparent;
                // --- SỬA LỖI CS1061: Hiển thị nhãn trong SP5 ---
                // Trong bản 5, thuộc tính này nằm trong pie.ExplodeFraction hoặc định dạng nhãn
                pie.DonutFraction = 0.5; // Biểu đồ Donut cho hiện đại

                // Hiển thị văn bản trên từng miếng bánh
                pie.DonutFraction = 0.6; // Làm lỗ ở giữa to ra chút cho thanh thoát
                
                foreach (var slice in slices)
                {
                    slice.LabelStyle.FontSize = 14;
                }

                formsPlotRatio.Plot.Title("Completion Rate");
                foreach (var slice in slices)
                {
                    slice.LabelStyle.FontSize = 13;
                    slice.LabelStyle.ForeColor = ScottPlot.Colors.White; // Hoặc White nếu nền App của bạn màu tố
                }
                // --- SỬA LỖI CS1061: Ẩn trục trong SP5 ---
                formsPlotRatio.Plot.Axes.Frameless(); // Ẩn khung và trục
                formsPlotRatio.Plot.HideGrid();      // Ẩn lưới


                chartProductivity.Plot.FigureBackground.Color = ScottPlot.Colors.Transparent;

                // 2. Làm trong suốt nền của vùng chứa dữ liệu bên trong các trục (Data Area)
                chartProductivity.Plot.DataBackground.Color = ScottPlot.Colors.Transparent;

                // 3. Thiết lập Control WinForms cũng phải trong suốt
                chartProductivity.BackColor = System.Drawing.Color.Transparent;

                // 4. (Tùy chọn) Làm mờ các đường lưới (Grid) để trông tinh tế hơn trên nền trong suốt
                //chartProductivity.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#808080").WithAlpha(0.2f);
                //chartProductivity.Plot.Axes.Color(ScottPlot.Colors.White);
                //chartProductivity.Plot.Axes.Title.Label.Text = "Productivity"; // Nhớ là "Năng" suất nhé!
                //chartProductivity.Plot.Axes.Title.Label.ForeColor = ScottPlot.Colors.White;
                //chartProductivity.Plot.Axes.Title.Label.FontSize = 18;

                

                chartProductivity.Plot.Layout.Fixed(new ScottPlot.PixelPadding(60, 30, 60, 50));

                // 4. (Tùy chọn) Đổi màu các vạch chia (Ticks) cho rõ hơn
                chartProductivity.Plot.Axes.Left.TickLabelStyle.ForeColor = ScottPlot.Colors.White;
                chartProductivity.Plot.Axes.Bottom.TickLabelStyle.ForeColor = ScottPlot.Colors.White;
                formsPlotRatio.Refresh();
            }
        }
        public void LoadTotalSummary()
        {
            // Lấy dữ liệu tổng từ PlayerStats để bao gồm cả điểm Achievement
            string query = "SELECT TotalExp, TotalCoin FROM PlayerStats WHERE Id = 1";
            DataTable dt = ToDoListApp.Helper.DatabaseHelper.GetData(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Cập nhật các Label tổng kết trên giao diện Statistics
                lblTotalExp.Text = dt.Rows[0]["TotalExp"].ToString();
                lblTotalCoin.Text = dt.Rows[0]["TotalCoin"].ToString();
            }
        }
        private void UC_Statistics_Load(object sender, EventArgs e)
        {
            LoadProductivityChart();
            LoadRatioChart();
            LoadTotalSummary();
        }
    }
}
