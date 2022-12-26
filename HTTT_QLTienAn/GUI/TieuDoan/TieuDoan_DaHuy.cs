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
        public QLTA db = new QLTA();

        public string MaDS_DaHuy;

        public void LoadDSDaHuy()
        {
            try
            {
                var ds_DaHuy = (from ds in db.DanhSachRaNgoais
                                join cbc in db.CanBoes on ds.MaCBc equals cbc.MaCanBo
                                join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo
                                join dv in db.DonVis on cbc.MaDonVi equals dv.MaDonVi

                                where ds.PheDuyet == -1 // tiểu đoàn đã hủy
                                select new
                                {
                                    MaDS = ds.MaDS,
                                    TenDonVi = dv.TenDonVi,
                                    NgayDK = ds.NgayDK,
                                    HoTenc = cbc.HoTen,
                                    HoTend = cbd.HoTen
                                }).ToList();
                if (ds_DaHuy.Count > 0)
                {
                    ds_DaHuy.Reverse();
                    dgvDaHuy_View.OptionsBehavior.Editable = false;
                    gridView2.OptionsBehavior.Editable = false;
                    dgvDaHuy.DataSource = ds_DaHuy;
                }
                else
                {
                    MessageBox.Show("Chưa có danh sách đã hủy nào !");
                    return;
                }
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
                MaDS_DaHuy = mads.ToString();
                var dsCTDaHuy = (from ds in db.DanhSachRaNgoais
                                 join dkn in db.DangKyNghis on ds.MaDS equals dkn.MaDS
                                 join ctn in db.ChiTietCatComs on dkn.MaDangKy equals ctn.MaDangKy
                                 join hv1 in db.HocViens on dkn.MaHocVien equals hv1.MaHocVien
                                 where ds.MaDS == mads
                                 select new
                                 {
                                     HoTen = hv1.HoTen,
                                     Lop = hv1.Lop,
                                     NgayNghi = ctn.NgayCatCom,
                                     SoBuoiSang = ctn.BuoiSang,
                                     SoBuoiTrua = ctn.BuoiTrua,
                                     SoBuoiToi = ctn.BuoiToi
                                 }).ToList();
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
    }
}
