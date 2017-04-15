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
    public partial class WeirBody_Subsurface : Telerik.WinControls.UI.RadForm
    {
        double TW, d, d1, h, TC, q, wb, angle, Hd, He, QP, d2, X;
        double Tad, Tbd, Tcd, Tdd, Ted, Tfd, Tak, Tbk, Tck, Tdk, Tek, Tfk;
        
        public WeirBody_Subsurface(double dd, double dd1, double hd, double twd, double qd, double wbd, double hdd, double qph, double xh, double d2h, double Heh, double sTad, double sTbd, double sTcd, double sTdd, double sTed, double sTfd, double sTak, double sTbk, double sTck, double sTdk, double sTek, double sTfk)
        {
            InitializeComponent();
            Tad = sTad;
            Tbd = sTbd;
            Tcd = sTcd;
            Tdd = sTdd;
            Ted = sTed;
            Tfd = sTfd;
            Tak = sTak;
            Tbk = sTbk;
            Tck = sTck;
            Tdk = sTdk;
            Tek = sTek;
            Tfk = sTfk;
            d = dd;
            He = Heh;
            d1 = dd1;
            h = hd;
            TW = twd;
            q = qd;
            wb = wbd;
            Hd = hdd;
            X = xh;
            QP = qph;
            d2 = d2h;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Blighchekbox.CheckState==CheckState.Checked)
            

            //if (comboBox1.Text == "bligh")
            {
               
                if (Tad <= 0.5)
                {
                    Tad = 0.5;
                    texta.Text = Tad.ToString();

                }
                else
                {
                    texta.Text = Tad.ToString();
                }// end of tad

                if (Tbd <= 0.5)
                {
                    Tbd = 0.5;
                    radtextb.Text = Tbd.ToString();

                }
                else
                {
                    radtextb.Text = Tbd.ToString();
                }// end of tbd 


                if (Tcd <= 0.5)
                {
                    Tcd = 0.5;
                    radtextc.Text = Tcd.ToString();
                }
                else
                {
                    radtextc.Text = Tcd.ToString();

                }  //end of tcd

                if (Tdd <= 0.5)
                {
                    Tdd = 0.5;
                    radtextd.Text = Tdd.ToString();
                }

                else
                {
                    radtextd.Text = Tdd.ToString();

                }  //end of tdd


                if (Ted <= 0.5)
                {
                    Ted = 0.5;
                    radtexte.Text = Ted.ToString();
                }

                else
                {
                    radtexte.Text = Ted.ToString();

                }  //end of ted

                if (Tfd <= 0.5)
                {
                    Tfd = 0.5;
                    radtextf.Text = Tfd.ToString();
                }

                else
                {
                    radtextf.Text = Tfd.ToString();

                }  //end of tfd



            } //end of If
           if(Khoslachekbox.CheckState==CheckState.Checked)

        // if(comboBox1.Text=="khosla")
         {
            

             if (Tak <= 0.5)
             {
                 Tak = 0.5;
                 texta.Text = Tak.ToString();

             }
             else
             {
                 texta.Text = Tak.ToString();
             }// end of tad

             if (Tbk<= 0.5)
             {
                 Tbk = 0.5;
                 radtextb.Text = Tbk.ToString();

             }
             else
             {
                 radtextb.Text = Tbk.ToString();
             }// end of tbd 


             if (Tck <= 0.5)
             {
                 Tck = 0.5;
                 radtextc.Text = Tck.ToString();
             }
             else
             {
                 radtextc.Text = Tck.ToString();

             }  //end of tcd

             if (Tdk <= 0.5)
             {
                 Tdk = 0.5;
                 radtextd.Text = Tdk.ToString();
             }

             else
             {
                 radtextd.Text = Tdk.ToString();

             }  //end of tdd


             if (Tek <= 0.5)
             {
                 Tek = 0.5;
                 radtexte.Text = Tek.ToString();
             }

             else
             {
                 radtexte.Text = Tek.ToString();

             }  //end of ted

             if (Tfk <= 0.5)
             {
                 Tfk = 0.5;
                 radtextf.Text = Tfk.ToString();
             }

             else
             {
                 radtextf.Text = Tfk.ToString();

             }  //end of tfd


         }
         Dynamicbtn.Visible = true;

        }

        private void Dynamicbtn_Click(object sender, EventArgs e)
        {
           
            TC = Convert.ToDouble(radtextc.Text);
            //d, d1randval, valueofh(), Tw, TC, q, wb, hdrandresult,Qp,X,d2,He
            Dynamic_Conditions frms = new Dynamic_Conditions(d,d1,h,TW,TC,q,wb,Hd,QP,X,d2,He);
            frms.Show();
        } //end of method 
    }
}
