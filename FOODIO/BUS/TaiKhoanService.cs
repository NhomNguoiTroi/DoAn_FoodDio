using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class TaiKhoanService
    {
        private readonly QLQAContext db = new QLQAContext();
        public List<TaiKhoan> GetAll()
        {
            return db.TaiKhoans.ToList();   
        }
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
        public TaiKhoan GetByUsername(string username)
        {
            if(string.IsNullOrEmpty(username)) return null; 
            return db.TaiKhoans.FirstOrDefault(x => x.TenNguoiDung.Trim() == username.Trim());
        }

        public void LoadToGrid(DataGridView datagridview)
        {
            var list = GetAll();
            datagridview.DataSource = list; 
        }
        public TaiKhoan GetTaiKhoanFromRow(DataGridViewRow row)
        {
            if (row == null) return null;
            var tk = new TaiKhoan()
            {
                ID = Convert.ToInt32(row.Cells[0].Value),
                TenNguoiDung = row.Cells[1].Value.ToString(),
                TenHienThi = row.Cells[2].Value.ToString(),
                MatKhau = row.Cells[3].Value.ToString()
            };
            return tk;
        }

        public bool DoiMatKhauDirect(string username, string newPassword)
        {
            var acc = db.TaiKhoans.FirstOrDefault(x => x.TenNguoiDung == username);
            if (acc == null) return false;
            acc.MatKhau = newPassword;
            db.SaveChanges();
            return true;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
