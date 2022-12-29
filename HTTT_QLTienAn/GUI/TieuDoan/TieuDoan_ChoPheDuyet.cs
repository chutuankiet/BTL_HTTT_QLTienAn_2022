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
    public partial class TieuDoan_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public TieuDoan_ChoPheDuyet()
        {
            InitializeComponent();
            
        }
        public QLTA_model db = new QLTA_model();

        List<DS_ChoPheDuyet> ds_CTChoPheDuyet = new List<DS_ChoPheDuyet>();

        static int maCBd;
        public int MaDS_XacNhan;
        private int mads;




        public void LoadDS1()
        {
            try
            {
                var ds_ChoPheDuyet = (from ds in db.DanhSachRaNgoais
                                      join cb in db.CanBoes on ds.MaCBc equals cb.MaCanBo
                                      join dv in db.DonVis on cb.MaDonVi equals dv.MaDonVi
                                      where ds.PheDuyet == 0
                                      select new
                                      {
                                          MaDS = ds.MaDS,
                                          TenDonVi = dv.TenDonVi,
                                          NgayDK = ds.NgayDK,
                                          HoTen = cb.HoTen
                                      }).ToList();


              
                dgvDSCho.DataSource = ds_ChoPheDuyet;

                mads = ds_ChoPheDuyet[0].MaDS;
                MaDS_XacNhan = mads;
                ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m=> m.MaDS == mads).ToList();
               
               
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<c_ChoPheDuyet> ds_ChoPheDuyet = db.c_ChoPheDuyet.Where(m => m.PheDuyet == 0).ToList();
                //mads = ds_ChoPheDuyet[0].MaDS;
                int index = gridView2.FocusedRowHandle;
                ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();
                int madk = ds_CTChoPheDuyet[index].MaDangKy;
                PhieuThanhToan ptt = db.PhieuThanhToans.Where(s => s.MaDangKy == madk).FirstOrDefault();

                db.PhieuThanhToans.Remove(ptt);
                ChiTietCatCom ctcc = db.ChiTietCatComs.Where(s => s.MaDangKy == madk).FirstOrDefault();
                db.ChiTietCatComs.Remove(ctcc);
                DangKyNghi dkn = db.DangKyNghis.Where(s => s.MaDangKy == madk).FirstOrDefault();

                db.DangKyNghis.Remove(dkn);
                ds_CTChoPheDuyet.RemoveAt(index);
                if (ds_CTChoPheDuyet.Count == 0)
                {
                    ds_ChoPheDuyet.RemoveAt(0);
                    DanhSachRaNgoai dsrn = db.DanhSachRaNgoais.Where(s => s.MaDS == MaDS_XacNhan).FirstOrDefault();
                    db.DanhSachRaNgoais.Remove(dsrn);
                }
                dgvDSCho.DataSource = ds_ChoPheDuyet;
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
                db.SaveChanges();

            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {

                var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS == MaDS_XacNhan);
                if (dsn != null)
                {
                    dsn.PheDuyet = -1;
                    dsn.MaCBd = MainForm.MaID;
                    db.SaveChanges();
                    MessageBox.Show("Danh sách đã được huỷ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvDSCho.DataSource = null;
                LoadDS1();
                //dgvChiTietDS1.DataSource = null;

            }

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS == MaDS_XacNhan);
            if (dsn != null)
            {
                List<DangKyNghi> Lst_dkn = db.DangKyNghis.Where(m => m.MaDS == dsn.MaDS).ToList();

                foreach(var item in Lst_dkn)
                {
                    int maTCA = (int)db.HocViens.Where(m => m.MaHocVien == item.MaHocVien).FirstOrDefault().LoaiHocVien.MaTCA;

                    TieuChuanAn tca_hv = db.TieuChuanAns.Where(m => m.MaTCA == maTCA).FirstOrDefault();

                    LoaiNghi ln_hv = db.LoaiNghis.Where(m => m.MaLoaiNghi == item.MaLoaiNghi).FirstOrDefault();


                    using (var context = new QLTA_model())
                    {
                        PhieuThanhToan newThanhToan = new PhieuThanhToan
                        {
                            TrangThaiTT = -2,
                            MaDangKy = item.MaDangKy, //---------------------------------------
                            TongTien = (int)ln_hv.SoBuoiSang * tca_hv.TienAnSang +
                                    (int)ln_hv.SoBuoiTrua * tca_hv.TienAnTrua +
                                    (int)ln_hv.SoBuoiToi * tca_hv.TienAnToi
                        };

                        context.PhieuThanhToans.Add(newThanhToan);


                        context.SaveChanges();

                    }
                }


                dsn.PheDuyet = 1;
                dsn.MaCBd = MainForm.MaID;
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

            int maDS = Convert.ToInt32(dgvDSCho_View.GetRowCellValue(e.RowHandle, "MaDS")); ;
            MaDS_XacNhan = maDS;
            List<DS_ChoPheDuyet> ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == MaDS_XacNhan).ToList();
            //ds_CTChoPheDuyet.Reverse();
            //dgvDSCho_View.OptionsBehavior.Editable = false;
            //gridView2.OptionsBehavior.Editable = false;
            dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
        }

        private void TieuDoan_ChoPheDuyet_Load(object sender, EventArgs e)
        {
            LoadDS1();
        }
    }
}
