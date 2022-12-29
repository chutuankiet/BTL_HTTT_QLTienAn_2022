namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_DaThanhToan
    {
        [StringLength(100)]
        public string HoTenCB { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string HoTenHV { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TongTien { get; set; }
    }
}
