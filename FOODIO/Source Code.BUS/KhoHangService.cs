using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source_Code.BUS
{
    public class KhoHangService
    {
        private readonly CSDL db = new CSDL();

        public List<KhoHang> GetAll()
        {
            return db.KhoHangs.ToList();
        }

        public KhoHang GetById(int id)
        {
            return db.KhoHangs.FirstOrDefault(x => x.ID == id);
        }

        public bool Add(KhoHang item)
        {
            if (db.KhoHangs.Any(x => x.ID == item.ID)) return false;
            db.KhoHangs.Add(item);
            db.SaveChanges();
            return true;
        }

        public bool Update(KhoHang item)
        {
            var old = db.KhoHangs.FirstOrDefault(x => x.ID == item.ID);
            if (old == null) return false;

            old.TenNguyenLieu = item.TenNguyenLieu;
            old.SoLuongTon = item.SoLuongTon;
            old.DoViTinh = item.DoViTinh;
            old.GiaNhap = item.GiaNhap;
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
    }
}
