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


namespace HTTT_QLTienAn.GUI.DaiDoi
{
    public partial class NhapDanhSach : UserControl
    {
        QLTA_model db = new QLTA_model();

        public NhapDanhSach()
        {
            InitializeComponent();
        }

        private void pnTranhThu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ThemHocVien_Load(object sender, EventArgs e)
        {
            string tenlop = "An ninh hệ thống thông tin";
            gridControl2.DataSource = db.HocViens.Where(s => s.Lop.TenLop == tenlop).ToList();
            gridControl1.DataSource = db.HocViens.ToList();
            int count;
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
