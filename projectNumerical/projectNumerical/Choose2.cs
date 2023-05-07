using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNumerical
{
    public partial class Choose2 : Form
    {
        public Choose2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("you are choosen " + comboBox1.Text);
            if (comboBox1.Text == "Gauss Elimination")
            {
                this.Hide();
                Algebric_Form Af = new Algebric_Form();
                Af.ShowDialog();
                Af = null;
                this.Show();
            }
            else if (comboBox1.Text == "LU Decomposition")
            {
                this.Hide();
                LUDecomposition LU = new LUDecomposition();
                LU.ShowDialog();
                LU = null;
                this.Show();
            }
            else if (comboBox1.Text == "Cramer's Rule")
            {
                this.Hide();
                CRule cs = new CRule();
                cs.ShowDialog();
                cs = null;
                this.Show();
            }

            else if (comboBox1.Text== "Gauss Elimination Partial Piv")
            {
                //this.Hide();
                //Gauss_PP pp = new Gauss_PP();
                //pp.ShowDialog();
                //pp = null;
                //this.Show();
            }
            else if (comboBox1.Text== "Gauss-Jordan ")
            {
                //this.Hide();
                //Gauss_Jordan gj = new Gauss_Jordan();
                //gj.ShowDialog();
                //gj = null;
                //this.Show();
            }
        }

        private void Choose2_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Second_Page sp = new Second_Page();
            sp.ShowDialog();
            

        }
    }
}
