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

namespace HTTT_QLTienAn.GUI.Lop
{
    public partial class Lop_ChoPheDuyet : DevExpress.XtraEditors.XtraUserControl
    {
        public Lop_ChoPheDuyet()
        {
            InitializeComponent();
        }
        public QLTA_model db = new QLTA_model();

        List<DS_LopChoPheDuyet> ds_ChoPheDuyet;

        List<DS_CTLopChoPheDuyet> ds_CTChoPheDuyet;


        Model.Lop targetLop;


        int MaDS_XacNhan;



        public void LoadDS1()
        {
            try
            {
                ds_ChoPheDuyet = db.DS_LopChoPheDuyet.Where(m => m.MaLop == targetLop.MaLop).ToList();

                gridControl1.DataSource = ds_ChoPheDuyet;


                ds_CTChoPheDuyet = db.DS_CTLopChoPheDuyet.Where(m => m.MaLop == targetLop.MaLop).ToList();

            }
            catch
            { }
        }




        private void Lop_ChoPheDuyet_Load(object sender, EventArgs e)
        {
            targetLop = db.Lops.Where(m => m.MaLopTruong == MainForm.MaID).FirstOrDefault();

            LoadDS1();

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int maDS = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "MaDS"));

            if (gridView1.FocusedColumn == gridView1.Columns["fldXoa"])
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<DangKyNghi> dsdk = db.DangKyNghis.Where(s => s.MaDS == maDS).ToList();

                    for (int i = 0; i < dsdk.Count; i++)
                    {
                        int madknghi = dsdk[i].MaDangKy;
                        List<ChiTietCatCom> ctn = db.ChiTietCatComs.Where(s => s.MaDangKy == madknghi).ToList();
                        List<PhieuThanhToan> dsTT = db.PhieuThanhToans.Where(s => s.MaDangKy == madknghi).ToList();

                        db.ChiTietCatComs.RemoveRange(ctn);
                        db.PhieuThanhToans.RemoveRange(dsTT);
                    }


                    db.DangKyNghis.RemoveRange(dsdk);


                    DanhSachRaNgoai DStemp = db.DanhSachRaNgoais.Where(s => s.MaDS == maDS).FirstOrDefault();
                    db.DanhSachRaNgoais.Remove(DStemp);
                    db.SaveChanges();
                    ReloadAll();
                    MessageBox.Show("Xóa thành công");
                }
                return;
            }


            MaDS_XacNhan = maDS;
            List<DS_CTLopChoPheDuyet> temp = ds_CTChoPheDuyet.Where(m => m.MaDS == maDS).ToList();

            gridControl2.DataSource = temp; 
        }

        public void ReloadAll()
        {
            Lop_ChoPheDuyet_Load(this, new EventArgs());
        }


        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
