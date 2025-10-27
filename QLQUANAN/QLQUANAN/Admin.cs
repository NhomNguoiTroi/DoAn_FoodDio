using QLQUANAN.MoDel;
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
            var list = db.MonAns.Select( x=> new
            {
                x.ID,
                x.TenMonAn,
                x.DonGia,
                x.HinhAnh
            }).ToList();
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
        private void LoadKho()
        {
            var listKho = db.KhoHangs.Select(x => new
            {
                x.ID,
                x.TenNguyenLieu,
                x.SoLuongTon,
                x.DonViTinh,
                x.GiaNhap
                ,
                x.NgayNhap
            }).ToList();
            dtgvKhoHang.DataSource = listKho;

        }
       

        private void fAdmin_Load(object sender, EventArgs e)
        {
            LoadFood();
            LoadKho();
            var listDT = db.DoanhThus.Select(x => new
            {   
                x.Ngay,
                x.TongSoHoaDon,
                x.TongDoanhThu,
                x.GhiChu
            }).ToList();
            dtgvDoanhThu.DataSource = listDT;
            
            var listAccount = db.TaiKhoans.Select(x => new {
            x.ID,
            x.TenDangNhap, 
            x.TenHienThi,
            x.MatKhau
            }).ToList();
            dtgvTaiKhoan.DataSource = listAccount;
            
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

            var listDt = db.DoanhThus.Where(x => x.Ngay>= Ngaybd && x.Ngay <= Ngaykt).Select(x => new
            {
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

        private void dtgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                 DataGridViewRow row = dtgvKhoHang.Rows[e.RowIndex];
                txbKhoID.Text = row.Cells["ID"].Value.ToString();
                txbKhotenNguyenLieu.Text = row.Cells["TenNguyenLieu"].Value.ToString();
                nmKhoSLT.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value.ToString());
                txbKhoDVT.Text = row.Cells["DonViTinh"].Value.ToString();
                nmKhoGiaNhap.Value = Convert.ToDecimal( row.Cells["GiaNhap"].Value.ToString());
                dtKhoNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value.ToString());
            }
        }
        private void dtgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {   if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBanAn.Rows[e.RowIndex];
                txbBanAnID.Text = row.Cells["ID"].Value.ToString();
                txbBanAnTenBan.Text = row.Cells["TenBan"].Value.ToString();
                txbBanAnSoCho.Text = row.Cells["SoCho"].Value.ToString();
                txbBanAnTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();   
            }

        }

        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvTaiKhoan.Rows[e.RowIndex];
                txbTaiKhoanTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txbTaiKhoanTenHienThi.Text = row.Cells["TenHienThi"].Value.ToString();
                txbTaiKhoanMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
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

        private void btnFoodSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txbFoodID.Text, out int id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                var check = db.MonAns.FirstOrDefault(x => x.ID == id);
                if (check == null)
                {
                    MessageBox.Show("❌ Không thấy món cần sửa");
                    return;
                }

                check.TenMonAn = txbFoodTenMon.Text.Trim();
                check.DonGia = (decimal)nmFoodGia.Value;

                // Xử lý hình ảnh an toàn
                if (ptbFoodHinhAnh.Tag != null)
                {
                    check.HinhAnh = Path.GetFileName(ptbFoodHinhAnh.Tag.ToString());
                }

                db.SaveChanges();
                MessageBox.Show("✅ Sửa thành công!");
                LoadFood();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

