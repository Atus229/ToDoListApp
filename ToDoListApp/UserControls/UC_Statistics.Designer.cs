namespace ToDoListApp.UserControls
{
    partial class UC_Statistics
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            chartProductivity = new ScottPlot.WinForms.FormsPlot();
            formsPlotRatio = new ScottPlot.WinForms.FormsPlot();
            label1 = new Label();
            label2 = new Label();
            parrotGradientPanel2 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            lblTotalExp = new Label();
            label4 = new Label();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            lblTotalCoin = new Label();
            label3 = new Label();
            parrotGradientPanel2.SuspendLayout();
            parrotGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(255, 107, 129);
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(82, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 52);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Statistics";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chartProductivity
            // 
            chartProductivity.BackColor = Color.White;
            chartProductivity.Location = new Point(82, 221);
            chartProductivity.Name = "chartProductivity";
            chartProductivity.Size = new Size(309, 246);
            chartProductivity.TabIndex = 7;
            // 
            // formsPlotRatio
            // 
            formsPlotRatio.Location = new Point(561, 221);
            formsPlotRatio.Name = "formsPlotRatio";
            formsPlotRatio.Size = new Size(250, 246);
            formsPlotRatio.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 107, 129);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(146, 178);
            label1.Name = "label1";
            label1.Size = new Size(179, 40);
            label1.TabIndex = 9;
            label1.Text = "Productivity";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 107, 129);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(593, 185);
            label2.Name = "label2";
            label2.Size = new Size(196, 33);
            label2.TabIndex = 10;
            label2.Text = "Completion Rate";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // parrotGradientPanel2
            // 
            parrotGradientPanel2.BorderStyle = BorderStyle.FixedSingle;
            parrotGradientPanel2.BottomLeft = Color.FromArgb(232, 90, 113);
            parrotGradientPanel2.BottomRight = Color.FromArgb(255, 107, 129);
            parrotGradientPanel2.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel2.Controls.Add(lblTotalExp);
            parrotGradientPanel2.Controls.Add(label4);
            parrotGradientPanel2.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel2.Location = new Point(539, 489);
            parrotGradientPanel2.Name = "parrotGradientPanel2";
            parrotGradientPanel2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel2.PrimerColor = Color.White;
            parrotGradientPanel2.Size = new Size(289, 50);
            parrotGradientPanel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel2.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel2.TabIndex = 12;
            parrotGradientPanel2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel2.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel2.TopRight = Color.Fuchsia;
            // 
            // lblTotalExp
            // 
            lblTotalExp.AutoSize = true;
            lblTotalExp.BackColor = Color.Transparent;
            lblTotalExp.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalExp.ForeColor = Color.Gold;
            lblTotalExp.Location = new Point(197, 6);
            lblTotalExp.Name = "lblTotalExp";
            lblTotalExp.Size = new Size(60, 38);
            lblTotalExp.TabIndex = 2;
            lblTotalExp.Text = "100";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(197, 41);
            label4.TabIndex = 1;
            label4.Text = "⭐ Tổng EXP:";
            // 
            // parrotGradientPanel1
            // 
            parrotGradientPanel1.BorderStyle = BorderStyle.FixedSingle;
            parrotGradientPanel1.BottomLeft = Color.FromArgb(232, 90, 113);
            parrotGradientPanel1.BottomRight = Color.FromArgb(255, 107, 129);
            parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel1.Controls.Add(lblTotalCoin);
            parrotGradientPanel1.Controls.Add(label3);
            parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel1.Location = new Point(82, 489);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.White;
            parrotGradientPanel1.Size = new Size(309, 50);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel1.TabIndex = 11;
            parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel1.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel1.TopRight = Color.Fuchsia;
            // 
            // lblTotalCoin
            // 
            lblTotalCoin.AutoSize = true;
            lblTotalCoin.BackColor = Color.Transparent;
            lblTotalCoin.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCoin.ForeColor = Color.Gold;
            lblTotalCoin.Location = new Point(212, 6);
            lblTotalCoin.Name = "lblTotalCoin";
            lblTotalCoin.Size = new Size(60, 38);
            lblTotalCoin.TabIndex = 3;
            lblTotalCoin.Text = "100";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(-1, 3);
            label3.Name = "label3";
            label3.Size = new Size(221, 41);
            label3.TabIndex = 0;
            label3.Text = "💰 Tổng Coin:";
            // 
            // UC_Statistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            Controls.Add(parrotGradientPanel2);
            Controls.Add(parrotGradientPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(formsPlotRatio);
            Controls.Add(chartProductivity);
            Controls.Add(lblTitle);
            Name = "UC_Statistics";
            Size = new Size(862, 572);
            Load += UC_Statistics_Load;
            parrotGradientPanel2.ResumeLayout(false);
            parrotGradientPanel2.PerformLayout();
            parrotGradientPanel1.ResumeLayout(false);
            parrotGradientPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ScottPlot.WinForms.FormsPlot chartProductivity;
        private ScottPlot.WinForms.FormsPlot formsPlotRatio;
        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel2;
        private Label lblTotalExp;
        private Label label4;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private Label lblTotalCoin;
        private Label label3;
    }
}
