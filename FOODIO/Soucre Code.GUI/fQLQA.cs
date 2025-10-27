using Source_Code.BUS;
using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Soucre_Code.GUI
{
    public partial class fQLQA : Form
    {
        private readonly BanAnService banAnService = new BanAnService();
        private readonly MonAnService monAnService = new MonAnService();
        private readonly HoaDonService hoaDonService = new HoaDonService();

        private int currentTableId = -1;
        private string username;
        public fQLQA(string tenDangNhap = "")
        {
            InitializeComponent();
            username = tenDangNhap;
            Text = $"Quản Lý Quán Ăn - Xin chào {username}";
        }

        private void fQLQA_Load(object sender, EventArgs e)
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

        private void LoadTable()
        {
            flpTable.Controls.Clear();
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
                    BackColor = table.TinhTrang == "Trống" ? Color.LightGreen : Color.LightCoral
                };
                btn.Click += Btn_Click;
                flpTable.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var ban = btn.Tag as BanAn;
            currentTableId = ban.ID;
            LoadBill(ban.ID);
        }
        private void LoadBill(int idBan)
        {
            listViewBill.Items.Clear();

            var hoaDon = hoaDonService.GetHoaDonChuaThanhToan(idBan) ?? hoaDonService.TaoHoaDonMoi(idBan);
            var chiTiet = hoaDonService.GetChiTietHoaDon(hoaDon.ID);

            decimal tong = 0;
            foreach (var ct in chiTiet)
            {
                var mon = monAnService.GetById(ct.IDMonAn);
                decimal thanhTien = ct.SoLuong * ct.DonGia;
                tong += thanhTien;

                ListViewItem item = new ListViewItem(mon.TenMonAn);
                item.SubItems.Add(ct.SoLuong.ToString());
                item.SubItems.Add(ct.DonGia.ToString("N0"));
                item.SubItems.Add(thanhTien.ToString("N0"));
                listViewBill.Items.Add(item);
            }

            txbTongTien.Text = $"{tong:N0} VNĐ";
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
                return;
            }

            var mon = (MonAn)cbMenu.SelectedItem;
            int soLuong = (int)nmSoLuong.Value;

            var hd = hoaDonService.GetHoaDonChuaThanhToan(currentTableId) ?? hoaDonService.TaoHoaDonMoi(currentTableId);
            hoaDonService.ThemMonVaoHoaDon(hd.ID, mon.ID, soLuong, mon.DonGia);
            LoadBill(currentTableId);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn để thanh toán!");
                return;
            }

            if (!decimal.TryParse(txbTongTien.Text.Replace("VNĐ", "").Trim(), out decimal tongTien))
                tongTien = 0;

            var hd = hoaDonService.GetHoaDonChuaThanhToan(currentTableId);
            if (hd != null)
            {
                hoaDonService.ThanhToan(hd.ID, tongTien);
                banAnService.UpdateTinhTrang(currentTableId, "Trống");
            }

            MessageBox.Show("Thanh toán thành công!");
            LoadTable();
            listViewBill.Items.Clear();
            txbTongTien.Clear();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fAdmin().ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fThongTin(username).ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
