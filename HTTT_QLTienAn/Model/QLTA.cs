using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HTTT_QLTienAn.Model
{
    public partial class QLTA : DbContext
    {
        public QLTA()
            : base("name=QLTA")
        {
        }

        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<ChiTietCatCom> ChiTietCatComs { get; set; }
        public virtual DbSet<ChiTietLoaiNghi> ChiTietLoaiNghis { get; set; }
        public virtual DbSet<DangKyNghi> DangKyNghis { get; set; }
        public virtual DbSet<DanhSachRaNgoai> DanhSachRaNgoais { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<DotThanhToan> DotThanhToans { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<LoaiHocVien> LoaiHocViens { get; set; }
        public virtual DbSet<LoaiNghi> LoaiNghis { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<PhieuThanhToan> PhieuThanhToans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TieuChuanAn> TieuChuanAns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DonVis)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBQL);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachRaNgoais)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBc);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachRaNgoais1)
                .WithOptional(e => e.CanBo1)
                .HasForeignKey(e => e.MaCBd);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.PhieuThanhToans)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBNhaBep);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<TieuChuanAn>()
                .Property(e => e.TenTCA)
                .IsUnicode(false);
        }
    }
}
