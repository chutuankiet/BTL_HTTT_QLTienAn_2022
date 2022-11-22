namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietRaNgoai")]
    public partial class ChiTietRaNgoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietRaNgoai()
        {
            PhieuThanhToans = new HashSet<PhieuThanhToan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDangKy { get; set; }

        [Required]
        [StringLength(100)]
        public string LyDo { get; set; }

        public int? MaHocVien { get; set; }

        public int? MaLoaiNghi { get; set; }

        public int? MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVe { get; set; }

        public virtual ChiTietLoaiNghi ChiTietLoaiNghi { get; set; }

        public virtual DanhSachRaNgoai DanhSachRaNgoai { get; set; }

        public virtual HocVien HocVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThanhToan> PhieuThanhToans { get; set; }
    }
}
