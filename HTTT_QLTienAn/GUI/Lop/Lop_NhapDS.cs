using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

        List<HocVien_DangKiNghi> listDK = new List<HocVien_DangKiNghi>();

        DanhSachRaNgoai ds = new DanhSachRaNgoai();

        List<LoaiNghi> ListLoaiNghi = new List<LoaiNghi>();


        // danh sách đăng ký nghỉ được lưu tạm tại listDK
        // danh sách chi tiết cắt cơm lưu tạm tại lsCTCatCom


        public Lop_NhapDS()
        {
            InitializeComponent();


        }

        int MaLopTruong = 0;
        int MaLop = 0;

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int index = gridView2.FocusedRowHandle;

                //foreach(var item in lsCTCatCom)
                //{
                //    if(item.MaDangKyTam == )
                //    {
                //        lsCTCatCom.Remove(item);
                //    }
                //}

                lsCTCatCom.RemoveAll(m => m.MaDangKyTam == listDK[index].MaDangKyTam);

                //MessageBox.Show("count = "+lsCTCatCom.Count.ToString());

                listDK.RemoveAt(index);
                gridControl2.DataSource = null;
                gridControl2.DataSource = listDK;
            }
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            //int index = gridView2.FocusedRowHandle;
            //int MaDK = listDK[index].MaDangKy;



        }

        private int MaHVCurrent = 0;
        private int MaDKTamCurrent = 0;

        //private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //    MaHVCurrent= Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
        //    txtHoTen.EditValue = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
        //    txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();


        //}

        public void reloadCombox(object sender, FormClosedEventArgs e)
        {
            cbLoainghi.DataSource = null;
            ListLoaiNghi = db.LoaiNghis.ToList();

            cbLoainghi.DataSource = ListLoaiNghi;

            cbLoainghi.ValueMember = "MaLoaiNghi";
            cbLoainghi.DisplayMember = "TenLoaiNghi";
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            MaHVCurrent = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaHocVien")); ;
            txtHoTen.EditValue = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            txtLop.Text = gridView1.GetRowCellValue(e.RowHandle, "Lop").ToString();

        }



        private void Lop_NhapDS_Load(object sender, EventArgs e)
        {
            MaLopTruong = MainForm.MaID;
            Model.Lop tempLop = db.Lops.Where(m => m.MaLopTruong == MaLopTruong).FirstOrDefault();

            MaLop = tempLop.MaLop;


            dateStart.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now;

            ListLoaiNghi = db.LoaiNghis.ToList();

            cbLoainghi.DataSource = ListLoaiNghi;

            cbLoainghi.ValueMember = "MaLoaiNghi";
            cbLoainghi.DisplayMember = "TenLoaiNghi";



            var DSHocVien = (
                from a in db.HocViens
                join b in db.Lops on a.MaLop equals b.MaLop
                where b.MaLop == MaLop
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


        private void SetDefaultState()
        {
            listDK.Clear();

            txtHoTen.Text = "";
            txtLop.Text = "";
            txtLyDo.Text = "";
            txtSang.Text = "";
            txtTrua.Text = "";
            txtToi.Text = "";


            dateStart.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now;

            gridControl2.DataSource = null;
        }


        private void btnThemLoaiNghi_Click(object sender, EventArgs e)
        {
            ThemLoaiNghi newform = new ThemLoaiNghi();
            newform.FormClosed += new FormClosedEventHandler(reloadCombox);
            newform.Show();
        }

        int sobuoinghi;

        private void cbLoainghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbLoainghi.SelectedIndex;
            txtSang.Text = ListLoaiNghi[index].SoBuoiSang.ToString();
            txtTrua.Text = ListLoaiNghi[index].SoBuoiTrua.ToString();
            txtToi.Text = ListLoaiNghi[index].SoBuoiToi.ToString();
            txtLyDo.Text = ListLoaiNghi[index].TenLoaiNghi;

            int maloainghi = ListLoaiNghi[index].MaLoaiNghi;
            sobuoinghi = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == maloainghi).Count();


            dateEnd.DateTime = dateStart.DateTime.AddDays(sobuoinghi - 1);

        }


        List<CT_CatCom_HocVien> lsCTCatCom = new List<CT_CatCom_HocVien>();


        bool IsNotDupDate(HocVien_DangKiNghi hv)
        {
            for (int i = 0; i < listDK.Count; i++)
            {

                if (listDK[i].MaHocVien == hv.MaHocVien)
                {

                    DateTime temp = hv.NgayBDNghi;

                    for (int j = 0; j < sobuoinghi; j++)
                    {

                        foreach (var item_cc in lsCTCatCom)
                        {

                            if (item_cc.NgayCatCom.ToString("dd/MM/yyyy") == temp.ToString("dd/MM/yyyy") && item_cc.MaDangKyTam != listDK[i].MaDangKyTam)
                            {
                                MessageBox.Show($"Đã tồn đăng ký trong danh sách", "Thông báo !");
                                return false;

                            }
                        }
                        temp = temp.AddDays(1);

                        //int isInCT = lsCTCatCom.Where(m => m.NgayCatCom.ToString("dd/MM/yyyy") == temp.ToString("dd/MM/yyyy") ).Count();
                        //&& 
                    }
                }
            }

            // check trung ngay trong csdl
            DateTime ngayTemp = hv.NgayBDNghi;
            while (DateTime.Compare(ngayTemp.AddDays(1), hv.NgayKTNghi) < 0)
            {
                var isDupInDB = db.ChiTietCatComs.Where(x => x.NgayCatCom == ngayTemp && x.DangKyNghi.MaHocVien == hv.MaHocVien).FirstOrDefault();

                if (isDupInDB != null)
                {
                    MessageBox.Show($"Đã tồn tại đăng ký tại ngày {hv.NgayBDNghi.ToString("dd-MM-yyyy")}", "Thông báo !");
                    return false;
                }

                ngayTemp = ngayTemp.AddDays(1);

            }

            return true;
        }

        bool checkDateTT()
        {
            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;
            if (DateTime.Compare(start, end) > 0)
            {
                MessageBox.Show("Ngày trả phép phải sau hoặc bằng ngày đăng ký nghỉ !", "Lỗi");
                dateEnd.EditValue = dateStart.DateTime;
                return false;
            }
            return true;
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {


            if (MaHVCurrent == 0)
            {
                MessageBox.Show("Chưa chọn học viên !", "Error");
                return;
            }


            if (!checkDateTT())
            {
                return;
            }


            if (txtSang.Text == null || txtTrua.Text == null && txtToi.Text == null)
            {
                MessageBox.Show("Chưa chọn loại nghỉ ! ", "Error");
                return;
            }

            int maloainghi = Convert.ToInt32(cbLoainghi.SelectedValue);

            //for(int i = 0; i < listDK.Count; i++)
            //{
            //    if(listDK[i].MaHocVien == MaHVCurrent)
            //    {
            //        MessageBox.Show("Đã có trong danh sách ! ", "Error");
            //        return;
            //    }
            //}

            // thêm chi tiết cắt cơm 

            List<ChiTietLoaiNghi> Ls_ctLN = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == maloainghi).ToList();

            MaDKTamCurrent++;



            //-------------------------------------------------
            HocVien_DangKiNghi hv_dk = new HocVien_DangKiNghi
            {
                MaHocVien = MaHVCurrent,
                HoTen = txtHoTen.Text,
                Lop = txtLop.Text,
                NgayBDNghi = dateStart.DateTime,
                NgayKTNghi = dateEnd.DateTime,
                MaLoaiNghi = maloainghi,
                TenLoaiNghi = db.LoaiNghis.Where(m => m.MaLoaiNghi == maloainghi).FirstOrDefault().TenLoaiNghi,
                LyDo = txtLyDo.Text,
                MaDangKyTam = MaDKTamCurrent
            };


            if (IsNotDupDate(hv_dk))
            {
                listDK.Add(hv_dk);

                DateTime StartDateTemp = dateStart.DateTime;
                foreach (var item in Ls_ctLN)
                {
                    lsCTCatCom.Add(new CT_CatCom_HocVien
                    {
                        NgayCatCom = StartDateTemp,
                        BuoiSang = item.BuoiSang,
                        BuoiTrua = item.BuoiTrua,
                        BuoiToi = item.BuoiToi,
                        MaDangKyTam = MaDKTamCurrent
                    });
                    StartDateTemp.AddDays(1);
                }

                gridControl2.DataSource = null;
                gridControl2.DataSource = listDK;
            }

            //MessageBox.Show("count = " + lsCTCatCom.Count.ToString());

        }

        private void btnSendList_Click(object sender, EventArgs e)
        {
            if (MaHVCurrent == 0 || listDK.Count == 0 || lsCTCatCom.Count == 0)
            {
                MessageBox.Show("Chưa chọn học viên ! Danh sách trống !!", "Error");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn hoàn thành và gửi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                ds.NgayDK = DateTime.Now;
                ds.PheDuyet = -3; // -3 : chua duyet | -2 : huy dai doi |-1 : huy tieu doan | 0 : daidoi | 1 : tieudoan

                db.DanhSachRaNgoais.Add(ds);


                db.SaveChanges();


                foreach (var item in listDK)
                {
                    DangKyNghi ctrn = new DangKyNghi
                    {
                        LyDo = item.LyDo,
                        MaHocVien = item.MaHocVien,
                        MaLoaiNghi = item.MaLoaiNghi,
                        MaDS = ds.MaDS,
                        NgayDi = item.NgayBDNghi,
                        NgayVe = item.NgayKTNghi
                    };



                    db.DangKyNghis.Add(ctrn);
                    db.SaveChanges();

                    int maTCA = (int)db.HocViens.Where(m => m.MaHocVien == item.MaHocVien).FirstOrDefault().LoaiHocVien.MaTCA;

                    TieuChuanAn tca_hv = db.TieuChuanAns.Where(m => m.MaTCA == maTCA).FirstOrDefault();

                    LoaiNghi ln_hv = db.LoaiNghis.Where(m => m.MaLoaiNghi == item.MaLoaiNghi).FirstOrDefault();


                    PhieuThanhToan newThanhToan = new PhieuThanhToan
                    {
                        TrangThaiTT = -2,
                        MaDangKy = ctrn.MaDangKy,
                        TongTien = (int)ln_hv.SoBuoiSang * tca_hv.TienAnSang +
                                    (int)ln_hv.SoBuoiTrua * tca_hv.TienAnTrua +
                                    (int)ln_hv.SoBuoiToi * tca_hv.TienAnToi
                    };

                    db.PhieuThanhToans.Add(newThanhToan);
                    db.SaveChanges();

                    List<CT_CatCom_HocVien> ls_Add_cc = lsCTCatCom.Where(m => m.MaDangKyTam == item.MaDangKyTam).ToList();

                    foreach (var icc in ls_Add_cc)
                    {
                        ChiTietCatCom ctcc = new ChiTietCatCom
                        {
                            BuoiSang = icc.BuoiSang,
                            BuoiTrua = icc.BuoiTrua,
                            BuoiToi = icc.BuoiToi,
                            MaDangKy = db.DangKyNghis.Where(m => m.MaHocVien == item.MaHocVien && m.MaDS == ds.MaDS).FirstOrDefault().MaDangKy,
                            NgayCatCom = icc.NgayCatCom
                        };
                        db.ChiTietCatComs.Add(ctcc);
                        db.SaveChanges();
                    }
                }

                db.SaveChanges();

                if (lsCTCatCom.Count > 0 && listDK.Count > 0)
                {
                    MessageBox.Show("Gửi danh sách thành công");
                }

                SetDefaultState();

            }

        }


        private void dateStart_EditValueChanged(object sender, EventArgs e)
        {
            dateEnd.DateTime = dateStart.DateTime.AddDays(sobuoinghi - 1);

        }
    }
}


//thông tin chi tiết khi chưa lưu về database