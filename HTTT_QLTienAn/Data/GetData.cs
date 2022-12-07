using HTTT_QLTienAn.Model;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HTTT_QLTienAn
{
    public class GetData
    {
        Model1 db = new Model1();
        //public List<int> GetMaDotTT(int maLop, int maDv)
        //{
        //    List<DotThanhToan> lstDot;
        //    var DTT = (from dtt in db.DotThanhToans
        //               join ptt in db.PhieuThanhToans on dtt.MaDot equals ptt.MaDot
        //               join ctrn in db.ChiTietRaNgoais on ptt.MaDangKy equals ctrn.MaDangKy
        //               join hv in db.HocViens on ctrn.MaHocVien equals hv.MaHocVien
        //               join lop in db.Lops on hv.MaLop equals lop.MaLop
        //               join dv in db.DonVis on lop.MaDonVi equals dv.MaDonVi
        //               where dv.MaDonVi == maDv && lop.MaLop == maLop
        //               select new
        //               {
        //                   maDot = dtt.MaDot,
        //               }).ToList();

        //    return DTT;
        //}
    }
}