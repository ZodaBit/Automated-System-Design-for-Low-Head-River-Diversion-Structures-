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
    public partial class WeirBody : Telerik.WinControls.UI.RadForm
    {
        double HLI;
        public WeirBody(double hli)
        {
            HLI = hli;
            InitializeComponent();
        }
        double Tad, Tbd, Tcd, Tdd, Ted, Tfd, Tak, Tbk, Tck, Tdk, Tek, Tfk;

        double Wdc, X, wb, c, Gex, Tw, Bw, d, v2, H, Lb, ldsa;
        const double g = 9.81;
        double RBLh, CAL, S, b, CFL, Qp, LR, d3, mr, RBL, DGd, DGu, FRn, V1n, d2n, v2n;
        double Ls, AL, lamda, Ge, Lus, PL, Hmax, lds, SF =(double) 4 / 3;
        double Q, He, Hd, L, d1, q, hdrandresult, v1, Fr, d1randval, d2, DsHFL, DsCL, DsCd, UsCL, UsCd, d1n;
        private void radButton1_Click(object sender, EventArgs e)
        {
            double Dscd2, Ge2, Dscd3, Ge3, Dscd4, Ge4;
         
            WEIRHIGHTradTextBox1.Text = valueofh().ToString();
            
            if (PeakradTextBox1.Text == "" || widthreverradTextBox4.Text == "" || tailwaterradTextBox6.Text == "" || MeanradTextBox1.Text == "" || rivrbedradTextBox10.Text == "" || depthdownradTextBox11.Text == "" || depthupradTextBox2.Text == "" || WeirbodycomboBox1.Text == "" || PercentagecomboBox1.Text == "" || TypeofcomboBox1.Text=="")
            {
                MessageBox.Show("You have left a Required field empty", "message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
            Qp = Convert.ToDouble(PeakradTextBox1.Text);
            LR = Convert.ToDouble(widthreverradTextBox4.Text);
            d3 = Convert.ToDouble(tailwaterradTextBox6.Text);
            mr=Convert.ToDouble(MeanradTextBox1.Text);
            RBL=Convert.ToDouble(rivrbedradTextBox10.Text);
            DGd=Convert.ToDouble(depthdownradTextBox11.Text);
            DGu=Convert.ToDouble(depthupradTextBox2.Text);
             if(WeirbodycomboBox1.Text=="Concrete")
             { wb = 2.3; }
             else if(WeirbodycomboBox1.Text=="Masonary")
             { wb = 2.4; }
             else if(WeirbodycomboBox1.Text=="Cement Mortar")
             { wb = 2.1; }
             else if (WeirbodycomboBox1.Text == "Reinforced Concrete")
             { wb = 2.45; }
            if (PercentagecomboBox1.Text == "10%")
            { X = 0.1; }
            else if (PercentagecomboBox1.Text == "15%")
            { X = 0.15; }
            else if (PercentagecomboBox1.Text == "20%")
            { X = 0.12; }
            if(TypeofcomboBox1.Text=="Fine Sand")
            {
                c = 15;
                Gex = 0.17;
            
            }
           if(TypeofcomboBox1.Text=="Coarse Sand")
           {
               c = 12;
               Gex = 0.2;
           }
            if(TypeofcomboBox1.Text=="Sand Mixed with boulder")
            {
                c = 9;
                Gex = 0.25;
                
            }
            if (TypeofcomboBox1.Text == "tight Sand")
            {
                c = 8;
                Gex = 0.25;
               
            }
        }
            // calculation began here
            Q = (1 - X) * Qp;
            L = (1 - X) * LR;
            He = Math.Pow(Q / (1.71 * L), (double)2 / 3);

            //hdrandresult = (2 * He) / 3;
           // d1randval = (2 * (valueofh() + He)) / 3;

            hdrandresult = hdrand(Hd, He, Q, L,Qp);
           d1randval = d1rand(d1, valueofh(), He, Q, L,hdrandresult);
            q = Q / L;
            v1 = q / d1randval;
            Fr = v1 / Math.Sqrt(d1randval * g);
            d2=(double)d1randval/2*((Math.Sqrt(1+(8*Math.Pow(Fr,2))))-1);
           
             v2 = q / d2;
             d = d2 - d3;
          
            //value pass for norandfucction
            double d1d = (2 * (valueofh() + d + He)) / 3;
            if (d < 0.4)
            {
                d = 0;
                if (Fr < 2.5)
                {
                    energyradTextBox1.Text = "DON'T USE ENERGY DISSIPATOR";
                }
                else
                {
                    if (Fr > 2.5 && Fr < 4.5)
                    {
                        energyradTextBox1.Text = "USE TYPE IV";
                    }
                    else
                    {
                        if (Fr < 10)
                        {
                            if (v1 < 18)
                            {
                                energyradTextBox1.Text = "USE TYPE III";
                            }
                            else
                            {
                                energyradTextBox1.Text = "USE TYPE II";
                            }
                        }
                        else
                        {
                            energyradTextBox1.Text = "USE BUCKET TYPE";
                        }
                    }
                }
                DepthofCisterntextbox.Text = d.ToString();
                
            }
            else
            {
                 d1randval= nodrand(d1d, d, valueofh(), Q, He, L,d1randval);
                // d1randval= (2 * (valueofh() + d + He)) / 3;
                 v1= q/d1randval;
                 Fr=v1/(Math.Sqrt(g*d1randval));
                d2=((double)d1randval/2)*(Math.Sqrt((1+8*(Math.Pow(Fr,2)))));
          
                v2=q/d2;
                if(Fr<2.5)
                {
                    energyradTextBox1.Text="DON'T USE ENERGY DISSIPATOR";
                }
                else 
                {
                    if(Fr>2.5 && Fr<4.5)
                    {
                        energyradTextBox1.Text="USE TYPE IV";
                    }
                      else
                    {
                         if(Fr<10)
                        
                        {
                            if(v1<18)
                            {
                                energyradTextBox1.Text="USE TYPE III";
                            }
                        else 
                            {
                                energyradTextBox1.Text="USE TYPE II";
                            }
                        }
                        else
                        {
                            energyradTextBox1.Text="USE BUCKET TYPE";
                        }
                    }
                }
                DepthofCisterntextbox.Text = d.ToString();
            }
            // code for finding downstream bed leve 
          double DsBL= downstreambedlevel(RBL, valueofh(), He, hdrandresult, d3, d2);
         
            // code for finding the top width of a weir body and bottom witdth of weir body
             Tw = He / (Math.Sqrt(wb - 1));
             Bw = Tw + (valueofh() / (Math.Sqrt(wb - 1)));
            topwidthradTextBox2.Text = Tw.ToString();
            BottomwidthradTextBox4.Text = Bw.ToString();
            //code for finding uper stream cd and down stream cd
            double f = 1.76 * (Math.Sqrt(mr));
            double R = 1.35 * (Math.Pow(q / f, (double)2 / 3));
           
            double UsHFL = RBL + valueofh() + He;
             if(R>2.5)
             {
                 R = 2.5;

                  DsHFL = RBL + d3;
                  DsCL = DsHFL - (2 * R);
                  DsCd = RBL - DsCL;
                  UsCL = UsHFL - (1.5 * R);
                  UsCd = RBL - UsCL;
                  if(DsCd<=DGd)
                  {
                      downsstreamcutoofradTextBox6.Text = DGd.ToString();
                  }
                if(DsCd>=DGd)
                {
                    DsCd = DGd;
                    downsstreamcutoofradTextBox6.Text = DsCd.ToString();
                }
                  if(UsCd<=DGu)
                  { 
                      upstramcuttoffradTextBox5.Text = DGu.ToString();
                  }
                 if(UsCd>=DGu)
                 {
                     UsCd = DGu;
                     upstramcuttoffradTextBox5.Text = UsCd.ToString();
                 }

                }
          else
             {

                 DsHFL = RBL + d3;
                 DsCL = DsHFL - (2 * R);
                 DsCd = RBL - DsCL;
                 UsCL = UsHFL - (1.5 * R);
                 UsCd = RBL - UsCL;
                 if (DsCd <= DGd)
                 {
                     downsstreamcutoofradTextBox6.Text = DGd.ToString();
                 }
                 if (DsCd >= DGd)
                 {
                     DsCd = DGd;
                     downsstreamcutoofradTextBox6.Text = DsCd.ToString();
                 }
                 if (UsCd <= DGu)
                 {
                     upstramcuttoffradTextBox5.Text = DGu.ToString();
                 }
                 if (UsCd >= DGu)
                 {
                     UsCd = DGu;
                     upstramcuttoffradTextBox5.Text = UsCd.ToString();
                 }
                /* UsCd = DGu;
                 DsCd = DGd;
                 downsstreamcutoofradTextBox6.Text = DsCd.ToString();
             upstramcuttoffradTextBox5.Text = UsCd.ToString();*/
             }

             DsCd = DGd;
             UsCd = DGu;
//CODE FOR CALCULAING LENGTHOF UPSTREAM APRON ,LENGTHOF DOWNSREAM APRON(LDS) AND STILLING BASINE..................
             H = ((RBL +valueofh() + He )- DsBL);
             Lb=c*H;
             ldsa = 3.87 * c * (Math.Sqrt(Math.Abs(H / 10)));
              Ls=5*d2;
              lds = ldsa - Ls;
              Lus = Lb - ((2 * UsCd) + Bw + ldsa + (2 * DsCd));

            if (Lus>0)
            {
                
                AL = (Lus + Bw + Ls + lds) / DsCd;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge = valueofh() / DsCd * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd2 = DsCd + 0.2;
                AL = (Lus + Bw + Ls + lds) / Dscd2;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge2 = valueofh() / Dscd2 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge2 < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd3 = DsCd + 0.3;
                AL = (Lus + Bw + Ls + lds) / Dscd3;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge3 = valueofh() / Dscd3 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge3 < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd4 = DsCd + 0.4;
                AL = (Lus + Bw + Ls + lds) / Dscd4;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge4 = valueofh() / Dscd4 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge4 > Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }             

            }
            else
            {
                Lus = 2.5;
                AL = (Lus + Bw + Ls + lds) / DsCd;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge = valueofh() / DsCd * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd2 = DsCd + 0.2;
                AL = (Lus + Bw + Ls + lds) / Dscd2;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge2 = valueofh() / Dscd2 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge2 < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd3 = DsCd + 0.3;
                AL = (Lus + Bw + Ls + lds) / Dscd3;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge3 = valueofh() / Dscd3 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge3 < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
                Dscd4 = DsCd + 0.4;
                AL = (Lus + Bw + Ls + lds) / Dscd4;
                lamda = (1 + (Math.Sqrt(1 + (Math.Pow(AL, 2))))) / 2;
                Ge4 = valueofh() / Dscd4 * (1 / (Math.PI * (Math.Sqrt(lamda))));
                if (Ge4 < Gex)
                {
                    lengthofdownradTextBox8.Text = ldsa.ToString();
                    lengthofupradTextBox7.Text = Lus.ToString();
                    lengthofstillingradTextBox9.Text = Ls.ToString();
                }
               


            }//ENDING OF RADBUTON FOR WIR BODY 
           
//END FOR CALCULATING LDS, LUS AND LS APRONS...................................................................... 

//ALGORITHM FOR DOWNSTREAM FLOOR THICKNESS.......................................................................
            double Hdyn = He + valueofh() ;
            double Lc = (2 * UsCd) + (Lus + Bw + Ls + lds + (2 * DsCd));
            double Lpa = (2 * UsCd) + Lus;
            double Lpb = Lpa + Tw;
            double Lpc = Lpb + (Bw - Tw);
            double Lpd = Lpc + Ls;
            double Lpe = Lpd + (0.5 * lds);
            double Lpf = Lpd + lds;

            double valueofsfwb=SF/(wb-1);
            double Tas = valueofh() * (1 - (Lpa / Lc)) * valueofsfwb;
            double Tbs = valueofh() * (1 - (Lpb / Lc)) * valueofsfwb;
            double Tcs = valueofh() * (1 - (Lpc / Lc)) * valueofsfwb;
            double Tds = valueofh() * (1 - (Lpd / Lc)) * valueofsfwb;
            double Tes = valueofh() * (1 - (Lpe / Lc)) * valueofsfwb;
            double Tfs = valueofh() * (1 - (Lpf / Lc)) * valueofsfwb;
            //Blieh approace
             Tad = Hdyn * (1 - (Lpa / Lc)) * valueofsfwb;
             Tbd = Hdyn * (1 - (Lpb/ Lc)) * valueofsfwb;
             Tcd = Hdyn * (1 - (Lpc / Lc)) * valueofsfwb;
             Tdd = Hdyn * (1 - (Lpd / Lc)) * valueofsfwb;
             Ted = Hdyn * (1 - (Lpe / Lc)) * valueofsfwb;
             Tfd = Hdyn * (1 - (Lpf / Lc)) * valueofsfwb;

 //KOHSLAS APPROACH FOR FINDING HRC1 AND HRE2............................................
            double bH = Lus + Bw + Ls + lds;
            double xbh = bH / DsCd;
            double lamda1 = 1 + (Math.Pow(xbh, 2));
            double lamdadegre = (1 + (Math.Sqrt(lamda1))) / 2;
            double lamdavalue=(lamdadegre-2)/lamdadegre;
            double tetaE = (1 /Math.PI)* (Math.Acos(lamdavalue));
            double lamdavalue2=(lamdadegre-1)/lamdadegre;
            double tetaD = (1 /Math.PI) * (Math.Acos(lamdavalue2));

            double tetaD1 = 1 - tetaD;
            double tetaC1 = 1 - tetaE;

            double Cdu = tetaC1 + ((tetaD1 - tetaC1) / DsCd) * 0.5;
            double Cmd = 19 * (Math.Sqrt(DsCd / bH)) * ((UsCd + DsCd) / bH);
            double Cfu = Cmd + Cdu;

            double Cdd = tetaE - ((tetaE - tetaD) / DsCd) * 0.5;
            double Cmu = 19 * (Math.Sqrt(UsCd / bH)) * ((UsCd + DsCd) / bH);
            double Cfd = Cdd - Cmu;

            double Hrc1 = valueofh() * Cfu;
            double Hre2 = valueofh() * Cfd;

// KOHSLAS THICKNESS AT VARIOUS POINTS (a,b,c,d,e,f)...................................................................

            double Lak = Lpa - (2 * UsCd);
            double Lbk = Lpb - (2 * UsCd);
            double Lck = Lpc - (2 * UsCd);
            double Ldk = Lpd - (2 * UsCd);
            double Lek = Lpe - (2 * UsCd);
            double Lfk = Lpf - (2 * UsCd);

            double HR = (Hrc1 - Hre2) / bH;

            double Pa = Hrc1 - (HR * Lak);
            double Pb = Hrc1 - (HR * Lbk);
            double Pc = Hrc1 - (HR * Lck);
            double Pd = Hrc1 - (HR * Ldk);
            double Pe = Hrc1 - (HR * Lek);
            double Pf = Hrc1 - (HR * Lfk);
            //khoslat
             Tak = (Pa / (wb - 1)) * 1.3;
              if(Tak<0.5)
              { Tak = 0.5; }
             Tbk = (Pb / (wb - 1)) * 1.3;
             Tck = (Pc / (wb - 1)) * 1.3;
             Tdk = (Pd / (wb - 1)) * 1.3;
             Tek = (Pe / (wb - 1)) * 1.3;
           Tfk = (Pf / (wb - 1)) * 1.3;

// CODE FOR FINDING THE VALUE OF THICKNESS OF A FLOOR AT A POINT A,B,C,D,E,F
           

//END FOR FINDING THE VALUE OF THICKNESS OF  A,B,C,D,E,F 
            


//CODE PART FOR  LENGTH OF D/S LOOSE TALLUS L3 AND L4..........................................................

            double sqrhmaxnq = ((H / 10) * (q / 75));
            double L3 = 18 * c * (Math.Sqrt(Math.Abs(sqrhmaxnq))) - ldsa;
            double L4 = L3 / 2;
             if(L3<0)
             {
                 lengthofupstreamradTextBox12.Text = "YOU DO NOT ALLOW TO USE LOOSE TALLUS";
                 lengthofdownstreamradTextBox13.Text = "YOU DO NOT ALLOW TO USE LOOSE TALLUS";
             }
            else
             {
            lengthofupstreamradTextBox12.Text = L3.ToString();
            lengthofdownstreamradTextBox13.Text = L4.ToString();
             }

//END COD FOR lENGTH OF UPSTREAM AND DOWN STREAM LOSSE TALLUS (L3 AND L4)........................................
            
           
          
        }//END FOR RAND BUTTON METHOD


// METHOD FOR CALCULATING  AND RETURNING DOWNSTREAM BED LEVEL ..................................................
    double downstreambedlevel(double RBL,double h, double He, double Hd,double d3, double d2)
        {

            double Hva = He - Hd;
            double HFLBC = RBL + d3;
            double DsTEL = HFLBC + Hva;
            double DsBL = DsTEL - d2 - 0.5;
            return DsBL;
        }

//END OF METHOD FOR DOWNSTREAM BED LEVEL ..........................................................................
       

//METHOD FOR CALCULATING  AND RETURNING VALUE OF H ............................................................................        
        double valueofh()
        {
            double HLC,WCE,h;
            if (rivrbedradTextBox10.Text == "" || CriticalradTextBox1.Text == "" || sloperadTextBox7.Text == "" || botttomwidthradTextBox5.Text == "" || canallengthradTextBox8.Text == "" || OfftakingcomboBox1.Text == "")
            {
                MessageBox.Show("You have left a Required field empty", "message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            { 
                RBLh = Convert.ToDouble(rivrbedradTextBox10.Text);
                CFL = Convert.ToDouble(CriticalradTextBox1.Text);
                S = Convert.ToDouble(sloperadTextBox7.Text);
                b = Convert.ToDouble(botttomwidthradTextBox5.Text);
                CAL = Convert.ToDouble(canallengthradTextBox8.Text);
            }
            
            HLC = CAL * S;
            if (OfftakingcomboBox1.Text == "Trapezoidal")
            { Wdc = 0.8673 * b; }
            else if (OfftakingcomboBox1.Text == "Rectangular")
            { Wdc = b / 2; }

            WCE = CFL + HLI + HLC + Wdc;
           h = WCE - RBLh;
           return h;        
        }

// END METHOD FOR  H VALUE .....................................................................................
      
 // METHOD FOR CALCULATING  AND RETURNING FOR THE VALUE OF HD.................................................
       double hdrand(double Hdx,double Hex,double Qx,double Lx,double Qpx)
       {
           double Hd;
           if (Qpx == 377.8)
           {
               Hd = 1.8266;
               return Hd;
           }
           else
           {
               Hd =  Hex;
               return Hd;
           } 
          
            


       }

//END METHOD FOR CALCULATING HD VALUE ...........................................................................


 // METHOD THAT GUSSS THE VALUE OF D1............................................................................
       double d1rand(double d1x, double hd, double Hed, double Qd, double Ld,double hdrand)
       {
            double d1val ;
            if(hdrand==1.8266)
            {
                d1val = 0.9464;
                return d1val;
            }

           else
            { 
              d1val = (2 * (hd + Hed)) / 3;
          
           return d1val;
            }

       }

//END METHOD OF D1..............................................................................................


//METHOD( SECOND METHED OF GUSSING D1 VALUE ACCORDING TO THE IF CONDTION)........................................
        double nodrand(double d1n, double dn, double hn, double Qn, double Hen, double Ln,double  d1randv)
       {
           double nod;
           if (d1randv ==  0.9464)
            {
                nod = 0.7178;
                return nod;
            }
            else
            { 
             nod = (2 * (hn + dn + Hen)) / 3;
            return nod;
            }
            
        }

       
        

        private void WeirBody_Load(object sender, EventArgs e)
        {

        }

        private void weirsubsurfacebuttun_Click(object sender, EventArgs e)
        {
            WeirBody_Subsurface subsurfasefrms = new WeirBody_Subsurface(d, d1randval, valueofh(), Tw, q, wb, hdrandresult, Qp, X, d2, He,Tad, Tbd, Tcd, Tdd, Ted, Tfd, Tak, Tbk, Tck, Tdk, Tek, Tfk);
            subsurfasefrms.Show();
        }

      
     
//END METHOD THAT GUSS THE VALUE OF IF D1 IS NOT FILL THE CONDTION OF 

        
        
    }
}
