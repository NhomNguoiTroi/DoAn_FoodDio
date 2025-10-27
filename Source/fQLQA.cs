using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQUANAN.MOdel;
using System.Data.Entity;

namespace Source
{
    public partial class fQLQA : Form
    {
        public fQLQA()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void fQLQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo",
                                        MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTin f = new fThongTin();
            f.Show();

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        private CSDL db = new CSDL();
        private void fQLQA_Load(object sender, EventArgs e)
        {
            var menu = db.MonAns.ToList();
            cbMenu.DataSource = menu;
            cbMenu.DisplayMember = "TenMonAn";
            cbMenu.ValueMember = "ID";
            listViewBill.View = View.Details;
            listViewBill.Columns.Add("Tên món", 150);
            listViewBill.Columns.Add("Số lượng", 80);
            listViewBill.Columns.Add("Đơn giá", 100); 
            listViewBill.Columns.Add("Thành tiền", 120);

            nmSoLuong.Minimum = 1;
            nmSoLuong.Maximum = 100;
            nmSoLuong.Value = 1;
            LoadTable();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (cbMenu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi thêm!");
                return;
            }

            var selectedFood = (MonAn)cbMenu.SelectedItem;
            int soLuong = (int)nmSoLuong.Value;
            bool exists = false;

            // Kiểm tra nếu món đã tồn tại trong ListView thì cộng dồn
            foreach (ListViewItem item in listViewBill.Items)
            {
                if (item.Text == selectedFood.TenMonAn)
                {
                    int oldSL = int.Parse(item.SubItems[1].Text); // cột 1 = số lượng
                    int newSL = oldSL + soLuong;

                    decimal donGia = decimal.Parse(item.SubItems[2].Text, System.Globalization.NumberStyles.Any);
                    decimal thanhTien = newSL * donGia;

                    item.SubItems[1].Text = newSL.ToString();
                    item.SubItems[3].Text = thanhTien.ToString("N0");
                    exists = true;
                    break;
                }
            }

            // Nếu chưa có món này thì thêm mới
            if (!exists)
            {
                ListViewItem item = new ListViewItem(selectedFood.TenMonAn);
                item.SubItems.Add(soLuong.ToString()); // cột 1 = số lượng
                item.SubItems.Add(selectedFood.DonGia.ToString("N0")); // cột 2 = đơn giá
                item.SubItems.Add((selectedFood.DonGia * soLuong).ToString("N0")); // cột 3 = thành tiền
                listViewBill.Items.Add(item);
            }

            // Reset số lượng về 1 sau khi thêm
            nmSoLuong.Value = 1;
            TinhTongTien();

        }
        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (ListViewItem item in listViewBill.Items)
            {
                // bỏ qua dòng tổng cộng nếu có
                if (item.Text == "Tổng cộng:") continue;

                if (decimal.TryParse(item.SubItems[3].Text, System.Globalization.NumberStyles.Any, null, out decimal tien))
                {
                    tong += tien;
                }
            }
            txbTongTien.Text = $"{tong:N0} VNĐ";
        }
        private void LoadTable()
        {
            flpTable.Controls.Clear(); // Xóa các button cũ

            var listTable = db.BanAns.ToList();

            foreach (var table in listTable)
            {
                Button btn = new Button()
                {
                    Width = 90,
                    Height = 90,
                    Text = $"{table.TenBan}\n{table.TinhTrang}",
                    Tag = table, // lưu tạm dữ liệu bàn để dùng khi click
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = table.TinhTrang == "Trống" ? Color.LightGreen : Color.LightCoral
                };

                btn.Click += Btn_Click; // Gắn sự kiện click cho mỗi bàn
                flpTable.Controls.Add(btn);
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            BanAn table = btn.Tag as BanAn;

            MessageBox.Show($"Bàn: {table.TenBan}\nTình trạng: {table.TinhTrang}\nSố chỗ: {table.SoCho}");
            LoadBill(table.ID);

        }

        private void LoadBill(int idBan)
        {
            listViewBill.Items.Clear();

            using (var db = new CSDL())
            {
                // Lấy hóa đơn chưa thanh toán của bàn
                var hoadon = db.HoaDons
                    .FirstOrDefault(h => h.IDBanAn == idBan && h.TinhTrang == 1);

                if (hoadon == null)
                {
                    MessageBox.Show("Bàn này hiện chưa có hóa đơn nào!");
                    return;
                }

                // Hiển thị thông tin bill
                this.Text = $"Hóa đơn bàn: {hoadon.BanAn.TenBan}  |  ID HĐ: {hoadon.ID}";

                // Lấy chi tiết hóa đơn
                var chitiet = db.CTHoaDons
                    .Where(ct => ct.IDHoaDon == hoadon.ID)
                    .Include(ct => ct.MonAn)
                    .ToList();

                decimal tongTien = 0;

                foreach (var item in chitiet)
                {
                    decimal thanhTien = item.SoLuong * item.MonAn.DonGia;
                    tongTien += thanhTien;

                    ListViewItem lvi = new ListViewItem(item.MonAn.TenMonAn);
                    lvi.SubItems.Add(item.SoLuong.ToString());
                    lvi.SubItems.Add(item.MonAn.DonGia.ToString("N0"));
                    lvi.SubItems.Add(thanhTien.ToString("N0"));

                    listViewBill.Items.Add(lvi);
                }

                // Có thể hiển thị tổng tiền
                ListViewItem total = new ListViewItem();
                total.SubItems.Add("");
                total.SubItems.Add("");
                total.SubItems.Add(tongTien.ToString("N0"));
                listViewBill.Items.Add(total);
                TinhTongTien();
            }
        }


    }
}
