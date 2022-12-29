namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachRaNgoai")]
    public partial class DanhSachRaNgoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSachRaNgoai()
        {
            DangKyNghis = new HashSet<DangKyNghi>();
        }

        [Key]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        public int? PheDuyet { get; set; }

        public int? MaCBc { get; set; }

        public int? MaCBd { get; set; }

        public int? MaLT { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual CanBo CanBo1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyNghi> DangKyNghis { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
