using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTT_QLTienAn.Model;

namespace HTTT_QLTienAn.GUI.TieuDoan
{
    public partial class TieuDoan_QuanLyDS : UserControl
    {
        public TieuDoan_QuanLyDS()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        private void NhaBep_QuanLyDanhSach_Load(object sender, EventArgs e)
        {
            dtpNgayC.EditValueChanged -= dtpNgayC_EditValueChanged;
            dtpNgayD.EditValueChanged -= dtpNgayD_EditValueChanged;
            dtpNgayC.EditValue = DateTime.Now;
            dtpNgayD.EditValue = DateTime.Now;
            dtpNgayC.EditValueChanged += dtpNgayC_EditValueChanged;
            dtpNgayD.EditValueChanged += dtpNgayD_EditValueChanged;


            //Load don vi:
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
            List<DonVi> lstDonVi = db.DonVis.ToList();
            cbbDonVi.Items.Clear();
            foreach (var item in lstDonVi.ToList())
            {
                if (item.TenDonVi.Contains("c"))
                {
                    cbbDonVi.Items.Add(item.TenDonVi);
                }
            }
            cbbDonVi.SelectedIndex = 0;
            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;

            //Load quan so:
            StartupLoadQuanSoD();

            LoadQuanSoC();

            LoadQuanSoD();

            LoadDBDaiDoi();
        }

        private void LoadDBDaiDoi()
        {
            ClearGridControl();

            var thisDate = dtpNgayC.DateTime.Date;
            string tenDonVi = cbbDonVi.SelectedItem.ToString();

            List<DonVi> lstDonVi = db.DonVis.ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == tenDonVi).MaDonVi;

            List<NhaBep_ListCatCom> lstCatCom = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date && s.MaDonVi == maC).ToList();

            gridView1.Columns[3].Visible = false;
            gridControl1.DataSource = lstCatCom;
            gridControl1.Refresh();

            int sobuoisang = lstCatCom.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatCom.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatCom.Count(s => s.BuoiToi == true);
            int quansoC = LoadQuanSoC();
            textEdit1.Text = (quansoC - sobuoisang).ToString();
            textEdit2.Text = (quansoC - sobuoitrua).ToString();
            textEdit3.Text = (quansoC - sobuoitoi).ToString();


        }

        private void LoadDBTieuDoan()
        {
            var thisDate = dtpNgayD.DateTime.Date;
            ClearGridControl();

            List<NhaBep_ListCatCom> lstCatComD = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date).ToList();

            gridView1.Columns[3].Visible = true;
            gridControl1.DataSource = lstCatComD;
            gridControl1.Refresh();

            int sobuoisang = lstCatComD.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatComD.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatComD.Count(s => s.BuoiToi == true);
            int quansoD = LoadQuanSoD();
            textEdit4.Text = (quansoD - sobuoisang).ToString();
            textEdit5.Text = (quansoD - sobuoitrua).ToString();
            textEdit11.Text = (quansoD - sobuoitoi).ToString();
        }

        private int LoadQuanSoC()
        {
            List<DonVi> lstDonVi = db.DonVis.ToList();
            int maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;
            int quansoC = (from hv in db.HocViens
                           join l in db.Lops on hv.MaLop equals l.MaLop
                           where l.MaDonVi == maC
                           select new
                           {
                               hv.MaHocVien
                           }).ToList().Count;
            textEdit7.Text = quansoC.ToString();
            textEdit8.Text = quansoC.ToString();
            textEdit9.Text = quansoC.ToString();

            return quansoC;

        }


        private int LoadQuanSoD()
        {
            int quansoD = db.HocViens.ToList().Count;
            textEdit6.Text = quansoD.ToString();
            textEdit10.Text = quansoD.ToString();
            textEdit12.Text = quansoD.ToString();

            return quansoD;
        }

        private void StartupLoadQuanSoD()
        {
            var thisDate = dtpNgayD.DateTime.Date;
            List<NhaBep_ListCatCom> lstCatComD = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date).ToList();

            int sobuoisang = lstCatComD.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatComD.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatComD.Count(s => s.BuoiToi == true);
            int quansoD = LoadQuanSoD();
            textEdit4.Text = (quansoD - sobuoisang).ToString();
            textEdit5.Text = (quansoD - sobuoitrua).ToString();
            textEdit11.Text = (quansoD - sobuoitoi).ToString();

        }
        private void ClearGridControl()
        {
            gridControl1.BeginUpdate();
            try
            {
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DonVi> lstDonVi = db.DonVis.ToList();
            colTenDonVi.Visible = false;

            LoadDBDaiDoi();
        }

        private void dtpNgayC_EditValueChanged(object sender, EventArgs e)
        {
            colTenDonVi.Visible = false;
            LoadDBDaiDoi();
        }

        private void dtpNgayD_EditValueChanged(object sender, EventArgs e)
        {
            colTenDonVi.Visible = true;
            LoadDBTieuDoan();
        }
    }
}
