using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTT_QLTienAn.Model;
using System.Windows.Forms;
using System.Globalization;

namespace HTTT_QLTienAn.GUI
{
    public partial class ThongtinHV : Form
    {
        public ThongtinHV()
        {
            InitializeComponent();
        }
        private int MaDK = 0;
        public bool editable = false;
        public int MaHocVien;
        public int MaDangKy;
        public ThongtinHV(int mahv, int madk, bool edit)
        {
            InitializeComponent();
            MaHocVien = mahv;
            MaDangKy = madk;

            //editable = edit;
            if (!editable) notEditable();

        }

        private void notEditable()
        {
            dateStart.Enabled = false;
            dateEnd.Enabled = false;
            txtSang.Enabled = false;
            txtTrua.Enabled = false;
            txtToi.Enabled = false;
            cbLoaiNghi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        QLTA_model db = new QLTA_model();



        private void ThongtinHV_Load(object sender, EventArgs e)
        {

            lbMaDK.Text = MaDangKy.ToString();
            ChiTietRaNgoai itemChiTiet = db.ChiTietRaNgoais.Where(m => m.MaDangKy == MaDangKy).FirstOrDefault();
            HocVien hv = db.HocViens.Where(m => m.MaHocVien == itemChiTiet.MaHocVien).FirstOrDefault();
            Model.Lop itemLop = db.Lops.Where(m => m.MaLop == hv.MaLop).FirstOrDefault();


            lbMaDS.Text = itemChiTiet.MaDS.ToString();
            lbTenHV.Text = hv.HoTen;
            lbMaHV.Text = hv.MaHocVien.ToString();
            lbTenLop.Text = itemLop.TenLop;
            lbTenDaiDoi.Text = db.DonVis.Where(m => m.MaDonVi == itemLop.MaDonVi).FirstOrDefault().TenDonVi;
            lbTenLoaiHV.Text = db.LoaiHocViens.Where(m => m.MaLHV == hv.MaLHV).FirstOrDefault().TenLHV;

            dateStart.Text = itemChiTiet.NgayDi.ToString("dd/MM/yyyy");
            dateEnd.Text = itemChiTiet.NgayVe.ToString("dd/MM/yyyy");

            ChiTietLoaiNghi itemLoaiNghi = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == itemChiTiet.MaLoaiNghi).FirstOrDefault();

            var dsloainghi = (from ds in db.ChiTietLoaiNghis
                              select new
                              {
                                  ds.TenLoaiNghi,
                                  MaLoaiNghi = ds.MaLoaiNghi
                              }
                              ).ToList();
            cbLoaiNghi.DataSource = dsloainghi;

            var loainghi_hv = (from ct in db.ChiTietRaNgoais
                               join ctln in db.ChiTietLoaiNghis on ct.MaLoaiNghi equals ctln.MaLoaiNghi
                               join hocv in db.HocViens on ct.MaHocVien equals hocv.MaHocVien
                               where hocv.MaHocVien == MaHocVien && ct.MaDangKy == MaDangKy
                               select ctln
                              ).FirstOrDefault();

            cbLoaiNghi.ValueMember = "MaLoaiNghi";
            cbLoaiNghi.DisplayMember = "TenLoaiNghi";
            cbLoaiNghi.SelectedIndex = loainghi_hv.MaLoaiNghi - 1;

            txtSang.Text = loainghi_hv.SoBuoiSang.ToString();
            txtTrua.Text = loainghi_hv.SoBuoiTrua.ToString();
            txtToi.Text = loainghi_hv.SoBuoiToi.ToString();



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ?",
                       "Thoát xem thông tin ?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
