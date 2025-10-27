using Source_Code.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soucre_Code.GUI
{
    public partial class fThongTin : Form
    {
        private readonly TaiKhoanService taiKhoanService = new TaiKhoanService();
        private string username;
        public fThongTin(string tenDangNhap)
        {
            InitializeComponent();
            username = tenDangNhap;
            LoadThongTin();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan f = new fThongTinTaiKhoan(username);
            f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fThongTin_Load(object sender, EventArgs e)
        {
            var acc = taiKhoanService.GetByUsername(username);
            if (acc != null)
            {
                txtLogin.Text = acc.TenNguoiDung;
                textBox1.Text = acc.TenHienThi;
                textBox2.Text = acc.MatKhau;
            }
        }
        private void LoadThongTin()
        {
            var acc = taiKhoanService.GetByUsername(username);
            if (acc != null)
            {
                txtLogin.Text = acc.TenNguoiDung;
                textBox1.Text = acc.TenHienThi;
            }
        }
    }
}
