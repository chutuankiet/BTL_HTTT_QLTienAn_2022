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
    public partial class DaiDoi_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_ChoPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();

        public int MaDS_XacNhan;

        //private int mads;
        string TenDonVi;

        List<DS_ChoPheDuyet> ds_CTChoPheDuyet = new List<DS_ChoPheDuyet>();

        List<c_ChoPheDuyet> ds_ChoPheDuyet;

        public void LoadDS1()
        {
            try
            {
                ds_ChoPheDuyet = db.c_ChoPheDuyet.Where(m => m.PheDuyet == -3 && m.TenDonVi == TenDonVi).ToList();

                dgvDSCho.DataSource = ds_ChoPheDuyet;

                MaDS_XacNhan = ds_ChoPheDuyet[0].MaDS;

                ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();

                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<c_ChoPheDuyet> ds_ChoPheDuyet = db.c_ChoPheDuyet.Where(m => m.PheDuyet == -3 && m.TenDonVi == TenDonVi).ToList();
                //mads = ds_ChoPheDuyet[0].MaDS;
                int index = gridView1.FocusedRowHandle;
                ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();
                int madk = ds_CTChoPheDuyet[index].MaDangKy;

                //Xoa dữ liệu ở phiếu thanh toán
                PhieuThanhToan ptt = db.PhieuThanhToans.Where(s => s.MaDangKy == madk).FirstOrDefault();
                db.PhieuThanhToans.Remove(ptt);

                //Xóa dữ liệu ở chi tiết cắt cơm
                ChiTietCatCom ctcc = db.ChiTietCatComs.Where(s => s.MaDangKy == madk).FirstOrDefault();
                db.ChiTietCatComs.Remove(ctcc);

                //Xóa dữ liệu ở dkn
                DangKyNghi dkn = db.DangKyNghis.Where(s => s.MaDangKy == madk).FirstOrDefault();
                db.DangKyNghis.Remove(dkn);

                ds_CTChoPheDuyet.RemoveAt(index);
                if (ds_CTChoPheDuyet.Count == 0)
                {
                    c_ChoPheDuyet cho = db.c_ChoPheDuyet.Where(s => s.MaDS == MaDS_XacNhan).FirstOrDefault();
                    //ds_ChoPheDuyet.Remove(cho);
                    DanhSachRaNgoai dsrn = db.DanhSachRaNgoais.Where(s => s.MaDS == MaDS_XacNhan).FirstOrDefault();
                    ds_ChoPheDuyet.Remove(cho);
                    db.DanhSachRaNgoais.Remove(dsrn);
                }
                db.SaveChanges();

                dgvDSCho.DataSource = ds_ChoPheDuyet;
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;

            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {

                var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS == MaDS_XacNhan);
                if (dsn != null)
                {
                    dsn.PheDuyet = -2;
                    dsn.MaCBc = MainForm.MaID;
                    db.SaveChanges();
                    MessageBox.Show("Danh sách đã được huỷ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvDSCho.DataSource = null;
                LoadDS1();
                dgvChiTietDS1.DataSource = null;

            }

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 0;
                dsn.MaCBc = MainForm.MaID;
                db.SaveChanges();
                MessageBox.Show("Danh sách đã được xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Danh sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDSCho.DataSource = null;
            LoadDS1();
            dgvChiTietDS1.DataSource = null;
        }


        private void dgvDSCho_View_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(dgvDSCho_View.GetRowCellValue(e.RowHandle, "MaDS"));
            MaDS_XacNhan = maDS;
            ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();
            dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
        }

        private void DaiDoi_ChoPheDuyet_Load(object sender, EventArgs e)
        {

            int madv = (int)db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault().MaDonVi;

            TenDonVi = db.DonVis.Where(m => m.MaDonVi == madv).FirstOrDefault().TenDonVi;


            LoadDS1();
        }
    }
}
