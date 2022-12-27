namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietCatCom")]
    public partial class ChiTietCatCom
    {
        [Key]
        public int MaCatCom { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayCatCom { get; set; }

        public bool BuoiSang { get; set; }

        public bool BuoiTrua { get; set; }

        public bool BuoiToi { get; set; }

        public int? MaDangKy { get; set; }

        public virtual DangKyNghi DangKyNghi { get; set; }
    }
}
