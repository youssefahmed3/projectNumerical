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
    public partial class CRule : Form
    {
        public CRule()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "x1";
            dataGridView1.Columns[1].Name = "x2";
            dataGridView1.Columns[2].Name = "x3";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public  void Displaym(float[,] _a)
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

        public  void CopyMatrix(float[,] _x, float[,] _y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _y[i, j] = _x[i, j];
                }

            }
        }

        public  void CramerRule(float[,] _a)
        {
            Displaym(_a);
            float[,] _ca = new float[3, 4];
            float detA;
            float[] _detA = new float[3];
            float r0, r1, r2;
            CopyMatrix(_a, _ca);
            r0 = _a[0, 0] * ((_a[1, 1] * _a[2, 2]) - (_a[1, 2] * _a[2, 1]));
            r1 = _a[0, 1] * ((_a[1, 0] * _a[2, 2]) - (_a[1, 2] * _a[2, 0]));
            r2 = _a[0, 2] * ((_a[1, 0] * _a[2, 1]) - (_a[1, 1] * _a[2, 0]));

            detA = r0 + (-r1) + r2;
            //Console.WriteLine($"Determinant of  A = {detA}");
            textBox19.Text = detA.ToString();

            for (int i = 0; i < 3; i++)
            {
                _a[0, i] = _a[0, 3];
                _a[1, i] = _a[1, 3];
                _a[2, i] = _a[2, 3];
                r0 = _a[0, 0] * ((_a[1, 1] * _a[2, 2]) - (_a[1, 2] * _a[2, 1]));
                r1 = _a[0, 1] * ((_a[1, 0] * _a[2, 2]) - (_a[1, 2] * _a[2, 0]));
                r2 = _a[0, 2] * ((_a[1, 0] * _a[2, 1]) - (_a[1, 1] * _a[2, 0]));
                _detA[i] = r0 + (-r1) + r2;
                CopyMatrix(_ca, _a);
                Console.WriteLine($"A[ {(i + 1)}]= {_detA[i]}");
            }

            textBox18.Text = _detA[0].ToString();
            textBox17.Text = _detA[1].ToString();
            textBox16.Text = _detA[2].ToString();


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"x {(i + 1)} = {(_detA[i] / detA)}");
            }
            textBox13.Text = (_detA[0] / detA).ToString();
            textBox14.Text = (_detA[1] / detA).ToString();
            textBox15.Text = (_detA[2] / detA).ToString();
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

            CramerRule(_a);
        }

        private void CRule_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
            textBox19.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
