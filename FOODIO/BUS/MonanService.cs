using DAL.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace BUS
{
    public class MonanService
    {
        private readonly QLQAContext db = new QLQAContext();

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
            if (db.MonAns.Any(x => x.ID == mon.ID))
            {
                MessageBox.Show("Mã món ăn đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (db.MonAns.Any(x => x.TenMonAn == mon.TenMonAn))
            {
                MessageBox.Show("Tên món ăn này đã có rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mon.DonGia < 1000)
            {
                MessageBox.Show("Vui lòng nhập giá tiền của món ăn lớn hơn 1000 VNĐ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrEmpty(mon.HinhAnh) && db.MonAns.Any(x => x.HinhAnh == mon.HinhAnh))
            {
                MessageBox.Show("Hình ảnh này đã được sử dụng cho món ăn khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

        public void LoadMonAnToGridView(DataGridView grid)
        {
            var listFood = GetAll();

            grid.DataSource = listFood.Select(x => new
            {
                x.ID,
                x.TenMonAn,
                x.DonGia,
                x.HinhAnh
            }).ToList();

            
            if (grid.Columns.Contains("HinhAnh"))
                grid.Columns["HinhAnh"].Visible = false;
            if (!grid.Columns.Contains("HinhAnhThuc"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "HinhAnhThuc";
                imgCol.HeaderText = "Hình ảnh món ăn";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grid.Columns.Add(imgCol);
            }
            foreach (DataGridViewRow row in grid.Rows)
            {
                string fileName = row.Cells["HinhAnh"].Value?.ToString();
                string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Image", fileName ?? "");
                if (File.Exists(path))
                {
                    using (var imgTemp = System.Drawing.Image.FromFile(path))
                    {
                        row.Cells["HinhAnhThuc"].Value = new Bitmap(imgTemp);
                    }
                }
            }
        }
        public MonAn GetMonAnFromRow(DataGridViewRow row) 
        {
            if (row == null) return null;
            var monan = new MonAn()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                TenMonAn = row.Cells["TenMonAn"].Value.ToString(),
                DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value),
                HinhAnh = row.Cells["HinhAnh"].Value.ToString()
            };
            return monan;
        }
        
        public Image GetHinhAnh (string filename)
        {
            string path = Path.Combine(Application.StartupPath, "Image", filename);

            if (File.Exists(path))
                return Image.FromFile(path);
            else
                return null;
        }
        public string ChonAnh(PictureBox pic)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình món ăn";
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(ofd.FileName);
                    string destPath = Path.Combine(Application.StartupPath, "Image", fileName);

                    if (!File.Exists(destPath))
                        File.Copy(ofd.FileName, destPath, true);

                    pic.Image = Image.FromFile(destPath);
                    return fileName;
                }
            }
            return null;
        }


    }
}
