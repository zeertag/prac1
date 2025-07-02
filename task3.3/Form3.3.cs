using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Text = String.Format("{0}", textBox1.Text);
            Brush Кисть = new SolidBrush(Color.LimeGreen);
            Graphics G = pictureBox1.CreateGraphics();
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            G.DrawString(Text, Font, Кисть, 150, 50);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            button1.Text = "Рисовать";
        }
    }
}
