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
                hv1.MaLop = int.Parse(txtThemLopHV.Text);
                hv1.NgaySinh = dateThemHV.DateTime;
                hv1.CapBac = txtThemCapBacHV.Text;
                hv1.ChucVu = txtThemChucVuHV.Text;
                hv1.MaLHV = int.Parse(txtThemMaLHV.Text);
                db.HocViens.Add(hv1);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                dgvTTHV.DataSource = null;
                var tthv1 = db.HocViens.ToList();
                dgvTTHV.DataSource = tthv1;
                LoadChiTietHV();
                txtThemTenHV.Text = "";
                txtThemLopHV.Text = "";
                dateThemHV.EditValue = null;
                txtThemCapBacHV.Text = "";
                txtThemChucVuHV.Text = "";
                
                txtThemMaLHV.Text = "";
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
            txtLopHV_CT.EditValue = hv.MaLop;
            txtCapBacHV_CT.EditValue = hv.CapBac;
            txtChucVuHV_CT.EditValue = hv.ChucVu;
          
            txtMaLHV.EditValue = hv.MaLHV;
            txtNgaySinhHV_CT.EditValue = hv.NgaySinh.ToString("dd/MM/yy");

            txtSuaMaHV.EditValue = hv.MaHocVien;

        }
        private void btnSuaHV_Click(object sender, EventArgs e)
        {
            HocVien hv2 = db.HocViens.Where(p => p.MaHocVien == hv.MaHocVien).FirstOrDefault();
            if (txtSuaLopHV.Text != "" && txtSuaMaLHV.Text != "")
            {
                int malophv = int.Parse(txtSuaLopHV.Text);
                int malhv = int.Parse(txtSuaMaLHV.Text);
                var temp_hv = db.Lops.Where(p => p.MaLop == malophv).FirstOrDefault();
                if (temp_hv == null)
                {
                    MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    hv2.MaLop = int.Parse(txtSuaLopHV.Text);
                }
                var temp_hv1 = db.LoaiHocViens.Where(p => p.MaLHV == malhv).FirstOrDefault();
                if (temp_hv1 == null)
                {
                    MessageBox.Show("Mã loại học viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    hv2.MaLHV = int.Parse(txtSuaMaLHV.Text);
                }
            }
            if (txtSuaTenHV.Text != "") hv2.HoTen = txtSuaTenHV.Text;
            if (txtSuaLopHV.Text != "") hv2.MaLop = int.Parse(txtSuaLopHV.Text);
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
            txtSuaLopHV.Text = "";
            dateSuaHV.EditValue = null;
            txtSuaTenHV.Text = "";
            txtSuaCapBacHV.Text = "";
            txtSuaChucVuHV.Text = "";
       
            txtSuaMaLHV.Text = "";
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
            if (txtThemLopHV.Text == "")
            {
                MessageBox.Show("Lớp của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
           
            if (txtThemMaLHV.Text == "")
            {
                MessageBox.Show("Mã tiêu chuẩn ăn của học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemLopHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã đơn vị của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtThemMaLHV.Text);
            }
            catch
            {
                MessageBox.Show("Mã tiêu chuẩn ăn của học viên phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int malophv = int.Parse(txtThemLopHV.Text);
            int malhv = int.Parse(txtThemMaLHV.Text);
            var temp_hv = db.Lops.Where(p => p.MaLop == malophv).FirstOrDefault();
            if (temp_hv == null)
            {
                MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var temp_hv1 = db.LoaiHocViens.Where(p => p.MaLHV == malhv).FirstOrDefault();
            if (temp_hv1 == null)
            {
                MessageBox.Show("Mã loại học viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Admin_HocVien_Load(object sender, EventArgs e)
        {
            var tthv1 = db.HocViens.ToList();
            dgvTTHV.DataSource = tthv1;
        }

        
    }
}
