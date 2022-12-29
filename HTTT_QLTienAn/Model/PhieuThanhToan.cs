namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThanhToan")]
    public partial class PhieuThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuThanhToan()
        {
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        public int MaThanhToan { get; set; }

        public int TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTT { get; set; }

        public int? TrangThaiTT { get; set; }

        public int? MaCBNhaBep { get; set; }

        public int? MaDangKy { get; set; }

        public int? MaDot { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual DangKyNghi DangKyNghi { get; set; }

        public virtual DotThanhToan DotThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
