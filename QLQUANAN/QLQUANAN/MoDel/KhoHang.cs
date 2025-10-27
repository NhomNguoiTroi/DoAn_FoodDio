namespace QLQUANAN.MoDel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoHang")]
    public partial class KhoHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoHang()
        {
            CTNguyenLieux = new HashSet<CTNguyenLieu>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguyenLieu { get; set; }

        public decimal SoLuongTon { get; set; }

        [Required]
        [StringLength(30)]
        public string DonViTinh { get; set; }

        public decimal GiaNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNguyenLieu> CTNguyenLieux { get; set; }
    }
}
