using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BanAnService
    {
        private QLQAContext db = new QLQAContext();
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
            using (var db = new QLQAContext())
            {
                var ban = db.BanAns.FirstOrDefault(x => x.ID == id);
                if (ban != null)
                {
                    ban.TinhTrang = tinhTrang;
                    db.SaveChanges();
                }
            }
        }

        public bool Add(BanAn ban)
        {
            if (db.BanAns.Any(x => x.ID == ban.ID)) return false;
            if(db.BanAns.Any(x=> x.TenBan == ban.TenBan))
            {
                MessageBox.Show("Tên bàn đã tồn tại", "Thông Báo", MessageBoxButtons.OK);
                return false;
            }
            
            db.BanAns.Add(ban);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using (var db = new QLQAContext())
            {
                var ban = db.BanAns.FirstOrDefault(x => x.ID == id);
                if (ban == null) return false;
                db.BanAns.Remove(ban);
                db.SaveChanges();
                return true;
            }
        }
        public bool Update(BanAn ban)
        {
            using(var db = new QLQAContext()) { 
            var old = db.BanAns.FirstOrDefault(x => x.ID == ban.ID);
            if (old == null) return false;

            old.TenBan = ban.TenBan;
            old.TinhTrang = ban.TinhTrang;
            old.SoCho = ban.SoCho;
            db.SaveChanges();
            return true;
            }
        }
        public void LoadToGrid(DataGridView dataGridView)
        {
            var list = GetAll();
            dataGridView.DataSource = list.Select(x=>new
            {
                x.ID,
                x.TenBan,
                x.TinhTrang,
                x.SoCho
            }).ToList();
        }
        public BanAn GetBanAnFromRow(DataGridViewRow row)
        {
            if(row == null) return null;
            var banan = new BanAn()
            {
                ID = Convert.ToInt32(row.Cells[0].Value),
                TenBan = row.Cells[1].Value.ToString(),
                TinhTrang = row.Cells[2].Value.ToString(),
                SoCho = Convert.ToInt32(row.Cells[3].Value)
            };
            return banan;
        }
    }
}
