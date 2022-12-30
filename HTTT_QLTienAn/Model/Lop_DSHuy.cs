namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lop_DSHuy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [StringLength(100)]
        public string TenCBc { get; set; }

        [StringLength(100)]
        public string TenCBd { get; set; }

        public int? PheDuyet { get; set; }

        public int? MaLop { get; set; }
    }
}
