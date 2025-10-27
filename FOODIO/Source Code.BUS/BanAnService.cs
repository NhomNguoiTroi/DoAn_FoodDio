using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source_Code.BUS
{
    public class BanAnService
    {
        private readonly CSDL db = new CSDL();

        public List<BanAn> GetAll()
        {
            return db.BanAns.ToList();
        }

        public BanAn GetById(int id)
        {
            return db.BanAns.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateTinhTrang(int id, string tinhTrang)
        {
            var ban = db.BanAns.FirstOrDefault(x => x.ID == id);
            if (ban != null)
            {
                ban.TinhTrang = tinhTrang;
                db.SaveChanges();
            }
        }

        public bool Add(BanAn ban)
        {
            if (db.BanAns.Any(x => x.ID == ban.ID)) return false;
            db.BanAns.Add(ban);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var ban = db.BanAns.FirstOrDefault(x => x.ID == id);
            if (ban == null) return false;
            db.BanAns.Remove(ban);
            db.SaveChanges();
            return true;
        }
        public bool Update(BanAn ban)
        {
            var old = db.BanAns.FirstOrDefault(x => x.ID == ban.ID);
            if (old == null) return false;

            old.TenBan = ban.TenBan;
            old.TinhTrang = ban.TinhTrang;
            old.SoCho = ban.SoCho;
            db.SaveChanges();
            return true;
        }
    }
}
