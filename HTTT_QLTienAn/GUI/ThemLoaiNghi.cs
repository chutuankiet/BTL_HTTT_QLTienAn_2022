using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTT_QLTienAn.Model;
using System.Windows.Forms;

namespace HTTT_QLTienAn.GUI
{
    public partial class ThemLoaiNghi : DevExpress.XtraEditors.XtraForm
    {
        public ThemLoaiNghi()
        {
            InitializeComponent();
        }

        QLTA_model db = new QLTA_model();

        List<ChiTietLoaiNghi> ListLoaiNghi;

        private void ThemLoaiNghi_Load(object sender, EventArgs e)
        {


            ListLoaiNghi = db.ChiTietLoaiNghis.ToList();

            cbLoaiNghi.DataSource = ListLoaiNghi;

            cbLoaiNghi.ValueMember = "MaLoaiNghi";
            cbLoaiNghi.DisplayMember = "TenLoaiNghi";
        }


        private void cbLoaiNghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbLoaiNghi.SelectedIndex;
            txtTenLoaiNghi.Text = ListLoaiNghi[index].TenLoaiNghi.ToString();
            txtSang.Text = ListLoaiNghi[index].SoBuoiSang.ToString();
            txtTrua.Text = ListLoaiNghi[index].SoBuoiTrua.ToString();
            txtToi.Text = ListLoaiNghi[index].SoBuoiToi.ToString();



        }

        private void ThemLoaiNghi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ?",
                       "Thoát ?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnThemloainghi_Click(object sender, EventArgs e)
        {
            ChiTietLoaiNghi newct = new ChiTietLoaiNghi
            {
                TenLoaiNghi = txtTenLoaiNghi.Text,
                SoBuoiSang = Convert.ToInt32(txtSang.Text),
                SoBuoiTrua = Convert.ToInt32(txtTrua.Text),
                SoBuoiToi = Convert.ToInt32(txtToi.Text),

            };

            foreach (var item in ListLoaiNghi)
            {
                if (item.TenLoaiNghi == newct.TenLoaiNghi)
                {
                    MessageBox.Show("Tên loại nghỉ đã tồn tại !!!", "Error");
                    return;
                }
            }

            db.ChiTietLoaiNghis.Add(newct);
            db.SaveChanges();
            MessageBox.Show("Thêm loại nghỉ thành công!!!");

            
        }
    }
}