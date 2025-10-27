using QLQUANAN.MoDel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQUANAN
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

            // Nếu chưa có món này thì
            if (!exists)
            {
                ListViewItem item = new ListViewItem(selectedFood.TenMonAn);
                item.SubItems.Add(soLuong.ToString()); // cột 1 = số lượng
                item.SubItems.Add(selectedFood.DonGia.ToString("N0")); // cột 2 = đơn giá
                item.SubItems.Add((selectedFood.DonGia * soLuong).ToString("N0")); // cột 3 = thành tiền
                listViewBill.Items.Add(item);
            }
            using (var db = new CSDL())
            {
                    CTHoaDon ct = new CTHoaDon()
                {
                    IDHoaDon = db.HoaDons.Max(h => h.ID), // Lấy ID hóa đơn mới nhất
                    IDMonAn = selectedFood.ID,
                        SoLuong = soLuong,
                    DonGia = selectedFood.DonGia,
                    ThanhTien = selectedFood.DonGia * soLuong,
                  
                };

                db.CTHoaDons.Add(ct);
                db.SaveChanges();
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
                // 1. Lấy hóa đơn CHƯA THANH TOÁN (TinhTrang = 1) của bàn
                var hoadon = db.HoaDons
                    .Include(h => h.BanAn) // load luôn BanAn để tránh null
                    .FirstOrDefault(h => h.IDBanAn == idBan && h.TinhTrang == 1);

                // 2. Nếu CHƯA có hóa đơn → tạo mới
                if (hoadon == null)
                {
                    hoadon = new HoaDon
                    {
                        IDBanAn = idBan,
                        NgayLap = DateTime.Now,
                        TinhTrang = 1 // 1 = Chưa thanh toán
                    };

                    db.HoaDons.Add(hoadon);

                    // Đổi trạng thái bàn sang "Có khách"
                    var ban = db.BanAns.Find(idBan);
                    if (ban != null)
                    {
                        ban.TinhTrang = "Có khách";
                    }

                    db.SaveChanges();

                    // ⚠ Sau khi SaveChanges(), cần lấy lại hóa đơn kèm BanAn để tránh null
                    hoadon = db.HoaDons
                        .Include(h => h.BanAn)
                        .FirstOrDefault(h => h.ID == hoadon.ID);
                }

                // ✅ Bây giờ hoadon chắc chắn tồn tại và có BanAn
                this.Text = $"Hóa đơn bàn: {hoadon.BanAn.TenBan} | ID HĐ: {hoadon.ID}";

                // 3. Lấy chi tiết hóa đơn
                var chitiet = db.CTHoaDons
                    .Where(ct => ct.IDHoaDon == hoadon.ID)
                    .Include(ct => ct.MonAn)
                    .ToList();

                decimal tongTien = 0;

                // 4. Hiển thị từng món trong ListView
                foreach (var item in chitiet)
                {
                    decimal thanhTien = item.SoLuong * item.MonAn.DonGia;
                    tongTien += thanhTien;

                    ListViewItem lvi = new ListViewItem(item.MonAn.TenMonAn);
                    lvi.SubItems.Add(item.SoLuong.ToString());             // Số lượng
                    lvi.SubItems.Add(item.MonAn.DonGia.ToString("N0"));    // Đơn giá
                    lvi.SubItems.Add(thanhTien.ToString("N0"));            // Thành tiền

                    listViewBill.Items.Add(lvi);
                }

                // 5. Hiển thị dòng tổng cộng (nếu muốn)
                ListViewItem total = new ListViewItem();
                total.SubItems.Add("");
                total.SubItems.Add("");
                total.SubItems.Add(tongTien.ToString("N0"));
                listViewBill.Items.Add(total);

                // 6. Cập nhật textbox tổng tiền
                TinhTongTien();
            }
        }

        /*
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
                            hoadon = new HoaDon
                            {
                                IDBanAn = idBan,
                                NgayLap = DateTime.Now,
                                TinhTrang = 1 // Chưa thanh toán
                            };
                            db.HoaDons.Add(hoadon);
                            var ban = db.BanAns.Find(idBan);
                            ban.TinhTrang = "Có khách";
                            db.SaveChanges();
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


                        ListViewItem total = new ListViewItem();
                        total.SubItems.Add("");
                        total.SubItems.Add("");
                        total.SubItems.Add(tongTien.ToString("N0"));
                        listViewBill.Items.Add(total);
                        TinhTongTien();
                    }
                }
                */
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewBill.Items.Count == 0)
                {
                    MessageBox.Show("Chưa có món nào để thanh toán!");
                    return;
                }

                using (var db = new CSDL())
                {
                    // 1. Tạo hóa đơn
                    HoaDon hd = new HoaDon
                    {
                        NgayLap = DateTime.Now,
                        TongTien = 0 // tạm thời
                    };
                    db.HoaDons.Add(hd);
                    db.SaveChanges(); // phải lưu để có ID

                    decimal tongTienHD = 0;

                    // 2. Lưu chi tiết hóa đơn
                    foreach (ListViewItem item in listViewBill.Items)
                    {
                        string tenMon = item.SubItems[0].Text;
                        int soLuong = int.Parse(item.SubItems[1].Text);

                        var mon = db.MonAns.FirstOrDefault(m => m.TenMonAn == tenMon);
                        if (mon == null) continue;

                        decimal donGia = mon.DonGia;
                        decimal thanhTien = donGia * soLuong;
                        tongTienHD += thanhTien;

                        CTHoaDon ct = new CTHoaDon
                        {
                            IDHoaDon = hd.ID,
                            IDMonAn = mon.ID,
                            SoLuong = soLuong,
                            DonGia = donGia,
                            ThanhTien = thanhTien
                        };
                        db.CTHoaDons.Add(ct);
                    }

                    // 3. Cập nhật tổng tiền hóa đơn
                    hd.TongTien = tongTienHD;
                    db.SaveChanges();

                    // 4. GỌI STORED PROCEDURE CẬP NHẬT DOANH THU
                    db.Database.ExecuteSqlCommand(
                        "EXEC CapNhatDoanhThu @Ngay, @TongTien",
                        new SqlParameter("@Ngay", DateTime.Now.Date),
                        new SqlParameter("@TongTien", tongTienHD)
                    );

                    MessageBox.Show("✅ Thanh toán thành công!");

                    listViewBill.Items.Clear();
                    TinhTongTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
