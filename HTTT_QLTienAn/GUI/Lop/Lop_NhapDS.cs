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
            //ds.MaDS = db.DanhSachRaNgoais.Select(m => m.MaDS).Last();

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

        private int MaHVCurrent = 0;

        //private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //    MaHVCurrent= Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
        //    txtHoTen.EditValue = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
        //    txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();


        //}

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
            txtHoTen.EditValue = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
        }

        private void Lop_NhapDS_Load(object sender, EventArgs e)
        {
            List<ChiTietLoaiNghi> LoaiNghis = db.ChiTietLoaiNghis.Select(m => m).ToList();

            cbLoainghi.DataSource = LoaiNghis;
            cbLoainghi.ValueMember = "MaLoaiNghi";
            cbLoainghi.DisplayMember = "TenLoaiNghi";


            var DSHocVien = (
                from a in db.HocViens
                join b in db.Lops on a.MaLop equals b.MaLop
                select new Model.HocVien_DangKiNghi
                {
                    MaHocVien = a.MaHocVien,
                    HoTen = a.HoTen,
                    NgaySinh = a.NgaySinh,
                    Lop = b.TenLop,
                    NgayBDNghi = DateTime.Now,
                    NgayKTNghi = DateTime.Now

                }).ToList();
            dsLop.DataSource = DSHocVien;


        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
            txtHoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();
        }
    }
}
