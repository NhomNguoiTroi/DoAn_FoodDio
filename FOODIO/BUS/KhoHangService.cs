using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class KhoHangService
    {
        private readonly QLQAContext db = new QLQAContext();

        public List<KhoHang> GetAll()
        {
            return db.KhoHangs.ToList();
        }

        public KhoHang GetById(int id)
        {
            return db.KhoHangs.FirstOrDefault(x => x.ID == id);
        }

        /*   public bool Add(KhoHang item)
           {
               if (db.KhoHangs.Any(x => x.ID == item.ID)) return false;
               db.KhoHangs.Add(item);
               db.SaveChanges();
               return true;
           }*/

        public bool Add(KhoHang item)
        {
            try
            {
                db.KhoHangs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*   public bool Update(KhoHang item)
           {
               var old = db.KhoHangs.FirstOrDefault(x => x.ID == item.ID);
               if (old == null) return false;

               old.TenNguyenLieu = item.TenNguyenLieu;
               old.SoLuongTon = item.SoLuongTon;
               old.DonViTinh = item.DonViTinh;
               old.GiaNhap = item.GiaNhap;
               db.SaveChanges();
               return true;
           }
        */
        public bool Update(KhoHang item)
        {
            var old = db.KhoHangs.FirstOrDefault(x => x.ID == item.ID);
            if (old == null) return false;

            old.TenNguyenLieu = item.TenNguyenLieu;
            old.SoLuongTon = item.SoLuongTon;
            old.DonViTinh = item.DonViTinh;
            old.GiaNhap = item.GiaNhap;
            old.NgayNhap = item.NgayNhap;

            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var item = db.KhoHangs.FirstOrDefault(x => x.ID == id);
            if (item == null) return false;
            db.KhoHangs.Remove(item);
            db.SaveChanges();
            return true;
        }

        public void LoadToGrid(DataGridView grid)
        {
            var listKho = GetAll();

            grid.DataSource = listKho.Select(x=> new
            {
                x.ID,
                x.TenNguyenLieu,
                x.SoLuongTon,
                x.DonViTinh,
                x.GiaNhap,
                x.NgayNhap
            }).ToList();
            grid.AutoGenerateColumns = false;
        }
        public KhoHang GetKhoFromRow(DataGridViewRow row)
        {
            if (row == null) return null;
            var kho= new KhoHang()
            {
                ID = Convert.ToInt32(row.Cells[0].Value),
                TenNguyenLieu = row.Cells[1].Value.ToString(),
                SoLuongTon = Convert.ToDecimal(row.Cells[2].Value),
                DonViTinh = row.Cells[3].Value.ToString(),
                GiaNhap = Convert.ToDecimal(row.Cells[4].Value),
                NgayNhap = Convert.ToDateTime(row.Cells[5].Value)
            };
            return kho;
        }
    }
}
