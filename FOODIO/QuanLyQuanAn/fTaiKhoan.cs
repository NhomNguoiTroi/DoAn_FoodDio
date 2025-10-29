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
    public partial class fTaiKhoan : Form
    {
        public fTaiKhoan()
        {
            InitializeComponent();
        }
        private QLQAContext context = new QLQAContext();
        private DoanhThuService doanhthuservice = new DoanhThuService();
        private BanAnService bananservice = new BanAnService();
        private MonanService monanservice = new MonanService();
        private KhoHangService khohangservice = new KhoHangService();
        private TaiKhoanService taikhoanservice = new TaiKhoanService();


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
            fBanAn an = new fBanAn();
            an.ShowDialog();
            this.Close();
        }

        private void btnQLKhoHang_Click(object sender, EventArgs e)
        {
            fKhoHang f = new fKhoHang();
            f.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTaiKhoanToData()
        {
            taikhoanservice.LoadToGrid(dtgvTaiKhoan);
        }

        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanToData();
        }

        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvTaiKhoan.Rows[e.RowIndex];
                var tk = taikhoanservice.GetTaiKhoanFromRow(row);
                if (tk != null)
                {
                    txbTenDangNhap.Text = tk.TenNguoiDung.ToString();
                    txbTenHienThi.Text = tk.TenHienThi.ToString();
                    txbMatKhau.Text = tk .MatKhau.ToString();   
                }
            }
        }

        private void dtgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvTaiKhoan.Columns[e.ColumnIndex].Name == "MatKhau" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(dtgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon tai khoan muon doi mat khau");
                return;
            }
            string username = dtgvTaiKhoan.CurrentRow.Cells[1].Value.ToString();
            var taikhoan = taikhoanservice.GetByUsername(username);
            if (taikhoan == null) {
                MessageBox.Show("Khong tim thay tai khoan trong he thong");
                return;
            }
            using (var f = new fDoiMK(taikhoan)) 
            {   
                this.Hide();
                var result =  f.ShowDialog();
                this.Show();
                if(result == DialogResult.OK)
                {
                    fTaiKhoan_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Chua cap nhat lai du lieu!", "Thong Bao");

                }
            }
            
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (dtgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon tai khoan muon doi mat khau");
                return;
            }
            string username = dtgvTaiKhoan.CurrentRow.Cells[1].Value.ToString();
            var taikhoan = taikhoanservice.GetByUsername(username);
            if (taikhoan == null)
            {
                MessageBox.Show("Khong tim thay tai khoan trong he thong");
                return;
            }
            using (var f = new fDoiMK(taikhoan))
            {
                this.Hide();
                var result = f.ShowDialog();
                this.Show();
                if (result == DialogResult.OK)
                {
                    fTaiKhoan_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Chua cap nhat lai du lieu!", "Thong Bao");

                }
            }
        }
    }
}
