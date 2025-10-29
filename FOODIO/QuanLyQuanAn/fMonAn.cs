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
    public partial class fMonAn : Form
    {
        public fMonAn()
        {
            InitializeComponent();
        }
        private QLQAContext context = new QLQAContext();
        private DoanhThuService doanhthuservice = new DoanhThuService();
        private BanAnService bananservice = new BanAnService();
        private MonanService monanservice = new MonanService();
        private KhoHangService khohangservice = new KhoHangService();
        private TaiKhoanService taikhoanservice = new TaiKhoanService();
        private void LoadMonAn()
        {
            monanservice.LoadMonAnToGridView(dtgvMonAn);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            fDoanhThu f = new fDoanhThu();
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

        private void fMonAn_Load(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        private void dtgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvMonAn.Rows[e.RowIndex];
                var monan = monanservice.GetMonAnFromRow(row);
                if (monan != null)
                {
                    txbFoodID.Text = monan.ID.ToString();
                    txbTenMonAn.Text = monan.TenMonAn;
                    nmGia.Value = monan.DonGia;

                    ptbMonAn.Image = monanservice.GetHinhAnh(monan.HinhAnh);
                }
                

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var mon = new MonAn()
            {
                TenMonAn = txbTenMonAn.Text,
                DonGia = nmGia.Value,
                HinhAnh = Path.GetFileName(ptbMonAn.Tag?.ToString() ?? "")
            };
            if (monanservice.Add(mon))
            {
                MessageBox.Show("Thêm món mới thành công!","Thông Báo",MessageBoxButtons.OK);
            }
            LoadMonAn();
            txbFoodID.Clear();
            txbTenMonAn.Clear();
            nmGia.Value = 0;
            ptbMonAn.Image = null;
            ptbMonAn.Tag = null;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            string file = monanservice.ChonAnh(ptbMonAn);
            ptbMonAn.Tag = file;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mon = new MonAn
            {
                ID = int.Parse(txbFoodID.Text),
                TenMonAn = txbTenMonAn.Text,
                DonGia = nmGia.Value,
                HinhAnh = Path.GetFileName(ptbMonAn.Tag?.ToString() ?? "")
            };
            if(MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu món ăn này?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) {return;}
            if (monanservice.Update(mon))
                MessageBox.Show("Cập nhật thành công!");
            else
                MessageBox.Show("Không tìm thấy món ăn!");
            LoadMonAn();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbFoodID.Text, out int id))
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa món này?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (monanservice.Delete(id))
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Không tìm thấy món ăn!");
                LoadMonAn();
            }
        }

        private void btnFoodTim_Click(object sender, EventArgs e)
        {
            string keyword = txbFoodTim.Text.Trim();
            var list = monanservice.Search(keyword);
            dtgvMonAn.DataSource = list.Select(x => new
            {
                x.ID,
                x.TenMonAn,
                x.DonGia,
                x.HinhAnh
            }).ToList();
        }

        private void dtgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
