using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Форма приветствия";
            label1.Text = "Name:";
            label2.Text = "Напишите имя.";
            button1.Text = "Ввод";

            toolTip1.SetToolTip(button1, "Введите имя");
            toolTip1.IsBalloon = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здравствуй " + textBox1.Text + "!", "Приветствие");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
