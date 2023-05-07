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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("you are choosen "+comboBox1.Text);
            if (comboBox1.Text== "Bisection Method")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                f1 = null;
                this.Show();
            }
            else if (comboBox1.Text== "FalsePosition Method")
            {
                this.Hide();
                FalsePosition fp = new FalsePosition();
                fp.ShowDialog();
                fp = null;
                this.Show();
            }
            else if (comboBox1.Text== "Secant Method")
            {
                this.Hide();
                Secant s = new Secant();
                s.ShowDialog();
                s = null;
                this.Show();
            }
            else if (comboBox1.Text== "Newton Method")
            {
                this.Hide();
                Newton n = new Newton();
                n.ShowDialog();
                n = null;
                this.Show();
            }
            else if (comboBox1.Text== "SimpleFixedPoint Method")
            {
                this.Hide();
                SimpleF sf = new SimpleF();
                sf.ShowDialog();
                sf = null;
                this.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
