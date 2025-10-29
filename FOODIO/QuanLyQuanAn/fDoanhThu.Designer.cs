namespace QuanLyQuanAn
{
    partial class fDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDoanhThu));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbDoanhThu = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnQLKhoHang = new System.Windows.Forms.Button();
            this.btnQLBanAn = new System.Windows.Forms.Button();
            this.btnQLMonAn = new System.Windows.Forms.Button();
            this.btnQLDoanhThu = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Crimson;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lbDoanhThu);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(982, 94);
            this.pnlHeader.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(901, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 94);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbDoanhThu
            // 
            this.lbDoanhThu.AutoSize = true;
            this.lbDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lbDoanhThu.Location = new System.Drawing.Point(410, 18);
            this.lbDoanhThu.Name = "lbDoanhThu";
            this.lbDoanhThu.Size = new System.Drawing.Size(187, 38);
            this.lbDoanhThu.TabIndex = 0;
            this.lbDoanhThu.Text = "DOANH THU";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlMenu.Controls.Add(this.btnQLTaiKhoan);
            this.pnlMenu.Controls.Add(this.btnQLKhoHang);
            this.pnlMenu.Controls.Add(this.btnQLBanAn);
            this.pnlMenu.Controls.Add(this.btnQLMonAn);
            this.pnlMenu.Controls.Add(this.btnQLDoanhThu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 94);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 459);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(0, 196);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(200, 49);
            this.btnQLTaiKhoan.TabIndex = 4;
            this.btnQLTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQLTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnQLKhoHang
            // 
            this.btnQLKhoHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLKhoHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLKhoHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLKhoHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKhoHang.ForeColor = System.Drawing.Color.White;
            this.btnQLKhoHang.Location = new System.Drawing.Point(0, 147);
            this.btnQLKhoHang.Name = "btnQLKhoHang";
            this.btnQLKhoHang.Size = new System.Drawing.Size(200, 49);
            this.btnQLKhoHang.TabIndex = 3;
            this.btnQLKhoHang.Text = "Quản lý kho hàng";
            this.btnQLKhoHang.UseVisualStyleBackColor = false;
            this.btnQLKhoHang.Click += new System.EventHandler(this.btnQLKhoHang_Click);
            // 
            // btnQLBanAn
            // 
            this.btnQLBanAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLBanAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLBanAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLBanAn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLBanAn.ForeColor = System.Drawing.Color.White;
            this.btnQLBanAn.Location = new System.Drawing.Point(0, 98);
            this.btnQLBanAn.Name = "btnQLBanAn";
            this.btnQLBanAn.Size = new System.Drawing.Size(200, 49);
            this.btnQLBanAn.TabIndex = 2;
            this.btnQLBanAn.Text = "Quản lý bàn ăn";
            this.btnQLBanAn.UseVisualStyleBackColor = false;
            this.btnQLBanAn.Click += new System.EventHandler(this.btnQLBanAn_Click);
            // 
            // btnQLMonAn
            // 
            this.btnQLMonAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLMonAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLMonAn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMonAn.ForeColor = System.Drawing.Color.White;
            this.btnQLMonAn.Location = new System.Drawing.Point(0, 49);
            this.btnQLMonAn.Name = "btnQLMonAn";
            this.btnQLMonAn.Size = new System.Drawing.Size(200, 49);
            this.btnQLMonAn.TabIndex = 1;
            this.btnQLMonAn.Text = "Quản lý món ăn";
            this.btnQLMonAn.UseVisualStyleBackColor = false;
            this.btnQLMonAn.Click += new System.EventHandler(this.btnQLMonAn_Click);
            // 
            // btnQLDoanhThu
            // 
            this.btnQLDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnQLDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.btnQLDoanhThu.Name = "btnQLDoanhThu";
            this.btnQLDoanhThu.Size = new System.Drawing.Size(200, 49);
            this.btnQLDoanhThu.TabIndex = 0;
            this.btnQLDoanhThu.Text = "Quản lý doanh thu";
            this.btnQLDoanhThu.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.Controls.Add(this.dtpDenNgay);
            this.pnlMain.Controls.Add(this.btnThongKe);
            this.pnlMain.Controls.Add(this.dtpTuNgay);
            this.pnlMain.Controls.Add(this.dtgvDoanhThu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 94);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(782, 459);
            this.pnlMain.TabIndex = 6;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(523, 62);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(237, 22);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Red;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(360, 56);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(92, 38);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(68, 62);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(232, 22);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // dtgvDoanhThu
            // 
            this.dtgvDoanhThu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvDoanhThu.Location = new System.Drawing.Point(0, 147);
            this.dtgvDoanhThu.Name = "dtgvDoanhThu";
            this.dtgvDoanhThu.RowHeadersWidth = 51;
            this.dtgvDoanhThu.RowTemplate.Height = 24;
            this.dtgvDoanhThu.Size = new System.Drawing.Size(782, 312);
            this.dtgvDoanhThu.TabIndex = 0;
            // 
            // fDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDoanhThu";
            this.Load += new System.EventHandler(this.fDoanhThu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbDoanhThu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnQLTaiKhoan;
        private System.Windows.Forms.Button btnQLKhoHang;
        private System.Windows.Forms.Button btnQLBanAn;
        private System.Windows.Forms.Button btnQLMonAn;
        private System.Windows.Forms.Button btnQLDoanhThu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DataGridView dtgvDoanhThu;
    }
}