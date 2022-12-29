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
namespace HTTT_QLTienAn.GUI.Admin
{
    public partial class Admin_QLTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public Admin_QLTaiKhoan()
        {
            InitializeComponent();
        }
         public QLTA_model db = new QLTA_model();
        public TaiKhoan ttdn = new TaiKhoan();
        private void Admin_DangNhap_Load(object sender, EventArgs e)
        {
            var tkdn = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = tkdn;
            LoadChiTietTk();
        }

        public void LoadChiTietTk()
        {
            try
            {
                int madn = (int)dgvTKDN_View.GetFocusedRowCellValue("MaTK");
                ttdn = db.TaiKhoans.Where(p => p.MaTK== madn).FirstOrDefault();
                txtTenTK_CT.EditValue = ttdn.TenDangNhap;
                txtQuyenTruyCap_CT.EditValue = ttdn.Quyen;
                txtMatKhau_CT.EditValue = ttdn.MatKhau;

                txtXoaMK.EditValue = ttdn.MatKhau;
                txtXoaQTC.EditValue = ttdn.Quyen;
                txtXoaTK.EditValue = ttdn.TenDangNhap;

                txtSuaMaDN.EditValue = ttdn.MaTK;
            }
            catch { }
        }

        private void dgvTKDN_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietTk();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            db.TaiKhoans.Remove(ttdn);
            db.SaveChanges();
            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ///

            dgvTKDN.DataSource = null;
            var tkdn = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = tkdn;
            LoadChiTietTk();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoan tt = new TaiKhoan();
            if (txtEditThemTK.Text != "" && txtEditMK.Text != "" && txtEditQTC.Text != "")
            {
                tt.TenDangNhap = txtEditThemTK.Text;
                tt.MatKhau = LoginForm.HashPass(txtEditMK.Text);
                tt.Quyen = txtEditQTC.Text;
                db.TaiKhoans.Add(tt);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKDN.DataSource = null;
                var t = db.TaiKhoans.ToList();
                dgvTKDN.DataSource = t;
                LoadChiTietTk();
                txtEditThemTK.Text = "";
                txtEditMK.Text = "";
                txtEditQTC.Text = "";
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan t2 = db.TaiKhoans.Where(p => p.MaTK == ttdn.MaTK).FirstOrDefault();
            if (txtSuaTK.Text != "") t2.TenDangNhap = txtSuaTK.Text;
            if (txtSuaMK.Text != "") t2.MatKhau = LoginForm.HashPass(txtSuaMK.Text);
            if (txtSuaQTC.Text != "") t2.Quyen = txtSuaQTC.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTKDN.DataSource = null;
            var t = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = t;
            LoadChiTietTk();
            txtSuaTK.Text = "";
            txtSuaMK.Text = "";
            txtSuaQTC.Text = "";
        }
    }
}
