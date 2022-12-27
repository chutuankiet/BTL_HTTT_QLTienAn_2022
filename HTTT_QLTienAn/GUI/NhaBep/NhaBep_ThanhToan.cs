using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTT_QLTienAn.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HTTT_QLTienAn.GUI.NhaBep
{
    public partial class NhaBep_ThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public NhaBep_ThanhToan()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();


        int MaDVCurrent;
        int MaLopCurrent;

        bool ishasLop;
        List<DonVi> lstDonVi;

        List<Model.Lop> lstLopHocVien;

        
        List<NhaBep_ListThanhToan> lstDaThanhToan;
        List<NhaBep_ListThanhToan> lstChuaThanhToan;



        private void NhaBep_ThanhToan_Load(object sender, EventArgs e)
        {
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;

            lstDonVi = db.DonVis.Where(s => s.TenDonVi.Contains("c")).ToList();



            foreach (var item in lstDonVi)
            {
                cbbDonVi.Items.Add(item.TenDonVi);
            }

            cbbDonVi.SelectedIndex = 1;

            MaDVCurrent = lstDonVi[0].MaDonVi;

            cbbLop.SelectedIndex = -1;
            cbbLop.Text = "";


            ishasLop = false;


            LoadDataGrid();


            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;

        }





        void LoadDataGrid()
        {
            List<NhaBep_ListThanhToan> lstThanhToan;
            lstThanhToan = new List<NhaBep_ListThanhToan>();
            //lstThanhToan = db.NhaBep_ListThanhToan.ToList();

            using(var ctx  = new Model.QLTA_model())
            {
                lstThanhToan = ctx.NhaBep_ListThanhToan.SqlQuery("Select * from NhaBep_ListThanhToan").ToList<NhaBep_ListThanhToan>();
            }


            gridControl1.DataSource = null;
            gridControl2.DataSource = null;

            if (ishasLop)
            {
                lstDaThanhToan = lstThanhToan.Where(s => s.MaDonVi == MaDVCurrent && s.MaLop == MaLopCurrent && s.TrangThaiTT == 1).ToList();

                lstChuaThanhToan = lstThanhToan.Where(m => m.TrangThaiTT == -2 && m.MaDonVi == MaDVCurrent && m.MaLop == MaLopCurrent).ToList();
            }
            else
            {
                lstDaThanhToan = lstThanhToan.Where(s => s.MaDonVi == MaDVCurrent && s.TrangThaiTT == 1).ToList();

                lstChuaThanhToan = lstThanhToan.Where(m => m.TrangThaiTT == -2 && m.MaDonVi == MaDVCurrent).ToList();
            }

            gridControl1.DataSource = lstDaThanhToan;

            gridControl2.DataSource = lstChuaThanhToan;
            LoadSummary();
        }



        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {


            //LoadDataGridControl12(ishasLop);
            //LoadSummary();

            int index = cbbDonVi.SelectedIndex;

            MaDVCurrent = lstDonVi[index].MaDonVi;
            lstLopHocVien = new List<Model.Lop>();

            lstLopHocVien = db.Lops.Where(m => m.MaDonVi == MaDVCurrent).ToList();

            if(lstLopHocVien.Count > 0)
            {

                cbbLop.Items.Clear();

                foreach (var item in lstLopHocVien)
                {
                    cbbLop.Items.Add(item.TenLop.ToString());
                }
                cbbLop.SelectedIndex = 0;
                MaLopCurrent = lstLopHocVien[0].MaLop;
                ishasLop = false;

            }
            else
            {
                ishasLop = false;
            }

            LoadDataGrid();
            


        }

        private void LoadSummary()
        {
            int TongSoSang = 0;
            int TongSoTrua = 0;
            int TongSoToi = 0;
            int TongSoTien1 = 0;
            foreach (var item in lstChuaThanhToan)
            {
                TongSoSang += (int)item.SoBuoiSang;
                TongSoTrua += (int)item.SoBuoiTrua;
                TongSoToi += (int)item.SoBuoiToi;
                TongSoTien1 += item.TongTien;
            }

            txtSang.Text = TongSoSang.ToString();
            txtTrua.Text = TongSoTrua.ToString();
            txtToi.Text = TongSoToi.ToString();
            txtTongTien.Text = TongSoTien1.ToString();


        }



 
        private void ClearList()
        {
            lstDaThanhToan = new List<NhaBep_ListThanhToan>();
            lstChuaThanhToan = new List<NhaBep_ListThanhToan>();
        }

       

        private void ClearDataShowed()
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

            gridControl2.BeginUpdate();
            try
            {
                gridControl2.DataSource = null;
                gridControl2.Refresh();
            }
            finally
            {
                gridControl2.EndUpdate();
            }

            //Clear TextBox:

        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbbLop.SelectedIndex;

            MaLopCurrent = lstLopHocVien[index].MaLop;

            ishasLop = true;

            LoadDataGrid();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {


            //UndoingChangesDbContextLevel(db);

            foreach (var itemTT in lstChuaThanhToan)
            {
                PhieuThanhToan ptt = db.PhieuThanhToans.Where(m => m.MaThanhToan == itemTT.MaThanhToan).FirstOrDefault();

                ptt.NgayTT = DateTime.Today;

                ptt.TrangThaiTT = 1;
                ptt.MaCBNhaBep = MainForm.MaID;
                db.Entry(ptt).State = EntityState.Modified;
                db.SaveChanges();

            }


            MessageBox.Show("Đã thanh toán thành công !");

            ClearList();
            //LoadDataGridControl12(true);

            ClearDataShowed();

            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            txtSang.Text = txtToi.Text = txtTrua.Text = txtTongTien.Text = "0";
            ishasLop = true;
            

            LoadDataGrid();
        }

      

        public static void UndoingChangesDbContextLevel(DbContext context)
        {
            foreach (DbEntityEntry entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ClearList();
            ishasLop = false;
            LoadDataGrid();


        }

     
    }
}
