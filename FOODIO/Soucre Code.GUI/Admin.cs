using Source_Code.BUS;
using Source_Code.DAL.Models;
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

namespace Soucre_Code.GUI
{
    public partial class fAdmin : Form
    {
        private MonAnService monAnService = new MonAnService();
        private KhoHangService khoHangService = new KhoHangService();
        private BanAnService banAnService = new BanAnService();
        private TaiKhoanService taiKhoanService = new TaiKhoanService();
        private DoanhThuService doanhThuService = new DoanhThuService();
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            LoadFood();
            LoadKho();
            LoadDoanhThu();
            LoadBanAn();
            LoadTaiKhoan();
        }
        private void LoadFood()
        {
            var list = monAnService.GetAll()
                .Select(x => new { x.ID, x.TenMonAn, x.DonGia, x.HinhAnh})
                .ToList();

            dtgvThucAn.DataSource = list;
            if (dtgvThucAn.Columns.Contains("HinhAnh"))
                dtgvThucAn.Columns["HinhAnh"].Visible = false;
        }

        private void LoadKho()
        {
            dtgvKhoHang.DataSource = khoHangService.GetAll();
        }

        private void LoadDoanhThu()
        {
            dtgvDoanhThu.DataSource = doanhThuService.GetAll();
        }

        private void LoadBanAn()
        {
            dtgvBanAn.DataSource = banAnService.GetAll();
        }

