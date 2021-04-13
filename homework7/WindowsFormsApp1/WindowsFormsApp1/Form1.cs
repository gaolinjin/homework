using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Pen p;
        private Graphics graphics;
        double th1 = 0;
        double th2 = 0;
        double per1 = 0;
        double per2 = 0;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th - th2);
            
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(p,(int)x0,(int)y0,(int)x1,(int)y1);
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void InitializeCombobox()
        {
            comboBox1.Items.Add("Pens.Blue");
            comboBox1.Items.Add("Pens.Red");
            comboBox1.Items.Add("Pens.Pink");
            comboBox1.Items.Add("Pens.Purple");
            comboBox1.Items.Add("Pens.Orange");
            comboBox1.Items.Add("Pens.Yellow");
            comboBox1.Items.Add("Pens.Green");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics==null) graphics = this.CreateGraphics();
               else graphics.Clear(Color.White);
            
            switch (comboBox1.SelectedItem)
            {
                case "Pens.Blue":p = Pens.Blue;break;
                case "Pens.Red":p = Pens.Red;break;
                case "Pens.Yellow":p = Pens.Yellow;break;
                case "Pens.Pink":p = Pens.Pink;break;
                case "Pens.Green":p = Pens.Green;break;
                case "Pens.Purple": p = Pens.Purple; break;
                case "Pens.Orange": p = Pens.Orange; break;
                default:break;
            }
            

            per1=double.Parse(textBox3.Text);
            per2=double.Parse(textBox4.Text);
            th1 = double.Parse(textBox5.Text);
            th2 = double.Parse(textBox6.Text);

            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(int.Parse(textBox1.Text), 400, 310, double.Parse(textBox2.Text), -Math.PI / 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCombobox();
        }
    }
}
