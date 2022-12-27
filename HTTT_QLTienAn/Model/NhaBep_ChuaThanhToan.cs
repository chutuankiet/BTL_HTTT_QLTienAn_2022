namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NhaBep_ChuaThanhToan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHocVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLop { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonVi { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string TenLoaiNghi { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLoaiNghi { get; set; }

        public int? SoBuoiSang { get; set; }

        public int? SoBuoiTrua { get; set; }

        public int? SoBuoiToi { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TongTien { get; set; }

        public int? TrangThaiTT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTT { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThanhToan { get; set; }
    }
}
