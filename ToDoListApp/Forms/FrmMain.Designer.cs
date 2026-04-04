namespace ToDoListApp.Forms
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
            pnlContainer = new Panel();
            pnlPetFrame = new Panel();
            picPet = new PictureBox();
            panel2 = new Panel();
            btnStatistics = new ReaLTaiizor.Controls.ParrotButton();
            btnAchievements = new ReaLTaiizor.Controls.ParrotButton();
            lblSidebarCoin = new Label();
            btnStore = new ReaLTaiizor.Controls.ParrotButton();
            btnAllTasks = new ReaLTaiizor.Controls.ParrotButton();
            pbExp = new ReaLTaiizor.Controls.ForeverProgressBar();
            lblLevel = new Label();
            panel1 = new Panel();
            btnCloseApp = new Button();
            nightForm1.SuspendLayout();
            pnlPetFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPet).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nightForm1
            // 
            nightForm1.BackColor = Color.FromArgb(15, 15, 15);
            nightForm1.Controls.Add(pnlContainer);
            nightForm1.Controls.Add(pnlPetFrame);
            nightForm1.Controls.Add(panel2);
            nightForm1.Controls.Add(panel1);
            nightForm1.Dock = DockStyle.Fill;
            nightForm1.DrawIcon = false;
            nightForm1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nightForm1.HeadColor = Color.FromArgb(50, 58, 61);
            nightForm1.Location = new Point(0, 0);
            nightForm1.MinimumSize = new Size(100, 42);
            nightForm1.Name = "nightForm1";
            nightForm1.Padding = new Padding(0, 31, 0, 0);
            nightForm1.Size = new Size(1082, 653);
            nightForm1.TabIndex = 0;
            nightForm1.Text = "TO DO LIST";
            nightForm1.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            nightForm1.TitleBarTextColor = Color.Gainsboro;
            // 
            // pnlContainer
            // 
            pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlContainer.BackColor = Color.Transparent;
            pnlContainer.Location = new Point(220, 81);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(862, 572);
            pnlContainer.TabIndex = 3;
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
            panel2.Controls.Add(btnStatistics);
            panel2.Controls.Add(btnAchievements);
            panel2.Controls.Add(lblSidebarCoin);
            panel2.Controls.Add(btnStore);
            panel2.Controls.Add(btnAllTasks);
            panel2.Controls.Add(pbExp);
            panel2.Controls.Add(lblLevel);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 572);
            panel2.TabIndex = 1;
            // 
            // btnStatistics
            // 
            btnStatistics.BackgroundColor = Color.FromArgb(20, 20, 20);
            btnStatistics.ButtonImage = null;
            btnStatistics.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnStatistics.ButtonText = "Statistics";
            btnStatistics.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnStatistics.ClickTextColor = Color.White;
            btnStatistics.CornerRadius = 5;
            btnStatistics.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnStatistics.Horizontal_Alignment = StringAlignment.Center;
            btnStatistics.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnStatistics.HoverTextColor = Color.White;
            btnStatistics.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnStatistics.Location = new Point(2, 444);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(220, 45);
            btnStatistics.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnStatistics.TabIndex = 12;
            btnStatistics.TextColor = Color.White;
            btnStatistics.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnStatistics.Vertical_Alignment = StringAlignment.Center;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnAchievements
            // 
            btnAchievements.BackgroundColor = Color.FromArgb(20, 20, 20);
            btnAchievements.ButtonImage = null;
            btnAchievements.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnAchievements.ButtonText = "Achievements";
            btnAchievements.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnAchievements.ClickTextColor = Color.White;
            btnAchievements.CornerRadius = 5;
            btnAchievements.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAchievements.Horizontal_Alignment = StringAlignment.Center;
            btnAchievements.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnAchievements.HoverTextColor = Color.White;
            btnAchievements.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnAchievements.Location = new Point(-1, 393);
            btnAchievements.Name = "btnAchievements";
            btnAchievements.Size = new Size(220, 45);
            btnAchievements.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnAchievements.TabIndex = 11;
            btnAchievements.TextColor = Color.White;
            btnAchievements.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnAchievements.Vertical_Alignment = StringAlignment.Center;
            btnAchievements.Click += btnAchievements_Click;
            // 
            // lblSidebarCoin
            // 
            lblSidebarCoin.AutoSize = true;
            lblSidebarCoin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSidebarCoin.ForeColor = Color.White;
            lblSidebarCoin.Location = new Point(22, 189);
            lblSidebarCoin.Name = "lblSidebarCoin";
            lblSidebarCoin.Size = new Size(110, 28);
            lblSidebarCoin.TabIndex = 10;
            lblSidebarCoin.Text = "Coins: 100";
            lblSidebarCoin.TextAlign = ContentAlignment.MiddleCenter;
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
            btnStore.Location = new Point(-1, 342);
            btnStore.Name = "btnStore";
            btnStore.Size = new Size(220, 45);
            btnStore.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnStore.TabIndex = 8;
            btnStore.TextColor = Color.White;
            btnStore.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnStore.Vertical_Alignment = StringAlignment.Center;
            btnStore.Click += btnStore_Click;
            // 
            // btnAllTasks
            // 
            btnAllTasks.BackgroundColor = Color.FromArgb(214, 78, 99);
            btnAllTasks.ButtonImage = null;
            btnAllTasks.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Material;
            btnAllTasks.ButtonText = "Tasks";
            btnAllTasks.ClickBackColor = Color.FromArgb(255, 107, 129);
            btnAllTasks.ClickTextColor = Color.White;
            btnAllTasks.CornerRadius = 5;
            btnAllTasks.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAllTasks.Horizontal_Alignment = StringAlignment.Center;
            btnAllTasks.HoverBackgroundColor = Color.FromArgb(255, 107, 129);
            btnAllTasks.HoverTextColor = Color.White;
            btnAllTasks.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            btnAllTasks.Location = new Point(-1, 291);
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
            pbExp.Location = new Point(22, 233);
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
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(55, 141);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(109, 31);
            lblLevel.TabIndex = 0;
            lblLevel.Text = "LEVEL 08";
            lblLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 107, 129);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnCloseApp);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 50);
            panel1.TabIndex = 0;
            // 
            // btnCloseApp
            // 
            btnCloseApp.Cursor = Cursors.Hand;
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseApp.ForeColor = Color.White;
            btnCloseApp.Location = new Point(1032, 13);
            btnCloseApp.Margin = new Padding(5);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(35, 30);
            btnCloseApp.TabIndex = 0;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = true;
            btnCloseApp.Click += btnCloseApp_Click;
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
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.NightForm nightForm1;
        private Panel panel2;
        private Panel panel1;
        private Panel pnlPetFrame;
        private PictureBox picPet;
        private Label lblLevel;
        private ReaLTaiizor.Controls.ForeverProgressBar pbExp;
        private ReaLTaiizor.Controls.ParrotButton btnAllTasks;
        private ReaLTaiizor.Controls.ParrotButton parrotButton3;
        private ReaLTaiizor.Controls.ParrotButton parrotButton2;
        private ReaLTaiizor.Controls.ParrotButton btnStore;
        private Panel pnlContainer;
        private Label lblSidebarCoin;
        private Button btnCloseApp;
        private ReaLTaiizor.Controls.ParrotButton parrotButton4;
        private ReaLTaiizor.Controls.ParrotButton btnAchievements;
        private ReaLTaiizor.Controls.ParrotButton btnStatistics;
    }
}
