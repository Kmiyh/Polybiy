using System;
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
            string replacedKey = numericUpDown1.Value.ToString();
            int count = 0;
            int newCount = 0;
            string temp = "";
            int rows = Convert.ToInt32(textBox1.Text);
            int columns = Convert.ToInt32(textBox2.Text);

            for (int j = 0; j < columns; j++)
            {
                dataGridView1.Columns.Add(j.ToString(), j.ToString());
            }

            for (int i = 0; i < rows - 1; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int j = 0; j < columns; j++)
            {
                dataGridView2.Columns.Add(j.ToString(), j.ToString());
            }

            for (int i = 0; i < rows - 1; i++)
            {
                dataGridView2.Rows.Add();
            }

            for (int j = 0; j < columns; j++)
            {

                for (int i = 0; i < rows; i++)
                {
                    dataGridView1[j, i].Value = replacedText[count];
                    count++;
                }
            }

            for (int ch = 0; ch < replacedKey.Length; ch++)
            {
                for (int col = 0; col < columns; col++) 
                {
                    int colIndex = dataGridView1.Columns[col].Index;
                    if (colIndex.ToString() == (replacedKey[ch]).ToString())
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            temp += dataGridView1[col, i].Value.ToString();
                            dataGridView2[ch, i].Value = temp[newCount];
                            newCount++;
                        }
                        break;
                    }
                }
            }
        }
    }
}
