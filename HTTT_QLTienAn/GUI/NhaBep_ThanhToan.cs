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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace HTTT_QLTienAn.GUI
{
    public partial class NhaBep_ThanhToan : UserControl
    {
        Model1 db = new Model1();

        public NhaBep_ThanhToan()
        {
            InitializeComponent();
        }
        public void reload()
        {
            cbbDonVi.Items.Clear();
            NhaBep_ThanhToan_Load(this, new EventArgs());
        }

        private void NhaBep_ThanhToan_Load(object sender, EventArgs e)
        {
            cbbDonVi.SelectedIndexChanged -= cbbDonVi_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;

            List<DonVi> lstDonVi = db.DonVis.Where(s => s.TenDonVi.Contains("c")).ToList();

            foreach (var item in lstDonVi)
            {
                cbbDonVi.Items.Add(item.TenDonVi);
            }
            cbbDonVi.Items.Add("Tất cả");



            cbbDonVi.SelectedIndexChanged += cbbDonVi_SelectedIndexChanged;
            //cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
            List<DotThanhToan> lstDot = db.DotThanhToans.ToList();
            foreach (var item in lstDot)
            {
                cbbDot.Items.Add(item.TenDot);
            }
            cbbDot.Items.Add("Tất cả");
            // Hiển thị danh sách đã thanh toán của cả tiểu đoàn
            List<NhaBep_LichSuCatComDaThanhToan> lstThanhToan = new List<NhaBep_LichSuCatComDaThanhToan>();
            lstThanhToan = db.NhaBep_LichSuCatComDaThanhToan.ToList();
            gridControl1.DataSource = lstThanhToan;
            // hiển thị danh sách chưa thanh toán của cả tiểu đoàn
            List<NhaBep_CatComChuaThanhToan> lstChuaTT = new List<NhaBep_CatComChuaThanhToan>();
            gridControl2.DataSource = lstChuaTT;
        }
        void TaoThanhToan()
        {
            List<PhieuThanhToan> LstPTT = new List<PhieuThanhToan>();
            List<NhaBep_CatComChuaThanhToan> lstChuaTT = new List<NhaBep_CatComChuaThanhToan>();
            NhaBep_CatComChuaThanhToan model = new NhaBep_CatComChuaThanhToan();
            List<NhaBep_TimDeTaoThanhToan> lstTao = new List<NhaBep_TimDeTaoThanhToan>();
            foreach(var item in lstTao)
            {
                PhieuThanhToan PTT = new PhieuThanhToan();
                PTT.MaDangKy = item.MaDangKy;
                PTT.MaCBNhaBep = 3;
                PTT.NgayTT = DateTime.Now;
                PTT.TrangThaiTT = 0;
                // Xử lý phần mã đợt ở đấy
            }
        }
        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            {
                // List<DonVi> lstDonVi = db.DonVis.Where(s => s.TenDonVi.Contains("c")).ToList();
                //int madv = db.DonVis.Where(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).Select(s => s.MaDonVi).First();
                //LoadDataIntoComboBoxLop(cbbDonVi.SelectedItem.ToString());
                //LoadDataIntoComboBoxLop(madv);

                //Clear Selected Item:
                // cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
                cbbLop.Text = cbbDonVi.SelectedText;
                //cbbLop.SelectedIndex = -1;
                //cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
                LoadDataGridControl1();
            }
        }


        private void LoadDataIntoComboBoxLop(int madv)

        {

            {
                //Clear Old List:
                cbbLop.Items.Clear();
                List<Lop> lstlop = db.Lops.Where(s => s.MaDonVi == madv).ToList();
                foreach (var item in lstlop)
                {
                    cbbLop.Items.Add(item.TenLop);
                }
                cbbLop.Items.Add("Tất cả");
            }

        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDonVi.SelectedItem.ToString() != "Tất cả")
            {
                int madv = db.DonVis.Where(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).Select(s => s.MaDonVi).First();
                LoadDataIntoComboBoxLop(madv);
            }
            else cbbLop.Items.Add("Tất cả");
            cbbLop.DisplayMember = "Tất cả";
            LoadDataGridControl1();
            //Clear Selected Item:
            /*  cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
                  cbbLop.Text = "";
                  cbbLop.SelectedIndex = -1;
                  cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;*/
        }
        private void ClearDataShowed()
        {
            gridControl1.BeginUpdate();
            try
            {
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }
            finally
            {
                gridControl1.EndUpdate();
            }

            gridControl2.BeginUpdate();
            try
            {
                gridControl2.DataSource = null;
                gridControl2.Refresh();
            }
            finally
            {
                gridControl2.EndUpdate();
            }

            //Clear TextBox:

        }

        private void LoadDataGridControl1()
        {
            List<DonVi> lstDonVi = db.DonVis.Where(s => s.TenDonVi.Contains("c")).ToList();
            List<NhaBep_LichSuCatComDaThanhToan> lstCatComLop;
            List<NhaBep_CatComChuaThanhToan> lstChuaTT;
            int maC;
            if (cbbDonVi.SelectedItem.ToString() != "Tất cả")
            {
                 maC = lstDonVi.Find(s => s.TenDonVi == cbbDonVi.SelectedItem.ToString()).MaDonVi;

            }
            else
            {
                 maC = -2;
            }
            string Lop = cbbLop.SelectedItem.ToString();
            string tenDot = cbbDot.SelectedItem.ToString();
            if(maC == -2)
            {
                if(tenDot == "Tất cả")
                {
                    lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.ToList();
                    lstChuaTT = db.NhaBep_CatComChuaThanhToan.ToList();
                }
                else
                {
                    lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.Where(s => tenDot == s.TenDot).ToList();
                    lstChuaTT = db.NhaBep_CatComChuaThanhToan.Where(s => tenDot == s.tenDot).ToList();
                }
            }
            else
            {
                if(tenDot == "Tất cả")
                {
                    if( Lop == "Tất cả")
                    {
                        lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.Where(s => s.MaDonVi == maC ).ToList();
                        lstChuaTT = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC).ToList();
                    }
                    else
                    {
                        lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.Where(s => s.MaDonVi == maC && s.TenLop == Lop).ToList();
                        lstChuaTT = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC && s.TenLop == Lop).ToList();

                    }
                }
                else
                {
                    if (Lop == "Tất cả")
                    {
                        lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.Where(s => s.MaDonVi == maC &&tenDot == s.TenDot).ToList();
                        lstChuaTT = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC && tenDot == s.tenDot).ToList();
                    }
                    else
                    {
                        lstCatComLop = db.NhaBep_LichSuCatComDaThanhToan.Where(s => s.MaDonVi == maC && s.TenLop == Lop&& tenDot == s.TenDot).ToList();
                        lstChuaTT = db.NhaBep_CatComChuaThanhToan.Where(s => s.MaDonVi == maC && tenDot == s.tenDot && s.TenLop == Lop).ToList();

                    }
                }
            }
           

            gridControl1.DataSource = lstCatComLop;
            gridControl2.DataSource = lstChuaTT;
            // gridControl1.Refresh();
        }

        private void UndoingChangesDbContextLevel(Model1 db)
        {
            throw new NotImplementedException();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            {


                MessageBox.Show("Đã thanh toán thành công!");
                reload();
            }
        }

        

        private void cbbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridControl1();

        }
        private void LoadDataGridControl2(object sender, EventArgs e)
        {
           // List<NhaBep_CatComChuaThanhToan> lst
        }








        // cần có một danh sách để tạo ra thanh toán - FindToCreateTT

    }


}
