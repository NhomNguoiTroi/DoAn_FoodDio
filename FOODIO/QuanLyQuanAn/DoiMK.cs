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
    public partial class fDoiMK : Form
    {
        private readonly TaiKhoan taikhoan = new TaiKhoan();
        private readonly TaiKhoanService taikhoanservice = new TaiKhoanService();

        public fDoiMK(TaiKhoan tk)
        {
            InitializeComponent();
            taikhoan = tk;
        }

        private void fDoiMK_Load(object sender, EventArgs e)
        {
            txbTenDangNhap.Text = taikhoan.TenNguoiDung;
            txbTenHienThi.Text = taikhoan.TenHienThi;
        }

        /*private void btnLuu_Click(object sender, EventArgs e)
        {
            string newpass = txbMatKhauMoi.Text;
            string comfirmpass = txbNhapLai.Text;

            if (string.IsNullOrEmpty(comfirmpass) || string.IsNullOrEmpty(newpass) )
            {
                MessageBox.Show("Vui long nhap day du thong tin", "Thong Bao");
                return;
            }
            if (newpass != comfirmpass) 
            {
                MessageBox.Show("Nhap mat khau khong khop!", "Thong Bao");
                return ;
            }
            if (txbMatKhau.Text != taikhoan.MatKhau)
            {
                MessageBox.Show("Mat khau cu khong dung", "Loi", MessageBoxButtons.OK)
                       ; return;
            }
            var accnew = taikhoanservice.GetByUsername(taikhoan.TenNguoiDung);
            if (accnew != null) 
            {
                if (accnew.MatKhau.Equals(comfirmpass) || accnew.MatKhau.Equals(newpass))
                {
                    accnew.MatKhau = newpass;
                    taikhoanservice.SaveChanges();
                    MessageBox.Show("Doi mat khau moi thanh cong!", "Thong Bao");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mat khau cu khong dung","Loi",MessageBoxButtons.OK)
                        ; return ;
                }
            }
            else
            {
                MessageBox.Show("Khong tim thay tai khoan", "Loi");
                return ;
            }
        }*/
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string oldPass = txbMatKhau.Text.Trim();
            string newPass = txbMatKhauMoi.Text.Trim();
            string confirmPass = txbNhapLai.Text.Trim();

           
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            bool result = taikhoanservice.DoiMatKhau(taikhoan.TenNguoiDung, oldPass, newPass);

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng hoặc tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
