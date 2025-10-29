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

namespace QuanLyQuanAn
{
    public partial class fDoanhThu : Form
    {
        public fDoanhThu()
        {
            InitializeComponent();
        }
        private DoanhThuService doanhthuservice = new DoanhThuService();
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime Ngaybd = dtpTuNgay.Value.Date;
            DateTime Ngaykt = dtpDenNgay.Value.Date;
            var thongke = doanhthuservice.GetByDateRange(Ngaybd, Ngaykt);
            dtgvDoanhThu.DataSource = thongke;
        }
        private void LoadDoanhThu()
        {
            dtgvDoanhThu.DataSource = doanhthuservice.GetAll();
        }
        private void fDoanhThu_Load(object sender, EventArgs e)
        {
            LoadDoanhThu();
        }
    }
}
