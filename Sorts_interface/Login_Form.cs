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
    }
}
