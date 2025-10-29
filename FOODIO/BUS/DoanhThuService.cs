using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoanhThuService
    {
        private QLQAContext db= new QLQAContext();
        public List<DoanhThu> GetAll()
        {
            return db.DoanhThus.ToList();
        }
        public List<DoanhThu> GetByDateRange(DateTime start, DateTime end)
        {
            return db.DoanhThus
                .Where(d => d.Ngay >= start && d.Ngay <= end)
                .ToList();
        }

        public decimal TongDoanhThu(DateTime start, DateTime end)
        {
            return db.DoanhThus
                .Where(d => d.Ngay >= start && d.Ngay <= end)
                .Sum(d => (decimal?)d.TongDoanhThu) ?? 0;
        }

    }
}
