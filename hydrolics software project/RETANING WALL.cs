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
    public partial class RETANING_WALL : Telerik.WinControls.UI.RadForm
    {
        double h , Hd , d2, Qp, X,He;
        public RETANING_WALL(double rh, double rHd, double rd2, double rQp, double rX,double Hex)
        {
            InitializeComponent();
            h = rh;
            He = Hex;
            Hd = rHd;
            d2 = rd2;
            Qp = rQp;
            X = rX;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            double Hus, Bwu, Hds, Bds, QU, Lu;
            //up stream retaing wall
            Hus = h + He + (double)0.5;
            Bwu = (double)2 / 3* Hus;
            
            //down stream retaing wall 
            Hds = d2 + 0.5;
            Bds = (double)2 / 3 * Hds;

            QU = X * Qp;
            Lu = QU / ((double)1.71 * (Math.Pow(Hd + h, (double)3 / 2)));

            undersluiceradTextBox1.Text = Lu.ToString();
            HeightradTextBox1.Text = Hus.ToString();
            BottomwidthradTextBox3.Text = Bwu.ToString();
            downheightradTextBox4.Text = Hds.ToString();
            downbottomradTextBox2.Text = Bds.ToString();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

       
    }
}
