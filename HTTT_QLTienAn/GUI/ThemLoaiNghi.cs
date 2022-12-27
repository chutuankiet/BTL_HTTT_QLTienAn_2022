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

        List<LoaiNghi> ListLoaiNghi;
        List<ChiTietLoaiNghi> lsCatCom = new List<ChiTietLoaiNghi>();
        int asang, atrua, atoi;
        bool IsTickAll = false;

        private void ThemLoaiNghi_Load(object sender, EventArgs e)
        {


            LoadCBLoaiNghi();
            MaLoaiNghiCurrent = ListLoaiNghi[0].MaLoaiNghi;
            LoadCTLoaiNghi(MaLoaiNghiCurrent);

        }

        void LoadCTLoaiNghi(int ma)
        {
            gridControl1.DataSource = null;
            lsCatCom = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == ma).ToList();
            gridControl1.DataSource = lsCatCom;
        }

        void LoadCBLoaiNghi()
        {
            ListLoaiNghi = db.LoaiNghis.ToList();

            cbLoaiNghi.DataSource = ListLoaiNghi;

            cbLoaiNghi.ValueMember = "MaLoaiNghi";
            cbLoaiNghi.DisplayMember = "TenLoaiNghi";


            LoadCTLoaiNghi(MaLoaiNghiCurrent);


        }

        int MaLoaiNghiCurrent;
        private void cbLoaiNghi_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = cbLoaiNghi.SelectedIndex;
            txtTenLoaiNghi.Text = ListLoaiNghi[index].TenLoaiNghi.ToString();
            lbSang.Text = ListLoaiNghi[index].SoBuoiSang.ToString();
            lbTrua.Text = ListLoaiNghi[index].SoBuoiTrua.ToString();
            lbToi.Text = ListLoaiNghi[index].SoBuoiToi.ToString();

            MaLoaiNghiCurrent = ListLoaiNghi[index].MaLoaiNghi;

            LoadCTLoaiNghi(MaLoaiNghiCurrent);

            btnXoa.Text = $"Xóa '{txtTenLoaiNghi.Text}' ?";
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            reloadSoBuoi();


            LoaiNghi newln = new LoaiNghi
            {
                TenLoaiNghi = txtTenLoaiNghi.Text,
                SoBuoiSang = Convert.ToInt32(lbSang.Text),
                SoBuoiTrua = Convert.ToInt32(lbTrua.Text),
                SoBuoiToi = Convert.ToInt32(lbToi.Text),

            };


            bool chinhsua = false;
            foreach (var item in ListLoaiNghi)
            {
                if (item.TenLoaiNghi == newln.TenLoaiNghi)
                {
                    chinhsua = true;
                }
            }



            if (chinhsua)
            {
                LoaiNghi lncosan = db.LoaiNghis.Where(m => m.TenLoaiNghi == newln.TenLoaiNghi).First();
                lncosan.SoBuoiSang = newln.SoBuoiSang;
                lncosan.SoBuoiTrua = newln.SoBuoiTrua;
                lncosan.SoBuoiToi = newln.SoBuoiToi;
                newln.MaLoaiNghi = lncosan.MaLoaiNghi;
                LuuLSCatCom(lncosan.MaLoaiNghi);
                MaLoaiNghiCurrent = lncosan.MaLoaiNghi;

                db.SaveChanges();
                MessageBox.Show("Sửa loại nghỉ thành công!!!");

            }
            else
            {
                db.LoaiNghis.Add(newln);
                db.SaveChanges();
                LuuLSCatCom(newln.MaLoaiNghi);
                MessageBox.Show("Thêm loại nghỉ thành công!!!");
                MaLoaiNghiCurrent = newln.MaLoaiNghi;
            }


            LoadCBLoaiNghi();

        }
        void LuuLSCatCom(int Ma)
        {
            List<ChiTietLoaiNghi> preList = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == Ma).ToList();
            db.ChiTietLoaiNghis.RemoveRange(preList);

            for (int i = 0; i < lsCatCom.Count; i++)
            {
                //if (i < preList.Count && )
                //{
                //    preList[i].Ngay = lsCatCom[i].Ngay;
                //    preList[i].BuoiSang = lsCatCom[i].BuoiSang;
                //    preList[i].BuoiTrua = lsCatCom[i].BuoiTrua;
                //    preList[i].BuoiToi = lsCatCom[i].BuoiToi;

                //}
                //else
                //{

                    ChiTietLoaiNghi newCTCC = new ChiTietLoaiNghi
                    {
                        Ngay = lsCatCom[i].Ngay,
                        BuoiSang = lsCatCom[i].BuoiSang,
                        BuoiTrua = lsCatCom[i].BuoiTrua,
                        BuoiToi = lsCatCom[i].BuoiToi,
                        MaLoaiNghi = Ma
                    };

                    db.ChiTietLoaiNghis.Add(newCTCC);
                //}
            }

            db.SaveChanges();

        }



        private void btnTickAll_Click(object sender, EventArgs e)
        {
            if (!IsTickAll)
            {

                foreach (var item in lsCatCom)
                {
                    item.BuoiSang = true;
                    item.BuoiTrua = true;
                    item.BuoiToi = true;
                }
                gridControl1.DataSource = null;
                gridControl1.DataSource = lsCatCom;
                IsTickAll = true;

                lbSang.Text = lbToi.Text = lbTrua.Text = txtSoNgay.Text;
                btnTickAll.Text = "Bỏ Tick Tất cả";
            }
            else
            {
                IsTickAll = false;

                btnTickAll.Text = "Tick Tất cả";
                foreach (var item in lsCatCom)
                {
                    item.BuoiSang = false;
                    item.BuoiTrua = false;
                    item.BuoiToi = false;
                }
                lbSang.Text = lbToi.Text = lbTrua.Text = "0";

                gridControl1.DataSource = null;
                gridControl1.DataSource = lsCatCom;
            }

        }


        void SuaCatCom()
        {


            int sobuoisang = Convert.ToInt32(lbSang.Text);
            int sobuoitrua = Convert.ToInt32(lbTrua.Text);
            int sobuoitoi = Convert.ToInt32(lbToi.Text);

            int calDay = Math.Max(sobuoisang, Math.Max(sobuoitrua, sobuoitoi));
            int songay = 0;

            gridControl1.DataSource = null;

            if (txtSoNgay.Text != "")
            {
                songay = Convert.ToInt32(txtSoNgay.Text);
            }
            else
            {
                songay = calDay;
            }


            List<ChiTietLoaiNghi> preCT = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == MaLoaiNghiCurrent).ToList();


            db.ChiTietLoaiNghis.RemoveRange(preCT);

            lsCatCom.Clear();

            for (int i = 0; i < songay; i++)
            {
                ChiTietLoaiNghi newct = new ChiTietLoaiNghi
                {
                    BuoiSang = true,
                    BuoiTrua = true,
                    BuoiToi = true,
                    Ngay = (i + 1)

                };

                //sobuoisang--; sobuoitrua--; sobuoitoi--;

                lsCatCom.Add(newct);
            }

            for (int i = 0; i < preCT.Count; i++)
            {
                if (i < songay && preCT.Count > songay) break;
                lsCatCom[i].BuoiSang = preCT[i].BuoiSang;
                lsCatCom[i].BuoiTrua = preCT[i].BuoiTrua;
                lsCatCom[i].BuoiToi = preCT[i].BuoiToi;
            }


            gridControl1.DataSource = lsCatCom;

            reloadSoBuoi();

        }



        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            reloadSoBuoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LoaiNghi xoaln = db.LoaiNghis.Where(m => m.MaLoaiNghi == MaLoaiNghiCurrent).First();
            if (MessageBox.Show($"Bạn có chắc chắn xóa ? {xoaln.TenLoaiNghi}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                List<ChiTietLoaiNghi> preCT = db.ChiTietLoaiNghis.Where(m => m.MaLoaiNghi == MaLoaiNghiCurrent).ToList();
                db.ChiTietLoaiNghis.RemoveRange(preCT);

                db.LoaiNghis.Remove(xoaln);
                db.SaveChanges();

                LoadCBLoaiNghi();

                gridControl1.DataSource = null;
                MessageBox.Show($"Đã xóa thành công  !");

            }
        }

        void reloadSoBuoi()
        {
            asang = atrua = atoi = 0;

            foreach (var item in lsCatCom)
            {
                if (item.BuoiSang) asang++;
                if (item.BuoiTrua) atrua++;
                if (item.BuoiToi) atoi++;
            }

            lbSang.Text = asang.ToString();
            lbTrua.Text = atrua.ToString();
            lbToi.Text = atoi.ToString();
        }
        private void btnSuaCatCom_Click(object sender, EventArgs e)
        {
            SuaCatCom();


        }
    }
}