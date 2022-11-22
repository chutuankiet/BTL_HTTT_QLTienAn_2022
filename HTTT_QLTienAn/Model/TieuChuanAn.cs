namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TieuChuanAn")]
    public partial class TieuChuanAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TieuChuanAn()
        {
            LoaiHocViens = new HashSet<LoaiHocVien>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTCA { get; set; }

        [StringLength(50)]
        public string TenTCA { get; set; }

        public int TienAnSang { get; set; }

        public int TienAnTrua { get; set; }

        public int TienAnToi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayApDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiHocVien> LoaiHocViens { get; set; }
    }
}
