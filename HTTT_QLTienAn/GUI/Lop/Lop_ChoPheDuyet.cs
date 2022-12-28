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
    public partial class Lop_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public Lop_ChoPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();

        List<DS_LopChoPheDuyet> ds_ChoPheDuyet;

        List<DS_CTLopChoPheDuyet> ds_CTChoPheDuyet;


        Model.Lop targetLop;


        int MaDS_XacNhan;
        public void LoadDS1()
        {
            try
            {
                ds_ChoPheDuyet = db.DS_LopChoPheDuyet.Where(m => m.MaLop == targetLop.MaLop).ToList();

                gridControl1.DataSource = ds_ChoPheDuyet;

                MaDS_XacNhan = ds_ChoPheDuyet[0].MaDS;

                ds_CTChoPheDuyet = db.DS_CTLopChoPheDuyet.Where(m => m.MaLop == targetLop.MaLop).ToList();

                gridControl2.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }




        private void Lop_ChoPheDuyet_Load(object sender, EventArgs e)
        {
            targetLop = db.Lops.Where(m => m.MaLopTruong == MainForm.MaID).FirstOrDefault();

            LoadDS1();

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaDS"));

            MaDS_XacNhan = maDS;
            List<DS_CTLopChoPheDuyet> temp = ds_CTChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();

            gridControl2.DataSource = temp; 
        }
    }
}
