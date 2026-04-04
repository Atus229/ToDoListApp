namespace ToDoListApp.UserControls
{
    partial class UC_Store
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
            panel1 = new Panel();
            flpStore = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
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
            lblTitle.Size = new Size(138, 52);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "STORE";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 107, 129);
            panel1.Controls.Add(flpStore);
            panel1.Location = new Point(60, 105);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(766, 372);
            panel1.TabIndex = 4;
            // 
            // flpStore
            // 
            flpStore.AutoScroll = true;
            flpStore.BackColor = Color.FromArgb(15, 15, 15);
            flpStore.Dock = DockStyle.Fill;
            flpStore.ForeColor = Color.Coral;
            flpStore.Location = new Point(1, 1);
            flpStore.Name = "flpStore";
            flpStore.Padding = new Padding(10);
            flpStore.Size = new Size(764, 370);
            flpStore.TabIndex = 0;
            // 
            // UC_Store
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Name = "UC_Store";
            Size = new Size(862, 572);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel panel1;
        private FlowLayoutPanel flpStore;
    }
}
