using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIE2264_miniproject_GUI
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
            collection.UpdateSettings();
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            do
            {
                form1 = new Form1();
                Application.Run(form1);
                if (form1.Form1Execute)
                {
                    form2 = new Form2();
                    Application.Run(form2);
                }
            } while (Form2.act == 1);
        }
    }
}
