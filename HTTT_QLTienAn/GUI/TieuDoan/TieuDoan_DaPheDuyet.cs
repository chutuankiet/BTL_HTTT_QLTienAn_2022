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
    public partial class TieuDoan_DaPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public TieuDoan_DaPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA db = new QLTA();


        public string MaDS_DaXacNhan;

        public void LoadDSDaPheDuyet()
        {
            try
            {
                var ds_DaXacNhan = (from ds in db.DanhSachRaNgoais
                                    join cbc in db.CanBoes on ds.MaCBc equals cbc.MaCanBo
                                    join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo
                                    join dv in db.DonVis on cbc.MaDonVi equals dv.MaDonVi
                                    where ds.PheDuyet == 1
                                    select new
                                    {
                                        MaDS = ds.MaDS,
                                        TenDonVi = dv.TenDonVi,
                                        NgayDK = ds.NgayDK,
                                        HoTenc = cbc.HoTen,
                                        HoTend = cbd.HoTen
                                    }).ToList();

                if (ds_DaXacNhan.Count > 0)
                {
                    ds_DaXacNhan.Reverse();
                    dgvDaXacNhan_View.OptionsBehavior.Editable = false;
                    gridView2.OptionsBehavior.Editable = false;
                    dgvDaXacNhan.DataSource = ds_DaXacNhan;
                    LoadDSChiTietDaXacNhan(ds_DaXacNhan[0].MaDS);

                }


            }
            catch
            { }
        }

        public void LoadDSChiTietDaXacNhan(int mads)
        {
            try
            {

                var dsCTDaXacNhan = (from ds in db.DanhSachRaNgoais
                                     join dkn in db.DangKyNghis on ds.MaDS equals dkn.MaDS
                                     join ctn in db.ChiTietCatComs on dkn.MaDangKy equals ctn.MaDangKy
                                     join hv1 in db.HocViens on dkn.MaHocVien equals hv1.MaHocVien
                                     join l in db.Lops on hv1.MaLop equals l.MaLop
                                     where ds.MaDS == mads
                                     select new
                                     {
                                         HoTen = hv1.HoTen,
                                         Lop =l.TenLop,
                                         NgayNghi = ctn.NgayCatCom,
                                         SoBuoiSang = ctn.BuoiSang,
                                         SoBuoiTrua = ctn.BuoiTrua,
                                         SoBuoiToi = ctn.BuoiToi
                                     }).ToList();
                dgvChiTietDaXacNhan.DataSource = dsCTDaXacNhan;

            }
            catch
            { }

        }



        private void dgvDaXacNhan_Load(object sender, EventArgs e)
        {
            LoadDSDaPheDuyet();

        }

        private void dgvDaXacNhan_View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            LoadDSChiTietDaXacNhan(Convert.ToInt32(dgvDaXacNhan_View.GetRowCellValue(e.RowHandle, "MaDS")));
        }
    }
}
