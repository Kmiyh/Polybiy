using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permutation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string replacedText = textBox3.Text.Replace(" ", "");
            int count = 0;
            int rows = Convert.ToInt32(textBox1.Text);
            int columns = Convert.ToInt32(textBox2.Text);

            for (int j = 0; j < columns; j++)
            {
                dataGridView1.Columns.Add((j+1).ToString(), (j+1).ToString());
            }

            for (int i = 0; i < rows - 1; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    dataGridView1[j, i].Value = replacedText[count];
                    count++;
                }
            }
        }
    }
}
