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
    public partial class Admin_QLHocVien : DevExpress.XtraEditors.XtraUserControl
    {
        public Admin_QLHocVien()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        public HocVien hv = new HocVien();

        private void btnThemHV_Click(object sender, EventArgs e)
        {
            HocVien hv1 = new HocVien();
            if (Check())
            {
                hv1.HoTen = txtThemTenHV.Text;
                hv1.NgaySinh = dateThemHV.DateTime;
                hv1.CapBac = txtThemCapBacHV.Text;
                hv1.ChucVu = txtThemChucVuHV.Text;
                hv1.MaLop = int.Parse(txtThemMaLopHV.Text);
                hv1.MaLHV = int.Parse(txtThemMaLoaiHV.Text);
                hv1.MaTK = int.Parse(txtThemMaTKHV.Text);
                db.HocViens.Add(hv1);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                dgvTTHV.DataSource = null;
                var tthv1 = db.HocViens.ToList();
                dgvTTHV.DataSource = tthv1;
                LoadChiTietHV();
                txtThemTenHV.Text = "";
                dateThemHV.EditValue = null;
                txtThemCapBacHV.Text = "";
                txtThemChucVuHV.Text = "";
                txtThemMaLopHV.Text = "";
                txtThemMaLoaiHV.Text = "";
                txtThemMaTKHV.Text = "";
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void LoadChiTietHV()
        {
            try
            {
                int mahv = (int)dgvTTHV_View.GetFocusedRowCellValue("MaHocVien");
                hv = db.HocViens.Where(p => p.MaHocVien == mahv).FirstOrDefault();
            }
            catch { }
            txtTenHV_CT.EditValue = hv.HoTen;
            txtCapBacHV_CT.EditValue = hv.CapBac;
            txtChucVuHV_CT.EditValue = hv.ChucVu;
            txtMaLopHV_CT.EditValue = hv.MaLop;
            txtMaLHV_CT.EditValue = hv.MaLHV;
            txtNgaySinhHV_CT.EditValue = hv.NgaySinh.ToString("dd/MM/yy");
            txtMaTKHV_CT.EditValue = hv.MaTK;
            txtSuaMaHV.EditValue = hv.MaHocVien;
        }

        private void btnSuaHV_Click(object sender, EventArgs e)
        {
            HocVien hv2 = db.HocViens.Where(p => p.MaHocVien == hv.MaHocVien).FirstOrDefault();
            if (txtSuaMaLoaiHV.Text != "" && txtSuaMaTKHV.Text != "" && txtSuaMaLopHV.Text != "")
            {
                int malophv = int.Parse(txtSuaMaLopHV.Text);
                int maloaihv = int.Parse(txtSuaMaLoaiHV.Text);
                int matkhv = int.Parse(txtSuaMaTKHV.Text);
                var temp_hv = db.Lops.Where(p => p.MaLop == malophv).FirstOrDefault();
                if (temp_hv == null)
                {
                    MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    hv2.MaLop = int.Parse(txtSuaMaLopHV.Text);
                }
                var temp_hv1 = db.LoaiHocViens.Where(p => p.MaLHV == maloaihv).FirstOrDefault();
                if (temp_hv1 == null)
                {
                    MessageBox.Show("Mã loại học viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    hv2.MaLHV = int.Parse(txtSuaMaLoaiHV.Text);
                }
                var temp_hv2 = db.TaiKhoans.Where(p => p.MaTK == matkhv).FirstOrDefault();
                if (temp_hv2 == null)
                {
                    MessageBox.Show("Mã tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    hv2.MaTK = int.Parse(txtSuaMaTKHV.Text);
                }
            }
            if (txtSuaTenHV.Text != "") hv2.HoTen = txtSuaTenHV.Text;
            if (dateSuaHV.DateTime != null) hv2.NgaySinh = dateSuaHV.DateTime;
            if (txtSuaCapBacHV.Text != "") hv2.CapBac = txtSuaCapBacHV.Text;
            if (txtSuaChucVuHV.Text != "") hv2.ChucVu = txtSuaChucVuHV.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvTTHV.DataSource = null;
            var tthv1 = db.HocViens.ToList();
            dgvTTHV.DataSource = tthv1;
            LoadChiTietHV();
            txtSuaMaLopHV.Text = "";
            dateSuaHV.EditValue = null;
            txtSuaTenHV.Text = "";
            txtSuaCapBacHV.Text = "";
            txtSuaChucVuHV.Text = "";
            txtSuaMaLoaiHV.Text = "";
            txtSuaMaTKHV.Text = "";
        }

        private void dgvTTHV_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietHV();
        }
        private bool Check()
        {
            if (txtThemTenHV.Text == "")
            {
                MessageBox.Show("Tên học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateThemHV.DateTime == null)
            {
                MessageBox.Show("Ngày sinh học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemCapBacHV.Text == "")
            {
                MessageBox.Show("Cấp bậc của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemChucVuHV.Text == "")
            {
                MessageBox.Show("Chức vụ của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaLopHV.Text == "")
            {
                MessageBox.Show("Mã lớp của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaLoaiHV.Text == "")
            {
                MessageBox.Show("Mã loại học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtThemMaTKHV.Text == "")
            {
                MessageBox.Show("Mã tài khoản của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaLopHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã lớp của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaTKHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã tài khoản của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaLoaiHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã loại học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int malophv = int.Parse(txtSuaMaLopHV.Text);
            int maloaihv = int.Parse(txtSuaMaLoaiHV.Text);
            int matkhv = int.Parse(txtSuaMaTKHV.Text);
            var temp_hv = db.Lops.Where(p => p.MaLop == malophv).FirstOrDefault();
            if (temp_hv == null)
            {
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var temp_hv1 = db.LoaiHocViens.Where(p => p.MaLHV == maloaihv).FirstOrDefault();
            if (temp_hv1 == null)
            {
                MessageBox.Show("Mã loại học viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var temp_hv2 = db.TaiKhoans.Where(p => p.MaTK == matkhv).FirstOrDefault();
            if (temp_hv2 == null)
            {
                MessageBox.Show("Mã tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Admin_QLHocVien_Load(object sender, EventArgs e)
        {
            var tthv1 = db.HocViens.ToList();
            dgvTTHV.DataSource = tthv1;
        }
    }
}
