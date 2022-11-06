namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanBo")]
    public partial class CanBo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanBo()
        {
            DanhSachNghis = new HashSet<DanhSachNghi>();
            DanhSachNghis1 = new HashSet<DanhSachNghi>();
            DanhSachNghis2 = new HashSet<DanhSachNghi>();
        }

        [Key]
        public int MaCanBo { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string CapBac { get; set; }

        [StringLength(30)]
        public string ChucVu { get; set; }

        public int? MaDangNhap { get; set; }

        public int? MaDonVi { get; set; }

        public virtual TTDangNhap TTDangNhap { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachNghi> DanhSachNghis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachNghi> DanhSachNghis1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachNghi> DanhSachNghis2 { get; set; }
    }
}
