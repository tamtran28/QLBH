namespace QLBH.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLBHDBContext : DbContext
    {
        public QLBHDBContext()
            : base("name=QLBHDBContext")
        {
        }

        public virtual DbSet<chitietphieudathang> chitietphieudathangs { get; set; }
        public virtual DbSet<chitietphieugiaohang> chitietphieugiaohangs { get; set; }
        public virtual DbSet<hanghoa> hanghoas { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaihanghoa> loaihanghoas { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<nhasanxuat> nhasanxuats { get; set; }
        public virtual DbSet<phieudathang> phieudathangs { get; set; }
        public virtual DbSet<phieugiaohang> phieugiaohangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.chitietphieudathangs)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.chitietphieugiaohangs)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieudathang>()
                .HasMany(e => e.chitietphieudathangs)
                .WithRequired(e => e.phieudathang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieugiaohang>()
                .HasMany(e => e.chitietphieugiaohangs)
                .WithRequired(e => e.phieugiaohang)
                .WillCascadeOnDelete(false);
        }
    }
}
