using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double t1 = double.Parse(textBox1.Text);
            double t2 = double.Parse(textBox2.Text);
            switch (comboBox1.SelectedItem.ToString())
            {
                case "+": label2.Text = (t1 + t2).ToString(); break;
                case "-": label2.Text = (t1 - t2).ToString(); break;
                case "*": label2.Text = (t1 * t2).ToString(); break;
                case "/": label2.Text = (t1 / t2).ToString(); break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}