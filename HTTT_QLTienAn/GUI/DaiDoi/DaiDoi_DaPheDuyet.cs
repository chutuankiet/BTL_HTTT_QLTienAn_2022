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
    public partial class DaiDoi_DaPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_DaPheDuyet()
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

        public void LoadDSDaPheDuyet()
        {

            var ds_DaXacNhan = (from ds in db.ds_huy

                                join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo
                                where ds.PheDuyet == 1 && ds.TenDonVi == TenDonVi // tiểu đoàn đã duyệt 
                                select new
                                {
                                    MaDS = ds.MaDS,
                                    NgayDK = ds.NgayDK,
                                    HoTenc = ds.HoTenc,
                                    HoTend = cbd.HoTen
                                }).ToList();

            var ds_DaXacNhan2 = (from ds in db.ds_huy
                                 where ds.PheDuyet == 0 && ds.TenDonVi == TenDonVi//  đại đội duyệt
                                 select new
                                 {
                                     MaDS = ds.MaDS,
                                     NgayDK = ds.NgayDK,
                                     HoTenc = ds.HoTenc,
                                     HoTend = ""
                                 }).ToList();
            foreach (var item in ds_DaXacNhan2)
            {
                ds_DaXacNhan.Add(item);
            }
            if (ds_DaXacNhan.Count > 0)
            {

                dgvDaXacNhan.DataSource = ds_DaXacNhan;

                LoadDSChiTietDaXacNhan(ds_DaXacNhan[0].MaDS);

            }
        }

        public void LoadDSChiTietDaXacNhan(int mads)
        {
            List<DS_ChoPheDuyet> dsCTDaXacNhan = db.DS_ChoPheDuyet.Where(m => m.MaDS == mads).ToList();
            dgvChiTietDaXaNhan.DataSource = dsCTDaXacNhan;
        }

        private void dgvDaXacNhan_View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int mads = Convert.ToInt32(dgvDaXacNhan_View.GetRowCellValue(e.RowHandle, "MaDS"));
            LoadDSChiTietDaXacNhan(mads);
        }

        private void DaiDoi_DaPheDuyet_Load(object sender, EventArgs e)
        {
            int madv = (int)db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi;
            TenDonVi = db.DonVis.Where(m => m.MaDonVi == madv).FirstOrDefault().TenDonVi;
            LoadDSDaPheDuyet();
        }
    }
}
