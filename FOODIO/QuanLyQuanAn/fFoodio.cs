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
    public partial class fFoodio : Form
    {
        public fFoodio()
        {
            InitializeComponent();
        }

        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            fDoanhThu f = new fDoanhThu();
            f.ShowDialog();
            this.Close();   
        }

        private void btnQLMonAn_Click(object sender, EventArgs e)
        {
            fMonAn f = new fMonAn();
            f.ShowDialog();
            this.Close();
        }

        private void btnQLBanAn_Click(object sender, EventArgs e)
        {
            fBanAn f = new fBanAn();    
            f.ShowDialog();
            this.Close();
        }

        private void btnQLKhoHang_Click(object sender, EventArgs e)
        {
            fKhoHang f = new fKhoHang();
            f.ShowDialog();
            this.Close();
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fFoodio_Load(object sender, EventArgs e)
        {

        }
    }
}
