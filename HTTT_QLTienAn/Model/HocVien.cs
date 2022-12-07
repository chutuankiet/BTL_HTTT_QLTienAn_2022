namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocVien")]
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            ChiTietRaNgoais = new HashSet<ChiTietRaNgoai>();
        }

        [Key]
        public int MaHocVien { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(20)]
        public string CapBac { get; set; }

        [Required]
        [StringLength(20)]
        public string ChucVu { get; set; }

        public int? MaLop { get; set; }

        public int? MaLHV { get; set; }

        public int? MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietRaNgoai> ChiTietRaNgoais { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual LoaiHocVien LoaiHocVien { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
