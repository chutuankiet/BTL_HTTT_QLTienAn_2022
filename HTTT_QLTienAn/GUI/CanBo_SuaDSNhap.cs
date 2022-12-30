using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTT_QLTienAn.Model;
using System.Windows.Forms;

namespace HTTT_QLTienAn.GUI
{
    public partial class CanBo_SuaDSNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public CanBo_SuaDSNhap()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();

        List<HocVien_DangKiNghi> DSHocVien;
        List<HocVien_DangKiNghi> DS_old_DK;

        List<ChiTietCatCom> lsCTCatCom = new List<ChiTietCatCom>();
        public CanBo_SuaDSNhap(int MaDS)
        {
            InitializeComponent();
            MaDSCur = MaDS;
        }


        int MaDSCur;

        public CanBo_SuaDSNhap(List<HocVien> dshv, List<DangKyNghi> dsdk)
        {
            InitializeComponent();

            DSHocVien = (
                from a in dshv
                join b in db.Lops on a.MaLop equals b.MaLop
                select new Model.HocVien_DangKiNghi
                {
                    MaHocVien = a.MaHocVien,
                    HoTen = a.HoTen,
                    NgaySinh = a.NgaySinh,
                    Lop = b.TenLop,
                    NgayBDNghi = DateTime.Now,
                    NgayKTNghi = DateTime.Now

                }).ToList();


            DS_old_DK = (
                from a in dsdk
                join c in db.HocViens on a.MaHocVien equals c.MaHocVien
                join b in db.Lops on c.MaLop equals b.MaLop
                join d in db.LoaiNghis on a.MaLoaiNghi equals d.MaLoaiNghi
                select new Model.HocVien_DangKiNghi
                {
                    MaHocVien = c.MaHocVien,
                    HoTen = c.HoTen,
                    NgaySinh = c.NgaySinh,
                    Lop = b.TenLop,
                    NgayBDNghi = a.NgayDi,
                    NgayKTNghi = a.NgayVe,
                    TenLoaiNghi = d.TenLoaiNghi,
                    MaLoaiNghi = d.MaLoaiNghi,
                    MaDangKyTam = a.MaDangKy
                    
                }).ToList();

            foreach(var item in DS_old_DK)
            {
                List<ChiTietCatCom> dsCatCom_old = db.ChiTietCatComs.Where(m => m.MaDangKy == item.MaDangKyTam).ToList();

                lsCTCatCom.AddRange(dsCatCom_old);

            }

            dsLop.DataSource = DSHocVien;
            gridControl2.DataSource = DS_old_DK;


        }

        List<CanBo_SuaNhapDS> listDS;


        private void CanBo_SuaDSNhap_Load(object sender, EventArgs e)
        {
            if(MaDSCur != 0)
            {

                listDS = db.CanBo_SuaNhapDS.Where(m => m.MaDS == MaDSCur).ToList(); 


            }

        }


        int sobuoinghi;


        private void SetDefaultState()
        {

            txtHoTen.Text = "";
            txtLop.Text = "";
            txtLyDo.Text = "";
            txtSang.Text = "";
            txtTrua.Text = "";
            txtToi.Text = "";


            dateStart.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now;

            gridControl2.DataSource = null;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int index = e.RowHandle;
            txtHoTen.Text = listDS[index].HoTen;
            txtLop.Text = listDS[index].TenLop;
            dateStart.DateTime = listDS[index].NgayDi;
            dateEnd.DateTime = listDS[index].NgayVe;
            txtLyDo.Text = listDS[index].LyDo;


        }
    }
}
