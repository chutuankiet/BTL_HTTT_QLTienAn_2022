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
    public partial class Admin_QLTieuChuanAn : DevExpress.XtraEditors.XtraUserControl
    {
        public Admin_QLTieuChuanAn()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        public TieuChuanAn TieuChuanAn = new TieuChuanAn();
        List<TieuChuanAn> lstTCA;
        private void Admin_QLTieuChuanAn_Load(object sender, EventArgs e)
        {
            lstTCA = db.TieuChuanAns.ToList();
            dgvLichSuTCA.DataSource = lstTCA;
            LoadChiTietTCA();
        }
        public void LoadChiTietTCA()
        {
            try
            {
                int id = lstTCA[0].MaTCA;
                TieuChuanAn = db.TieuChuanAns.Where(p => p.MaTCA == id).FirstOrDefault();
            }
            catch
            {

            }
            dateNgayApDung.DateTime = TieuChuanAn.NgayApDung;
            txtBuaSang.EditValue = TieuChuanAn.TienAnSang;
            txtBuaTrua.EditValue = TieuChuanAn.TienAnTrua;
            txtBuaToi.EditValue = TieuChuanAn.TienAnToi;
            txtTenTCA.EditValue = TieuChuanAn.TenTCA;
            txtTienAnHocVien.EditValue = (int)TieuChuanAn.TienAnSang + (int)TieuChuanAn.TienAnTrua + (int)TieuChuanAn.TienAnToi;
        }
        private bool check()
        {
            if (txtEditTenTCA.Text == "")
            {
                MessageBox.Show("Tiền tiêu chuẩn ăn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditSang.Text == "")
            {
                MessageBox.Show("Tiền ăn sáng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditTrua.Text == "")
            {
                MessageBox.Show("Tiền ăn trưa không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEditToi.Text == "")
            {
                MessageBox.Show("Tiền ăn tối không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditToi.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn tối phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditSang.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn sáng phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int k = int.Parse(txtEditTrua.Text);
            }
            catch
            {
                MessageBox.Show("Tiền ăn trưa phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {

                int count = db.TieuChuanAns.Count();
                TieuChuanAn.MaTCA = count + 1;
                TieuChuanAn.TenTCA = txtEditTenTCA.Text;
                TieuChuanAn.TienAnSang = int.Parse(txtEditSang.Text);
                TieuChuanAn.TienAnTrua = int.Parse(txtEditTrua.Text);
                TieuChuanAn.TienAnToi = int.Parse(txtEditToi.Text);
                TieuChuanAn.NgayApDung = dateEditNgayApDung.DateTime;
                db.TieuChuanAns.Add(TieuChuanAn);
                db.SaveChanges();
                MessageBox.Show("Lưu tiêu chuẩn ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLichSuTCA.DataSource = null;
                var tca = db.TieuChuanAns.ToList();
                dgvLichSuTCA.DataSource = tca;
                txtEditToi.EditValue = "";
                txtEditSang.EditValue = "";
                txtEditTrua.EditValue = "";
                txtEditTenTCA.EditValue = "";
            }
        }

        private void dgvTCA_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietTCA();
        }
    }
}
