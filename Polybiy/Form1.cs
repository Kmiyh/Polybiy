using System;
using System.Windows.Forms;

namespace Polybiy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string abc = "abcdefghijklmnopqrstuvwxyz .,?";
            int count = 0;
            dataGridView1.Rows.Add(5);

            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                for (int j = 0; j < 6; j++)
                {
                    dataGridView1[j, i].Value = abc[count];
                    count++;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string CryptText = "";

            for (int x = 0; x < text.Length; x++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (text[x] == Convert.ToChar(dataGridView1[j, i].Value))
                        {
                            if (i + 1 > 4)
                            {
                                CryptText += dataGridView1[j, 0].Value;
                            } else
                            {
                                CryptText += dataGridView1[j, i + 1].Value;
                            }
                        }

                    }
                }
            }
            textBox2.Text = CryptText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string EncryptText = "";

            for (int x = 0; x < text.Length; x++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (text[x] == Convert.ToChar(dataGridView1[j, i].Value))
                        {
                            if (i - 1 < 0)
                            {
                                EncryptText += dataGridView1[j, 4].Value;
                            }
                            else
                            {
                                EncryptText += dataGridView1[j, i - 1].Value;
                            }
                        }

                    }
                }
            }
            textBox2.Text = EncryptText;
        }
    }
}
