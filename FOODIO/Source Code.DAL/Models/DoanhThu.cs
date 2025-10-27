namespace Source_Code.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        public int ID { get; set; }

        public DateTime NgayThanhToan { get; set; }

        public int IDHoaDon { get; set; }

        public int IDBanAn { get; set; }

        public decimal TongTien { get; set; }

        public decimal? GiamGia { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ThanhTien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual BanAn BanAn { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
