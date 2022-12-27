using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTTT_QLTienAn.GUI;
using HTTT_QLTienAn.GUI.Lop;

namespace HTTT_QLTienAn
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            //Application.Run(new ThongTinDK_HV(1, true));
            //Application.Run(new ThemLoaiNghi());

            //DateTime start = new DateTime(2022, 12, 9);
            //DateTime end = new DateTime(2022, 12, 13);

            //Application.Run(new CatCom_HV(start,end,1,1));


        }
    }
}
