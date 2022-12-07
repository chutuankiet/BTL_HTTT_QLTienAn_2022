namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lstCatCom")]
    public partial class lstCatCom
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHocVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLop { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonVi { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }

        public int? SoBuoiSang { get; set; }

        public int? SoBuoiTrua { get; set; }

        public int? SoBuoiToi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVe { get; set; }
    }
}
