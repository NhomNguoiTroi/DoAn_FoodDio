namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public int TongSoHoaDon { get; set; }

        public decimal TongDoanhThu { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }
    }
}
