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
namespace HTTT_QLTienAn.GUI.NhaBep
{
    public partial class NhaBep_LSCatCom : UserControl
    {
        public NhaBep_LSCatCom()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();
        private void NhaBep_LSThanhToan_Load(object sender, EventArgs e)
        {
            dateStart.DateTime = DateTime.Today.AddDays(-30);
            dateEnd.DateTime = DateTime.Today;

            LoadLS_Base();

        }

        //List<db.NhaBep_LSThanhToan> dsLsTT = new List<db.NhaBep_LSThanhToan>();
        List<DS_DaThanhToan> dsTT = new List<DS_DaThanhToan>();

        void LoadLS_Base()
        {
            List<DS_DaThanhToan> dsTT = db.DS_DaThanhToan.OrderBy(m => m.NgayTT).ToList();
            gridControl1.DataSource = dsTT;
        }


        void Load_LSThanhToan()
        {
            gridControl1.DataSource = null;
            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;
            List<DS_DaThanhToan> dsTT = db.DS_DaThanhToan.OrderBy(m => m.NgayTT).ToList();
            gridControl1.DataSource = dsTT.Where(m => DateTime.Compare(m.NgayTT.Date, start.Date) >= 0 && DateTime.Compare(m.NgayTT.Date, end.Date) <= 0);


        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Load_LSThanhToan();
        }
    }
}
