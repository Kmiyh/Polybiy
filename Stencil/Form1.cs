using System;
using System.Windows.Forms;

namespace Stencil
{
    public partial class Form1 : Form
    {
        public int removeCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
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

            // заполняем нулями
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dataGridView1[i, j].Value = 0;
                }
            }

            // таблица для вывода
            for (int j = 0; j < size; j++)
            {
                dataGridView2.Columns.Add(j.ToString(), "");
            }

            for (int i = 0; i < size - 1; i++)
            {
                dataGridView2.Rows.Add();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            int count = 0;
            int size = Convert.ToInt32(textBox1.Text);
            int[,] grid = new int[size, size];

            // заполняем трафарет
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[j, i] = Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (text.Length < size)
                {
                    int test = size - text.Length;
                    string temp = text.Substring(0, size - test);
                    Detect(grid, size, temp, count);
                    grid = Rotate(grid);
                    text = text.Remove(0, removeCounter);
                    count = 0;
                    MessageBox.Show(text);
                } 
                else
                {
                    string temp = text.Substring(0, size);
                    Detect(grid, size, temp, count);
                    grid = Rotate(grid);
                    text = text.Remove(0, removeCounter);
                    count = 0;
                    MessageBox.Show(text);
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

        // вставка символов в новую таблицу
        public void Detect(int[,] grid, int size, string text, int count)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (grid[k, j].ToString() == 1.ToString())
                    {
                        dataGridView2[k, j].Value = text[count];
                        count++;
                    }
                }
            }
            removeCounter = count;
        }

        // поворот решетки по часовой стрелке
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out int j))
            {
                int numVal = j * j;
                string counter = textBox3.Text.Length.ToString();
                label2.Text = counter + "/" + numVal.ToString() + " симв.";
            }
            
        }
    }
}
