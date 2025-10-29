namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHienThi { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }
    }
}
