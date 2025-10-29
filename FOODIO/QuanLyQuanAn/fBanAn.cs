using BUS;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fBanAn : Form
    {
        public fBanAn()
        {
            InitializeComponent();
        }

        private QLQAContext context = new QLQAContext();
        private DoanhThuService doanhthuservice = new DoanhThuService();
        private BanAnService bananservice = new BanAnService();
        private MonanService monanservice = new MonanService();
        private KhoHangService khohangservice = new KhoHangService();
        private TaiKhoanService taikhoanservice = new TaiKhoanService();

        private void LoadBanAn()
        {
            bananservice.LoadToGrid(dtgvBanAn);
        }
        private void fBanAn_Load(object sender, EventArgs e)
        {
            LoadBanAn();
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

        private void dtgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBanAn.Rows[e.RowIndex];
                var banan= bananservice.GetBanAnFromRow(row);
                if (banan != null)
                {
                    txbID.Text = banan.ID.ToString();
                    txbTenBan.Text = banan.TenBan;
                    txbTinhTrang.Text = banan.TinhTrang;
                    nmSoCho.Value = banan.SoCho;
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbID.Text)||string.IsNullOrEmpty(txbTenBan.Text)
                ||string.IsNullOrEmpty(txbTinhTrang.Text)||string.IsNullOrEmpty(nmSoCho.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }

            var ban = new BanAn()
            {
                TenBan = txbTenBan.Text,
                TinhTrang = txbTinhTrang.Text,
                SoCho = (int)nmSoCho.Value
            };
            if (bananservice.Add(ban))
            {
                MessageBox.Show("Thêm bàn mới thành công!", "Thông Báo", MessageBoxButtons.OK);
            }
            LoadBanAn();
            txbID.Clear();
            txbTenBan.Clear();
            txbTinhTrang.Clear();
            nmSoCho.Value = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn cập nhật bàn ăn này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            var ban = new BanAn()
            {
                ID = int.Parse(txbID.Text),
                TenBan = txbTenBan.Text.Trim(),
                SoCho = (int)nmSoCho.Value,
                TinhTrang = txbTinhTrang.Text.Trim()
            };

            if (bananservice.Update(ban))
            {
                MessageBox.Show("Cập nhật bàn ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBanAn();
                txbID.Clear();
                txbTenBan.Clear();
                txbTinhTrang.Clear();
                nmSoCho.Value = 0;
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn ăn cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txbID.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bàn ăn này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (bananservice.Delete(id))
            {
                MessageBox.Show("Xóa bàn ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBanAn();
                txbID.Text = "";
                txbTenBan.Clear();
                txbTinhTrang.Clear();
                nmSoCho.Value = 0;
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn ăn cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
