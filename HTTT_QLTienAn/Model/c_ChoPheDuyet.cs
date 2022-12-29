namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class c_ChoPheDuyet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        public int? PheDuyet { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }
    }
}
