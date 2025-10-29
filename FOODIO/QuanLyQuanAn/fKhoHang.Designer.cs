namespace QuanLyQuanAn
{
    partial class fKhoHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fKhoHang));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbKhoHang = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnQLKhoHang = new System.Windows.Forms.Button();
            this.btnQLBanAn = new System.Windows.Forms.Button();
            this.btnQLMonAn = new System.Windows.Forms.Button();
            this.btnQLDoanhThu = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grbThongTinKhoHang = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nmGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.lbGiaNhap = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbDonViTinh = new System.Windows.Forms.TextBox();
            this.lbDonViTinh = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nmSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.lbSoLuongTon = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbTenNguyenLieu = new System.Windows.Forms.TextBox();
            this.lbTenNguyenLieu = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbID = new System.Windows.Forms.TextBox();
            this.lbFoodID = new System.Windows.Forms.Label();
            this.dtgvKhoHang = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grbThongTinKhoHang.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongTon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Crimson;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lbKhoHang);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(982, 94);
            this.pnlHeader.TabIndex = 6;
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
            // lbKhoHang
            // 
            this.lbKhoHang.AutoSize = true;
            this.lbKhoHang.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhoHang.ForeColor = System.Drawing.Color.White;
            this.lbKhoHang.Location = new System.Drawing.Point(410, 18);
            this.lbKhoHang.Name = "lbKhoHang";
            this.lbKhoHang.Size = new System.Drawing.Size(168, 38);
            this.lbKhoHang.TabIndex = 0;
            this.lbKhoHang.Text = "KHO HÀNG";
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
            this.pnlMenu.TabIndex = 7;
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
            this.btnQLDoanhThu.Click += new System.EventHandler(this.btnQLDoanhThu_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.Controls.Add(this.grbThongTinKhoHang);
            this.pnlMain.Controls.Add(this.dtgvKhoHang);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 94);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(782, 459);
            this.pnlMain.TabIndex = 9;
            // 
            // grbThongTinKhoHang
            // 
            this.grbThongTinKhoHang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbThongTinKhoHang.BackgroundImage")));
            this.grbThongTinKhoHang.Controls.Add(this.panel6);
            this.grbThongTinKhoHang.Controls.Add(this.panel5);
            this.grbThongTinKhoHang.Controls.Add(this.panel4);
            this.grbThongTinKhoHang.Controls.Add(this.panel3);
            this.grbThongTinKhoHang.Controls.Add(this.panel2);
            this.grbThongTinKhoHang.Controls.Add(this.btnXoa);
            this.grbThongTinKhoHang.Controls.Add(this.btnSua);
            this.grbThongTinKhoHang.Controls.Add(this.btnThem);
            this.grbThongTinKhoHang.Controls.Add(this.panel1);
            this.grbThongTinKhoHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinKhoHang.ForeColor = System.Drawing.Color.White;
            this.grbThongTinKhoHang.Location = new System.Drawing.Point(11, 113);
            this.grbThongTinKhoHang.Name = "grbThongTinKhoHang";
            this.grbThongTinKhoHang.Size = new System.Drawing.Size(295, 343);
            this.grbThongTinKhoHang.TabIndex = 12;
            this.grbThongTinKhoHang.TabStop = false;
            this.grbThongTinKhoHang.Text = "Thông tin kho hàng:";
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.Controls.Add(this.dtpNgayNhap);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel6.Location = new System.Drawing.Point(3, 229);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(289, 39);
            this.panel6.TabIndex = 13;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Location = new System.Drawing.Point(144, 0);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(142, 30);
            this.dtpNgayNhap.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày nhập:";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.Controls.Add(this.nmGiaNhap);
            this.panel5.Controls.Add(this.lbGiaNhap);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel5.Location = new System.Drawing.Point(3, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 41);
            this.panel5.TabIndex = 12;
            // 
            // nmGiaNhap
            // 
            this.nmGiaNhap.Location = new System.Drawing.Point(144, 0);
            this.nmGiaNhap.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmGiaNhap.Name = "nmGiaNhap";
            this.nmGiaNhap.Size = new System.Drawing.Size(142, 30);
            this.nmGiaNhap.TabIndex = 0;
            // 
            // lbGiaNhap
            // 
            this.lbGiaNhap.AutoSize = true;
            this.lbGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaNhap.Location = new System.Drawing.Point(3, 0);
            this.lbGiaNhap.Name = "lbGiaNhap";
            this.lbGiaNhap.Size = new System.Drawing.Size(71, 20);
            this.lbGiaNhap.TabIndex = 1;
            this.lbGiaNhap.Text = "Giá nhập:";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Controls.Add(this.txbDonViTinh);
            this.panel4.Controls.Add(this.lbDonViTinh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel4.Location = new System.Drawing.Point(3, 149);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 39);
            this.panel4.TabIndex = 11;
            // 
            // txbDonViTinh
            // 
            this.txbDonViTinh.Location = new System.Drawing.Point(144, 0);
            this.txbDonViTinh.Multiline = true;
            this.txbDonViTinh.Name = "txbDonViTinh";
            this.txbDonViTinh.Size = new System.Drawing.Size(142, 33);
            this.txbDonViTinh.TabIndex = 0;
            // 
            // lbDonViTinh
            // 
            this.lbDonViTinh.AutoSize = true;
            this.lbDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDonViTinh.Location = new System.Drawing.Point(3, 0);
            this.lbDonViTinh.Name = "lbDonViTinh";
            this.lbDonViTinh.Size = new System.Drawing.Size(84, 20);
            this.lbDonViTinh.TabIndex = 1;
            this.lbDonViTinh.Text = "Đơn vị tính:";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.nmSoLuongTon);
            this.panel3.Controls.Add(this.lbSoLuongTon);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 46);
            this.panel3.TabIndex = 10;
            // 
            // nmSoLuongTon
            // 
            this.nmSoLuongTon.Location = new System.Drawing.Point(144, 0);
            this.nmSoLuongTon.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmSoLuongTon.Name = "nmSoLuongTon";
            this.nmSoLuongTon.Size = new System.Drawing.Size(142, 30);
            this.nmSoLuongTon.TabIndex = 0;
            // 
            // lbSoLuongTon
            // 
            this.lbSoLuongTon.AutoSize = true;
            this.lbSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuongTon.Location = new System.Drawing.Point(3, 0);
            this.lbSoLuongTon.Name = "lbSoLuongTon";
            this.lbSoLuongTon.Size = new System.Drawing.Size(98, 20);
            this.lbSoLuongTon.TabIndex = 1;
            this.lbSoLuongTon.Text = "Số lượng tồn:";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.txbTenNguyenLieu);
            this.panel2.Controls.Add(this.lbTenNguyenLieu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel2.Location = new System.Drawing.Point(3, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 38);
            this.panel2.TabIndex = 9;
            // 
            // txbTenNguyenLieu
            // 
            this.txbTenNguyenLieu.Location = new System.Drawing.Point(144, 0);
            this.txbTenNguyenLieu.Multiline = true;
            this.txbTenNguyenLieu.Name = "txbTenNguyenLieu";
            this.txbTenNguyenLieu.Size = new System.Drawing.Size(142, 32);
            this.txbTenNguyenLieu.TabIndex = 0;
            // 
            // lbTenNguyenLieu
            // 
            this.lbTenNguyenLieu.AutoSize = true;
            this.lbTenNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNguyenLieu.Location = new System.Drawing.Point(3, 0);
            this.lbTenNguyenLieu.Name = "lbTenNguyenLieu";
            this.lbTenNguyenLieu.Size = new System.Drawing.Size(115, 20);
            this.lbTenNguyenLieu.TabIndex = 1;
            this.lbTenNguyenLieu.Text = "Tên nguyên liệu:";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Cyan;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnXoa.Location = new System.Drawing.Point(184, 298);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 39);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Cyan;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSua.Location = new System.Drawing.Point(93, 298);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 39);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Cyan;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnThem.Location = new System.Drawing.Point(3, 298);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 39);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.txbID);
            this.panel1.Controls.Add(this.lbFoodID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 39);
            this.panel1.TabIndex = 0;
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(144, 0);
            this.txbID.Multiline = true;
            this.txbID.Name = "txbID";
            this.txbID.ReadOnly = true;
            this.txbID.Size = new System.Drawing.Size(142, 33);
            this.txbID.TabIndex = 0;
            // 
            // lbFoodID
            // 
            this.lbFoodID.AutoSize = true;
            this.lbFoodID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFoodID.Location = new System.Drawing.Point(3, 0);
            this.lbFoodID.Name = "lbFoodID";
            this.lbFoodID.Size = new System.Drawing.Size(27, 20);
            this.lbFoodID.TabIndex = 1;
            this.lbFoodID.Text = "ID:";
            // 
            // dtgvKhoHang
            // 
            this.dtgvKhoHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhoHang.Location = new System.Drawing.Point(312, 127);
            this.dtgvKhoHang.Name = "dtgvKhoHang";
            this.dtgvKhoHang.RowHeadersWidth = 51;
            this.dtgvKhoHang.RowTemplate.Height = 24;
            this.dtgvKhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvKhoHang.Size = new System.Drawing.Size(467, 329);
            this.dtgvKhoHang.TabIndex = 0;
            this.dtgvKhoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKhoHang_CellClick);
            // 
            // fKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fKhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fKhoHang";
            this.Load += new System.EventHandler(this.fKhoHang_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.grbThongTinKhoHang.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongTon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbKhoHang;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnQLTaiKhoan;
        private System.Windows.Forms.Button btnQLKhoHang;
        private System.Windows.Forms.Button btnQLBanAn;
        private System.Windows.Forms.Button btnQLMonAn;
        private System.Windows.Forms.Button btnQLDoanhThu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dtgvKhoHang;
        private System.Windows.Forms.GroupBox grbThongTinKhoHang;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbSoLuongTon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbTenNguyenLieu;
        private System.Windows.Forms.Label lbTenNguyenLieu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label lbFoodID;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbGiaNhap;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbDonViTinh;
        private System.Windows.Forms.Label lbDonViTinh;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.NumericUpDown nmGiaNhap;
        private System.Windows.Forms.NumericUpDown nmSoLuongTon;
    }
}