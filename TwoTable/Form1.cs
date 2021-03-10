using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string abc = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ .";
            string abc2 = "ЯЮЭЬЫЪЩШЧЦХФУТ. СРПОНМЛКЙИЗЖЁЕДГВБА";
            int count = 0;

            for (int j = 0; j < 5; j++)
            {
                dataGridView1.Columns.Add(j.ToString(), "");
                dataGridView2.Columns.Add(j.ToString(), "");
            }

            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
            }

            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView2.Rows[i].HeaderCell.Value = (i + 1).ToString();

                for (int j = 0; j < 5; j++)
                {
                    dataGridView1[j, i].Value = abc[count];
                    dataGridView2[j, i].Value = abc2[count];
                    count++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string сryptText = "";
        }
    }
}
