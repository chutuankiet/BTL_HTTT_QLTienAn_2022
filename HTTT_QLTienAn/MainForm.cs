using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using HTTT_QLTienAn.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTTT_QLTienAn
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();
            LoadByAccessPermission();
        }
        NhaBep_ThanhToan uc1;
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

            uc1 = new NhaBep_ThanhToan();

            uc1.Dock = DockStyle.Fill;

            fluentDesignFormContainer1.Controls.AddRange(new Control[] { uc1 });


        }

        private void It1_Click(object sender, EventArgs e)
        {
            uc1.BringToFront();
        }

    }
}
