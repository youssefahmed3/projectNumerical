using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematical.Expressions;
using org.matheval;

namespace projectNumerical
{
  
    
    public partial class Form1 : Form
    {
        
        public  Form1()
        {
            
            InitializeComponent();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "i";
            dataGridView1.Columns[1].Name = "Xl";
            dataGridView1.Columns[2].Name = "F(Xl)";
            dataGridView1.Columns[3].Name = "Xu";
            dataGridView1.Columns[4].Name = "F(Xu)";
            dataGridView1.Columns[5].Name = "Xr";
            dataGridView1.Columns[6].Name = "F(Xr)";
            dataGridView1.Columns[7].Name = "Error%";


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //for (int i = 0; i <= 7; i++)
            //{
            //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public static double f(double x, string eq)
        {

            Expression expression = new Expression(eq);
            expression.Bind("x", x);
            double result = expression.Eval<double>();
            return result;

        } 
        public  double bisect(double xl, double xu, string eq, double eps)
        {
            int iter = 0;
            double xr = 0, xrold = 0, error = 0;
            do
            {
                xrold = xr;
                xr = (xl + xu) / 2;
                //Math.Round(xr, 3);
                error = Math.Abs((xr - xrold) / xr) * 100;
                if (iter == 0)
                {
                    //Console.WriteLine($"|iter={iter} |xl= {xl}  | f(xl)= {f(xl, eq)} |xu= {xu}  |f(xu)= {f(xu, eq)} |xr= {xr} |f(xr) = {f(xr, eq)} error =  none");
                    dataGridView1.Rows.Add(iter.ToString(), Math.Round(xl,3).ToString(), Math.Round( f(xl,eq),3).ToString(),Math.Round(xu,3) .ToString(), Math.Round(f(xu,eq),3).ToString(),Math.Round( xr,3).ToString(),Math.Round(f(xr, eq), 3).ToString(),"-");

                }
                else
                {


                    //Console.WriteLine($"|iter={iter} |xl= {xl}  | f(xl)= {f(xl, eq)} |xu= {xu}  |f(xu)= {f(xu, eq)} |xr= {xr} |f(xr) = {f(xr, eq)} error =  {error}");
                    //dataGridView1.Rows.Add(iter.ToString(),xl.ToString(), f(xl, eq).ToString(), xu.ToString(), f(xu, eq), xr.ToString(), f(xr, eq).ToString(), error.ToString()+"%");
                    dataGridView1.Rows.Add(iter.ToString(),Math.Round( xl,3).ToString(), Math.Round(f(xl, eq), 3).ToString(),Math.Round(xu,3) .ToString(), Math.Round(f(xu, eq), 3).ToString(), Math.Round(xr, 3).ToString(), Math.Round(f(xr, eq), 3).ToString(), Math.Round( error,3).ToString() + "%");
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
            ROOTLB.Text = Math.Round( xr,3).ToString();
            return xr;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (txteq.Text!=""&&txterr.Text!=""&&txtxl.Text!=""&&txtxu.Text!="")
            {
                double xl = double.Parse(txtxl.Text);
                double xu = double.Parse(txtxu.Text);
                double error = double.Parse(txterr.Text);
                string eq = txteq.Text;


                bisect(xl, xu, eq, error);
            }

            else
            {
                MessageBox.Show("Please Complete The Empty Data", "error  ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            txteq.Clear();
            txtxl.Clear();
            txtxu.Clear();
            txterr.Clear();
            ROOTLB.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ROOTLB_Click(object sender, EventArgs e)
        {

        }
    }
}
