namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ds_huy
    {
        public int? PheDuyet { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [StringLength(100)]
        public string HoTenc { get; set; }

        public int? MaCBd { get; set; }

        [StringLength(100)]
        public string TenDonVi { get; set; }
    }
}
