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
namespace HTTT_QLTienAn.GUI.DaiDoi
{
    public partial class DaiDoi_DaHuyPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_DaHuyPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();

        string TenDonVi;
        public void reload()
        {
            LoadDSDaHuy();
        }

        public void LoadDSDaHuy()
        {

            var ds_DaHuy = (from ds in db.ds_huy
                            join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo
                            where ds.PheDuyet == -1 && ds.TenDonVi == TenDonVi // tiểu đoàn đã hủy 
                            select new
                            {
                                MaDS = ds.MaDS,
                                NgayDK = ds.NgayDK,
                                HoTenc = "",
                                HoTend = cbd.HoTen
                            }).ToList();

            var ds_dahuy2 = (from ds in db.ds_huy
                             where ds.PheDuyet == -2 && ds.TenDonVi == TenDonVi//  đại đội hủy
                             select new
                             {
                                 MaDS = ds.MaDS,
                                 NgayDK = ds.NgayDK,
                                 HoTenc = ds.HoTenc,
                                 HoTend = ""
                             }).ToList();


            ds_DaHuy.AddRange(ds_dahuy2);


            if (ds_DaHuy.Count > 0)
            {
                dgvDaHuy.DataSource = ds_DaHuy;
            }

        }

        private void DaiDoi_DaHuyPheDuyet_Load(object sender, EventArgs e)
        {
            int madv = (int)db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi;

            TenDonVi = db.DonVis.Where(m => m.MaDonVi == madv).FirstOrDefault().TenDonVi;
            LoadDSDaHuy();
        }

        private void dgvDaHuy_View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(dgvDaHuy_View.GetRowCellValue(e.RowHandle, "MaDS"));

            List<DS_ChoPheDuyet> dsCTDaHuy = db.DS_ChoPheDuyet.Where(m => m.MaDS == maDS).ToList();

            dgvChiTietDaHuy.DataSource = dsCTDaHuy;
        }
    }
}
