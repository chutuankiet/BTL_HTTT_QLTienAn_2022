using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTT_QLTienAn.Model;
using System.Windows.Forms;

namespace HTTT_QLTienAn.GUI
{
    public partial class Chung_DSPhanHoi : DevExpress.XtraEditors.XtraUserControl
    {
        public Chung_DSPhanHoi(string userrole)
        {
            role = userrole;
            InitializeComponent();
        }
        string role;
        QLTA_model db = new QLTA_model();

        public void reload()
        {
            List<Chung_GetPhanHoi> lstPhanHoi;


            lstPhanHoi = db.Chung_GetPhanHoi.SqlQuery("Select * from Chung_GetPhanHoi ").ToList<Chung_GetPhanHoi>();




            if (role == "c" || role == "d")
            {
                gridControl1.DataSource = lstPhanHoi;

            }
            else if (role == "l")
            {
                gridControl1.DataSource = lstPhanHoi.Where(m => m.MaLopTruong == MainForm.MaID);

            }
            else
            {
                gridControl1.DataSource = lstPhanHoi;
            }
        }

        private void Chung_DSPhanHoi_Load(object sender, EventArgs e)
        {

            reload();

        }
    }
}
