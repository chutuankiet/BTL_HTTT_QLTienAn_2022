using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HTTT_QLTienAn.Model;

namespace HTTT_QLTienAn.GUI.Lop
{
    public partial class Lop_NhapDS : UserControl
    {
        QLTA_model db = new QLTA_model();

        List<ChiTietRaNgoai> listDK = new List<ChiTietRaNgoai>();

        DanhSachRaNgoai ds = new DanhSachRaNgoai();

    
        public Lop_NhapDS()
        {
            InitializeComponent();
            ds.NgayDK = DateTime.Now;
            ds.PheDuyet = -1;
            ds.MaCBc = MainForm.MaID;
            //ds.MaDS = db.DanhSachRaNgoais.Select(m => m.MaDS).Last();\
            ds.MaDS = 0;
            if(db.DanhSachRaNgoais.Count() > 0)
            {
                ds.MaDS = db.DanhSachRaNgoais.Select(m => m.MaDS).LastOrDefault();
            }








        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            if (edit.SelectedIndex == 2)
            {
                ThongtinHV newform = new ThongtinHV();
                newform.Show();
            }
            else if (edit.SelectedIndex == 1)
            {
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            listDK.RemoveAt(index);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            int MaDK = listDK[index].MaDangKy;


            


        }
    }
}
