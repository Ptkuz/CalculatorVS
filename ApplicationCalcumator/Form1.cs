using System;
using System.Windows.Forms;

namespace ApplicationCalcumator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // string operation;
        // string n1;
        // string n2;
        // string stepen;
        // string koren;
        // double n1d;
        // double n2d;
        // double stepenD;
        // double korenD;
        // double nProc;
        // double result;

        //bool flagOper = false;
        //bool flagStepen = false;
        //bool flagKoren = false;


        public string Operation { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string Stepen { get; set; }
        public string Koren { get; set; }
        public double N1D { get; set; }
        public double N2D { get; set; }
        public double StepenD { get; set; }
        public double KorenD { get; set; }
        public double NProc { get; set; }
        public double Result { get; set; }

        public bool FlagOper { get; set; }
        public bool FlagStepen { get; set; }
        public bool FlagKoren { get; set; }









        public double Oper()
        {
          
                N1D = Convert.ToDouble(N1);
                N2D = Convert.ToDouble(N2);
                switch (Operation)
                {
                    case "+":
                        Result = N1D + N2D;
                        break;
                    case "-":

                        Result = N1D - N2D;
                        break;

                    case "*":
                        Result = N1D * N2D;
                        break;
                    case "/":

                        Result = N1D / N2D;
                        break;


                }
                return Result;
           



        }

        public double MethodProc()
        {
           
            N1D = Convert.ToDouble(N1);
            switch (Operation)
            {
                case "+":
                    Result = N1D + (N1D * N2D) / 100;
                    break;
                case "-":

                    Result = N1D - (N1D * N2D) / 100;
                    break;

                case "*":
                    Result = N1D * (N1D * N2D) / 100;
                    break;
                case "/":

                    Result = N1D / (N1D * N2D) / 100;
                    break;

            }
            return Result;
            


        }

        public double MethodStepen()
        {
           
            N1D = Convert.ToDouble(N1);
            N2D = Convert.ToDouble(N2);
            switch (Operation)
            {
                case "+":
                    Result = N1D + Math.Pow(N2D, StepenD);
                    break;
                case "-":
                    Result = N1D - Math.Pow(N2D, StepenD);
                    break;
                case "*":
                    Result = N1D * Math.Pow(N2D, StepenD);
                    break;
                case "/":
                    Result = N1D / Math.Pow(N2D, StepenD);
                    break;

            }
            return Result;
           

        }

        public double MethodKoren()
        {
           
            N1D = Convert.ToDouble(N1);
            N2D = Convert.ToDouble(N2);
            switch (Operation)
            {
                case "+":
                    Result = N1D + Math.Pow(N2D, 1 / KorenD);
                    break;
                case "-":
                    Result = N1D - Math.Pow(N2D, 1 / KorenD);
                    break;
                case "*":
                    Result = N1D * Math.Pow(N2D, 1 / KorenD);
                    break;
                case "/":
                    Result = N1D / Math.Pow(N2D, 1 / KorenD);
                    break;

            }
            return Result;
           

        }

        public void DropPerem()
        {
            N1 = null;
            N2 = null;
            N1D = 0;
            N2D = 0;
            Operation = null;
            Stepen = null;
            StepenD = 0;
            Koren = null;
            KorenD = 0;

        }



        private void Numbers_Click(object sender, EventArgs e)
        {



            // Третье дейситве 
            if (FlagOper)

            {

                FlagOper = false;
                //textBox1.Clear();
                Button B = sender as Button;
                textBox1.Text = textBox1.Text + B.Text;

            }
            // Первое дейситвие 
            else
            {
                Button B = sender as Button;
                if (textBox1.Text == "0")
                {
                    textBox1.Text = B.Text;
                }
                else
                {

                    textBox1.Text = textBox1.Text + B.Text;

                }
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Text = "0";
            DropPerem();


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }

        private void OperationBut_Click(object sender, EventArgs e)
        {
            if (FlagKoren)
            {
                Koren = textBox1.Text;
                KorenD = Convert.ToDouble(Koren);
                FlagKoren = false;
                MethodKoren();
                textBox1.Text = Convert.ToString(Result);
                DropPerem();
                N1 = textBox1.Text;
                textBox1.Clear();
                Button B = sender as Button;
                Operation = B.Text;
                textBox2.Text = N1 + " " + Operation;
                //flagOper = true;

            }

            else if (FlagStepen)
            {
                Stepen = textBox1.Text;
                StepenD = Convert.ToDouble(Stepen);
                FlagStepen = false;
                MethodStepen();
                textBox1.Text = Convert.ToString(Result);
                DropPerem();
                N1 = textBox1.Text;
                textBox1.Clear();
                Button B = sender as Button;
                Operation = B.Text;
                textBox2.Text = N1 + " " + Operation;


            }

            else if (N1 != null)
            {

                N2 = textBox1.Text;
               
                    Oper();
                
                textBox1.Text = Convert.ToString(Result);
                Button B = sender as Button;
                Operation = B.Text;
                N1 = textBox1.Text;
                FlagOper = true;
                textBox1.Clear();
                textBox2.Text = N1 + " " + Operation;



            }



            else if (FlagOper)
            {
                Button B = sender as Button;
                Operation = B.Text;
                //label1.Text = B.Text;
                FlagOper = false;

            }
            // Второе действие
            else
            {

                Button B = sender as Button;
                Operation = B.Text;
                //label1.Text = B.Text;
                N1 = textBox1.Text;
                FlagOper = true;
                textBox1.Clear();
                textBox2.Text = N1 + " " + Operation;


            }


        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (FlagStepen)
            {
                if (Operation != null)
                {
                    FlagStepen = false;
                    Stepen = textBox1.Text;
                    StepenD = Convert.ToDouble(Stepen);
                    textBox1.Clear();
                    textBox2.Text = N1 + " " + Operation + "(" + N2 + ")^" + Stepen;
                    MethodStepen();
                    textBox1.Text = Convert.ToString(Result);
                    DropPerem();

                }
                else
                {

                    FlagStepen = false;
                    Stepen = textBox1.Text;
                    N1D = Convert.ToDouble(N1);
                    StepenD = Convert.ToDouble(Stepen);
                    textBox1.Clear();
                    textBox2.Text = "(" + N1 + ")^" + Stepen;
                    textBox1.Text = Convert.ToString(Math.Pow(N1D, StepenD));
                    DropPerem();
                }
            }
            else if (FlagKoren)
            {

                if (Operation != null)
                {
                    FlagKoren = false;
                    Koren = textBox1.Text;
                    KorenD = Convert.ToDouble(Koren);
                    textBox1.Clear();
                    textBox2.Text = N1 + " " + Operation + "sqrt(" + N2 + ")" + "^1/" + Koren;
                    MethodKoren();
                    textBox1.Text = Convert.ToString(Result);
                    DropPerem();

                }
                else
                {
                    FlagKoren = false;
                    Koren = textBox1.Text;
                    N1D = Convert.ToDouble(N1);
                    KorenD = Convert.ToDouble(Koren);
                    textBox1.Clear();
                    textBox2.Text = "sqrt(" + N1 + ")" + Koren;
                    textBox1.Text = Convert.ToString(Math.Pow(N1D, 1 / KorenD));
                    DropPerem();
                }

            }


            else
            {


                N2 = textBox1.Text;
               

                    Oper();
                
                textBox1.Text = Convert.ToString(Result);
                textBox2.Text = N1 + " " + Operation + " " + N2;
                DropPerem();
            }
        }

        private void Koren_Click(object sender, EventArgs e)
        {
            // Четвертое действие
            if (N1 != null)
            {
                FlagKoren = true;
                N2 = textBox1.Text;
                textBox1.Clear();
                textBox2.Text = N1 + " " + Operation + " " + "sqrt(" + N2 + ")";

            }
            else
            {
                FlagKoren = true;
                N1 = textBox1.Text;
                textBox1.Clear();
                textBox2.Text = " sqrt(" + N1 + ")";
            }
        }

        private void Stepen_Click(object sender, EventArgs e)
        {
            if (N1 != null)
            {
                FlagStepen = true;
                N2 = textBox1.Text;
                textBox1.Clear();
                textBox2.Text = N1 + " " + Operation + " " + N2 + " ^ ";
            }
            else
            {
                FlagStepen = true;
                N1 = textBox1.Text;
                textBox1.Clear();
                textBox2.Text = " ^ " + N1;
            }

        }

        private void Procent_Click(object sender, EventArgs e)
        {
            if (N1 != null)
            {
                N2 = textBox1.Text;
                N2D = Convert.ToDouble(N2);
                textBox2.Text = N1 + " " + Operation + " " + N2 + "%";
                MethodProc();
                textBox1.Text = Convert.ToString(Result);
                DropPerem();
                FlagOper = false;



            }
            else
            {

                N1 = textBox1.Text;
                N1D = Convert.ToDouble(N1);
                N1D = N1D / 100;
                textBox1.Text = Convert.ToString(N1D);
                textBox2.Text = N1 + "%";
                NProc = Convert.ToDouble(textBox1.Text);
                DropPerem();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyValue)
            {
                case (char)Keys.NumPad1:
                    button7.PerformClick();
                    break;

                case (char)Keys.NumPad2:
                    button8.PerformClick();
                    break;

                case (char)Keys.NumPad3:
                    button9.PerformClick();
                    break;

                case (char)Keys.NumPad4:
                    button4.PerformClick();
                    break;

                case (char)Keys.NumPad5:
                    button5.PerformClick();
                    break;

                case (char)Keys.NumPad6:
                    button6.PerformClick();
                    break;

                case (char)Keys.NumPad7:
                    button1.PerformClick();
                    break;

                case (char)Keys.NumPad8:
                    button2.PerformClick();
                    break;

                case (char)Keys.NumPad9:
                    button3.PerformClick();
                    break;

                case (char)Keys.NumPad0:
                    button10.PerformClick();
                    break;

                case (char)Keys.Subtract:
                    button16.PerformClick();
                    break;

                case (char)Keys.Add:
                    button12.PerformClick();
                    break;

                case (char)Keys.Multiply:
                    button15.PerformClick();
                    break;

                case (char)Keys.Divide:
                    button14.PerformClick();
                    break;

                case (char)Keys.Back:
                    button18.PerformClick();
                    break;

                case (char)Keys.Delete:
                    button17.PerformClick();
                    break;

                case (char)Keys.F:
                    Enter_Click(button13, null);
                    break;

                case (char)Keys.Decimal:
                    button11.PerformClick();
                    break;



            }



        }
    }
}
