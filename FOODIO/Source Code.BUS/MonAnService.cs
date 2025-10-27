using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source_Code.BUS
{
    public class MonAnService
    {
        private readonly CSDL db = new CSDL();

        public List<MonAn> GetAll()
        {
            return db.MonAns.ToList();
        }

        public MonAn GetById(int id)
        {
            return db.MonAns.FirstOrDefault(x => x.ID == id);
        }

        public bool Add(MonAn mon)
        {
            if (db.MonAns.Any(x => x.ID == mon.ID)) return false;
            db.MonAns.Add(mon);
            db.SaveChanges();
            return true;
        }

        public bool Update(MonAn mon)
        {
            var old = db.MonAns.FirstOrDefault(x => x.ID == mon.ID);
            if (old == null) return false;
            old.TenMonAn = mon.TenMonAn;
            old.DonGia = mon.DonGia;
            old.HinhAnh = mon.HinhAnh;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var mon = db.MonAns.FirstOrDefault(x => x.ID == id);
            if (mon == null) return false;
            db.MonAns.Remove(mon);
            db.SaveChanges();
            return true;
        }
        public List<MonAn> Search(string keyword)
        {
            return db.MonAns
                     .Where(x => x.TenMonAn.Contains(keyword))
                     .ToList();
        }
    }
}
