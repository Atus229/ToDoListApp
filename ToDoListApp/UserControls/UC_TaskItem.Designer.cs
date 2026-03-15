namespace ToDoListApp
{
    partial class UC_TaskItem
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
            pnlPriority = new Panel();
            chkDone = new ReaLTaiizor.Controls.ParrotCheckBox();
            lblTaskName = new Label();
            lblReward = new Label();
            lblDeadline = new Label();
            SuspendLayout();
            // 
            // pnlPriority
            // 
            pnlPriority.BackColor = Color.FromArgb(255, 107, 129);
            pnlPriority.Dock = DockStyle.Left;
            pnlPriority.Location = new Point(5, 5);
            pnlPriority.Name = "pnlPriority";
            pnlPriority.Size = new Size(5, 40);
            pnlPriority.TabIndex = 0;
            // 
            // chkDone
            // 
            chkDone.BadgeColor = Color.White;
            chkDone.BorderColor = Color.FromArgb(110, 110, 110);
            chkDone.CheckboxCheckColor = SystemColors.ScrollBar;
            chkDone.CheckboxColor = Color.White;
            chkDone.CheckboxHoverColor = Color.FromArgb(249, 55, 98);
            chkDone.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.Material;
            chkDone.Checked = false;
            chkDone.ForeColor = Color.Tomato;
            chkDone.Location = new Point(16, 8);
            chkDone.Name = "chkDone";
            chkDone.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            chkDone.Size = new Size(26, 26);
            chkDone.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            chkDone.TabIndex = 3;
            chkDone.TextRenderingType = System.Drawing.Text.TextRenderingHint.SystemDefault;
            chkDone.TickThickness = 2;
            chkDone.CheckedStateChanged += chkDone_CheckedChanged;
            // 
            // lblTaskName
            // 
            lblTaskName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskName.ForeColor = Color.White;
            lblTaskName.Location = new Point(48, 5);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(411, 38);
            lblTaskName.TabIndex = 4;
            lblTaskName.Text = "Hoàn thành UI cho to do list app";
            lblTaskName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReward
            // 
            lblReward.BorderStyle = BorderStyle.FixedSingle;
            lblReward.Dock = DockStyle.Right;
            lblReward.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReward.ForeColor = Color.FromArgb(255, 107, 129);
            lblReward.Location = new Point(592, 5);
            lblReward.Name = "lblReward";
            lblReward.Size = new Size(133, 40);
            lblReward.TabIndex = 5;
            lblReward.Text = "+50 EXP | 10 Coins";
            lblReward.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeadline.ForeColor = Color.White;
            lblDeadline.Location = new Point(465, 13);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(106, 23);
            lblDeadline.TabIndex = 6;
            lblDeadline.Text = "15/03/2026";
            // 
            // UC_TaskItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(lblDeadline);
            Controls.Add(lblReward);
            Controls.Add(lblTaskName);
            Controls.Add(chkDone);
            Controls.Add(pnlPriority);
            ForeColor = Color.Crimson;
            Name = "UC_TaskItem";
            Padding = new Padding(5);
            Size = new Size(730, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlPriority;
        private ReaLTaiizor.Controls.ParrotCheckBox chkDone;
        private Label lblTaskName;
        private Label lblReward;
        private Label lblDeadline;
    }
}
