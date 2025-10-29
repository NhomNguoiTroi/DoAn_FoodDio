using BUS;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fThongTin : Form
    {
        private readonly TaiKhoan taikhoan = new TaiKhoan();
        private readonly TaiKhoanService taikhoanservice = new TaiKhoanService();
        public fThongTin(TaiKhoan tk)
        {
            InitializeComponent();
            taikhoan = tk;
        }
        public fThongTin()
        {
            InitializeComponent();
        }


        private void fThongTin_Load(object sender, EventArgs e)
        {
            txbTenDangNhap.Text = taikhoan.TenNguoiDung;
            txbTenHienThi.Text = taikhoan.TenHienThi;
            txbMatKhau.Text = taikhoan.MatKhau;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
