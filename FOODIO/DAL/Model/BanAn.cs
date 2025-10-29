namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanAn")]
    public partial class BanAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BanAn()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBan { get; set; }

        [Required]
        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int SoCho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
