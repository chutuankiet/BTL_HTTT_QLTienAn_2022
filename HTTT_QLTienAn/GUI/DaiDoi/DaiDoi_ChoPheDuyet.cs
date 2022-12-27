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
namespace HTTT_QLTienAn.GUI.DaiDoi
{
    public partial class DaiDoi_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public DaiDoi_ChoPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();
        public DaiDoi_ChoPheDuyet(int maCB)
        {
            InitializeComponent();
            maCBc = maCB;
        }

        static int maCBc;
        public string MaDS_XacNhan;
        private int mads;
        private int mahv;



        public void LoadDS1()
        {
            try
            {
                List<c_ChoPheDuyet> ds_ChoPheDuyet = db.c_ChoPheDuyet.Where(m=>m.PheDuyet == -3).ToList();


                ds_ChoPheDuyet.Reverse();
                dgvDSCho.DataSource = ds_ChoPheDuyet;

                mads = ds_ChoPheDuyet[0].MaDS;
                MaDS_XacNhan = mads.ToString();
                List<DS_ChoPheDuyet> ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m=>m.MaDS == mads).ToList();
                ds_CTChoPheDuyet.Reverse();
               
                dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
            }
            catch
            { }
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{

        //    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        int index = gridView1.FocusedRowHandle;

        //        //foreach(var item in lsCTCatCom)
        //        //{
        //        //    if(item.MaDangKyTam == )
        //        //    {
        //        //        lsCTCatCom.Remove(item);
        //        //    }
        //        //}
                
        //        lsCTCatCom.RemoveAll(m => m.MaDangKyTam == listDK[index].MaDangKyTam);

        //        //MessageBox.Show("count = "+lsCTCatCom.Count.ToString());

        //        listDK.RemoveAt(index);
        //        gridControl2.DataSource = null;
        //        gridControl2.DataSource = listDK;
        //    }
        //}


        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {

                var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
                if (dsn != null)
                {
                    dsn.PheDuyet = -2;
                    dsn.MaCBc = MainForm.MaID;
                    db.SaveChanges();
                    MessageBox.Show("Danh sách đã được huỷ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvDSCho.DataSource = null;
                LoadDS1();
                dgvChiTietDS1.DataSource = null;

            }

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            var dsn = db.DanhSachRaNgoais.SingleOrDefault(p => p.MaDS.ToString() == MaDS_XacNhan);
            if (dsn != null)
            {
                dsn.PheDuyet = 0;
                dsn.MaCBc = MainForm.MaID;
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

            List<DS_ChoPheDuyet> ds_CTChoPheDuyet = db.DS_ChoPheDuyet.Where(m => m.MaDS == mads).ToList();

            ds_CTChoPheDuyet.Reverse();
            //dgvDSCho_View.OptionsBehavior.Editable = false;
            //gridView2.OptionsBehavior.Editable = false;
            dgvChiTietDS1.DataSource = ds_CTChoPheDuyet;
        }

        private void DaiDoi_ChoPheDuyet_Load(object sender, EventArgs e)
        {
            LoadDS1();
        }
    }
}
