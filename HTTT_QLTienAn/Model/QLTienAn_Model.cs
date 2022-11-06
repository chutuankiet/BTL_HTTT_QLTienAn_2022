using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HTTT_QLTienAn.Model
{
    public partial class QLTienAn_Model : DbContext
    {
        public QLTienAn_Model()
            : base("name=QLTienAn_Model")
        {
        }

        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<ChiTietNghi> ChiTietNghis { get; set; }
        public virtual DbSet<DangKyNghi> DangKyNghis { get; set; }
        public virtual DbSet<DanhSachNghi> DanhSachNghis { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<TieuChuanAn> TieuChuanAns { get; set; }
        public virtual DbSet<TTDangNhap> TTDangNhaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis)
                .WithOptional(e => e.CanBo)
                .HasForeignKey(e => e.MaCBDaiDoi);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis1)
                .WithOptional(e => e.CanBo1)
                .HasForeignKey(e => e.MaCBNhaBep);

            modelBuilder.Entity<CanBo>()
                .HasMany(e => e.DanhSachNghis2)
                .WithOptional(e => e.CanBo2)
                .HasForeignKey(e => e.MaCBTieuDoan);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TTDangNhap>()
                .Property(e => e.QuyenTruyCap)
                .IsUnicode(false);
        }
    }
}
