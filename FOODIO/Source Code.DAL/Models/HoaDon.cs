namespace Source_Code.DAL.Models
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
            DoanhThus = new HashSet<DoanhThu>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? NgayLap { get; set; }

        public int IDBanAn { get; set; }

        public int TinhTrang { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_New { get; set; }

        public virtual BanAn BanAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoanhThu> DoanhThus { get; set; }
    }
}
