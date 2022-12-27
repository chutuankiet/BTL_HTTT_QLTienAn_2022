namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNghi")]
    public partial class LoaiNghi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNghi()
        {
            ChiTietLoaiNghis = new HashSet<ChiTietLoaiNghi>();
            DangKyNghis = new HashSet<DangKyNghi>();
        }

        [Key]
        public int MaLoaiNghi { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiNghi { get; set; }

        public int? SoBuoiSang { get; set; }

        public int? SoBuoiTrua { get; set; }

        public int? SoBuoiToi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietLoaiNghi> ChiTietLoaiNghis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyNghi> DangKyNghis { get; set; }
    }
}
