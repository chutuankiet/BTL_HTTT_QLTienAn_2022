namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chung_GetPhanHoi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPH { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TenCB { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayGui { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Trangthai { get; set; }

        public int? MaCanBo { get; set; }

        public int? MaLopTruong { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(500)]
        public string PhanHoi { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThanhToan { get; set; }
    }
}
