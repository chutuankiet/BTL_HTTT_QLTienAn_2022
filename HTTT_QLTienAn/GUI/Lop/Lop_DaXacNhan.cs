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
    public partial class Lop_DaXacNhan : UserControl
    {
        public Lop_DaXacNhan()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
        }

        QLTA_model db = new QLTA_model(); 

        private void Lop_DaXacNhan_Load(object sender, EventArgs e)
        {
            CanBo cbo = db.CanBoes.Where(s => s.MaCanBo == MainForm.MaID).FirstOrDefault();
            var danhsach = (from ds in db.DanhSachRaNgoais
                            join cbc in db.CanBoes on ds.MaCBc equals cbc.MaCanBo
                            join cbd in db.CanBoes on ds.MaCBd equals cbd.MaCanBo
                            join dv in db.DonVis on cbc.MaDonVi equals dv.MaDonVi
                            where cbc.MaDonVi == cbo.MaDonVi && ds.PheDuyet == 1

                            select new
                            {
                                ds.MaDS,
                                NgayDangKy = ds.NgayDK,
                                CanBoC = cbc.HoTen,
                                CanBoD = cbd.HoTen
                            }).ToList();
            gridControl1.DataSource = danhsach;
            gridControl2 = null;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[0]));
            var chitiet = (from ds in db.DanhSachRaNgoais
                           join ct in db.ChiTietRaNgoais on ds.MaDS equals ct.MaDS
                           join hv in db.HocViens on ct.MaHocVien equals hv.MaHocVien
                           where ds.MaDS == maDS
                           select new
                           {
                               HoTen = hv.HoTen,
                               Lop = hv.Lop,
                               NgayNghi = ct.NgayDi
                               
                              
                           }).ToList();

        }



    }
}
