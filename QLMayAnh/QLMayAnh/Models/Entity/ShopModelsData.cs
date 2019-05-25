namespace QLMayAnh.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModelsData : DbContext
    {
        public ShopModelsData()
            : base("name=ShopModelsData2")
        {
        }

        public virtual DbSet<CTDONHANG> CTDONHANGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIMAY> LOAIMAYs { get; set; }
        public virtual DbSet<MAYANH> MAYANHs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<MAYANH>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);
        }
    }
}
