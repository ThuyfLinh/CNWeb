namespace QLMayAnh.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAYANH")]
    public partial class MAYANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MAYANH()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        public int IDMAY { get; set; }

        [StringLength(100)]
        public string TENMAY { get; set; }

        [StringLength(300)]
        public string HINHANH { get; set; }

        [StringLength(300)]
        public string MOTA { get; set; }

        public int? DONGIA { get; set; }

        public int? IDLOAIMAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual LOAIMAY LOAIMAY { get; set; }
    }
}
