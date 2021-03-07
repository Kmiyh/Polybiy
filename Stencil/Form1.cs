using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stencil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox1.Text);
            // создать размерность трафарета
            for (int j = 0; j < size; j++)
            {
                dataGridView1.Columns.Add(j.ToString(), "");
            }

            for (int i = 0; i < size - 1; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int j = 0; j < size; j++)
            {
                dataGridView2.Columns.Add(j.ToString(), "");
            }

            for (int i = 0; i < size - 1; i++)
            {
                dataGridView2.Rows.Add();
            }

            // заполняем нулями
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dataGridView1[i, j].Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            int count = 0;
            int size = Convert.ToInt32(textBox1.Text);
            int[,] grid = new int[size, size];
            int[,] resultGrid = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i] = Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }

            text = text.Remove(size, size*(size-1));

            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (grid[k, j].ToString() == 1.ToString())
                    {
                        //MessageBox.Show(text[count].ToString());
                        dataGridView2[k, j].Value = text[count];      
                        count++;
                    }
                }
            }

            count = 0;
            text = textBox3.Text;
            text = text.Remove(0, size);
            text = text.Remove(size, size * 2);
            int[,] grid90 = Rotate(grid);

            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (grid90[k, j].ToString() == 1.ToString())
                    {
                        //MessageBox.Show(text[count].ToString());
                        dataGridView2[k, j].Value = text[count];
                        count++;
                    }
                }
            }

            count = 0;
            text = textBox3.Text;
            text = text.Remove(0, size * 2);
            text = text.Remove(size, size);
            int[,] grid180 = Rotate(grid90);

            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (grid180[k, j].ToString() == 1.ToString())
                    {
                        //MessageBox.Show(text[count].ToString());
                        dataGridView2[k, j].Value = text[count];
                        count++;
                    }
                }
            }

            count = 0;
            text = textBox3.Text;
            text = text.Remove(0, size * 3);
            int[,] grid270 = Rotate(grid180);

            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (grid270[k, j].ToString() == 1.ToString())
                    {
                        //MessageBox.Show(text[count].ToString());
                        dataGridView2[k, j].Value = text[count];
                        count++;
                    }
                }
            }

            string result = "";
            int resultCount = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += dataGridView2[j, i].Value.ToString();
                    resultCount++;
                }
            }
            textBox4.Text = result;
        }

        public static int[,] Rotate(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }
    }
}
