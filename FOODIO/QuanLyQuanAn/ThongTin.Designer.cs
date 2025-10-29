namespace QuanLyQuanAn
{
    partial class fThongTin
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbThongTinTaiKhoan = new System.Windows.Forms.Label();
            this.lbTenDangNhap = new System.Windows.Forms.Label();
            this.txbTenDangNhap = new System.Windows.Forms.TextBox();
            this.lbTenHienThi = new System.Windows.Forms.Label();
            this.txbTenHienThi = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Red;
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lbThongTinTaiKhoan);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(466, 65);
            this.pnlTop.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(396, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 65);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbThongTinTaiKhoan
            // 
            this.lbThongTinTaiKhoan.AutoSize = true;
            this.lbThongTinTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.lbThongTinTaiKhoan.Location = new System.Drawing.Point(20, 15);
            this.lbThongTinTaiKhoan.Name = "lbThongTinTaiKhoan";
            this.lbThongTinTaiKhoan.Size = new System.Drawing.Size(271, 31);
            this.lbThongTinTaiKhoan.TabIndex = 0;
            this.lbThongTinTaiKhoan.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // lbTenDangNhap
            // 
            this.lbTenDangNhap.AutoSize = true;
            this.lbTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenDangNhap.Location = new System.Drawing.Point(22, 90);
            this.lbTenDangNhap.Name = "lbTenDangNhap";
            this.lbTenDangNhap.Size = new System.Drawing.Size(133, 23);
            this.lbTenDangNhap.TabIndex = 8;
            this.lbTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txbTenDangNhap
            // 
            this.txbTenDangNhap.Location = new System.Drawing.Point(200, 90);
            this.txbTenDangNhap.Multiline = true;
            this.txbTenDangNhap.Name = "txbTenDangNhap";
            this.txbTenDangNhap.ReadOnly = true;
            this.txbTenDangNhap.Size = new System.Drawing.Size(250, 25);
            this.txbTenDangNhap.TabIndex = 9;
            // 
            // lbTenHienThi
            // 
            this.lbTenHienThi.AutoSize = true;
            this.lbTenHienThi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenHienThi.Location = new System.Drawing.Point(22, 140);
            this.lbTenHienThi.Name = "lbTenHienThi";
            this.lbTenHienThi.Size = new System.Drawing.Size(108, 23);
            this.lbTenHienThi.TabIndex = 10;
            this.lbTenHienThi.Text = "Tên hiển thị:";
            // 
            // txbTenHienThi
            // 
            this.txbTenHienThi.Location = new System.Drawing.Point(200, 140);
            this.txbTenHienThi.Multiline = true;
            this.txbTenHienThi.Name = "txbTenHienThi";
            this.txbTenHienThi.ReadOnly = true;
            this.txbTenHienThi.Size = new System.Drawing.Size(250, 25);
            this.txbTenHienThi.TabIndex = 11;
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhau.Location = new System.Drawing.Point(22, 190);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(91, 23);
            this.lbMatKhau.TabIndex = 12;
            this.lbMatKhau.Text = "Mật khẩu:";
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(350, 230);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Location = new System.Drawing.Point(200, 190);
            this.txbMatKhau.Multiline = true;
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.ReadOnly = true;
            this.txbMatKhau.Size = new System.Drawing.Size(250, 25);
            this.txbMatKhau.TabIndex = 15;
            this.txbMatKhau.UseSystemPasswordChar = true;
            // 
            // fThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 285);
            this.Controls.Add(this.txbMatKhau);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.txbTenHienThi);
            this.Controls.Add(this.lbTenHienThi);
            this.Controls.Add(this.txbTenDangNhap);
            this.Controls.Add(this.lbTenDangNhap);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDoiMatKhau";
            this.Load += new System.EventHandler(this.fThongTin_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbThongTinTaiKhoan;
        private System.Windows.Forms.Label lbTenDangNhap;
        private System.Windows.Forms.TextBox txbTenDangNhap;
        private System.Windows.Forms.Label lbTenHienThi;
        private System.Windows.Forms.TextBox txbTenHienThi;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txbMatKhau;
    }
}