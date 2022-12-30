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
using System.Data.Entity;
using HTTT_QLTienAn.Model;
namespace HTTT_QLTienAn.GUI.NhaBep
{
    public partial class NhaBep_ThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        public NhaBep_ThongKe()
        {
            InitializeComponent();
            dtpCuoi.EditValue = DateTime.Now;
            dtpDau.EditValue = DateTime.Now.AddMonths(-1);
            //dtpCuoi.Properties.MaxValue = DateTime.Now;
            //dtpDau.Properties.MaxValue = DateTime.Now;
            LoadDataChart1();
            LoadDataChart2();
        }


        QLTA_model db = new QLTA_model();

        private void LoadDataChart1()
        {
            List<Class_RPNhaBep> lstData = new List<Class_RPNhaBep>();

            List<PhieuThanhToan> lstThanhToan =
                db.PhieuThanhToans.Where(s => DbFunctions.TruncateTime(s.NgayTT) >= dtpDau.DateTime.Date && DbFunctions.TruncateTime(s.NgayTT) <= dtpCuoi.DateTime.Date).ToList();

            int tongtien = 0;

            foreach (var item in lstThanhToan)
            {
                var thisItem = lstData.Find(s => s.ngay == (DateTime)item.NgayTT);
                if (thisItem != null)
                {
                    thisItem.sotien += item.TongTien;
                }
                else
                {
                    thisItem = new Class_RPNhaBep();
                    thisItem.ngay = (DateTime)item.NgayTT;
                    thisItem.sotien = item.TongTien;
                    lstData.Add(thisItem);
                }




            }


            chartControl1.Series["BDTien"].Points.Clear();

            foreach (var item in lstData)
            {
                chartControl1.Series["BDTien"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.ngay, item.sotien));
                tongtien += item.sotien;
            }

            chartControl1.Refresh();

            txtTongTien.Text = tongtien.ToString();

        }



        private void LoadDataChart2()
        {
            List<ChiTietCatCom> lstCTT = db.ChiTietCatComs.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) >= dtpDau.DateTime.Date && DbFunctions.TruncateTime(s.NgayCatCom) <= dtpCuoi.DateTime.Date).ToList();


            List<Class_RPNhaBep> lstData = new List<Class_RPNhaBep>();

            int soluot = 0;
            int buoisang;
            int buoitrua;
            int buoitoi;
            foreach (var item in lstCTT)
            {
                if (item.BuoiSang)
                {
                    buoisang = 1;
                }
                else buoisang = 0;
                if (item.BuoiSang)
                {
                    buoitrua = 1;
                }
                else buoitrua = 0;
                if (item.BuoiSang)
                {
                    buoitoi = 1;
                }
                else buoitoi = 0;
                var thisItem = lstData.Find(s => s.ngay == (DateTime)item.NgayCatCom);

                if (thisItem != null)
                {
                    thisItem.sotien = (buoisang + buoitrua + buoitoi + thisItem.sotien);
                }
                else
                {
                    thisItem = new Class_RPNhaBep();
                    thisItem.ngay = item.NgayCatCom.Date;
                    thisItem.sotien = buoisang + buoitrua + buoitoi;
                    lstData.Add(thisItem);
                }


            }

            chartControl2.Series["BDLuot"].Points.Clear();
            foreach (var item in lstData)
            {
                chartControl2.Series["BDLuot"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.ngay, item.sotien));
                soluot += item.sotien;
            }
            chartControl2.Refresh();

            txtLuot.Text = soluot.ToString();

        }
        public void reload()
        {
            LoadDataChart1();
            LoadDataChart2();
        }

        private void dtpDau_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataChart1();
            LoadDataChart2();
        }

        private void dtpCuoi_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataChart1();
            LoadDataChart2();
        }
    }
}
