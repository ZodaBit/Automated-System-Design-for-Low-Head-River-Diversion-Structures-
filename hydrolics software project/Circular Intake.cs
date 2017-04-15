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
    public partial class Circular_Intake : Telerik.WinControls.UI.RadForm
    {
        double FI, QC, QI, LI, FT, HLI, CBL, co=(double)0.81, BLIP, CLIP;
        public Circular_Intake()
        {
            InitializeComponent();
        }

        private void CircularcalcBtn_Click(object sender, EventArgs e)
        {
            double[] Dp=new double[9]{0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,1.0};
            double g = 9.81;
            
            if(Dischargeintaketextbox.Text=="" || Lengthcirculartextbox.Text=="" || canalbedcircletextbox.Text=="")
            {
                MessageBox.Show("you need to fill empty fields", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                QC = Convert.ToDouble(Dischargeintaketextbox.Text);
                LI = Convert.ToDouble(Lengthcirculartextbox.Text);
                CBL = Convert.ToDouble(canalbedcircletextbox.Text);
                
            }
            
           
              for(int i=0 ;i<Dp.Length;i++)
              {
                  
                  FI = ((double)0.024402 * LI) / (Math.Pow(Dp[i], (double)1 / 3));
                  FT = (double)1.5 + FI;

                  QI = (co * Math.PI * Math.Pow(Dp[i], 2) * Math.Sqrt(2 * g * 0.6)) * (double)1 / 4;

                  HLI = ((8 * Math.Pow(QI, 2)) * FT) / (Math.Pow(Math.PI, 2) * Math.Pow(Dp[i], 4) * g);

                 // HLI=((2*Math.Pow(QC,2))/g*Math.PI*Math.Pow(Dp[i],2))*((double)1.5+(0.024402/(Math.Pow(Dp[i],(double)1/3))));

                 

                  BLIP = HLI + CBL;
                  
                  if(QI>QC)
                  {
                      OutDiameterCircletextbox.Text = Dp[i].ToString();
                      CLIP = BLIP + Dp[i];
                      opcrestcircletextbox.Text = CLIP.ToString();
                      opbottomcircletextbox.Text = BLIP.ToString();
                     
                      break;
                     
                  }
                if(Dp[i]==1.0)
                 {

                   Rectangular_Intake frm = new Rectangular_Intake();
                    frm.Show();

                    this.Hide();
                   MessageBox.Show("YOU BETER TO USE RECTANGULAR TYPE");
                    break;
                  }
                  
              }
             
               
              weirbodyradButton1.Visible = true;
            
        }

        private void weirbodyradButton1_Click(object sender, EventArgs e)
        {
            WeirBody weirbodycircle = new WeirBody(HLI);
           
            weirbodycircle.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IntakeDesign frm = new IntakeDesign();
            frm.Show();
            this.Hide();
        }

        private void Dischargeintaketextbox_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
