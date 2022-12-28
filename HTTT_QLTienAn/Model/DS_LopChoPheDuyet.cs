namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_LopChoPheDuyet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        public int? MaLop { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonVi { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }
    }
}
