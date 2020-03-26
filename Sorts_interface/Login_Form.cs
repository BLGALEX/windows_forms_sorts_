using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorts_interface
{
    public partial class Login_Form : Form
    {
        Sorts main_sorts = new Sorts();
        public Login_Form()
        {
            InitializeComponent();
            button7.Focus();
        }

        private void cout_result()
        {
            ConsoleOut2.Text = "";
            String Text = new string('1', main_sorts.array.Length * 7);
            Text = "";
            for (int i = 0; i < main_sorts.array.Length; i++)
            {
                Text += main_sorts.array[i];
                Text += System.Environment.NewLine;
            }
            ConsoleOut2.Text = Text;
            TimeOut.Text = "Time: " + main_sorts.time;
            Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void bubble_sort_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            button7.Focus();
            main_sorts.bubbleSort();
            cout_result();
        }

        private void Insertion_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void quick_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            main_sorts.QuickSort();
            cout_result();
        }

        private void introsort_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void LSD_sort_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void data_save_Click(object sender, EventArgs e)
        {
            button7.Focus();
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

    }
}
