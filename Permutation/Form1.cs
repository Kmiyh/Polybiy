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
            string finalKey = "";
            int repCount = 0;
            int count = 0;
            int newCount = 0;
            //int ind = 0;
            string temp = "";
            int rows = Convert.ToInt32(textBox1.Text);
            int columns = Convert.ToInt32(textBox2.Text);
            

            for (int s = 0; s < replacedKey.Length; s++)
            {
                int test = Convert.ToInt32(replacedKey[repCount].ToString()) - 1;
                string conv = test.ToString();
                finalKey += conv;
                repCount++;
            }

            for (int j = 0; j < columns; j++)
            {
                dataGridView1.Columns.Add(j.ToString(), (j+1).ToString());
            }

            for (int i = 0; i < rows - 1; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int j = 0; j < columns; j++)
            {
                dataGridView2.Columns.Add(j.ToString(), (j + 1).ToString());
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

            for (int ch = 0; ch < finalKey.Length; ch++)
            {
                for (int col = 0; col < columns; col++) 
                {
                    int colIndex = dataGridView1.Columns[col].Index;
                    if (colIndex.ToString() == (finalKey[ch]).ToString())
                    {
                        int columInd = finalKey[colIndex] - '0';
                        for (int i = 0; i < rows; i++)
                        {
                            temp += dataGridView1[col, i].Value.ToString();
                            dataGridView2[columInd, i].Value = temp[newCount];
                            newCount++;
                        }
                        //MessageBox.Show(temp.ToString());
                    }
                }
            }

            string result = "";
            int resultCount = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += dataGridView2[j, i].Value.ToString();
                    resultCount++;
                }
            }
            for (int i = rows; i <= result.Length; i += rows)
            {
                result = result.Insert(i, " ");
                i++;
            }
            textBox5.Text = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
