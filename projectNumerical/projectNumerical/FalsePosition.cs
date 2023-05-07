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
    public partial class FalsePosition : Form
    {
        public FalsePosition()
        {
            InitializeComponent();
            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "i";
            dataGridView2.Columns[1].Name = "Xl";
            dataGridView2.Columns[2].Name = "F(Xl)";
            dataGridView2.Columns[3].Name = "Xu";
            dataGridView2.Columns[4].Name = "F(Xu)";
            dataGridView2.Columns[5].Name = "Xr";
            dataGridView2.Columns[6].Name = "F(Xr)";
            dataGridView2.Columns[7].Name = "Error";


            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void FalsePosition_Load(object sender, EventArgs e)
        {

        }
        public static double f(double x, string eq)
        {
            Expression expr = new Expression(eq);
            expr.Bind("x", x);
            double result = expr.Eval<double>();
            return result;
        }

        public  double FalsePos(double xl, double xu, string eq, double eps)
        {

            int iter = 0;
            double xr = 0, xrold = 0, error = 0;
            do
            {
                xrold = xr;
                xr = xu - ((f(xu, eq) * (xl - xu) / (f(xl, eq) - f(xu, eq))));
                error = Math.Abs((xr - xrold) / xr) * 100;
                if (iter == 0)
                {
                    //dataGridView2.Rows.Add(iter.ToString(),xl.ToString(), f(xl, eq).ToString(), xu.ToString(), f(xu, eq), xr.ToString(), f(xr, eq).ToString(), "-");
                    dataGridView2.Rows.Add(iter.ToString(), Math.Round(xl, 3).ToString(), Math.Round(f(xl, eq), 3).ToString(), Math.Round(xu, 3).ToString(), Math.Round(f(xu, eq), 3).ToString(), Math.Round(xr, 3).ToString(), Math.Round(f(xr, eq), 3).ToString(), "-");
                }
                else
                {


                    //dataGridView2.Rows.Add(iter.ToString(),xl.ToString(), f(xl, eq).ToString(), xu.ToString(), f(xu, eq), xr.ToString(), f(xr, eq).ToString(), error.ToString() + "%");
                    dataGridView2.Rows.Add(iter.ToString(), Math.Round(xl, 3).ToString(), Math.Round(f(xl, eq), 3).ToString(), Math.Round(xu, 3).ToString(), Math.Round(f(xu, eq), 3).ToString(), Math.Round(xr, 3).ToString(), Math.Round(f(xr, eq), 3).ToString(), Math.Round(error, 3).ToString() + "%");
                }


                if (f(xl, eq) * f(xr, eq) > 0)
                {
                    xl = xr;
                }
                else if (f(xl, eq) * f(xr, eq) == 0)
                {
                    break;
                }
                else
                {
                    xu = xr;
                }
                iter++;

            } while (error > eps);
            ROOTLB.Text = Math.Round(xr, 3).ToString();
            return xr;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double xl = double.Parse(txtxl.Text);
            double xu = double.Parse(txtxu.Text);
            double error = double.Parse(txterr.Text);
            string eq = txteq.Text;
           



            FalsePos(xl, xu, eq, error);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            txteq.Clear();
            txterr.Clear();
            txtxl.Clear();
            txtxu.Clear();
            ROOTLB.Text = "";
        }
    }
}
