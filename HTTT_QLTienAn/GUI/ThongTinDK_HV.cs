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

namespace HTTT_QLTienAn.GUI
{
    public partial class ThongTinDK_HV : DevExpress.XtraEditors.XtraForm
    {
        public ThongTinDK_HV()
        {
            InitializeComponent();
        }

        private int MaDK = 0;
        public bool editable = false;
        public int MaHocVien;
        public int MaDangKy;

        private DangKyNghi chitietrn;
        public ThongTinDK_HV(int madk, bool edit)
        {
            InitializeComponent();
            MaDangKy = madk;

            chitietrn = db.DangKyNghis.Where(m => m.MaDangKy == madk).FirstOrDefault();

            MaHocVien = (int)chitietrn.MaHocVien;

            //editable = edit;
            if (editable) notEditable();

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

        List<LoaiNghi> ListLoaiNghi;



        private void ThongTinDK_HV_Load(object sender, EventArgs e)
        {

            lbMaDK.Text = MaDangKy.ToString();

            HocVien hv = db.HocViens.Where(m => m.MaHocVien == chitietrn.MaHocVien).FirstOrDefault();

            Model.Lop itemLop = db.Lops.Where(m => m.MaLop == hv.MaLop).FirstOrDefault();


            lbMaDS.Text = chitietrn.MaDS.ToString();
            lbTenHV.Text = hv.HoTen;
            lbMaHV.Text = hv.MaHocVien.ToString();
            lbTenLop.Text = itemLop.TenLop;
            lbTenDaiDoi.Text = db.DonVis.Where(m => m.MaDonVi == itemLop.MaDonVi).FirstOrDefault().TenDonVi;
            lbTenLoaiHV.Text = db.LoaiHocViens.Where(m => m.MaLHV == hv.MaLHV).FirstOrDefault().TenLHV;

            dateStart.DateTime = chitietrn.NgayDi;
            dateEnd.DateTime = chitietrn.NgayVe;

            LoaiNghi itemLoaiNghi = db.LoaiNghis.Where(m => m.MaLoaiNghi == chitietrn.MaLoaiNghi).FirstOrDefault();


            //var dsloainghi = (from ds in db.LoaiNghis
            //                  select new
            //                  {
            //                      ds.TenLoaiNghi,
            //                      MaLoaiNghi = ds.MaLoaiNghi
            //                  }
            //                  ).ToList();

            ListLoaiNghi = db.LoaiNghis.ToList();


            cbLoaiNghi.DataSource = ListLoaiNghi;

            var loainghi_hv = (from ct in db.DangKyNghis
                               join ctln in db.LoaiNghis on ct.MaLoaiNghi equals ctln.MaLoaiNghi
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

        private void btnSua_Click(object sender, EventArgs e)
        {

            chitietrn.NgayDi = dateStart.DateTime;
            chitietrn.NgayVe = dateEnd.DateTime;


            chitietrn.MaLoaiNghi = cbLoaiNghi.SelectedIndex;

            db.SaveChanges();

            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void cbLoaiNghi_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = cbLoaiNghi.SelectedIndex;
            txtSang.Text = ListLoaiNghi[index].SoBuoiSang.ToString();
            txtTrua.Text = ListLoaiNghi[index].SoBuoiTrua.ToString();
            txtToi.Text = ListLoaiNghi[index].SoBuoiToi.ToString();
        }
    }
}