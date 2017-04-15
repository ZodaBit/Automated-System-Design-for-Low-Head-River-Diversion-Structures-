using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace hydrolics_software_project
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }


        private void radButton1_Click(object sender, EventArgs e)
        {
           IntakeDesign intakefrm = new IntakeDesign();
            intakefrm.Show();
            this.Hide();
        }

        private void radButton1_MouseClick(object sender, MouseEventArgs e)
        {
            radButton1.Text = "";
        }

       
    }
}
