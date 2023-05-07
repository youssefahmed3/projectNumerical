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
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;


namespace projectNumerical
{
    public partial class Newton : Form
    {
        public  Newton()
        {
            InitializeComponent();
            dataGridView4.ColumnCount = 5;
            dataGridView4.Columns[0].Name = "i";
            dataGridView4.Columns[1].Name = "Xi";
            dataGridView4.Columns[2].Name = "F(Xi)";
            dataGridView4.Columns[3].Name = "f'(Xi)";
            dataGridView4.Columns[4].Name = "Error";

            dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            txteq.Clear();
            txterr.Clear();
            txtxi.Clear();
            ROOTLB.Text="";
        }
       
        static double error = 0;
        static double iter = 0;
        static double xi = 0;
        static double xiPlus1 = 0;

        public  double f(double x, string eq)
        {
            org.matheval.Expression exp = new org.matheval.Expression(eq);
            exp.Bind("x", x);
            double result = exp.Eval<double>();
            return result;
        }
        public  double fDash(double x, string e)
        {

            Expr eq = e;
            var func = eq;
            var x1 = Expr.Variable("x");
            var derivative = func.Differentiate(x1);
            string eq1 = derivative.ToString();
            org.matheval.Expression exp = new org.matheval.Expression(eq1);
            exp.Bind("x", x);
            double result = exp.Eval<double>();
            return result;
        }

        public  double NewtonM(double x, string eq, double eps,int iter)
        {
            xi = x;
            xiPlus1 = xi - (f(xi, eq) / fDash(xi, eq));
            dataGridView4.Rows.Add(iter.ToString(),Math.Round(xi,3).ToString(), Math.Round(f(xi, eq),3).ToString(), Math.Round(fDash(xi, eq),3), Math.Round(error,3).ToString() + " %");
            if (error > eps || iter == 0)
            {
                error = Math.Abs((xiPlus1 - xi) / xiPlus1) * 100;
                iter++;
                NewtonM(xiPlus1, eq, eps,iter);
            }
            ROOTLB.Text = Math.Round(xi, 3).ToString();
            return xi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Newton_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x0 = double.Parse(txtxi.Text);
            double eps = double.Parse(txterr.Text);
            string eq = txteq.Text;
            const int iter = 0;
            NewtonM(x0, eq, eps, iter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            txteq.Clear();
            txterr.Clear();
            txtxi.Clear();
            ROOTLB.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(1);    
        }
    }
}
