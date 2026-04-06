namespace ToDoListApp.UserControls
{
    partial class UC_AchievementItem
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
            picMedal = new Label();
            prgProgress = new ReaLTaiizor.Controls.HopeProgressBar();
            lblDesc = new Label();
            lblRW = new Label();
            btnClaim = new Button();
            SuspendLayout();
            // 
            // picMedal
            // 
            picMedal.AutoSize = true;
            picMedal.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            picMedal.ForeColor = Color.FromArgb(80, 80, 80);
            picMedal.Location = new Point(3, 5);
            picMedal.Name = "picMedal";
            picMedal.Size = new Size(85, 60);
            picMedal.TabIndex = 16;
            picMedal.Text = "🏵";
            // 
            // prgProgress
            // 
            prgProgress.BarColor = Color.FromArgb(220, 223, 230);
            prgProgress.BaseColor = Color.FromArgb(255, 107, 129);
            prgProgress.DangerColor = Color.FromArgb(245, 108, 108);
            prgProgress.Font = new Font("Segoe UI", 10F);
            prgProgress.ForeColor = Color.FromArgb(242, 246, 252);
            prgProgress.FullBallonColor = Color.FromArgb(103, 194, 58);
            prgProgress.FullBallonText = "Ok!";
            prgProgress.FullBarColor = Color.FromArgb(103, 194, 58);
            prgProgress.IsError = false;
            prgProgress.Location = new Point(462, 22);
            prgProgress.Name = "prgProgress";
            prgProgress.ProgressBarStyle = ReaLTaiizor.Controls.HopeProgressBar.Style.ToolTip;
            prgProgress.Size = new Size(131, 32);
            prgProgress.TabIndex = 19;
            prgProgress.Text = "prgProgress";
            prgProgress.ValueNumber = 0;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesc.ForeColor = Color.White;
            lblDesc.Location = new Point(77, 22);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(379, 31);
            lblDesc.TabIndex = 20;
            lblDesc.Text = "Hoàn thành 5 task Red trong 1 ngày";
            // 
            // lblRW
            // 
            lblRW.AutoSize = true;
            lblRW.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRW.ForeColor = Color.Gold;
            lblRW.Location = new Point(596, 36);
            lblRW.Name = "lblRW";
            lblRW.Size = new Size(91, 20);
            lblRW.TabIndex = 21;
            lblRW.Text = "🎁500 coin";
            // 
            // btnClaim
            // 
            btnClaim.Cursor = Cursors.Hand;
            btnClaim.Dock = DockStyle.Right;
            btnClaim.FlatStyle = FlatStyle.Flat;
            btnClaim.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClaim.ForeColor = Color.White;
            btnClaim.Location = new Point(695, 0);
            btnClaim.Margin = new Padding(5);
            btnClaim.Name = "btnClaim";
            btnClaim.Size = new Size(35, 74);
            btnClaim.TabIndex = 22;
            btnClaim.Text = "✔️";
            btnClaim.UseVisualStyleBackColor = true;
            btnClaim.Click += btnClaim_Click;
            // 
            // UC_AchievementItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(btnClaim);
            Controls.Add(lblRW);
            Controls.Add(lblDesc);
            Controls.Add(prgProgress);
            Controls.Add(picMedal);
            Name = "UC_AchievementItem";
            Size = new Size(730, 74);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEdit;
        private Button btnClaim;
        private Label lblDeadline;
        private Label lblReward;
        private Label lblTaskName;
        private Label picMedal;
        private ReaLTaiizor.Controls.HopeProgressBar prgProgress;
        private Label lblDesc;
        private Label lblRW;
    }
}
