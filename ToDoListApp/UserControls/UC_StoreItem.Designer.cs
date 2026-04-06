namespace ToDoListApp.UserControls
{
    partial class UC_StoreItem
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
            btnBuy = new Button();
            lblPrice = new Label();
            lblItemName = new Label();
            picItem = new PictureBox();
            pnlStoreItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // pnlStoreItem
            // 
            pnlStoreItem.BackColor = Color.FromArgb(30, 30, 30);
            pnlStoreItem.Controls.Add(btnBuy);
            pnlStoreItem.Controls.Add(lblPrice);
            pnlStoreItem.Controls.Add(lblItemName);
            pnlStoreItem.Controls.Add(picItem);
            pnlStoreItem.Dock = DockStyle.Fill;
            pnlStoreItem.Location = new Point(1, 1);
            pnlStoreItem.Name = "pnlStoreItem";
            pnlStoreItem.Size = new Size(178, 248);
            pnlStoreItem.TabIndex = 0;
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.White;
            btnBuy.Cursor = Cursors.Hand;
            btnBuy.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuy.ForeColor = Color.FromArgb(255, 107, 129);
            btnBuy.Location = new Point(42, 203);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(94, 29);
            btnBuy.TabIndex = 3;
            btnBuy.Text = "BUY";
            btnBuy.UseVisualStyleBackColor = false;
            btnBuy.Click += btnBuy_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Gold;
            lblPrice.Location = new Point(108, 156);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(57, 23);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "💰 50";
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
            // UC_StoreItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 107, 129);
            Controls.Add(pnlStoreItem);
            Name = "UC_StoreItem";
            Padding = new Padding(1);
            Size = new Size(180, 250);
            pnlStoreItem.ResumeLayout(false);
            pnlStoreItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStoreItem;
        private Label lblItemName;
        private PictureBox picItem;
        private Button btnBuy;
        private Label lblPrice;
    }
}
