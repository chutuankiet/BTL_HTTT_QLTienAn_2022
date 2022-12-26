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

        List<HocVien_DangKiNghi> listDK = new List<HocVien_DangKiNghi>();

        DanhSachRaNgoai ds = new DanhSachRaNgoai();

        List<LoaiNghi> ListLoaiNghi = new List<LoaiNghi>();


        public Lop_NhapDS()
        {
            InitializeComponent();
            
           
        }

        int MaLopTruong = 0;
        int MaLop = 0;

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
            int MaDK = listDK[index].MaDangKyTam;



        }

        private int MaHVCurrent = 0;

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

            cMaLop = tempLop.MaLop;


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



        private void cbLoainghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbLoainghi.SelectedIndex;
            txtSang.Text = ListLoaiNghi[index].SoBuoiSang.ToString();
            txtTrua.Text = ListLoaiNghi[index].SoBuoiTrua.ToString();
            txtToi.Text = ListLoaiNghi[index].SoBuoiToi.ToString();
            txtLyDo.Text = ListLoaiNghi[index].TenLoaiNghi;
        }

        private bool checkDate()
        {
            return dateStart.DateTime <= dateEnd.DateTime;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!checkDate())
            {

                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày trả phép !", "Error");
                return;
            }

            if (MaHVCurrent == 0)
            {
                MessageBox.Show("Chưa chọn học viên !", "Error");
                return;
            }

            if (txtSang.Text == null || txtTrua.Text == null && txtToi.Text == null)
            {
                MessageBox.Show("Chưa chọn loại nghỉ ! ", "Error");
                return;
            }

            int maloainghi = Convert.ToInt32(cbLoainghi.SelectedValue);

            for(int i = 0; i < listDK.Count; i++)
            {
                if(listDK[i].MaHocVien == MaHVCurrent)
                {
                    MessageBox.Show("Đã có trong danh sách ! ", "Error");
                    return;
                }
            }


            HocVien_DangKiNghi hv_dk = new HocVien_DangKiNghi
            {
                MaHocVien = MaHVCurrent,
                HoTen = txtHoTen.Text,
                Lop = txtLop.Text,
                NgayBDNghi = dateStart.DateTime,
                NgayKTNghi = dateEnd.DateTime,
                MaLoaiNghi = maloainghi,
                TenLoaiNghi = db.LoaiNghis.Where(m => m.MaLoaiNghi == maloainghi).FirstOrDefault().TenLoaiNghi,
                LyDo = txtLyDo.Text
            };

            listDK.Add(hv_dk);
            gridControl2.DataSource = null;
            gridControl2.DataSource = listDK;


        }

        private void btnSendList_Click(object sender, EventArgs e)
        {

            ds.NgayDK = DateTime.Now;
            ds.PheDuyet = -1;
            db.DanhSachRaNgoais.Add(ds);
            db.SaveChanges();


            foreach (var item in listDK)
            {
                db.DangKyNghis.Add(new DangKyNghi
                {
                    LyDo = item.LyDo,
                    MaHocVien = item.MaHocVien,
                    MaLoaiNghi = item.MaLoaiNghi,
                    MaDS = ds.MaDS,
                    NgayDi = item.NgayBDNghi,
                    NgayVe = item.NgayKTNghi
                });
            }
            db.SaveChanges();
            MessageBox.Show("Gửi danh sách thành công");

            SetDefaultState();



        }
    }
}


//thông tin chi tiết khi chưa lưu về database