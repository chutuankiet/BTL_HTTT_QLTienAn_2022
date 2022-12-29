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
namespace HTTT_QLTienAn.GUI.DaiDoi
{
    public partial class DaiDoi_QuanLyDS : UserControl
    {
        public DaiDoi_QuanLyDS()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        int maC;
        private void NhaBep_QuanLyDanhSach_Load(object sender, EventArgs e)
        {
            maC = Convert.ToInt32(db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi);
            dtpNgayL.EditValueChanged -= dtpNgayL_EditValueChanged;
            dtpNgayC.EditValueChanged -= dtpNgayC_EditValueChanged;
            dtpNgayL.EditValue = DateTime.Now;
            dtpNgayC.EditValue = DateTime.Now;
            dtpNgayL.EditValueChanged += dtpNgayL_EditValueChanged;
            dtpNgayC.EditValueChanged += dtpNgayC_EditValueChanged;


            //Load don vi:
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
           
            List<string> lstTenLop = db.Lops.Where(m=> m.MaDonVi == maC).Select( m=> m.TenLop).ToList();
            cbbDonVi.Items.Clear();
            foreach (var item in lstTenLop)
            {
                  cbbDonVi.Items.Add(item);           
            }
            cbbDonVi.SelectedIndex = 0;
            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;

            //Load quan so:
            StartupLoadQuanSoC();

            LoadQuanSoL();

            LoadQuanSoC();

            LoadDBLop();
        }

        private void LoadDBLop()
        {
            ClearGridControl();

            var thisDate = dtpNgayL.DateTime.Date;
            string tenLop = cbbDonVi.SelectedItem.ToString();
            List<NhaBep_ListCatCom> lstCatCom = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date && s.TenLop == tenLop).ToList();

            gridView1.Columns[3].Visible = false;
            gridControl1.DataSource = lstCatCom;
            gridControl1.Refresh();

            int sobuoisang = lstCatCom.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatCom.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatCom.Count(s => s.BuoiToi == true);
            int quansoL = LoadQuanSoL();
            textEdit1.Text = (quansoL - sobuoisang).ToString();
            textEdit2.Text = (quansoL - sobuoitrua).ToString();
            textEdit3.Text = (quansoL - sobuoitoi).ToString();


        }

        private void LoadDBDaiDoi()
        {
            var thisDate = dtpNgayC.DateTime.Date;
            ClearGridControl();
            maC = Convert.ToInt32(db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi);

            List<NhaBep_ListCatCom> lstCatComC = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date && s.MaDonVi == maC).ToList();

            gridView1.Columns[3].Visible = true;
            gridControl1.DataSource = lstCatComC;
            gridControl1.Refresh();

            int sobuoisang = lstCatComC.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatComC.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatComC.Count(s => s.BuoiToi == true);
            int quansoC = LoadQuanSoC();
            textEdit4.Text = (quansoC - sobuoisang).ToString();
            textEdit5.Text = (quansoC - sobuoitrua).ToString();
            textEdit11.Text = (quansoC - sobuoitoi).ToString();
        }

        private int LoadQuanSoL()
        {
            int maC = Convert.ToInt32(db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi);

            
            int maL = db.Lops.Where(s => s.TenLop == cbbDonVi.SelectedItem.ToString() && s.MaDonVi == maC).Select(m=>m.MaLop).FirstOrDefault();
            int quansoL = db.HocViens.Where(m=> m.MaLop == maL).Select(m=> m.MaHocVien).ToList().Count;
            textEdit7.Text = quansoL.ToString();
            textEdit8.Text = quansoL.ToString();
            textEdit9.Text = quansoL.ToString();

            return quansoL;

        }


        private int LoadQuanSoC()
        {
            maC = Convert.ToInt32(db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi);
            int quansoC = Convert.ToInt32(db.getQScs.Where(m=>m.MaDonVi == maC).FirstOrDefault().QuanSo);
            textEdit6.Text = quansoC.ToString();
            textEdit10.Text = quansoC.ToString();
            textEdit12.Text = quansoC.ToString();

            return quansoC;
        }

        private void StartupLoadQuanSoC()
        {
            maC = Convert.ToInt32(db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi);

            var thisDate = dtpNgayC.DateTime.Date;
            List<NhaBep_ListCatCom> lstCatComC = db.NhaBep_ListCatCom.Where(s => DbFunctions.TruncateTime(s.NgayCatCom) == thisDate.Date && s.MaDonVi == maC).ToList();

            int sobuoisang = lstCatComC.Count(s => s.BuoiSang == true);
            int sobuoitrua = lstCatComC.Count(s => s.BuoiTrua == true);
            int sobuoitoi = lstCatComC.Count(s => s.BuoiToi == true);
            int quansoC = LoadQuanSoC();
            textEdit4.Text = (quansoC - sobuoisang).ToString();
            textEdit5.Text = (quansoC - sobuoitrua).ToString();
            textEdit11.Text = (quansoC - sobuoitoi).ToString();

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
            //List<DonVi> lstDonVi = db.DonVis.ToList();
            colTenLop.Visible = false;

            LoadDBLop();
        }

        private void dtpNgayL_EditValueChanged(object sender, EventArgs e)
        {
            colTenLop.Visible = false;
            LoadDBLop();
        }

        private void dtpNgayC_EditValueChanged(object sender, EventArgs e)
        {
            colTenLop.Visible = true;
            LoadDBDaiDoi();
        }
    }
}
