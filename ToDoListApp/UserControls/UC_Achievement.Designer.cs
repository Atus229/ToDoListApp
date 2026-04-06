namespace ToDoListApp.UserControls
{
    partial class UC_Achievement
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
            panel1 = new Panel();
            flpAchievements = new FlowLayoutPanel();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 107, 129);
            panel1.Controls.Add(flpAchievements);
            panel1.Location = new Point(48, 133);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(766, 372);
            panel1.TabIndex = 8;
            // 
            // flpAchievements
            // 
            flpAchievements.AutoScroll = true;
            flpAchievements.BackColor = Color.FromArgb(15, 15, 15);
            flpAchievements.Dock = DockStyle.Fill;
            flpAchievements.FlowDirection = FlowDirection.TopDown;
            flpAchievements.ForeColor = Color.Coral;
            flpAchievements.Location = new Point(1, 1);
            flpAchievements.Name = "flpAchievements";
            flpAchievements.Padding = new Padding(10);
            flpAchievements.Size = new Size(764, 370);
            flpAchievements.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(255, 107, 129);
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(48, 68);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(304, 52);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "ACHIEVEMENTS";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UC_Achievement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Name = "UC_Achievement";
            Size = new Size(862, 572);
            Load += UC_Achievement_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flpAchievements;
        private Label lblTitle;
    }
}
