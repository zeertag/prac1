using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3._2
{
    public partial class Form3_2 : Form
    {
        public Form3_2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile("C:\\Users\\taras\\OneDrive\\Рабочий стол\\1.jpg");
                    break;
                case 1:
                    pictureBox1.Image = Image.FromFile("C:\\Users\\taras\\OneDrive\\Рабочий стол\\2.jpg");
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile("C:\\Users\\taras\\OneDrive\\Рабочий стол\\3.jpg");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile("C:\\Users\\taras\\OneDrive\\Рабочий стол\\5.jpg");
                    break;
            }
            label1.Text = comboBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_2_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            this.Text = "Фотогалерея";
            comboBox1.Text = "Список";
        }
    }
}
