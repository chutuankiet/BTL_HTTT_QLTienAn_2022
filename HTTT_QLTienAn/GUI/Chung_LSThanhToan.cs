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
    public partial class Chung_LSThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public Chung_LSThanhToan()
        {
            InitializeComponent();

        }
        public Chung_LSThanhToan(bool isCanBo)
        {
            InitializeComponent();
            isCB = isCanBo;
        }
        QLTA_model db = new QLTA_model();

        bool isCB;

        CanBo cb;
        HocVien loptruong;

        List<NhaBep_ListThanhToan> dsHocVien;
        private void Chung_LSThanhToan_Load(object sender, EventArgs e)
        {
            if (isCB)
            {
                cb = db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault();
                string TenDonvi = db.DonVis.Where(m => m.MaDonVi == cb.MaDonVi).FirstOrDefault().TenDonVi;


                lbTenDV.Text = TenDonvi;

                dsHocVien = db.NhaBep_ListThanhToan.Where(m => m.TrangThaiTT == 1 && m.TenDonVi == TenDonvi).ToList();


                gridControl1.DataSource = dsHocVien;



            }

        }


        void LoadChiTietInfo_HocVien(NhaBep_ListThanhToan hv)
        {
            lbHoTen.Text = hv.HoTen;
            lbTenLop.Text = hv.TenLop;

            HocVien thishv = db.HocViens.Where(m => m.MaHocVien == hv.MaHocVien).FirstOrDefault();

            lbLoaiHocVien.Text = thishv.LoaiHocVien.TenLHV;
            lbLoaiTCA.Text = thishv.LoaiHocVien.TieuChuanAn.TenTCA;


            lbTongTien.Text = hv.TongTien.ToString();


            List<ChiTietCatCom> dsCTCC = db.ChiTietCatComs.Where(m => m.MaDangKy == hv.MaDangKy).ToList();

            gridControl2.DataSource = dsCTCC;

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int index = e.RowHandle;

            LoadChiTietInfo_HocVien(dsHocVien[index]);

        }
    }
}
