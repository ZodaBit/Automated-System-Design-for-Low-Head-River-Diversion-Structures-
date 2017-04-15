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
    public partial class IntakeDesign : Telerik.WinControls.UI.RadForm
    {
        public IntakeDesign()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Rectangular_Intake recintake = new Rectangular_Intake();
            recintake.Show();
            this.Hide();
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Circular_Intake circintake = new Circular_Intake();
            circintake.Show();
            this.Hide();
            
        }
    }
}