        private void LoadTaiKhoan()
        {
            dtgvTaiKhoan.DataSource = taiKhoanService.GetAll();
        }
        //===================MÓN ĂN=====================
        private void btnFoodThem_Click(object sender, EventArgs e)
        {
            try
            {
                var mon = new MonAn()
                {
                    ID = int.Parse(txbFoodID.Text),
                    TenMonAn = txbFoodTenMon.Text,
                    DonGia = nmFoodGia.Value,
                    HinhAnh = Path.GetFileName(ptbFoodHinhAnh.Tag?.ToString())
                };
                monAnService.Add(mon);
                MessageBox.Show("Thêm món thành công!");
                LoadFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnFoodSua_Click(object sender, EventArgs e)
        {
            try
            {
                var mon = new MonAn()
                {
                    ID = int.Parse(txbFoodID.Text),
                    TenMonAn = txbFoodTenMon.Text,
                    DonGia = nmFoodGia.Value,
                    HinhAnh = Path.GetFileName(ptbFoodHinhAnh.Tag?.ToString())
                };
                monAnService.Update(mon);
                MessageBox.Show("Cập nhật thành công!");
                LoadFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void bntFoodXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFoodID.Text)) return;
            int id = int.Parse(txbFoodID.Text);
            monAnService.Delete(id);
            MessageBox.Show("Đã xóa món ăn!");
            LoadFood();
        }

        private void btnFoodTim_Click(object sender, EventArgs e)
        {
            string keyword = txbFoodTim.Text.Trim();
            dtgvThucAn.DataSource = string.IsNullOrEmpty(keyword)
                ? monAnService.GetAll()
                : monAnService.Search(keyword);
        }

        private void ptbFoodHinhAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbFoodHinhAnh.Image = Image.FromFile(ofd.FileName);
                    ptbFoodHinhAnh.Tag = ofd.FileName;
                }
            }
        }
        //====================KHO HÀNG====================
        private void btnKhoThem_Click(object sender, EventArgs e)
        {
            var kho = new KhoHang()
            {
                TenNguyenLieu = txbKhotenNguyenLieu.Text,
                SoLuongTon = nmKhoSLT.Value,
                DoViTinh = txbKhoDVT.Text,
                GiaNhap = nmKhoGiaNhap.Value,
                NgayNhap = dtKhoNgayNhap.Value
            };
            khoHangService.Add(kho);
            LoadKho();
        }

        private void btnKhoXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbKhoID.Text);
            khoHangService.Delete(id);
            LoadKho();
        }

        private void btnKhoSua_Click(object sender, EventArgs e)
        {
            var kho = new KhoHang()
            {
                ID = int.Parse(txbKhoID.Text),
                TenNguyenLieu = txbKhotenNguyenLieu.Text,
                SoLuongTon = nmKhoSLT.Value,
                DoViTinh = txbKhoDVT.Text,
                GiaNhap = nmKhoGiaNhap.Value,
                NgayNhap = dtKhoNgayNhap.Value
            };
            khoHangService.Update(kho);
            LoadKho();
        }
        //====================BÀN ĂN====================
        private void btnBanAnThem_Click(object sender, EventArgs e)
        {
            var b = new BanAn()
            {
                ID = int.Parse(txbBanAnID.Text),
                TenBan = txbBanAnTenBan.Text,
                TinhTrang = txbBanAnTinhTrang.Text,
                SoCho = int.Parse(txbBanAnSoCho.Text)
            };
            banAnService.Add(b);
            LoadBanAn();
        }

        private void btnBanAnSua_Click(object sender, EventArgs e)
        {
            var b = new BanAn()
            {
                ID = int.Parse(txbBanAnID.Text),
                TenBan = txbBanAnTenBan.Text,
                TinhTrang = txbBanAnTinhTrang.Text,
                SoCho = int.Parse(txbBanAnSoCho.Text)
            };
            banAnService.Update(b);
            LoadBanAn();
        }

        private void btnBanAnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbBanAnID.Text);
            banAnService.Delete(id);
            LoadBanAn();
        }
        //====================DOANH THU====================
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            DateTime start = dtpFrom.Value.Date;
            DateTime end = dtpTo.Value.Date;

            var list = doanhThuService.GetByDateRange(start, end);
            dtgvDoanhThu.DataSource = list;

            decimal tong = doanhThuService.TongDoanhThu(start, end);
            MessageBox.Show($"Tổng doanh thu từ {start:dd/MM/yyyy} đến {end:dd/MM/yyyy}: {tong:N0} VNĐ",
                "Kết quả thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtgvThucAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvThucAn.Rows[e.RowIndex];
                txbFoodID.Text = row.Cells["ID"].Value.ToString();
                txbFoodTenMon.Text = row.Cells["TenMonAn"].Value.ToString();
                nmFoodGia.Value = Convert.ToDecimal(row.Cells["DonGia"].Value);

                // Nếu có hình ảnh, hiển thị
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    string path = Path.Combine(Application.StartupPath, "Image", fileName);
                    if (File.Exists(path))
                    {
                        ptbFoodHinhAnh.Image = Image.FromFile(path);
                        ptbFoodHinhAnh.Tag = path;
                    }
                    else
                    {
                        ptbFoodHinhAnh.Image = null;
                        ptbFoodHinhAnh.Tag = null;
                    }
                }
            }
        }

        private void dtgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKhoHang.Rows[e.RowIndex];
                txbKhoID.Text = row.Cells["ID"].Value.ToString();
                txbKhotenNguyenLieu.Text = row.Cells["TenNguyenLieu"].Value.ToString();
                nmKhoSLT.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value);
                txbKhoDVT.Text = row.Cells["DoViTinh"].Value.ToString();
                nmKhoGiaNhap.Value = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                dtKhoNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
            }
        }

        private void dtgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBanAn.Rows[e.RowIndex];
                txbBanAnID.Text = row.Cells["ID"].Value.ToString();
                txbBanAnTenBan.Text = row.Cells["TenBan"].Value.ToString();
                txbBanAnTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
                txbBanAnSoCho.Text = row.Cells["SoCho"].Value.ToString();
            }
        }

        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvTaiKhoan.Rows[e.RowIndex];
                txbTaiKhoanTenDangNhap.Text = row.Cells["ID"].Value.ToString();
                txbTaiKhoanTenHienThi.Text = row.Cells["TenDangNhap"].Value.ToString();
                txbTaiKhoanMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            }
        }

        
    }
}
