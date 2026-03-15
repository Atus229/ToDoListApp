namespace ToDoListApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            nightForm1 = new ReaLTaiizor.Forms.NightForm();
            pnlPetFrame = new Panel();
            picPet = new PictureBox();
            panel2 = new Panel();
            btnToday = new ReaLTaiizor.Controls.ParrotButton();
            btnAllTasks = new ReaLTaiizor.Controls.ParrotButton();
            pbExp = new ReaLTaiizor.Controls.ForeverProgressBar();
            label1 = new Label();
            panel1 = new Panel();
            btnCompleted = new ReaLTaiizor.Controls.ParrotButton();
            btnStore = new ReaLTaiizor.Controls.ParrotButton();
            nightForm1.SuspendLayout();
            pnlPetFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPet).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // nightForm1
            // 
            nightForm1.BackColor = Color.FromArgb(15, 15, 15);
            nightForm1.Controls.Add(pnlPetFrame);
            nightForm1.Controls.Add(panel2);
            nightForm1.Controls.Add(panel1);
            nightForm1.Dock = DockStyle.Fill;
            nightForm1.DrawIcon = false;
            nightForm1.Font = new Font("Segoe UI", 9F);
            nightForm1.HeadColor = Color.FromArgb(50, 58, 61);
            nightForm1.Location = new Point(0, 0);
            nightForm1.MinimumSize = new Size(100, 42);
            nightForm1.Name = "nightForm1";
            nightForm1.Size = new Size(1082, 653);
            nightForm1.TabIndex = 0;
            nightForm1.Text = "TO DO LIST";
            nightForm1.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            nightForm1.TitleBarTextColor = Color.Gainsboro;
            // 
            // pnlPetFrame
            // 
            pnlPetFrame.BackColor = Color.FromArgb(255, 107, 129);
            pnlPetFrame.Controls.Add(picPet);
            pnlPetFrame.Location = new Point(65, 120);
            pnlPetFrame.Name = "pnlPetFrame";
            pnlPetFrame.Size = new Size(100, 100);
            pnlPetFrame.TabIndex = 2;
            // 
            // picPet
            // 
            picPet.Dock = DockStyle.Fill;
            picPet.Image = (Image)resources.GetObject("picPet.Image");
            picPet.Location = new Point(0, 0);
            picPet.Name = "picPet";
            picPet.Padding = new Padding(3);
            picPet.Size = new Size(100, 100);
            picPet.SizeMode = PictureBoxSizeMode.Zoom;
            picPet.TabIndex = 3;
            picPet.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnStore);
            panel2.Controls.Add(btnCompleted);
            panel2.Controls.Add(btnToday);
            panel2.Controls.Add(btnAllTasks);
            panel2.Controls.Add(pbExp);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 603);
            panel2.TabIndex = 1;
            // 
            // btnToday
            // 
            btnToday.BackgroundColor = Color.FromArgb(20, 20, 20);
            btnToday.ButtonImage = null;
            btnToday.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnToday.ButtonText = "Today";
            btnToday.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnToday.ClickTextColor = Color.White;
            btnToday.CornerRadius = 5;
            btnToday.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnToday.Horizontal_Alignment = StringAlignment.Center;
            btnToday.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnToday.HoverTextColor = Color.White;
            btnToday.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnToday.Location = new Point(-1, 318);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(220, 45);
            btnToday.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnToday.TabIndex = 6;
            btnToday.TextColor = Color.White;
            btnToday.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnToday.Vertical_Alignment = StringAlignment.Center;
            // 
            // btnAllTasks
            // 
            btnAllTasks.BackgroundColor = Color.FromArgb(214, 78, 99);
            btnAllTasks.ButtonImage = null;
            btnAllTasks.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnAllTasks.ButtonText = "All Tasks";
            btnAllTasks.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnAllTasks.ClickTextColor = Color.White;
            btnAllTasks.CornerRadius = 5;
            btnAllTasks.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAllTasks.Horizontal_Alignment = StringAlignment.Center;
            btnAllTasks.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnAllTasks.HoverTextColor = Color.White;
            btnAllTasks.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnAllTasks.Location = new Point(-1, 267);
            btnAllTasks.Name = "btnAllTasks";
            btnAllTasks.Size = new Size(220, 45);
            btnAllTasks.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnAllTasks.TabIndex = 3;
            btnAllTasks.TextColor = Color.White;
            btnAllTasks.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnAllTasks.Vertical_Alignment = StringAlignment.Center;
            btnAllTasks.Click += btnAllTasks_Click;
            // 
            // pbExp
            // 
            pbExp.BackColor = Color.Transparent;
            pbExp.BaseColor = Color.FromArgb(45, 47, 49);
            pbExp.DarkerProgress = Color.FromArgb(214, 78, 99);
            pbExp.ForeColor = Color.FromArgb(214, 78, 99);
            pbExp.Location = new Point(22, 184);
            pbExp.Maximum = 100;
            pbExp.MoveBalloon = true;
            pbExp.Name = "pbExp";
            pbExp.Pattern = true;
            pbExp.PercentSign = false;
            pbExp.ProgressColor = Color.FromArgb(255, 107, 129);
            pbExp.ShowBalloon = true;
            pbExp.Size = new Size(180, 42);
            pbExp.TabIndex = 5;
            pbExp.Text = "foreverProgressBar1";
            pbExp.Value = 70;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(55, 141);
            label1.Name = "label1";
            label1.Size = new Size(109, 31);
            label1.TabIndex = 0;
            label1.Text = "LEVEL 08";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 107, 129);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 50);
            panel1.TabIndex = 0;
            // 
            // btnCompleted
            // 
            btnCompleted.BackgroundColor = Color.FromArgb(20, 20, 20);
            btnCompleted.ButtonImage = null;
            btnCompleted.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnCompleted.ButtonText = "Completed";
            btnCompleted.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnCompleted.ClickTextColor = Color.White;
            btnCompleted.CornerRadius = 5;
            btnCompleted.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnCompleted.Horizontal_Alignment = StringAlignment.Center;
            btnCompleted.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnCompleted.HoverTextColor = Color.White;
            btnCompleted.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnCompleted.Location = new Point(0, 369);
            btnCompleted.Name = "btnCompleted";
            btnCompleted.Size = new Size(220, 45);
            btnCompleted.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnCompleted.TabIndex = 7;
            btnCompleted.TextColor = Color.White;
            btnCompleted.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnCompleted.Vertical_Alignment = StringAlignment.Center;
            // 
            // btnStore
            // 
            btnStore.BackgroundColor = Color.FromArgb(20, 20, 20);
            btnStore.ButtonImage = null;
            btnStore.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnStore.ButtonText = "Store";
            btnStore.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnStore.ClickTextColor = Color.White;
            btnStore.CornerRadius = 5;
            btnStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnStore.Horizontal_Alignment = StringAlignment.Center;
            btnStore.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnStore.HoverTextColor = Color.White;
            btnStore.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnStore.Location = new Point(-5, 420);
            btnStore.Name = "btnStore";
            btnStore.Size = new Size(220, 45);
            btnStore.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnStore.TabIndex = 8;
            btnStore.TextColor = Color.White;
            btnStore.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnStore.Vertical_Alignment = StringAlignment.Center;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1082, 653);
            Controls.Add(nightForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1020);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Fuchsia;
            Load += FrmMain_Load;
            nightForm1.ResumeLayout(false);
            pnlPetFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPet).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.NightForm nightForm1;
        private Panel panel2;
        private Panel panel1;
        private Panel pnlPetFrame;
        private PictureBox picPet;
        private Label label1;
        private ReaLTaiizor.Controls.ForeverProgressBar pbExp;
        private ReaLTaiizor.Controls.ParrotButton btnAllTasks;
        private ReaLTaiizor.Controls.ParrotButton parrotButton3;
        private ReaLTaiizor.Controls.ParrotButton parrotButton2;
        private ReaLTaiizor.Controls.ParrotButton btnToday;
        private ReaLTaiizor.Controls.ParrotButton btnStore;
        private ReaLTaiizor.Controls.ParrotButton btnCompleted;
    }
}
