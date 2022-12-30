namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CanBo_SuaNhapDS
    {
        public int? MaHocVien { get; set; }

        [Key]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVe { get; set; }

        [StringLength(100)]
        public string TenLoaiNghi { get; set; }

        public int? MaDangKy { get; set; }

        public int? MaLop { get; set; }

        public int? MaDonVi { get; set; }

        public int? MaDS { get; set; }

        public int? MaLoaiNghi { get; set; }

        [StringLength(100)]
        public string LyDo { get; set; }

        public int? PheDuyet { get; set; }
    }
}
