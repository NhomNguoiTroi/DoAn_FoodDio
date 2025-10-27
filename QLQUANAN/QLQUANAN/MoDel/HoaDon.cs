namespace QLQUANAN.MoDel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        public int ID { get; set; }

        public DateTime? NgayLap { get; set; }

        public int IDBanAn { get; set; }

        public int TinhTrang { get; set; }

        public decimal? GiamGia { get; set; }

        public decimal? TongTien { get; set; }

        public virtual BanAn BanAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
