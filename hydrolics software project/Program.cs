
using System;
using System.Linq;
using System.Windows.Forms;

namespace hydrolics_software_project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application hydraulics.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RadForm1());
           // RadForm1
            
        }
    }
}