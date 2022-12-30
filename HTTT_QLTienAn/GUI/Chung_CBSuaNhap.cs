using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTT_QLTienAn.Model;



namespace HTTT_QLTienAn.GUI
{
    public partial class Chung_CBSuaNhap : DevExpress.XtraEditors.XtraForm
    {
        public Chung_CBSuaNhap()
        {
            InitializeComponent();
        }

        public QLTA_model db = new QLTA_model();

        public Chung_CBSuaNhap(int MaDS)
        {
            InitializeComponent();

            MaDSCur = MaDS;
        }

        CanBo TargetCanbo;

        List<HocVien_DangKiNghi> DSHocVien;
        List<HocVien_DangKiNghi> DS_old_DK;

        List<LoaiNghi> ListLoaiNghi = new List<LoaiNghi>();

        int MaDSCur;
        List<CanBo_SuaNhapDS> listDS;

        private void Chung_CBSuaNhap_Load(object sender, EventArgs e)
        {

            TargetCanbo = db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault();

            DSHocVien = db.HocViens.Where(m => m.Lop.MaDonVi == TargetCanbo.MaDonVi).Select(a => new HocVien_DangKiNghi
            {
                MaHocVien = a.MaHocVien,
                HoTen = a.HoTen,
                NgaySinh = a.NgaySinh,
                Lop = a.Lop.TenLop,
                NgayBDNghi = DateTime.Now,
                NgayKTNghi = DateTime.Now
            }).ToList() ;


            dsLop.DataSource = DSHocVien;
            //--------------------------------------------
            lbMaDS.Text = MaDSCur.ToString();
            
            if (MaDSCur != 0)
            {

                listDS = db.CanBo_SuaNhapDS.Where(m => m.MaDS == MaDSCur).ToList();


            }





            //--------------------------------------------



            dateStart.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now;

            ListLoaiNghi = db.LoaiNghis.ToList();

            cbLoainghi.DataSource = ListLoaiNghi;

            cbLoainghi.ValueMember = "MaLoaiNghi";
            cbLoainghi.DisplayMember = "TenLoaiNghi";


        }

        int MaHVCurrent;

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
            txtHoTen.EditValue = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
        }



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