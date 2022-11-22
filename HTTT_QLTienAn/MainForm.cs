using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HTTT_QLTienAn.GUI.Lop;
using DevExpress.XtraBars.Navigation;

namespace HTTT_QLTienAn
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        bool logout;
        public MainForm()

        {
            InitializeComponent();
            LoadByAccessPermission();


        }

        Lop_NhapDS uc1;
        public static int MaID;

        

        public void LoadByAccessPermission()
        {

            AccordionControlElement it1 = new AccordionControlElement(ElementStyle.Item) { Text = "Nhập danh sách" };
            AccordionControlElement it2 = new AccordionControlElement(ElementStyle.Item) { Text = "Đang chờ duyệt" };
            AccordionControlElement it3 = new AccordionControlElement(ElementStyle.Item) { Text = "Đã duyệt" };
            AccordionControlElement it4 = new AccordionControlElement(ElementStyle.Item) { Text = "Đã hủy" };
            accordionControl1.Elements.AddRange(new AccordionControlElement[] { it1, it2, it3, it4 });
            accordionControl1.AllowItemSelection = true;
            accordionControl1.ExpandAll();

            it1.Click += It1_Click;
         
            uc1 = new Lop_NhapDS();
          
            uc1.Dock = DockStyle.Fill;
           
            showUsercontrol.Controls.AddRange(new Control[] { uc1 });


        }

        private void It1_Click(object sender, EventArgs e)
        {
            uc1.BringToFront();
        }


    }
}
