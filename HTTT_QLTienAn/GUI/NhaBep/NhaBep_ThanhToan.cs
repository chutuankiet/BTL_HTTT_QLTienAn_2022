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

namespace HTTT_QLTienAn.GUI.NhaBep
{
    public partial class NhaBep_ThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public NhaBep_ThanhToan()
        {
            InitializeComponent();
        }
        QLTA_model db = new QLTA_model();
        
        private void NhaBep_ThanhToan_Load(object sender, EventArgs e)
        {
           

            List<DonVi> lstDonVi = db.DonVis.Where(s => s.TenDonVi.Contains("c")).ToList();
            cbbDonVi.DataSource = lstDonVi;
        
            cbbDonVi.SelectedIndex = 1;

            cbbLop.SelectedIndex = -1;
            cbbLop.Text = "";

            LoadDataIntoComboBoxLop(cbbDonVi.SelectedItem.ToString(), lstDonVi);

         
        }

        private void LoadDataIntoComboBoxLop(string tenDonVi, List<DonVi> lstDonVi)
        {
            //Clear Old List:
            cbbLop.Items.Clear();

            int maC = lstDonVi.Find(s => s.TenDonVi == tenDonVi).MaDonVi;

            var lstLopHocVien = db.HocViens.Where(s => s.Lop.MaDonVi == maC).Select(s => new { s.Lop }).Distinct().ToList();

            foreach (var item in lstLopHocVien)
            {
                cbbLop.Items.Add(item.Lop.ToString());
            }
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
   
        }


        private void LoadDataGridControl1(bool isLoadlop)
        {
           


        }
    }
}
