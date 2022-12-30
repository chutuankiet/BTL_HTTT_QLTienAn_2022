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
    public partial class Admin_LoaiHV : UserControl
    {
        public Admin_LoaiHV()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();
        public int malhv;
        LoaiHocVien lhv = new LoaiHocVien();
        private void Admin_LoaiHV_Load(object sender, EventArgs e)
        {
            var dv = db.LoaiHocViens.ToList();
            dgvLHV.DataSource = dv;
            LoadChiTietLHV();
        }
        private void LoadChiTietLHV()
        {
            try
            {
                malhv = (int)dgvLHV_View.GetFocusedRowCellValue("MaLHV");
            }
            catch { }
            txtSuaMaLHV.EditValue = malhv;
        }
        private void btnThemLHV_Click(object sender, EventArgs e)
        {
            LoaiHocVien lhv = new LoaiHocVien();
            if (Check())
            {
                lhv.TenLHV = txtThemTenLHV.Text;
                lhv.MaTCA = int.Parse(txtTCA.Text);
                
                db.LoaiHocViens.Add(lhv);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                dgvLHV.DataSource = null;
                var ttlhv = db.LoaiHocViens.ToList();
                dgvLHV.DataSource = ttlhv;
                LoadChiTietLHV();
                txtThemTenLHV.Text = "";
                txtTCA.Text = "";
               
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool Check()
        {
            if (txtThemTenLHV.Text == "")
            {
                MessageBox.Show("Tên loại học viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTCA.Text == "")
            {
                MessageBox.Show("Mã tiêu chuẩn ăn không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
     
            try
            {
                int k = int.Parse(txtTCA.Text);
            }
            catch
            {
                MessageBox.Show("Mã tiêu chuẩn ăn phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            int maTCA = int.Parse(txtTCA.Text);
            
            var temp_tca = db.TieuChuanAns.Where(p => p.MaTCA == maTCA).FirstOrDefault();
            if (temp_tca == null)
            {
                MessageBox.Show("Mã tiêu chuẩn ăn không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
      
        private void btnSuaLHV_Click(object sender, EventArgs e)
        {
            

            LoaiHocVien lhv2 = db.LoaiHocViens.Where(p => p.MaLHV == lhv.MaLHV).FirstOrDefault();
            if ( txtMaTCA.Text != "")
            {
                int maTCA = int.Parse(txtMaTCA.Text);
                
                var temp_tca = db.TieuChuanAns.Where(p => p.MaTCA == maTCA).FirstOrDefault();
                if (temp_tca == null)
                {
                    MessageBox.Show("Mã tiêu chuẩn ăn không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    lhv2.MaTCA = int.Parse(txtMaTCA.Text);
                }
              
            }
            if (txtSuaTenLHV.Text != "") lhv2.TenLHV = txtSuaTenLHV.Text;
            if (txtMaTCA.Text != "") lhv2.MaTCA = int.Parse(txtMaTCA.Text);
         
            db.SaveChanges();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //

            dgvLHV.DataSource = null;
            var ttlhv1 = db.LoaiHocViens.ToList();
            dgvLHV.DataSource = ttlhv1;
            LoadChiTietLHV();
            txtSuaTenLHV.Text = "";
            
            txtMaTCA.Text = "";
        }
        private void dgvLHV_View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiTietLHV();

        }
    }
}
