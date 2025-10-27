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
    public partial class fThongTinTaiKhoan : Form
    {
        private readonly TaiKhoanService taiKhoanService = new TaiKhoanService();
        private string username;

        public fThongTinTaiKhoan(string tenDangNhap)
        {
            InitializeComponent();
            username = tenDangNhap;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string oldPass = textBox2.Text.Trim();
            string newPass = textBox3.Text.Trim();
            string rePass = textBox4.Text.Trim();

            if (newPass != rePass)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = taiKhoanService.DoiMatKhau(username, oldPass, newPass);

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}