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
    public partial class fKhoHang : Form
    {
        public fKhoHang()
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
        private void LoadKhoHang()
        {
            khohangservice.LoadToGrid(dtgvKhoHang);
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

        private void fKhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
        }

        private void dtgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKhoHang.Rows[e.RowIndex];
                var khohang = khohangservice.GetKhoFromRow(row);
                if (khohang != null)
                {
                    txbID.Text = khohang.ID.ToString();
                    txbTenNguyenLieu.Text = khohang.TenNguyenLieu.ToString();
                    nmSoLuongTon.Value = khohang.SoLuongTon;
                    txbDonViTinh.Text = khohang.DonViTinh.ToString();
                    nmGiaNhap.Value = khohang.GiaNhap;
                    dtpNgayNhap.Value = khohang.NgayNhap.Value;
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txbID.Text)||string.IsNullOrEmpty(txbTenNguyenLieu.Text)
                ||string.IsNullOrEmpty(txbDonViTinh.Text)||nmGiaNhap.Value <= 0 
                || nmSoLuongTon.Value<0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!", "Thông báo");
                return;
            }
            if (dtpNgayNhap.Value.Date > DateTime.Now) 
            {
                MessageBox.Show("Ngày nhập không được lớn hơn ngày hôm nay!", "Thông báo");
                return;
            }
            KhoHang kho = new KhoHang()
            {
                TenNguyenLieu = txbTenNguyenLieu.Text.Trim(),
                DonViTinh = txbDonViTinh.Text.Trim(),
                SoLuongTon = (int)nmSoLuongTon.Value,
                GiaNhap = (decimal)nmGiaNhap.Value,
                NgayNhap = dtpNgayNhap.Value
            };
            khohangservice.Add(kho);
            MessageBox.Show("Thêm nguyên liệu mới thành công!","Thông Báo"
                ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadKhoHang();
            ClearInput();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID.Text))
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa!", "Thông báo");
                return;
            }
            if (dtpNgayNhap.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Ngày nhập không được lớn hơn ngày hôm nay!", "Thông báo");
                return;
            }
            int id = int.Parse(txbID.Text);
            var kho = khohangservice.GetById(id);
            if (kho == null)
            {
                MessageBox.Show("Không tìm thấy nguyên liệu!", "Lỗi");
                return;
            }

          
            kho.TenNguyenLieu = txbTenNguyenLieu.Text.Trim();
            kho.DonViTinh = txbDonViTinh.Text.Trim();
            kho.SoLuongTon = (int)nmSoLuongTon.Value;
            kho.GiaNhap = (decimal)nmGiaNhap.Value;
            kho.NgayNhap = dtpNgayNhap.Value;

            khohangservice.Update(kho);

            MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thông báo");
            LoadKhoHang();
            ClearInput();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID.Text))
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa!", "Thông báo");
                return;
            }

            int id = int.Parse(txbID.Text);

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                khohangservice.Delete(id);
                MessageBox.Show("Xóa nguyên liệu thành công!", "Thông báo");
                LoadKhoHang();
                ClearInput();
            }
        }
        private void ClearInput()
        {
            txbID.Clear();
            txbTenNguyenLieu.Clear();
            txbDonViTinh.Clear();
            nmSoLuongTon.Value = 0;
            nmGiaNhap.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
        }

    }
}
