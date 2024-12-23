﻿using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoa { get; set; }
        public DbSet<Loai> loais { get; set; }
        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<DonHangChiTiet> donHangChiTiets { get; set; }
        #endregion
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DonHang>(e => 
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.nguoinhan).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH,e.MaHH});
                entity.HasOne(e => e.DonHang)
                        .WithMany(e => e.DonHangChiTiets)
                        .HasForeignKey(e => e.MaDH)
                        .HasConstraintName("FK_DonHangChiTiet_DonHang");

                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH, e.MaHH });
                entity.HasOne(e => e.HangHoa)
                        .WithMany(e => e.DonHangChiTiets)
                        .HasForeignKey(e => e.MaHH)
                        .HasConstraintName("FK_DonHangChiTiet_HangHoa");
            });
        }


    }
}
