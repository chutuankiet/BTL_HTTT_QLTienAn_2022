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
namespace HTTT_QLTienAn.GUI.TieuDoan
{
    public partial class TieuDoan_DaHuy : DevExpress.XtraEditors.XtraUserControl
    {
        public TieuDoan_DaHuy()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        public void reload()
        {
            LoadDSDaHuy();
        }
        public void LoadDSDaHuy()
        {
            try
            {
                var ds_DaHuy = (from ds in db.ds_huy 
                                join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo

                                where ds.PheDuyet == -1 // tiểu đoàn đã hủy
                                select new
                                {
                                    MaDS = ds.MaDS,
                                    TenDonVi = ds.TenDonVi,
                                    NgayDK = ds.NgayDK,
                                    HoTenc = ds.HoTenc,
                                    HoTend = cbd.HoTen
                                }).ToList();
                if (ds_DaHuy.Count > 0)
                {
                    dgvDaHuy_View.OptionsBehavior.Editable = false;
                    gridView2.OptionsBehavior.Editable = false;
                    dgvDaHuy.DataSource = ds_DaHuy;
                }
                //else
                //{
                //    MessageBox.Show("Chưa có danh sách đã hủy nào !");
                //    return;
                //}
            }
            catch
            { }
            //LoadDSChiTietDaHuy();
        }

        public void LoadDSChiTietDaHuy()
        {
            try
            {
                int mads = (int)dgvDaHuy_View.GetFocusedRowCellValue("MaDS");
                List<DS_ChoPheDuyet> dsCTDaHuy = db.DS_ChoPheDuyet.Where(m => m.MaDS == mads).ToList();
                dgvChiTietDaHuy.DataSource = dsCTDaHuy;

            }
            catch
            { }
        }

        private void dgvDaHuy_Load(object sender, EventArgs e)
        {
            LoadDSDaHuy();

        }

        private void dgvDaHuy_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDSChiTietDaHuy();

        }

        private void TieuDoan_DaHuy_Load(object sender, EventArgs e)
        {
            LoadDSDaHuy();
        }
    }
}
