namespace ToDoListApp.UserControls
{
    partial class UC_InventoryItem
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
            pnlStoreItem = new Panel();
            btnUse = new Button();
            lblQuantity = new Label();
            lblItemName = new Label();
            picItem = new PictureBox();
            pnlStoreItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // pnlStoreItem
            // 
            pnlStoreItem.BackColor = Color.FromArgb(30, 30, 30);
            pnlStoreItem.Controls.Add(btnUse);
            pnlStoreItem.Controls.Add(lblQuantity);
            pnlStoreItem.Controls.Add(lblItemName);
            pnlStoreItem.Controls.Add(picItem);
            pnlStoreItem.Dock = DockStyle.Fill;
            pnlStoreItem.Location = new Point(0, 0);
            pnlStoreItem.Name = "pnlStoreItem";
            pnlStoreItem.Size = new Size(178, 248);
            pnlStoreItem.TabIndex = 1;
            // 
            // btnUse
            // 
            btnUse.BackColor = Color.White;
            btnUse.Cursor = Cursors.Hand;
            btnUse.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUse.ForeColor = Color.FromArgb(255, 107, 129);
            btnUse.Location = new Point(42, 203);
            btnUse.Name = "btnUse";
            btnUse.Size = new Size(94, 29);
            btnUse.TabIndex = 3;
            btnUse.Text = "USE";
            btnUse.UseVisualStyleBackColor = false;
            btnUse.Click += btnUse_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.Gold;
            lblQuantity.Location = new Point(108, 156);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(52, 23);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "SL: 10";
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemName.ForeColor = Color.White;
            lblItemName.Location = new Point(15, 154);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(63, 25);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "Streak";
            lblItemName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picItem
            // 
            picItem.Location = new Point(15, 15);
            picItem.Name = "picItem";
            picItem.Size = new Size(150, 120);
            picItem.SizeMode = PictureBoxSizeMode.Zoom;
            picItem.TabIndex = 0;
            picItem.TabStop = false;
            // 
            // UC_InventoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlStoreItem);
            Name = "UC_InventoryItem";
            Size = new Size(178, 248);
            pnlStoreItem.ResumeLayout(false);
            pnlStoreItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStoreItem;
        private Button btnUse;
        private Label lblQuantity;
        private Label lblItemName;
        private PictureBox picItem;
    }
}
