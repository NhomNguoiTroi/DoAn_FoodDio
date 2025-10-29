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
    public partial class fFOODIO_QLQA : Form
    {
        private string username;
        private TaiKhoan currentUser;
        public fFOODIO_QLQA(TaiKhoan user)
        {
            InitializeComponent();
            currentUser = user;
        }
        private readonly BanAnService banAnService = new BanAnService();
        private readonly MonanService monAnService = new MonanService();
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly TaiKhoanService taikhoanservice = new TaiKhoanService();
        private int currentTableId = -1;
        private List<int> selectedTableIds = new List<int>();
      

        private void fFOODIO_QLQA_Load(object sender, EventArgs e)
        {
            LoadMenu();
            LoadTable();    
        }
        private void LoadMenu()
        {
            cbMenu.DataSource = monAnService.GetAll();
            cbMenu.DisplayMember = "TenMonAn";
            cbMenu.ValueMember = "ID";
        }
        /*
        private void LoadTable()
        {
            flpnlBanAn.Controls.Clear();
            var listTable = banAnService.GetAll();

            foreach (var table in listTable)
            {
                Button btn = new Button()
                {
                    Width = 90,
                    Height = 90,
                    Text = $"{table.TenBan}\n{table.TinhTrang}",
                    Tag = table,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = table.TinhTrang == "Trống" ? Color.LightGreen :
                                (selectedTableIds.Contains(table.ID) ? Color.Yellow : Color.LightCoral)
                };
                btn.Click += Btn_Click;
                flpnlBanAn.Controls.Add(btn);
            }
        }*/
        private void LoadTable()
        {
            flpnlBanAn.Controls.Clear();
            var listTable = banAnService.GetAll();

            foreach (var table in listTable)
            {
                var hoaDon = hoaDonService.GetHoaDonChuaThanhToan(table.ID);
                string tinhTrang = (hoaDon != null) ? "Có khách" : "Trống";

                Button btn = new Button()
                {
                    Width = 90,
                    Height = 90,
                    Text = $"{table.TenBan}\n{tinhTrang}",
                    Tag = table,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = tinhTrang == "Trống" ? Color.LightGreen :
                                (selectedTableIds.Contains(table.ID) ? Color.Yellow : Color.LightCoral)
                };
                btn.Click += Btn_Click;
                flpnlBanAn.Controls.Add(btn);
            }
        }

       /* private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var ban = btn.Tag as BanAn;

            if (selectedTableIds.Contains(ban.ID))
            {
                selectedTableIds.Remove(ban.ID);
                btn.BackColor = ban.TinhTrang == "Trống" ? Color.LightGreen : Color.LightCoral;
            }
            else
            {
                selectedTableIds.Add(ban.ID);
                btn.BackColor = Color.Yellow;
            }

            if (selectedTableIds.Count == 1)
            {
                currentTableId = ban.ID;
                LoadBill(ban.ID);
            }
            else
            {
                listView1.Items.Clear();
                txbTongTien.Clear();
            }

        }
        */
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            var mon = (MonAn)cbMenu.SelectedItem;
            int soLuong = (int)nmSLMonAn.Value;

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }

            var hd = hoaDonService.GetHoaDonChuaThanhToan(currentTableId);

            if (hd == null)
            {
                hd = hoaDonService.TaoHoaDonMoi(currentTableId);
                banAnService.UpdateTinhTrang(currentTableId, "Có khách");
            }

            hoaDonService.ThemMonVaoHoaDon(hd.ID, mon.ID, soLuong, mon.DonGia);
            CapNhatTongTienCacBan(selectedTableIds);
            LoadBill(currentTableId);
            LoadTable();
            //CapNhatTongTien(hd.ID);

            foreach (Control ctrl in flpnlBanAn.Controls)
            {
                if (ctrl is Button btn && btn.Tag is BanAn ban && ban.ID == currentTableId)
                {
                    btn.BackColor = Color.LightCoral;
                    btn.Text = $"{ban.TenBan}\nCó khách";
                }
            }
            nmSLMonAn.Value = 1;
        }

       
       
        private void CapNhatTongTien(int idHoaDon)
        {
            var chitiet = hoaDonService.GetChiTietHoaDon(idHoaDon);
            decimal tongtien = chitiet.Sum(ct => ct.SoLuong * ct.DonGia);
            txbTongTien.Text = tongtien.ToString("N0");
        }
        private void CapNhatTongTienCacBan(List<int> tableIds)
        {
            decimal tongTatCa = 0;
            foreach (int idBan in tableIds)
            {
                var hd = hoaDonService.GetHoaDonChuaThanhToan(idBan);
                if (hd != null)
                {
                    var chiTiet = hoaDonService.GetChiTietHoaDon(hd.ID);
                    tongTatCa += chiTiet.Sum(ct => ct.ThanhTien ?? 0);
                }
            }
            txbTongTien.Text = tongTatCa.ToString("N0");
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fFoodio f = new fFoodio();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            using (var f = new fThongTin(currentUser)) 
            {
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (currentTableId != -1)
                LoadBill(currentTableId);
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedTableIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 bàn để thanh toán!");
                return;
            }

            if (txbTongTien.Text == "0 VNĐ")
            {
                MessageBox.Show("Bàn này chưa sử dụng gì!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }

            decimal tongTienChung = 0;
            decimal giamGiaPhanTram = (decimal)numericUpDown2.Value;

            foreach (int tableID in selectedTableIds)
            {
                var hd = hoaDonService.GetHoaDonChuaThanhToan(tableID);
                if (hd != null)
                {
                    var chitiet = hoaDonService.GetChiTietHoaDon(hd.ID);
                    decimal tongtienban = chitiet.Sum(ct => ct.SoLuong * ct.DonGia);
                    decimal tienSauGiam = tongtienban - (tongtienban * giamGiaPhanTram / 100);

                    tongTienChung += tienSauGiam;

                    hoaDonService.ThanhToan(hd.ID, tongtienban, tongtienban * giamGiaPhanTram / 100);
                    banAnService.UpdateTinhTrang(tableID, "Trống");
                }
            }

            MessageBox.Show($"Đã thanh toán {selectedTableIds.Count} bàn.\nTổng cộng (sau giảm): {tongTienChung:N0} VNĐ");

            selectedTableIds.Clear();
            LoadTable();
            listView1.Items.Clear();
            txbTongTien.Clear();
        }
        /*
        private void LoadBill(int idBan)
        {
            listView1.Items.Clear();

            var hoaDon = hoaDonService.GetHoaDonChuaThanhToan(idBan) ?? hoaDonService.TaoHoaDonMoi(idBan);
            var chiTiet = hoaDonService.GetChiTietHoaDon(hoaDon.ID);

            decimal tong = 0;

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Tên món", 150);
            listView1.Columns.Add("Số lượng", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Thành tiền (VNĐ)", 120, HorizontalAlignment.Right);

            foreach (var ct in chiTiet)
            {
                var mon = monAnService.GetById(ct.IDMonAn);
                decimal thanhTien = ct.SoLuong * ct.DonGia;
                tong += thanhTien;

                ListViewItem item = new ListViewItem(mon.TenMonAn);
                item.SubItems.Add(ct.SoLuong.ToString());
                item.SubItems.Add(thanhTien.ToString("N0"));
                listView1.Items.Add(item);
            }

            decimal giamGiaPhanTram = (decimal)numericUpDown2.Value;
            decimal tienSauGiam = tong - (tong * giamGiaPhanTram / 100);

            txbTongTien.Text = $"{tienSauGiam:N0} VNĐ";
        }
        */
        private void LoadBill(int idBan)
        {
            listView1.Items.Clear();

            var hoaDon = hoaDonService.GetHoaDonChuaThanhToan(idBan) ?? hoaDonService.TaoHoaDonMoi(idBan);
            var chiTiet = hoaDonService.GetChiTietHoaDon(hoaDon.ID);

            decimal tong = 0;

            // Cấu hình hiển thị ListView
            listView1.View = View.Details;
            listView1.Columns.Clear();

            // 👉 Thêm cột mới "Đơn giá"
            listView1.Columns.Add("Tên món", 150);
            listView1.Columns.Add("Đơn giá (VNĐ)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Số lượng", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Thành tiền (VNĐ)", 120, HorizontalAlignment.Right);

            foreach (var ct in chiTiet)
            {
                var mon = monAnService.GetById(ct.IDMonAn);
                decimal thanhTien = ct.SoLuong * ct.DonGia;
                tong += thanhTien;

                // Tạo item cho từng dòng
                ListViewItem item = new ListViewItem(mon.TenMonAn);
                item.SubItems.Add(ct.DonGia.ToString("N0"));  // ✅ Thêm đơn giá
                item.SubItems.Add(ct.SoLuong.ToString());
                item.SubItems.Add(thanhTien.ToString("N0"));

                listView1.Items.Add(item);
            }

            decimal giamGiaPhanTram = (decimal)numericUpDown2.Value;
            decimal tienSauGiam = tong - (tong * giamGiaPhanTram / 100);

            txbTongTien.Text = $"{tienSauGiam:N0} VNĐ";
        }

        private void menuLamMoi_Click(object sender, EventArgs e)
        {
            fFOODIO_QLQA_Load(sender, e);
        }
        private void LoadBillsForSelectedTables()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Tên món", 150);
            listView1.Columns.Add("Đơn giá (VNĐ)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Số lượng", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Thành tiền (VNĐ)", 120, HorizontalAlignment.Right);

            // ✅ Dictionary để gộp món theo ID
            var allItems = new Dictionary<int, (string TenMon, decimal DonGia, int SoLuong)>();

            foreach (int tableId in selectedTableIds)
            {
                var hoaDon = hoaDonService.GetHoaDonChuaThanhToan(tableId);
                if (hoaDon == null) continue;

                var chiTiet = hoaDonService.GetChiTietHoaDon(hoaDon.ID);
                foreach (var ct in chiTiet)
                {
                    var mon = monAnService.GetById(ct.IDMonAn);
                    if (allItems.ContainsKey(ct.IDMonAn))
                    {
                        var old = allItems[ct.IDMonAn];
                        allItems[ct.IDMonAn] = (mon.TenMonAn, ct.DonGia, old.SoLuong + ct.SoLuong);
                    }
                    else
                    {
                        allItems.Add(ct.IDMonAn, (mon.TenMonAn, ct.DonGia, ct.SoLuong));
                    }
                }
            }

            decimal tong = 0;

            // ✅ Đổ dữ liệu ra ListView
            foreach (var item in allItems.Values)
            {
                decimal thanhTien = item.SoLuong * item.DonGia;
                tong += thanhTien;

                ListViewItem lvItem = new ListViewItem(item.TenMon);
                lvItem.SubItems.Add(item.DonGia.ToString("N0"));
                lvItem.SubItems.Add(item.SoLuong.ToString());
                lvItem.SubItems.Add(thanhTien.ToString("N0"));
                listView1.Items.Add(lvItem);
            }

            decimal giamGiaPhanTram = (decimal)numericUpDown2.Value;
            decimal tienSauGiam = tong - (tong * giamGiaPhanTram / 100);
            txbTongTien.Text = $"{tienSauGiam:N0} VNĐ";
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var ban = btn.Tag as BanAn;

            if (selectedTableIds.Contains(ban.ID))
            {
                selectedTableIds.Remove(ban.ID);
                btn.BackColor = ban.TinhTrang == "Trống" ? Color.LightGreen : Color.LightCoral;
            }
            else
            {
                selectedTableIds.Add(ban.ID);
                btn.BackColor = Color.Yellow;
            }

            if (selectedTableIds.Count == 1)
            {
                currentTableId = ban.ID;
            }
            else
            {
                currentTableId = -1;
            }

            // 👉 Gọi hàm hiển thị tổng món của tất cả bàn đang chọn
            LoadBillsForSelectedTables();
            fFOODIO_QLQA_Load(sender, e);
        }

    }
}
