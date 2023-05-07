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
    public partial class SimpleF : Form
    {
        public SimpleF()
        {
            InitializeComponent();
            dataGridView5.ColumnCount = 4;
            dataGridView5.Columns[0].Name = "i";
            dataGridView5.Columns[1].Name = "Xi";
            dataGridView5.Columns[2].Name = "Xi+1";
            dataGridView5.Columns[3].Name = "Error %";

            dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView5.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView5.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView5.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtxl_TextChanged(object sender, EventArgs e)
        {

        }
        public  double f(double x, string eq)
        {
            Expression expression = new Expression(eq);
            expression.Bind("x", x);
            double result = expression.Eval<double>();
            return result;
        }
        public int iter = 0;
        public  double xiplus = 0, xi = 0, error = 0;
        public  double Sfixed(double x0, double eps, string eq,int iter)
        {
            xi = x0;
            xiplus = f(xi, eq);
            dataGridView5.Rows.Add(iter.ToString(), Math.Round( xi,3).ToString(), Math.Round(xiplus,3).ToString(),  Math.Round(error, 3).ToString() + "%");
           
            if (error > eps || iter==0)
            {
                error = Math.Abs((xiplus - xi) / xiplus) * 100;
                iter++;
                Sfixed(xiplus, eps, eq,iter);
            }
            //else
            //{
            //    //dataGridView5.Rows.Add(iter.ToString(), xi.ToString(), xiplus.ToString(), error.ToString() + "%");
            //    dataGridView5.Rows.Add(iter.ToString(), Math.Round(xi, 3).ToString(), Math.Round(xiplus, 3).ToString(), Math.Round(error, 3).ToString() + "%");
            //}
            ROOTLB.Text = Math.Round(xi,3).ToString();
            //textBox1.Text = xiplus.ToString();
            return xi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x0 = double.Parse(txtx0.Text);
            double eps = double.Parse(txterr.Text);
            string eq = txteq.Text;
            const int iter = 0;
            Sfixed(x0, eps, eq, iter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
            txteq.Clear();
            txtx0.Clear();
            txterr.Clear();
            ROOTLB.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void SimpleF_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
