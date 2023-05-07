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
    public partial class Second_Page : Form
    {
        public Second_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Second_Page_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Second_Page_Load(object sender, EventArgs e)   
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
