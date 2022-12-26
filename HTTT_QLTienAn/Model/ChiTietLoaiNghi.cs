namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietLoaiNghi")]
    public partial class ChiTietLoaiNghi
    {
        [Key]
        public int MaCTLoaiNghi { get; set; }

        public int Ngay { get; set; }

        public bool BuoiSang { get; set; }

        public bool BuoiTrua { get; set; }

        public bool BuoiToi { get; set; }

        public int MaLoaiNghi { get; set; }

        public virtual LoaiNghi LoaiNghi { get; set; }
    }
}
