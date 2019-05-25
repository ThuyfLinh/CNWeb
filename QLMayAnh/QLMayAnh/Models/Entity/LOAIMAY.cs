namespace QLMayAnh.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIMAY")]
    public partial class LOAIMAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMAY()
        {
            MAYANHs = new HashSet<MAYANH>();
        }

        [Key]
        public int IDLOAIMAY { get; set; }

        [StringLength(100)]
        public string TENLMAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAYANH> MAYANHs { get; set; }
    }
}
