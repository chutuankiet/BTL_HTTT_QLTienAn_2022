namespace HTTT_QLTienAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_ChoPheDuyet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDangKy { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TenLop { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string TenLoaiNghi { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDS { get; set; }
    }
}
