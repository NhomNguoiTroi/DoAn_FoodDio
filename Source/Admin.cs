using Source.MOdel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQUANAN
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void LoadAccount()
        {
            SqlConnection connection = new SqlConnection();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTaiKhoanDatLaiMK_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan f = new fThongTinTaiKhoan();
            f.ShowDialog();
        }

        private CSDL db = new CSDL();
        private void LoadFood()
        {
            var list = db.MonAns.ToList();
            dtgvThucAn.DataSource = list;

            // Ẩn cột đường dẫn
            if (dtgvThucAn.Columns.Contains("HinhAnh"))
                dtgvThucAn.Columns["HinhAnh"].Visible = false;

            // Thêm cột ảnh thật
            if (!dtgvThucAn.Columns.Contains("HinhAnhThuc"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "HinhAnhThuc";
                imgCol.HeaderText = "Hình ảnh món ăn";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dtgvThucAn.Columns.Add(imgCol);
            }

            // Load ảnh
            foreach (DataGridViewRow row in dtgvThucAn.Rows)
            {
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                string path = Path.Combine(Application.StartupPath, "Image", fileName ?? "");
                if (File.Exists(path))
                {
                    using (var imgTemp = Image.FromFile(path))
                    {
                        row.Cells["HinhAnhThuc"].Value = new Bitmap(imgTemp);
                    }
                }
            }
        }

       

        private void fAdmin_Load(object sender, EventArgs e)
        {
            LoadFood();

            var listDT = db.DoanhThus.Select(x => new
            {
                x.ID,
                x.Ngay,
                x.TongSoHoaDon,
                x.TongDoanhThu,
                x.GhiChu
            }).ToList();
            dtgvDoanhThu.DataSource = listDT;
            
            var listAccount = db.TaiKhoans.Select(x => new {
            x.ID,
            x.TenNguoiDung, 
            x.TenHienThi,
            x.MatKhau
            }).ToList();
            dtgvTaiKhoan.DataSource = listAccount;
            var listKho = db.KhoHangs.Select(x => new
            {
                x.ID,
                x.TenNguyenLieu,
                x.SoLuongTon,
                x.DoViTinh,
                x.GiaNhap
                , x.NgayNhap
            }).ToList();
            dtgvKhoHang.DataSource = listKho;
            var listTable = db.BanAns.Select(
                x => new
                {
                    x.ID,
                    x.TenBan,
                    x.TinhTrang,
                    x.SoCho
                }).ToList();
            dtgvBanAn.DataSource = listTable;

        }

        private void btnDoanhThuThongKe_Click(object sender, EventArgs e)
        {
            DateTime Ngaybd = dtpFrom.Value.Date;
            DateTime Ngaykt = dtpTo.Value.Date;

            var listDt = db.DoanhThus.Where(x => x.Ngay >= Ngaybd && x.Ngay <= Ngaykt).Select(x => new
            {
                x.ID,
                x.Ngay,
                x.TongSoHoaDon,
                x.TongDoanhThu,
                x.GhiChu
            }
                ).ToList();
            dtgvDoanhThu.DataSource = listDt;
        }

       

        private void dtgvThucAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvThucAn.Rows[e.RowIndex];
                txbFoodID.Text = row.Cells["ID"].Value.ToString();
                txbFoodTenMon.Text = row.Cells["TenMonAn"].Value.ToString();
                nmFoodGia.Value = Convert.ToDecimal(row.Cells["DonGia"].Value.ToString());

                string fileName = row.Cells["HinhAnh"].Value.ToString();
                string path = Path.Combine(Application.StartupPath, "Image", fileName);

                if (File.Exists(path))
                    ptbFoodHinhAnh.Image = Image.FromFile(path);
                else
                    ptbFoodHinhAnh.Image = null;    

            }
        }

        private void btnFoodThem_Click(object sender, EventArgs e)
        {
           
            try
            {
                int id = int.Parse(txbFoodID.Text);

                // Kiểm tra trùng ID
                var check = db.MonAns.FirstOrDefault(x => x.ID == id);
                if (check != null)
                {
                    MessageBox.Show("❌ ID đã tồn tại. Vui lòng nhập ID khác!");
                    return;
                }

                // Tạo món ăn mới
                MonAn mon = new MonAn()
                {
                    ID = id,
                    TenMonAn = txbFoodTenMon.Text,
                    DonGia = nmFoodGia.Value,
                    HinhAnh = Path.GetFileName(ptbFoodHinhAnh.Tag?.ToString()) // lưu tên file
                };

                db.MonAns.Add(mon);
                db.SaveChanges();
                MessageBox.Show("✅ Thêm món ăn thành công!");
                LoadFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ptbFoodHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg;*.png)|*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbFoodHinhAnh.Image = Image.FromFile(ofd.FileName);
                    ptbFoodHinhAnh.Tag = ofd.FileName; // lưu tạm đường dẫn để thêm vào DB
                }
            }

        }

        private void bntFoodXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFoodID.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!");
                return;
            }

            int id = int.Parse(txbFoodID.Text);

            var monAn = db.MonAns.Find(id);
            if (monAn != null)
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa món '{monAn.TenMonAn}' không?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    db.MonAns.Remove(monAn);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LoadFood(); // Load lại bảng
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy món ăn cần xóa!");
            }
            txbFoodTenMon.Clear();
            txbFoodID.Clear();
            nmFoodGia.Value = 0;    
            ptbFoodHinhAnh.Image = null;
        }

    }
}
  
