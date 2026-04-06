namespace ToDoListApp.Forms
{
    partial class FrmAddQuest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblExpValue = new Label();
            btnCancel = new Button();
            lblCoinValue = new Label();
            txtQuestName = new TextBox();
            cboPriority = new ComboBox();
            dtpDeadline = new DateTimePicker();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 107, 129);
            label1.Location = new Point(28, 46);
            label1.Name = "label1";
            label1.Size = new Size(157, 31);
            label1.TabIndex = 0;
            label1.Text = "Quest Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 107, 129);
            label2.Location = new Point(28, 108);
            label2.Name = "label2";
            label2.Size = new Size(101, 31);
            label2.TabIndex = 2;
            label2.Text = "Priotity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 107, 129);
            label3.Location = new Point(28, 170);
            label3.Name = "label3";
            label3.Size = new Size(115, 31);
            label3.TabIndex = 4;
            label3.Text = "Deadline:";
            // 
            // lblExpValue
            // 
            lblExpValue.AutoSize = true;
            lblExpValue.BackColor = Color.FromArgb(255, 107, 129);
            lblExpValue.BorderStyle = BorderStyle.Fixed3D;
            lblExpValue.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpValue.ForeColor = Color.White;
            lblExpValue.Location = new Point(277, 241);
            lblExpValue.Name = "lblExpValue";
            lblExpValue.Size = new Size(130, 40);
            lblExpValue.TabIndex = 8;
            lblExpValue.Text = "Exp: 100";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(255, 107, 129);
            btnCancel.Location = new Point(277, 330);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 27);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = ContentAlignment.TopCenter;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCoinValue
            // 
            lblCoinValue.AutoSize = true;
            lblCoinValue.BackColor = Color.FromArgb(255, 107, 129);
            lblCoinValue.BorderStyle = BorderStyle.Fixed3D;
            lblCoinValue.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoinValue.ForeColor = Color.White;
            lblCoinValue.Location = new Point(49, 241);
            lblCoinValue.Name = "lblCoinValue";
            lblCoinValue.Size = new Size(142, 40);
            lblCoinValue.TabIndex = 11;
            lblCoinValue.Text = "Coin: 100";
            // 
            // txtQuestName
            // 
            txtQuestName.Location = new Point(191, 50);
            txtQuestName.Name = "txtQuestName";
            txtQuestName.Size = new Size(236, 27);
            txtQuestName.TabIndex = 12;
            // 
            // cboPriority
            // 
            cboPriority.FormattingEnabled = true;
            cboPriority.Items.AddRange(new object[] { "Normal", "Important", "Urgent" });
            cboPriority.Location = new Point(191, 114);
            cboPriority.Name = "cboPriority";
            cboPriority.Size = new Size(151, 28);
            cboPriority.TabIndex = 13;
            cboPriority.SelectedIndexChanged += cboPriority_SelectedIndexChanged;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Location = new Point(191, 174);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(250, 27);
            dtpDeadline.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSave.ForeColor = Color.FromArgb(255, 107, 129);
            btnSave.Location = new Point(55, 330);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(136, 27);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.TopCenter;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmAddQuest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(450, 421);
            Controls.Add(btnSave);
            Controls.Add(dtpDeadline);
            Controls.Add(cboPriority);
            Controls.Add(txtQuestName);
            Controls.Add(lblCoinValue);
            Controls.Add(btnCancel);
            Controls.Add(lblExpValue);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(1920, 1020);
            Name = "FrmAddQuest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Quest!";
            TransparencyKey = Color.Fuchsia;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label lblExpValue;
        private Button button1;
        private Button btnCancel;
        private Label lblCoinValue;
        private TextBox txtQuestName;
        private ComboBox cboPriority;
        private DateTimePicker dtpDeadline;
        private Button btnSave;
    }
}