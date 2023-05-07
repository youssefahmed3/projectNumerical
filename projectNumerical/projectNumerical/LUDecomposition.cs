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
    public partial class LUDecomposition : Form
    {
        public LUDecomposition()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "X1";
            dataGridView1.Columns[1].Name = "X2";
            dataGridView1.Columns[2].Name = "X3";
            

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

            dataGridView2.ColumnCount = 3;

            dataGridView2.Columns[0].Name = "X1";
            dataGridView2.Columns[1].Name = "X2";
            dataGridView2.Columns[2].Name = "X3";

            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView3.ColumnCount = 3;

            dataGridView3.Columns[0].Name = "X1";
            dataGridView3.Columns[1].Name = "X2";
            dataGridView3.Columns[2].Name = "X3";

            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Display(float[,] _a)
        {
            this.dataGridView1.ColumnCount = 3;

            for (int r = 0; r < 3; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < 3; c++)
                {
                    row.Cells[c].Value = _a[r, c];
                }

                this.dataGridView1.Rows.Add(row);
            }


        }

        public void Display2(float[,] _a)
        {
            this.dataGridView2.ColumnCount = 3;

            for (int r = 0; r < 3; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView2);

                for (int c = 0; c < 3; c++)
                {
                    row.Cells[c].Value = _a[r, c];
                }

                this.dataGridView2.Rows.Add(row);
            }



        }
        public void Display3(float[,] _a)
        {
            this.dataGridView3.ColumnCount = 3;

            for (int r = 0; r < 3; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView3);

                for (int c = 0; c < 3; c++)
                {
                    row.Cells[c].Value = _a[r, c];
                }

                this.dataGridView3.Rows.Add(row);
            }



        }

        public  void GJE(float[,] _a, ref float m21, ref float m31, ref float m32)
        {
            Display(_a);
            m21 = _a[1, 0] / _a[0, 0];
            m31 = _a[2, 0] / _a[0, 0];
            // rule E2-(m21)E1 = E2
            for (int j = 0; j < 4; j++)
            {
                float e2 = _a[1, j];
                float e1 = ((m21) * _a[0, j]);
                _a[1, j] = e2 - e1;
            }
            
            //rule E3-(m31)E1 = E3
            for (int j = 0; j < 4; j++)
            {
                float e3 = _a[2, j];
                float e1 = ((m31) * _a[0, j]);
                _a[2, j] = e3 - e1;
            }
            m32 = _a[2, 1] / _a[1, 1];
            
            // rule E3-(m32)E2 = E3
            for (int j = 0; j < 4; j++)
            {
                float e3 = _a[2, j];
                float e1 = ((m32) * _a[1, j]);
                _a[2, j] = e3 - e1;
            }
           
            float x3 = _a[2, 3] / _a[2, 2];
            float x2 = (_a[1, 3] - (_a[1, 2] * x3)) / _a[1, 1];
            float x1 = (_a[0, 3] - ((_a[0, 1] * x2) + (_a[0, 2] * x3))) / _a[0, 0];
            Console.WriteLine($"Gauss Jordan Result:{'\n'} x1 = {x1} {'\n'} x2 = {x2} {'\n'} x3 = {x3} {'\n'} ");
        }

        public  void LUDecompositions(float[,] _a)
        {
            float[,] _u = new float[3, 3];
            float[,] _l = new float[3, 3];
            float[] _b = new float[3];
            float _m21 = 0, _m31 = 0, _m32 = 0;
            for (int i = 0; i < 3; i++)
            {
                _b[i] = _a[i, 3];
            }
            GJE(_a, ref _m21, ref _m31, ref _m32);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _u[i, j] = _a[i, j];
                }
            }
            Console.WriteLine();
            Console.WriteLine("U matrix");
            Display2(_u);
            _l[0, 1] = 0F;
            _l[0, 2] = 0F;
            _l[1, 2] = 0F;

            _l[0, 0] = 1F;
            _l[1, 1] = 1F;
            _l[2, 2] = 1F;
            _l[1, 0] = _m21;
            _l[2, 0] = _m31;
            _l[2, 1] = _m32;
            Console.WriteLine("L matrix");
            Display3(_l);
            //lc=b
            float c1 = _b[0] / _l[0, 0];
            float c2 = (_b[1] - (_l[1, 0] * c1)) / _l[1, 1];
            float c3 = (_b[2] - ((_l[2, 0] * c1) + (_l[2, 1] * c2))) / _l[2, 2];
            textBox16.Text = c3.ToString();
            textBox17.Text = c2.ToString();
            textBox18.Text = c1.ToString();
            //ux=c
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _a[i, j] = _u[i, j];
                }
            }
            _a[0, 3] = c1;
            _a[1, 3] = c2;
            _a[2, 3] = c3;
            float x3 = _a[2, 3] / _a[2, 2];
            float x2 = (_a[1, 3] - (_a[1, 2] * x3)) / _a[1, 1];
            float x1 = (_a[0, 3] - ((_a[0, 1] * x2) + (_a[0, 2] * x3))) / _a[0, 0];
            textBox13.Text = x1.ToString();
            textBox14.Text = x2.ToString();
            textBox15.Text = x3.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
            float x00 = float.Parse(textBox1.Text);
            float x01 = float.Parse(textBox2.Text);
            float x02 = float.Parse(textBox3.Text);
            float x03 = float.Parse(textBox4.Text);
            float x10 = float.Parse(textBox5.Text);
            float x11 = float.Parse(textBox6.Text);
            float x12 = float.Parse(textBox7.Text);
            float x13 = float.Parse(textBox8.Text);
            float x20 = float.Parse(textBox9.Text);
            float x21 = float.Parse(textBox10.Text);
            float x22 = float.Parse(textBox11.Text);
            float x23 = float.Parse(textBox12.Text);
            float[,] _a = new float[3, 4]
            {
                {x00,x01,x02,x03},
                {x10,x11,x12,x13},
                {x20,x21,x22,x23}
            };

            LUDecompositions(_a);

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LUDecomposition_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
