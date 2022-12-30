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
    public partial class Lop_DaHuy : DevExpress.XtraEditors.XtraUserControl
    {
        public Lop_DaHuy()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();

        List<Lop_DSHuy> lstDaHuy;
        private void Lop_DaHuy_Load(object sender, EventArgs e)
        {
            HocVien hv = db.HocViens.Where(m => m.MaHocVien == MainForm.MaID).FirstOrDefault();
            lstDaHuy = db.Lop_DSHuy.Where(m => m.MaLop == hv.MaLop).ToList();

            gridControl1.DataSource = lstDaHuy;

            int mads1 = lstDaHuy[0].MaDS;


        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int mads = lstDaHuy[e.RowHandle].MaDS;
            List<DS_CTLopChoPheDuyet> templist = db.DS_CTLopChoPheDuyet.Where(m => m.MaDS == mads).ToList();
            gridControl2.DataSource = templist;
        }
    }
}
