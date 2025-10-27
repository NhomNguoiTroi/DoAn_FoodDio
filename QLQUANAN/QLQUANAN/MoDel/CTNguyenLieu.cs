namespace QLQUANAN.MoDel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTNguyenLieu")]
    public partial class CTNguyenLieu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNguyenLieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMonAn { get; set; }

        public decimal SoLuong { get; set; }

        public virtual MonAn MonAn { get; set; }

        public virtual KhoHang KhoHang { get; set; }
    }
}
