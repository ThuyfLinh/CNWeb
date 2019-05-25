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
        public int IDCTDONHANG { get; set; }

        public int? IDDONHANG { get; set; }

        public int? IDMAY { get; set; }

        public int? DONGIA { get; set; }

        public int? SOLUONG { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual MAYANH MAYANH { get; set; }
    }
}
