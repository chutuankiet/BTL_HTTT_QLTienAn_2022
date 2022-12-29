namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        public int MaPH { get; set; }

        public int? MaCanBo { get; set; }

        public int MaThanhToan { get; set; }

        public int? MaLopTruong { get; set; }

        [Column("PhanHoi")]
        [Required]
        [StringLength(500)]
        public string PhanHoi1 { get; set; }

        public int DaXuLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGui { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual PhieuThanhToan PhieuThanhToan { get; set; }
    }
}
