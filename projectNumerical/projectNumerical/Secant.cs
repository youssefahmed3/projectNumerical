using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.matheval;

namespace projectNumerical
{
    public partial class Secant : Form
    {
        public Secant()
        {
            InitializeComponent();
            dataGridView3.ColumnCount =6 ;
            dataGridView3.Columns[0].Name = "i";
            dataGridView3.Columns[1].Name = "Xi-1";
            dataGridView3.Columns[2].Name = "F(Xi-1)";
            dataGridView3.Columns[3].Name = "Xi";
            dataGridView3.Columns[4].Name = "F(Xi)";
            dataGridView3.Columns[5].Name = "Error %";


            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static double f(double x, string eq)
        {
            Expression exp = new Expression(eq);
            exp.Bind("x", x);
            double result = exp.Eval<double>();
            return result;
        }
        static double error = 0;
        static int iter = 0;
        static double xi = 0;
        static double xiPlus1 = 0;
        static double xiMin1 = 0;
        public  double SecantM(double a, double b, string eq, double eps,int iter)
        {


            xi = a;
            xiMin1 = b;
            xiPlus1 = xi - (f(xi, eq) * (xiMin1 - xi)) / (f(xiMin1, eq) - f(xi, eq));
            dataGridView3.Rows.Add(iter.ToString(),Math.Round( xiMin1,3).ToString(),Math.Round( f(xiMin1, eq),3).ToString(),Math.Round( xi,3).ToString(),Math.Round( f(xi, eq),3).ToString(),Math.Round( error,3).ToString()+" %");
            if (error >= eps || iter == 0)
            {
                error = Math.Abs((xiPlus1 - xi) / xiPlus1) * 100;
                iter++;
                xiMin1 = xi;
                xi = xiPlus1;
                SecantM(xi, xiMin1, eq, eps,iter);
            }
            ROOTLB.Text = Math.Round(xi, 3).ToString();
            return xi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double ximin = double.Parse(txtximin.Text);
            double xi = double.Parse(txtxi.Text);
            double error = double.Parse(txterr.Text);
            string eq = txteq.Text;
            const int iter = 0;
            SecantM(xi, ximin, eq, error,iter);
        }

        private void Secant_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            txteq.Clear();
            txterr.Clear();
            txtxi.Clear();
            txtximin.Clear();
            ROOTLB.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double ximin = double.Parse(txtximin.Text);
            double xi = double.Parse(txtxi.Text);
            double error = double.Parse(txterr.Text);
            string eq = txteq.Text;
            const int iter = 0;
            SecantM(xi, ximin, eq, error, iter);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            txteq.Clear();
            txterr.Clear();
            txtxi.Clear();
            txtximin.Clear();
            ROOTLB.Text="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
