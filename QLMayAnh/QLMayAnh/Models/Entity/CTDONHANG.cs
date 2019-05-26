namespace QLMayAnh.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDONHANG")]
    public partial class CTDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDONHANG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMAY { get; set; }

        public int? DONGIA { get; set; }

        public int? SOLUONG { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual MAYANH MAYANH { get; set; }
    }
}
