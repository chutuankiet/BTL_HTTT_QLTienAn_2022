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
        public Chung_LSThanhToan(string per)
        {
            InitializeComponent();
            accPer = per;
        }
        QLTA_model db = new QLTA_model();

        string accPer;

        CanBo cb;
        HocVien loptruong;

        List<NhaBep_ListThanhToan> dsHocVien;
        private void Chung_LSThanhToan_Load(object sender, EventArgs e)
        {
            switch (accPer)
            {

                case "l":
                    {
                        loptruong = db.HocViens.Where(m => m.MaHocVien == MainForm.MaID).FirstOrDefault();
                        string TenDonvi = db.DonVis.Where(m => m.MaDonVi == loptruong.Lop.MaDonVi).FirstOrDefault().TenDonVi;
                        string TenLop = db.Lops.Where(m => m.MaLop == loptruong.MaLop).FirstOrDefault().TenLop;
                        lbTenDV.Text = $"Lớp {TenLop} - Đại đội {TenDonvi}";

                        dsHocVien = db.NhaBep_ListThanhToan.Where(m => m.TrangThaiTT == 1 && m.MaLop == loptruong.MaLop).ToList();
                        break;
                    }
                case "c":
                    {
                        cb = db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault();
                        string TenDonvi = db.DonVis.Where(m => m.MaDonVi == cb.MaDonVi).FirstOrDefault().TenDonVi;


                        lbTenDV.Text = TenDonvi;

                        dsHocVien = db.NhaBep_ListThanhToan.Where(m => m.TrangThaiTT == 1 && m.TenDonVi == TenDonvi).ToList();

                        break;
                    }

                case "d":
                    {
                        string TenDonvi = "Tiểu đoàn 1";

                        lbTenDV.Text = TenDonvi;

                        dsHocVien = db.NhaBep_ListThanhToan.ToList();
                        break;
                    }


            }

            gridControl1.DataSource = dsHocVien;

            if(dsHocVien.Count > 0) LoadChiTietInfo_HocVien(dsHocVien[0]);


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
