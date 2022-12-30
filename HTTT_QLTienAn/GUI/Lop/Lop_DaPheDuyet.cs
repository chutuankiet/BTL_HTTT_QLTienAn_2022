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



namespace HTTT_QLTienAn.GUI.Lop
{
    public partial class Lop_DaPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public Lop_DaPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();

        string TenDonVi;
        public string MaDS_DaXacNhan;


        public void reload()
        {
            LoadDSDaPheDuyet();
        }

        Model.Lop LopTarget;

        List<DS_Lop_DaPheDuyet> ds_DaXacNhan;
        public void LoadDSDaPheDuyet()
        {

            ds_DaXacNhan = db.DS_Lop_DaPheDuyet.Where(m => m.PheDuyet == 1 && m.MaLop == LopTarget.MaLop).ToList();



            if (ds_DaXacNhan.Count > 0)
            {
                gridControl1.DataSource = ds_DaXacNhan;

                LoadDSChiTietDaXacNhan(ds_DaXacNhan[0].MaDS);
            }
        }

        public void LoadDSChiTietDaXacNhan(int mads)
        {
            List<DS_ChoPheDuyet> dsCTDaXacNhan = db.DS_ChoPheDuyet.Where(m => m.MaDS == mads).ToList();
            gridControl2.DataSource = dsCTDaXacNhan;
        }

        private void Lop_DaPheDuyet_Load(object sender, EventArgs e)
        {
            LopTarget = db.Lops.Where(m => m.MaLopTruong == MainForm.MaID).FirstOrDefault();

            LoadDSDaPheDuyet();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int index = e.RowHandle;
            int mads = ds_DaXacNhan[index].MaDS;
            LoadDSChiTietDaXacNhan(mads);
        }
    }
}
