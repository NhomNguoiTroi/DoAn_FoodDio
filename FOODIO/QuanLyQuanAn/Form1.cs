using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.CodeDom;
namespace QuanLyQuanAn
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
            this.AcceptButton =  btnDangNhap;
        }
        private TaiKhoanService taikhoanservice = new TaiKhoanService();


     
        private void fDangNhap_Load(object sender, EventArgs e)
        {
            

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTenDangNhap.Text.Trim();
            string matkhau = txbMatKhau.Text.Trim();    

            if(string.IsNullOrEmpty(tendangnhap) || string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông Báo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool dangnhap =taikhoanservice.KiemTraDangNhap(tendangnhap, matkhau);
            if (dangnhap)
            {
                var tk = taikhoanservice.GetByUsername(txbTenDangNhap.Text.Trim());
                fFOODIO_QLQA f = new fFOODIO_QLQA(tk);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu!","Lỗi Đăng Nhập"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*fTK fTK = new fTK();
            fTK.ShowDialog();*/

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát không?","Thông Báo",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
               e.Cancel = true;
            }
        }
    }
}
