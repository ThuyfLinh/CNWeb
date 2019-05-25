namespace QLMayAnh.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        public int IDNV { get; set; }

        [StringLength(100)]
        public string TENNV { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string TAIKHOAN { get; set; }

        [StringLength(100)]
        public string MATKHAU { get; set; }
    }
}
