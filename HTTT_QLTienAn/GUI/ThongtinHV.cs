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

namespace HTTT_QLTienAn.GUI
{
    public partial class ThongtinHV : Form
    {
        public ThongtinHV()
        {
            InitializeComponent();
        }
        private int MaDK = 0;

        QLTA_model db = new QLTA_model();

        public ThongtinHV(int madangky)
        {
            InitializeComponent();
            MaDK = madangky;
        }

        private void ThongtinHV_Load(object sender, EventArgs e)
        {

            lbMaDK.Text= MaDK.ToString();
            ChiTietRaNgoai itemChiTiet = db.ChiTietRaNgoais.Where(m => m.MaDangKy == MaDK).FirstOrDefault();
            HocVien hv = db.HocViens.Where(m => m.MaHocVien == itemChiTiet.MaHocVien).FirstOrDefault();
            Model.Lop itemLop = db.Lops.Where(m => m.MaLop == hv.MaLop).FirstOrDefault();
            
            
            lbTenHV.Text = hv.HoTen;
            lbMaHV.Text = hv.MaHocVien.ToString();
            lbTenLop.Text = itemLop.TenLop;
            lbTenDaiDoi.Text = db.DonVis.Where(m => m.MaDonVi == itemLop.MaDonVi).FirstOrDefault().TenDonVi;
            lbTenLoaiHV.Text = db.LoaiHocViens.Where(m => m.MaLHV == hv.MaLHV).FirstOrDefault().TenLHV;

            dateStart.Text = itemChiTiet.NgayDi.ToString();
            dateEnd.Text = itemChiTiet.NgayVe.ToString();

            ChiTietLoaiNghi itemLoaiNghi = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == itemChiTiet.MaLoaiNghi).FirstOrDefault();

            listLoaiNghi.Select


        }
    }
}
