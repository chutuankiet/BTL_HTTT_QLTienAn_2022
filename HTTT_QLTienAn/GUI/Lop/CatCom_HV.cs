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
    public partial class CatCom_HV : DevExpress.XtraEditors.XtraForm
    {

        DateTime NgayBDnghi;
        DateTime NgayKTnghi;
        int MaLoaiNghi;
        int MaDK;
        public CatCom_HV(DateTime start, DateTime end, int madk, int maloainghi)
        {
            InitializeComponent();
            NgayBDnghi = start;
            NgayKTnghi = end;
            MaDK = madk;
            MaLoaiNghi = maloainghi;
        }
        List<ChiTietCatCom> lsCatCom= new List<ChiTietCatCom>();
        private void CatCom_HV_Load(object sender, EventArgs e)
        {
            int songay = (NgayKTnghi.Date - NgayBDnghi.Date).Days;
            DateTime runday = NgayBDnghi ;
            for(int i = 0;i <= songay; i++)
            {
                ChiTietCatCom newct = new ChiTietCatCom
                {
                    NgayCatCom = runday
                };

                runday = runday.AddDays(1);
                lsCatCom.Add(newct);
            }

            gridControl1.DataSource = lsCatCom; 


        }
    }
}