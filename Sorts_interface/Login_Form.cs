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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
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

       
    }
}
