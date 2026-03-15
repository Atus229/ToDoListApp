namespace ToDoListApp
{
    partial class UC_TaskPage
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
            label1 = new Label();
            lblTitle = new Label();
            panel1 = new Panel();
            flpTasks = new FlowLayoutPanel();
            parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            lblTotalCoin = new Label();
            label3 = new Label();
            parrotGradientPanel2 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            lblTotalEXP = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            parrotGradientPanel1.SuspendLayout();
            parrotGradientPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(312, 164);
            label1.Name = "label1";
            label1.Padding = new Padding(20);
            label1.Size = new Size(55, 60);
            label1.TabIndex = 1;
            label1.Text = "s";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(255, 107, 129);
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(60, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 52);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "MY QUESTS";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 107, 129);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flpTasks);
            panel1.ForeColor = Color.FromArgb(255, 107, 129);
            panel1.Location = new Point(60, 118);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(770, 376);
            panel1.TabIndex = 3;
            // 
            // flpTasks
            // 
            flpTasks.AutoScroll = true;
            flpTasks.BackColor = Color.FromArgb(15, 15, 15);
            flpTasks.Dock = DockStyle.Fill;
            flpTasks.FlowDirection = FlowDirection.TopDown;
            flpTasks.ForeColor = Color.Black;
            flpTasks.Location = new Point(1, 1);
            flpTasks.Name = "flpTasks";
            flpTasks.Size = new Size(766, 372);
            flpTasks.TabIndex = 0;
            flpTasks.WrapContents = false;
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
            parrotGradientPanel1.Location = new Point(140, 509);
            parrotGradientPanel1.Name = "parrotGradientPanel1";
            parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel1.PrimerColor = Color.White;
            parrotGradientPanel1.Size = new Size(150, 50);
            parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel1.TabIndex = 4;
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
            lblTotalCoin.Location = new Point(89, 6);
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
            label3.Size = new Size(98, 41);
            label3.TabIndex = 0;
            label3.Text = "Coin :";
            // 
            // parrotGradientPanel2
            // 
            parrotGradientPanel2.BorderStyle = BorderStyle.FixedSingle;
            parrotGradientPanel2.BottomLeft = Color.FromArgb(232, 90, 113);
            parrotGradientPanel2.BottomRight = Color.FromArgb(255, 107, 129);
            parrotGradientPanel2.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotGradientPanel2.Controls.Add(lblTotalEXP);
            parrotGradientPanel2.Controls.Add(label4);
            parrotGradientPanel2.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotGradientPanel2.Location = new Point(598, 509);
            parrotGradientPanel2.Name = "parrotGradientPanel2";
            parrotGradientPanel2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotGradientPanel2.PrimerColor = Color.White;
            parrotGradientPanel2.Size = new Size(150, 50);
            parrotGradientPanel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotGradientPanel2.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            parrotGradientPanel2.TabIndex = 5;
            parrotGradientPanel2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            parrotGradientPanel2.TopLeft = Color.DeepSkyBlue;
            parrotGradientPanel2.TopRight = Color.Fuchsia;
            // 
            // lblTotalEXP
            // 
            lblTotalEXP.AutoSize = true;
            lblTotalEXP.BackColor = Color.Transparent;
            lblTotalEXP.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalEXP.ForeColor = Color.Gold;
            lblTotalEXP.Location = new Point(85, 6);
            lblTotalEXP.Name = "lblTotalEXP";
            lblTotalEXP.Size = new Size(60, 38);
            lblTotalEXP.TabIndex = 2;
            lblTotalEXP.Text = "100";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(89, 41);
            label4.TabIndex = 1;
            label4.Text = "EXP :";
            // 
            // UC_TaskPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            Controls.Add(parrotGradientPanel2);
            Controls.Add(parrotGradientPanel1);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Name = "UC_TaskPage";
            Size = new Size(862, 572);
            Load += UC_TaskPage_Load;
            panel1.ResumeLayout(false);
            parrotGradientPanel1.ResumeLayout(false);
            parrotGradientPanel1.PerformLayout();
            parrotGradientPanel2.ResumeLayout(false);
            parrotGradientPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lblTitle;
        private Panel panel1;
        private FlowLayoutPanel flpTasks;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel2;
        private Label label3;
        private Label label5;
        private Label lblTotalEXP;
        private Label label4;
        private Label lblTotalCoin;
    }
}
