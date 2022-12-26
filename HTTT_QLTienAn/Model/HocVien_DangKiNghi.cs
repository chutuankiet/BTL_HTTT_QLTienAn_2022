using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTT_QLTienAn.Model
{
    class HocVien_DangKiNghi
    {
        public int MaHocVien { get; set; }
        public int MaDangKyTam { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public DateTime NgayBDNghi { get; set; }
        public DateTime NgayKTNghi { get; set; }
        public int MaLoaiNghi { get; set; }

        public string TenLoaiNghi { get; set; }

        public string LyDo { get; set; }
    }
}
