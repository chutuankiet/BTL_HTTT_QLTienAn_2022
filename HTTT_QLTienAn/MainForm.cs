using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTTT_QLTienAn.GUI.Admin;
using HTTT_QLTienAn.GUI.Lop;
using HTTT_QLTienAn.GUI.DaiDoi;
using HTTT_QLTienAn.GUI.TieuDoan;
using HTTT_QLTienAn.GUI.NhaBep;
using HTTT_QLTienAn.GUI;
using HTTT_QLTienAn.Model;

using DevExpress.XtraBars.Navigation;

namespace HTTT_QLTienAn
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        bool logout;


        Lop_NhapDS uc1;
        Lop_ChoPheDuyet uc2;
        Lop_DaHuy uc3;
        Lop_DaPheDuyet uc4;

        DaiDoi_ChoPheDuyet uc5;
        DaiDoi_DaHuyPheDuyet uc6;
        DaiDoi_DaPheDuyet uc7;
        DaiDoi_QuanLyDS uc71;

        TieuDoan_ChoPheDuyet uc8;
        TieuDoan_DaHuy uc9;
        TieuDoan_DaPheDuyet uc10;
        TieuDoan_QuanLyDS uc101;

        NhaBep_QuanLyDS uc11;
        NhaBep_ThanhToan uc12;
        NhaBep_ThongKe uc13;
        NhaBep_LSCatCom uc131;
        

        Admin_QLCanBo uc14;
        Admin_QLDonVi uc15;
        Admin_QLHocVien uc16;
        Admin_QLTaiKhoan uc17;
        Admin_QLTieuChuanAn uc18;


        CanBo_SuaDSNhap ucSuaNhap;
        Chung_LSThanhToan ucLSThanhToan;

        public static int MaID;

        QLTA_model db = new QLTA_model();

        public MainForm(int maid, string accPer)

        {
            InitializeComponent();
            LoadByAccessPermission(accPer);
            logout = false;
            MaID = maid;
        }

        int Ma = MaID; 


        public MainForm(string accPer)
        {
            InitializeComponent();
            logout = false;
            LoadByAccessPermission(accPer);

        }

        public void LoadByAccessPermission(string accPer)
        {
            
            switch (accPer)
            {

                case "l":

                    this.Text = "Lớp";

                    //AccordionControlElement gr1 = new AccordionControlElement(ElementStyle.Group) { Text = "Quản lý danh sách" };
                    AccordionControlElement it1 = new AccordionControlElement(ElementStyle.Item) { Text = "Nhập danh sách" };
                    AccordionControlElement it2 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách chờ phê duyệt" };
                    AccordionControlElement it3 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã hủy" };
                    AccordionControlElement it4 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã phê duyệt" };

                    //gr1.Elements.AddRange(new AccordionControlElement[] { it6, it7, it8 });
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it1, it2, it3, it4 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it1.Click += It1_Click;
                    it2.Click += It2_Click;
                    it3.Click += It3_Click;
                    it4.Click += It4_Click;

                    uc1 = new Lop_NhapDS();
                    uc2 = new Lop_ChoPheDuyet();
                    uc3 = new Lop_DaHuy();
                    uc4 = new Lop_DaPheDuyet();

                    uc1.Dock = DockStyle.Fill;
                    uc2.Dock = DockStyle.Fill;
                    uc3.Dock = DockStyle.Fill;
                    uc4.Dock = DockStyle.Fill;
                    showUsercontrol.Controls.AddRange(new Control[] { uc1, uc2, uc3, uc4 });
                    break;


                case "c":
                    this.Text = "Đại đội";
                    AccordionControlElement it5 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách chờ phê duyệt" };
                    AccordionControlElement it6 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã hủy" };
                    AccordionControlElement it7 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã phê duyệt" };
                    AccordionControlElement itLichSuTT = new AccordionControlElement(ElementStyle.Item) { Text = "Lịch sử thanh toán" };
                    AccordionControlElement it71 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lý quân số ăn" };

                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it5, it6, it7, itLichSuTT, it71 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it5.Click += It5_Click;
                    it6.Click += It6_Click;
                    it7.Click += It7_Click;
                    itLichSuTT.Click += ItLSTT_Click;
                    it71.Click += It71_Click;
                    //itSuaNhap.Click += itSuaNhap_Click;

                    uc5 = new DaiDoi_ChoPheDuyet();
                    uc6 = new DaiDoi_DaHuyPheDuyet();
                    uc7 = new DaiDoi_DaPheDuyet();
                    ucLSThanhToan = new Chung_LSThanhToan(true);
                    uc71 = new DaiDoi_QuanLyDS();

                    //testing..............

                    //CanBo cbc = db.CanBoes.Where(m => m.MaCanBo == Ma).FirstOrDefault();

                    //List<HocVien> dshv = db.HocViens.ToList();
                    //List<DangKyNghi> dsdk = db.DangKyNghis.ToList();

                    //ucSuaNhap = new CanBo_SuaDSNhap(dshv,dsdk);


                    uc5.Dock = DockStyle.Fill;
                    uc6.Dock = DockStyle.Fill;
                    uc7.Dock = DockStyle.Fill;
                    ucLSThanhToan.Dock = DockStyle.Fill;
                    uc71.Dock = DockStyle.Fill;
                    //ucSuaNhap.Dock = DockStyle.Fill;

                    showUsercontrol.Controls.AddRange(new Control[] { uc5, uc6, uc7, ucLSThanhToan,uc71 });

                    break;

                case "d":
                    this.Text = "Tiểu đoàn";

                    AccordionControlElement it8 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đang chờ duyệt" };
                    AccordionControlElement it9 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã hủy" };
                    AccordionControlElement it10 = new AccordionControlElement(ElementStyle.Item) { Text = "Danh sách đã duyệt" };
                    AccordionControlElement it101 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lý quân số ăn" };

                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it8, it9, it10, it101 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it8.Click += It8_Click;
                    it9.Click += It9_Click;
                    it10.Click += It10_Click;
                    it101.Click += It101_Click;


                    uc8 = new TieuDoan_ChoPheDuyet();//para macanbo
                    uc9 = new TieuDoan_DaHuy();
                    uc10 = new TieuDoan_DaPheDuyet();
                    uc101 = new TieuDoan_QuanLyDS();

                    uc8.Dock = DockStyle.Fill;
                    uc9.Dock = DockStyle.Fill;
                    uc10.Dock = DockStyle.Fill;
                    uc101.Dock = DockStyle.Fill;


                    showUsercontrol.Controls.AddRange(new Control[] { uc8, uc9, uc10,uc101 });

                    break;

                case "nb":
                    this.Text = "Nhà bếp";

                    AccordionControlElement it11 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lý danh sách" };
                    AccordionControlElement it12 = new AccordionControlElement(ElementStyle.Item) { Text = "Thanh toán" };
                    AccordionControlElement it13 = new AccordionControlElement(ElementStyle.Item) { Text = "Thống kê" };
                    AccordionControlElement it131 = new AccordionControlElement(ElementStyle.Item) { Text = "Lịch sử thanh toán" };
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it11, it12, it13, it131 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it11.Click += It11_Click;
                    it12.Click += It12_Click;
                    it13.Click += It13_Click;
                    it131.Click += It131_Click;
                    uc11 = new NhaBep_QuanLyDS();
                    uc12 = new NhaBep_ThanhToan();
                    uc13 = new NhaBep_ThongKe();
                    uc131 = new NhaBep_LSCatCom();
                    uc11.Dock = DockStyle.Fill;
                    uc12.Dock = DockStyle.Fill;
                    uc13.Dock = DockStyle.Fill;
                    uc131.Dock = DockStyle.Fill;

                    showUsercontrol.Controls.AddRange(new Control[] { uc11, uc12, uc13,uc131 });
                    break;

                case "admin":
                    this.Text = "Quản trị viên";
                    AccordionControlElement it14 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lí cán bộ" };
                    AccordionControlElement it15 = new AccordionControlElement(ElementStyle.Item) { Text = "Thông tin đơn vị" };
                    AccordionControlElement it16 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lí học viên" };
                    AccordionControlElement it17 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lý Tài khoản" };
                    AccordionControlElement it18 = new AccordionControlElement(ElementStyle.Item) { Text = "Quản lí Tiêu chuẩn ăn" };
                    accordionControl1.Elements.AddRange(new AccordionControlElement[] { it14, it15, it16, it17, it18 });
                    accordionControl1.AllowItemSelection = true;
                    accordionControl1.ExpandAll();

                    it14.Click += It14_Click;
                    it15.Click += It15_Click;
                    it16.Click += It16_Click;
                    it17.Click += It17_Click;
                    it18.Click += It18_Click;

                    uc14 = new Admin_QLCanBo();
                    uc15 = new Admin_QLDonVi();
                    uc16 = new Admin_QLHocVien();
                    uc17 = new Admin_QLTaiKhoan();
                    uc18 = new Admin_QLTieuChuanAn();

                    uc14.Dock = DockStyle.Fill;
                    uc15.Dock = DockStyle.Fill;
                    uc16.Dock = DockStyle.Fill;
                    uc17.Dock = DockStyle.Fill;
                    uc18.Dock = DockStyle.Fill;

                    showUsercontrol.Controls.AddRange(new Control[] { uc14, uc15, uc16, uc17 ,uc18});
                    break;
                default:
                    break;

            }


         
        }

        private void ItLSTT_Click(object sender, EventArgs e)
        {
            ucLSThanhToan.BringToFront();
        }

        private void itSuaNhap_Click(object sender, EventArgs e)
        {
            ucSuaNhap.BringToFront();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout == false)
            {
                Application.Exit();
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout = true;
            this.Close();
        }




        #region admin
        private void It18_Click(object sender, EventArgs e)
        {
            uc18.BringToFront();
        }

        private void It17_Click(object sender, EventArgs e)
        {
            uc17.BringToFront();
        }

        private void It16_Click(object sender, EventArgs e)
        {
            uc16.BringToFront();
        }

        private void It15_Click(object sender, EventArgs e)
        {
            uc15.BringToFront();
        }

        private void It14_Click(object sender, EventArgs e)
        {
            uc14.BringToFront();
        }


        #endregion

        #region nhabep
        private void It13_Click(object sender, EventArgs e)
        {
            uc13.BringToFront();
        }

        private void It12_Click(object sender, EventArgs e)
        {
            uc12.BringToFront();
        }

        private void It11_Click(object sender, EventArgs e)
        {
            uc11.BringToFront();
        }
        private void It131_Click(object sender, EventArgs e)
        {
            uc131.BringToFront();
        }
        #endregion

        #region tieudoan
        private void It10_Click(object sender, EventArgs e)
        {
            uc10.reload();
            uc10.BringToFront();
            uc10.reload();
        }
        private void It101_Click(object sender, EventArgs e)
        {
            
            uc101.BringToFront();
           
        }
        private void It9_Click(object sender, EventArgs e)
        {
            uc9.reload();
            uc9.BringToFront();
            uc9.reload();
        }

        private void It8_Click(object sender, EventArgs e)
        {
            uc8.BringToFront();
        }

        #endregion

        #region daidoi

        private void It7_Click(object sender, EventArgs e)
        {
            uc7.BringToFront();
            uc7.reload();

        }
        private void It71_Click(object sender, EventArgs e)
        {
            uc71.BringToFront();
            //uc7.reload();

        }
        private void It6_Click(object sender, EventArgs e)
        {
            uc6.BringToFront();
            uc6.reload();

        }

        private void It5_Click(object sender, EventArgs e)
        {
            uc5.BringToFront();
        }

        #endregion





        #region Lop
        private void It4_Click(object sender, EventArgs e)
        {
            uc4.BringToFront();

        }

        private void It3_Click(object sender, EventArgs e)
        {
            uc3.BringToFront();

        }


        private void It2_Click(object sender, EventArgs e)
        {
            uc2.BringToFront();
            uc2.LoadDS1();
        }

        private void It1_Click(object sender, EventArgs e)
        {

            uc1.BringToFront();

        }

        #endregion







    }
}
