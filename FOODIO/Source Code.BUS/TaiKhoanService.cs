using Source_Code.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source_Code.BUS
{
    public class TaiKhoanService
    {
        private readonly CSDL db = new CSDL();

        public bool KiemTraDangNhap(string username, string password)
        {
            return db.TaiKhoans.Any(x => x.TenNguoiDung == username && x.MatKhau == password);
        }

        public bool DoiMatKhau(string username, string oldPass, string newPass)
        {
            var acc = db.TaiKhoans.FirstOrDefault(x => x.TenNguoiDung == username && x.MatKhau == oldPass);
            if (acc == null) return false;
            acc.MatKhau = newPass;
            db.SaveChanges();
            return true;
        }
        public List<TaiKhoan> GetAll()
        {
            return db.TaiKhoans.ToList();
        }
        public TaiKhoan GetByUsername(string username)
        {
            return db.TaiKhoans.FirstOrDefault(x => x.TenNguoiDung == username);
        }
    }
}
