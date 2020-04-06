using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sorts_interface
{ 
    public partial class Login_Form : Form
    {
        Sorts main_sorts = new Sorts();
        public Login_Form()
        {
            InitializeComponent();
            button7.Focus();
            if(File.Exists("Output.txt"))
                File.Delete("Output.txt");
        }

        private void cout_result()
        {
            if (main_sorts.array.Length == 0)
            {
                ConsoleOut.Text += System.Environment.NewLine;
                ConsoleOut.Text += "Задайте массив";
                TimeOut.Text = "Нет данных";
                ConsoleOut2.Text = "...";
                return;
            }
            if (main_sorts.time == 0)
                TimeOut.Text = "Time < 0.001";
            else
                TimeOut.Text = "Time: " + Convert.ToString(main_sorts.time);
            Cursor = System.Windows.Forms.Cursors.Arrow;
            ConsoleOut.Text += System.Environment.NewLine;
            ConsoleOut.Text += "Массив отсортирован";
        }
        private void bubble_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.bubbleSort();
            cout_result();
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void Insertion_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.Insertion_sort();
            cout_result();
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void quick_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.QuickSort();
            cout_result();
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void introsort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.Introsort();
            cout_result();
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void LSD_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.LSD();
            cout_result();
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void data_save_Click(object sender, EventArgs e)
        {
            button7.Focus();
            if (main_sorts.last_sort == null) return;
            File.AppendAllText("Output.txt", "Сосртировка: " + main_sorts.last_sort + Environment.NewLine);
            File.AppendAllText("Output.txt", "Количество элементов: " + Convert.ToString(main_sorts.array.Length) + Environment.NewLine);
            File.AppendAllText("Output.txt", "Время: " + Convert.ToString(main_sorts.time) + Environment.NewLine);
            File.AppendAllText("Output.txt", Environment.NewLine);
            ConsoleOut.Text += Environment.NewLine;
            ConsoleOut.Text += "Данные успешно сохранены в файл";
        }

        Point last_point;
        private void Login_Form_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - last_point.X;
                this.Top += e.Y - last_point.Y;
            }
        }

        private void Login_Form_MouseDown(object sender, MouseEventArgs e)
        {
            last_point = new Point(e.X, e.Y);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Focus();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button7.Focus();
            String array_size = array_size_input.Text;
            array_size = main_sorts.set_N(array_size);
            if (array_size != "")
            {
                System.Threading.Thread.Sleep(50);
                ConsoleOut.Text += System.Environment.NewLine;
                ConsoleOut.Text += "Массив создан успешно";
                array_size_input.Text = "";
            }
            else
            {
                System.Threading.Thread.Sleep(50);
                ConsoleOut.Text += System.Environment.NewLine;
                ConsoleOut.Text += System.Environment.NewLine;
                ConsoleOut.Text += "Введите число разрядности не больше шести без знаков и пробелов";
                array_size_input.Text = "";
            }
        }

        private void array_size_input_KeyDown(object sender, KeyEventArgs e) //нужно убрать звук при нажатии enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                String array_size = array_size_input.Text;
                array_size = main_sorts.set_N(array_size);
                if (array_size != "")
                {
                    System.Threading.Thread.Sleep(50);
                    ConsoleOut.Text += System.Environment.NewLine;
                    ConsoleOut.Text += "Массив создан успешно";
                    array_size_input.Text = "";
                }
                else
                {
                    System.Threading.Thread.Sleep(50);
                    ConsoleOut.Text += System.Environment.NewLine;
                    ConsoleOut.Text += System.Environment.NewLine;
                    ConsoleOut.Text += "Введите число разрядности не больше шести без знаков и пробелов";
                    array_size_input.Text = "";
                }
            }
        }

        private void ShowArray_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ConsoleOut2.Text = "";
            String Text = new string('1', main_sorts.array.Length * 7);
            Text = "";
            for (int i = 0; i < main_sorts.array.Length; i++)
            {
                Text += main_sorts.array[i];
                Text += System.Environment.NewLine;
            }
            ConsoleOut2.Text = Text;
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }
    }
}
