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
    public partial class Rectangular_Intake : Telerik.WinControls.UI.RadForm
    {
        public Rectangular_Intake()
        {
            InitializeComponent();
        }
        double WDC;
        double QC, Y1, RBL, CFL, CAL, S, b;
        double HLI ,LI,SI;
        private void CircularcalcBtn_Click(object sender, EventArgs e)
        {
           
            double HCRT, Bt,HLC, WCF, BLT;
          
            if (Discanalrecttextbox.Text == "" || averageyradTextBox1.Text == "" || rblradTextBox2.Text == "" || cflradTextBox3.Text == "" || calradTextBox4.Text == "" || slopradTextBox5.Text == "" || BtmwdthradTextBox7.Text == "" || SIradTextBox1.Text=="" || LIradTextBox1.Text=="")
            {
                MessageBox.Show("please fill the filled corectly", "message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                QC = Convert.ToDouble(Discanalrecttextbox.Text);
                Y1 = Convert.ToDouble(averageyradTextBox1.Text);
                RBL = Convert.ToDouble(rblradTextBox2.Text);
                CFL = Convert.ToDouble(cflradTextBox3.Text);
                CAL = Convert.ToDouble(calradTextBox4.Text);
                S = Convert.ToDouble(slopradTextBox5.Text);
                b = Convert.ToDouble(BtmwdthradTextBox7.Text);
                LI = Convert.ToDouble(LIradTextBox1.Text);
                SI = Convert.ToDouble(SIradTextBox1.Text);
            }

            HCRT = (double)0.9 * Y1;
            Bt = QC / ((double)1.61 * (Math.Sqrt(Math.Pow(HCRT, 3))));
            HLC = CAL * S;
            HLI = LI *SI;

            if (CanaltypecomboBox1.Text == "Trapezoidal")
            {WDC = (double)0.8673*b; }
            else if(CanaltypecomboBox1.Text=="Rectangular")
            { WDC = (double)b / 2; }

            WCF = CFL + HLI + HLC + WDC;
            BLT = WCF - HCRT;

            if (BLT < RBL)
            {

                bwtradTextBox8.Text = Math.Round(Bt, 2).ToString();
                bltradTextBox9.Text = Math.Round(RBL,2).ToString();
            }
            else
            {
                bwtradTextBox8.Text = Bt.ToString();
            bltradTextBox9.Text = BLT.ToString();
            }


            radButton1.Visible = true; 


        }

        

        private void radButton1_Click(object sender, EventArgs e)
        {
            WeirBody WEIRFRM = new WeirBody(HLI);
            WEIRFRM.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IntakeDesign frm = new IntakeDesign();
            frm.Show();
            this.Hide();
            
        }
    }
}
