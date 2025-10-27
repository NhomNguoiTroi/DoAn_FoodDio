using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source_Code.BUS
{
    public class DoanhThuService
    {
        private readonly CSDL db = new CSDL();

        public List<DoanhThu> GetAll()
        {
            return db.DoanhThus.ToList();
        }

        public List<DoanhThu> GetByDateRange(DateTime start, DateTime end)
        {
            return db.DoanhThus
                .Where(d => d.NgayThanhToan >= start && d.NgayThanhToan <= end)
                .ToList();
        }

        public decimal TongDoanhThu(DateTime start, DateTime end)
        {
            return db.DoanhThus
                .Where(d => d.NgayThanhToan >= start && d.NgayThanhToan <= end)
                .Sum(d => (decimal?)d.ThanhTien) ?? 0;
        }
    }
}
