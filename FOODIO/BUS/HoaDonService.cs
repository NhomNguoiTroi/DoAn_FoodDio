using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonService
    {
        private readonly QLQAContext db = new QLQAContext();

        public HoaDon GetHoaDonChuaThanhToan(int idBan)
        {
            return db.HoaDons.FirstOrDefault(h => h.IDBanAn == idBan && h.TinhTrang == 0);
        }

        public HoaDon TaoHoaDonMoi(int idBan)
        {
            var hd = new HoaDon
            {
                IDBanAn = idBan,
                NgayLap = DateTime.Now,
                TinhTrang = 0
            };
            db.HoaDons.Add(hd);
            db.SaveChanges();
            return hd;
        }
        public List<CTHoaDon> GetChiTietHoaDon(int idHD)
        {
            using (var context = new QLQAContext())
            {
                //context.Configuration.LazyLoadingEnabled = false;
                return context.CTHoaDons
                    .AsNoTracking()
                    .Where(ct => ct.IDHoaDon == idHD)
                    .ToList();
            }
        }

        public void ThemMonVaoHoaDon(int idHD, int idMon, int soLuong, decimal donGia)
        {
            var ct = db.CTHoaDons.FirstOrDefault(c => c.IDHoaDon == idHD && c.IDMonAn == idMon);
            if (ct != null)
            {
                ct.SoLuong += soLuong;
                ct.ThanhTien = ct.SoLuong * ct.DonGia;
            }
            else
            {
                db.CTHoaDons.Add(new CTHoaDon
                {
                    IDHoaDon = idHD,
                    IDMonAn = idMon,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }
            db.SaveChanges();
        }

        public void ThanhToan(int idHD, decimal tongTien, decimal giamGia = 0)
        {
            var hd = db.HoaDons.FirstOrDefault(h => h.ID == idHD);
            if (hd != null)
            {
                hd.TinhTrang = 1; // Đã thanh toán
                db.SaveChanges();

                decimal thanhToan = tongTien - giamGia;
                DateTime ngayHienTai = DateTime.Today;

                var doanhthu = db.DoanhThus.FirstOrDefault(dt => dt.Ngay == ngayHienTai);
                if (doanhthu == null)
                {
                    doanhthu = new DoanhThu
                    {
                        Ngay = ngayHienTai,
                        TongSoHoaDon = 1,
                        TongDoanhThu = thanhToan,
                        GhiChu = "Đơn đầu tiên!"
                    };
                    db.DoanhThus.Add(doanhthu);
                }
                else
                {
                    doanhthu.TongSoHoaDon += 1;
                    doanhthu.TongDoanhThu += thanhToan;
                }
            }
            db.SaveChanges();
        }


    }
}
