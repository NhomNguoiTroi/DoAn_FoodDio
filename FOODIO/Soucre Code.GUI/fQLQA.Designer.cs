namespace Soucre_Code.GUI
{
    partial class fQLQA
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
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbMenu = new System.Windows.Forms.ComboBox();
            this.txbTongTien = new System.Windows.Forms.TextBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.lbGiamGia = new System.Windows.Forms.Label();
            this.lbChuyenBan = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewBill = new System.Windows.Forms.ListView();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printDialog4 = new System.Windows.Forms.PrintDialog();
            this.printDialog3 = new System.Windows.Forms.PrintDialog();
            this.printDialog2 = new System.Windows.Forms.PrintDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(12, 36);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(395, 406);
            this.flpTable.TabIndex = 9;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(224, 5);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(75, 52);
            this.btnThemMon.TabIndex = 1;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(305, 19);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(56, 22);
            this.nmSoLuong.TabIndex = 2;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThemMon);
            this.panel4.Controls.Add(this.nmSoLuong);
            this.panel4.Controls.Add(this.cbMenu);
            this.panel4.Location = new System.Drawing.Point(416, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 72);
            this.panel4.TabIndex = 5;
            // 
            // cbMenu
            // 
            this.cbMenu.FormattingEnabled = true;
            this.cbMenu.Location = new System.Drawing.Point(3, 17);
            this.cbMenu.Name = "cbMenu";
            this.cbMenu.Size = new System.Drawing.Size(215, 24);
            this.cbMenu.TabIndex = 0;
            // 
            // txbTongTien
            // 
            this.txbTongTien.Location = new System.Drawing.Point(212, 30);
            this.txbTongTien.Name = "txbTongTien";
            this.txbTongTien.ReadOnly = true;
            this.txbTongTien.Size = new System.Drawing.Size(75, 22);
            this.txbTongTien.TabIndex = 5;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(209, 11);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(63, 16);
            this.lbTongTien.TabIndex = 8;
            this.lbTongTien.Text = "Tổng tiền";
            // 
            // lbGiamGia
            // 
            this.lbGiamGia.AutoSize = true;
            this.lbGiamGia.Location = new System.Drawing.Point(118, 13);
            this.lbGiamGia.Name = "lbGiamGia";
            this.lbGiamGia.Size = new System.Drawing.Size(61, 16);
            this.lbGiamGia.TabIndex = 7;
            this.lbGiamGia.Text = "Giảm giá";
            // 
            // lbChuyenBan
            // 
            this.lbChuyenBan.AutoSize = true;
            this.lbChuyenBan.Location = new System.Drawing.Point(3, 11);
            this.lbChuyenBan.Name = "lbChuyenBan";
            this.lbChuyenBan.Size = new System.Drawing.Size(78, 16);
            this.lbChuyenBan.TabIndex = 6;
            this.lbChuyenBan.Text = "Chuyển bàn";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(3, 30);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(95, 24);
            this.comboBox3.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(121, 32);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(71, 22);
            this.numericUpDown2.TabIndex = 4;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(301, 0);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 52);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbTongTien);
            this.panel3.Controls.Add(this.lbTongTien);
            this.panel3.Controls.Add(this.lbGiamGia);
            this.panel3.Controls.Add(this.lbChuyenBan);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(416, 385);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 57);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewBill);
            this.panel2.Location = new System.Drawing.Point(413, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 268);
            this.panel2.TabIndex = 7;
            // 
            // listViewBill
            // 
            this.listViewBill.HideSelection = false;
            this.listViewBill.Location = new System.Drawing.Point(0, 0);
            this.listViewBill.Name = "listViewBill";
            this.listViewBill.Size = new System.Drawing.Size(373, 268);
            this.listViewBill.TabIndex = 9;
            this.listViewBill.UseCompatibleStateImageBehavior = false;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.thôngTinToolStripMenuItem.Text = "Thông tin ";
            this.thôngTinToolStripMenuItem.Click += new System.EventHandler(this.thôngTinToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printDialog4
            // 
            this.printDialog4.UseEXDialog = true;
            // 
            // printDialog3
            // 
            this.printDialog3.UseEXDialog = true;
            // 
            // printDialog2
            // 
            this.printDialog2.UseEXDialog = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // fQLQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fQLQA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Quán Ăn";
            this.Load += new System.EventHandler(this.fQLQA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbMenu;
        private System.Windows.Forms.TextBox txbTongTien;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbGiamGia;
        private System.Windows.Forms.Label lbChuyenBan;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewBill;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PrintDialog printDialog4;
        private System.Windows.Forms.PrintDialog printDialog3;
        private System.Windows.Forms.PrintDialog printDialog2;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}