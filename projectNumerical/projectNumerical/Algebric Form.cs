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
    public partial class Algebric_Form : Form
    {
        public  Algebric_Form()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "X1";
            dataGridView1.Columns[1].Name = "X2";
            dataGridView1.Columns[2].Name = "X3";
            dataGridView1.Columns[3].Name = "b";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.ColumnCount = 3;

            dataGridView2.Columns[0].Name = "X1";
            dataGridView2.Columns[1].Name = "X2";
            dataGridView2.Columns[2].Name = "X3";

            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public  void Display(float[,] _a)
        {
            this.dataGridView1.ColumnCount = 4;

            for (int r = 0; r < 3; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < 4; c++)
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
        public void GJE(float[,] _a, ref float m21, ref float m31, ref float m32)
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
            Display2(_a);
            float x3 = _a[2, 3] / _a[2, 2];
            float x2 = (_a[1, 3] - (_a[1, 2] * x3)) / _a[1, 1];
            float x1 = (_a[0, 3] - ((_a[0, 1] * x2) + (_a[0, 2] * x3))) / _a[0, 0];
            textBox13.Text=(x1.ToString());
            textBox14.Text = (x2.ToString());
            textBox15.Text = (x3.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {

            float _m21 = 0F;
            float _m31 = 0F;
            float _m32 = 0F;

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


            GJE(_a,ref _m21,ref _m31 ,ref _m32);



        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Algebric_Form_Load(object sender, EventArgs e)
        {
           

           
            }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Clear();
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