/*
        private void btnKhoThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ID
                if (!int.TryParse(txbKhoID.Text, out int id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                // Kiểm tra trùng
                var check = db.KhoHangs.FirstOrDefault(x => x.ID == id);
                if (check != null)
                {
                    MessageBox.Show("❌ ID đã tồn tại. Vui lòng nhập ID khác!");
                    return;
                }

                KhoHang kho = new KhoHang()
                {
                    ID = id,
                    TenNguyenLieu = txbKhotenNguyenLieu.Text.Trim(),
                    SoLuongTon = int.Parse(txbKhoSLT.Text),
                    DonViTinh = txbKhoDVT.Text.Trim(),
                    GiaNhap = (decimal)nmKhoGiaNhap.Value,
                    NgayNhap = dtKhoNgayNhap.Value
                };

                db.KhoHangs.Add(kho);
                db.SaveChanges();
                MessageBox.Show("✅ Thêm thành công!");
                LoadKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        */
         private void btnKhoThem_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txbKhotenNguyenLieu.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nguyên liệu!");
                    txbKhotenNguyenLieu.Focus();
                    return;
                }

                // Tạo đối tượng mới
                KhoHang kho = new KhoHang()
                {
                  //  ID = txbKhoID.Text.Trim() == "" ? 0 : int.Parse(txbKhoID.Text.Trim()),
                    TenNguyenLieu = txbKhotenNguyenLieu.Text.Trim(),
                    SoLuongTon = nmKhoSLT.Value,
                    DonViTinh = txbKhoDVT.Text.Trim(),
                    GiaNhap = nmKhoGiaNhap.Value,
                    NgayNhap = dtKhoNgayNhap.Value
                };

                db.KhoHangs.Add(kho);
                db.SaveChanges();
                MessageBox.Show("Thêm nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnKhoXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txbKhoID.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kho = db.KhoHangs.FirstOrDefault(x => x.ID == id);
                if (kho == null)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var r = MessageBox.Show($"Bạn có chắc muốn xóa nguyên liệu '{kho.TenNguyenLieu}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    db.KhoHangs.Remove(kho);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKho();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txbKhoID.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kho = db.KhoHangs.FirstOrDefault(x => x.ID == id);
                if (kho == null)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật
                kho.TenNguyenLieu = txbKhotenNguyenLieu.Text.Trim();
                kho.SoLuongTon = nmKhoSLT.Value;
                kho.DonViTinh = txbKhoDVT.Text.Trim();
                kho.GiaNhap = nmKhoGiaNhap.Value;
                kho.NgayNhap = dtKhoNgayNhap.Value;

                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBanAnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ID
                if (!int.TryParse(txbBanAnID.Text, out int id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }
                // Kiểm tra trùng
                var check = db.BanAns.FirstOrDefault(x => x.ID == id);
                if (check != null)
                {
                    MessageBox.Show("❌ ID đã tồn tại. Vui lòng nhập ID khác!");
                    return;
                }
                BanAn banAn = new BanAn()
                {
                    ID = id,
                    TenBan = txbBanAnTenBan.Text.Trim(),
                    SoCho = int.Parse(txbBanAnSoCho.Text),
                    TinhTrang = txbBanAnTinhTrang.Text.Trim()
                };
                db.BanAns.Add(banAn);
                db.SaveChanges();
                MessageBox.Show("✅ Thêm thành công!");
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnBanAnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(!int.TryParse(txbBanAnID.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var banAn = db.BanAns.FirstOrDefault(x => x.ID == id);  
                if(banAn == null)
                {
                    MessageBox.Show("Không tìm thấy bàn ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var r = MessageBox.Show($"Bạn có chắc muốn xóa bàn ăn '{banAn.TenBan}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r == DialogResult.Yes)
                {
                    db.BanAns.Remove(banAn);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBanAnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txbBanAnID.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var banAn = db.BanAns.FirstOrDefault(x => x.ID == id);
                if (banAn == null)
                {
                    MessageBox.Show("Không tìm thấy bàn ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Cập nhật
                banAn.TenBan = txbBanAnTenBan.Text.Trim();
                banAn.SoCho = int.Parse(txbBanAnSoCho.Text);
                banAn.TinhTrang = txbBanAnTinhTrang.Text.Trim();
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvThucAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFoodTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFoodTim.Text))
            {
                LoadFood();
                return;
            }
            var list = db.MonAns.Where(x => x.TenMonAn.Contains(txbFoodTim.Text)).Select(x => new
            {
                x.ID,
                x.TenMonAn,
                x.DonGia,
                x.HinhAnh
            }).ToList();
            dtgvThucAn.DataSource = list;

        }
    }
}
  
