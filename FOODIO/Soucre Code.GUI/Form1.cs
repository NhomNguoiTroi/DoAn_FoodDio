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
    public partial class FLogin : Form
    {
        private readonly TaiKhoanService taiKhoanService = new TaiKhoanService();
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text.Trim();
            string password = txbPassword.Text.Trim();

            if (taiKhoanService.KiemTraDangNhap(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                fQLQA f = new fQLQA(username);
                f.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
                e.Cancel = true;
        }
    }
}
