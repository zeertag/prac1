using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5._4
{
    public partial class Form5_4 : Form
    {
        public Form5_4()
        {
            InitializeComponent();
        }

        private void Form5_4_Load(object sender, EventArgs e)
        {
            this.Text = "Закрашивание фигур";
            label1.Text = "Выберите фигуру";
            comboBox1.Text = "Фигуры";

            string[] фигуры = { "Прямоугольник", "Эллипс", "Окружность" };
            comboBox1.Items.AddRange(фигуры);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очистка области рисования
            pictureBox1.Refresh();

            // Получаем объект Graphics
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                Brush заливка = new SolidBrush(Color.Orange);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        g.FillRectangle(заливка, 60, 60, 120, 180);
                        break;
                    case 1:
                        g.FillEllipse(заливка, 60, 60, 120, 180);
                        break;
                    case 2:
                        g.FillEllipse(заливка, 60, 60, 120, 120);
                        break;
                }
            }
        }
    }
}
