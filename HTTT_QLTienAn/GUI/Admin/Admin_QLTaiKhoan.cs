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
        public TaiKhoan tk = new TaiKhoan();

        private void Admin_QLTaiKhoan_Load(object sender, EventArgs e)
        {
            var tk = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = tk;
            LoadChiTietTK();
        }

        public void LoadChiTietTK()
        {
            try
            {
                int matk = (int)dgvTKDN_View.GetFocusedRowCellValue("MaTaiKhoan");
                tk = db.TaiKhoans.Where(p => p.MaTK == matk).FirstOrDefault();
                txtTenDN_CT.EditValue = tk.TenDangNhap;
                txtQuyenTruyCap_CT.EditValue = tk.Quyen;
                txtMatKhau_CT.EditValue = tk.MatKhau;
                txtXoaMK.EditValue = tk.MatKhau;
                txtXoaQTC.EditValue = tk.Quyen;
                txtXoaTenDN.EditValue = tk.TenDangNhap;
                txtSuaMaTK.EditValue = tk.MaTK;
            }
            catch { }
        }

        private void dgvTKDN_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietTK();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ///

            dgvTKDN.DataSource = null;
            var tkdn = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = tkdn;
            LoadChiTietTK();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            if (txtEditThemTenDN.Text != "" && txtEditMK.Text != "" && txtEditQTC.Text != "")
            {
                tk.TenDangNhap = txtEditThemTenDN.Text;
                tk.MatKhau = LoginForm.HashPass(txtEditMK.Text);
                tk.Quyen = txtEditQTC.Text;
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKDN.DataSource = null;
                var t = db.TaiKhoans.ToList();
                dgvTKDN.DataSource = t;
                LoadChiTietTK();
                txtEditThemTenDN.Text = "";
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
            TaiKhoan t2 = db.TaiKhoans.Where(p => p.MaTK == tk.MaTK).FirstOrDefault();
            if (txtSuaTenDN.Text != "") t2.TenDangNhap = txtSuaTenDN.Text;
            if (txtSuaMK.Text != "") t2.MatKhau = LoginForm.HashPass(txtSuaMK.Text);
            if (txtSuaQTC.Text != "") t2.Quyen = txtSuaQTC.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTKDN.DataSource = null;
            var t = db.TaiKhoans.ToList();
            dgvTKDN.DataSource = t;
            LoadChiTietTK();
            txtSuaTenDN.Text = "";
            txtSuaMK.Text = "";
            txtSuaQTC.Text = "";
        }
    }
}
