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
    public partial class Chung_PhanHoi : DevExpress.XtraEditors.XtraForm
    {
        public Chung_PhanHoi()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();

        public Chung_PhanHoi(string userrole,int maTT)
        {
            InitializeComponent();
            role = userrole;
            MaThanhToan = maTT;

        }
        string role;
        int MaThanhToan;
        PhanHoi newPhanHoi;
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtLyDo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung phản hồi !");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn hoàn thành và gửi phản hồi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                newPhanHoi.PhanHoi1 = txtLyDo.Text;
                newPhanHoi.MaThanhToan = MaThanhToan;
                db.PhanHois.Add(newPhanHoi);
                db.SaveChanges();
                MessageBox.Show("Gửi phản hồi thành công!", "Thông báo");
                this.Dispose();
            }
            //txtHoTen.Text;
            //txtCapBac.Text;
            //txtChucVu.Text;
            //txtDonvi.Text;
        }

        HocVien tarLoptruong;
        CanBo tarCanBo;


        private void Chung_PhanHoi_Load(object sender, EventArgs e)
        {
            if(role == "c" || role == "d")
            {
                tarCanBo = db.CanBoes.Where(m => m.MaCanBo == MainForm.MaID).FirstOrDefault();

                txtHoTen.Text = tarCanBo.HoTen;
                txtCapBac.Text = tarCanBo.CapBac;
                txtChucVu.Text = tarCanBo.ChucVu;
                txtDonvi.Text = db.DonVis.Where(m => m.MaDonVi == tarCanBo.MaDonVi).FirstOrDefault().TenDonVi;

                newPhanHoi = new PhanHoi
                {
                    MaCanBo = tarCanBo.MaCanBo,
                    NgayGui = DateTime.Today,
                    DaXuLy = 0,
                    MaLopTruong = null
                };


            }
            else if(role == "l")
            {
                tarLoptruong = db.HocViens.Where(m => m.MaHocVien == MainForm.MaID).FirstOrDefault();


                txtHoTen.Text = tarLoptruong.HoTen;
                txtCapBac.Text = tarLoptruong.CapBac;
                txtChucVu.Text = tarLoptruong.ChucVu;
                txtDonvi.Text = db.DonVis.Where(m => m.MaDonVi == tarLoptruong.Lop.MaDonVi).FirstOrDefault().TenDonVi;

                newPhanHoi = new PhanHoi
                {
                    MaLopTruong = tarLoptruong.MaHocVien,
                    NgayGui = DateTime.Today,
                    DaXuLy = 0,
                    MaCanBo = null

                };
            }

            txtMaTT.Text = MaThanhToan.ToString();


        }
    }
}