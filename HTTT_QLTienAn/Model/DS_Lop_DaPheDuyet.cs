namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_Lop_DaPheDuyet
    {
        public int? PheDuyet { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [StringLength(100)]
        public string HoTenc { get; set; }

        [StringLength(100)]
        public string HoTend { get; set; }

        public int? MaCBd { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        public int? MaDonVi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLop { get; set; }
    }
}
