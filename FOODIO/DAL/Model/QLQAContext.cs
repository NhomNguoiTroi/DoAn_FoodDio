using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class QLQAContext : DbContext
    {
        public QLQAContext()
            : base("name=QLQAContext")
        {
        }

        public virtual DbSet<BanAn> BanAns { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<CTNguyenLieu> CTNguyenLieux { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanAn>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.BanAn)
                .HasForeignKey(e => e.IDBanAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTHoaDon>()
                .Property(e => e.DonGia)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CTHoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(26, 2);

            modelBuilder.Entity<CTNguyenLieu>()
                .Property(e => e.SoLuong)
                .HasPrecision(15, 2);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.IDHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .Property(e => e.SoLuongTon)
                .HasPrecision(15, 2);

            modelBuilder.Entity<KhoHang>()
                .Property(e => e.GiaNhap)
                .HasPrecision(15, 2);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.CTNguyenLieux)
                .WithRequired(e => e.KhoHang)
                .HasForeignKey(e => e.IDNguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.DonGia)
                .HasPrecision(15, 2);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.CTHoaDons)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.IDMonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.CTNguyenLieux)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.IDMonAn)
                .WillCascadeOnDelete(false);
        }
    }
}
