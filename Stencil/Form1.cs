using System;
using System.Windows.Forms;

namespace Stencil
{
    public partial class Form1 : Form
    {
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

            text = text.Remove(size, size*(size-1));

            Detect(grid, size, text, count);

            text = textBox3.Text;
            text = text.Remove(0, size);
            text = text.Remove(size, size * 2);
            grid = Rotate(grid);

            Detect(grid, size, text, count);

            text = textBox3.Text;
            text = text.Remove(0, size * 2);
            text = text.Remove(size, size);
            grid = Rotate(grid);

            Detect(grid, size, text, count);

            text = textBox3.Text;
            text = text.Remove(0, size * 3);
            grid = Rotate(grid);

            Detect(grid, size, text, count);

            // еще один поворот для возврата в исходное состояние
            grid = Rotate(grid);

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
    }
}
