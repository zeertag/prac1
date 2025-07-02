using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trajectory
{
    public partial class FormT : Form
    {
        double InitT = 0, LastT; // Полный оборот (360°)
        double Step = 0.1, angle;
        double x, y, x1, y1;
        int cX = 200, cY = 200; // Центр большой окружности
        double R2;         // Радиус большой окружности
        double k;            // Кол-во сегментов
        int R1;                 // Радиус малой окружности
        List<PointF> points = new List<PointF>();
        bool isAnimating = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public FormT()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormT_Load(object sender, EventArgs e)
        {

        }

        void Paint_Circle(Graphics g, float cX, float cY, float centX, float centY, float radius, float x, float y)
        {
            g.DrawEllipse(Pens.Black, centX + cX - radius, cY - radius - centY, radius * 2, radius * 2);
            g.DrawLine(Pens.Black, centX + cX, cY - centY, cX + x, cY + y);
        }

        void Paint_Graphic(Graphics g, float cX, float cY, float r2, float x, float y, List<PointF> p)
        {
            pictureBox1.BackColor = Color.White;
            Paint_Circle(g, cX, cY, 0, 0, r2, x, y);
            if (p.Count > 1)
                g.DrawLines(Pens.Red, p.ToArray());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;
            isAnimating = true;

            try
            {
                R1 = Convert.ToInt32(textBox1.Text);
                k = double.Parse(textBox2.Text, CultureInfo.InvariantCulture);

                if (k <= 0)
                {
                    MessageBox.Show("Параметр k должен быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isAnimating = false;
                    return;
                }

                angle = InitT;
                R2 = R1 * k;
                points.Clear();

                LastT = GetFullCycleRadians(k);

                while (angle <= LastT)
                {
                    x = R1 * (k - 1) * (Math.Cos(angle) + Math.Cos((k - 1) * angle) / (k - 1));
                    y = R1 * (k - 1) * (Math.Sin(angle) - Math.Sin((k - 1) * angle) / (k - 1));

                    points.Add(new PointF(cX + (float)x, cY + (float)y));

                    x1 = (R2 - R1) * Math.Sin(angle + Math.PI / 2);
                    y1 = (R2 - R1) * Math.Cos(angle + Math.PI / 2);

                    pictureBox1.Refresh();
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        Paint_Graphic(g, cX, cY, (float)R2, (float)x, (float)y, points);
                        Paint_Circle(g, cX, cY, (float)x1, (float)y1, R1, (float)x, (float)y);
                    }

                    angle += Step;
                    await Task.Delay(40);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAnimating = false;
        }


        double GetFullCycleRadians(double k)
        {
            // Если k целое — цикл = 2π
            if (k % 1 == 0)
                return 2 * Math.PI;

            // Иначе найдём приближение дроби через знаменатель
            int maxDenominator = 1000;
            double epsilon = 1e-6;

            for (int den = 1; den <= maxDenominator; den++)
            {
                double num = k * den;
                if (Math.Abs(num - Math.Round(num)) < epsilon)
                {
                    int n = (int)Math.Round(num);
                    return 2 * Math.PI * den;
                }
            }

            // По умолчанию: несколько оборотов
            return 2 * Math.PI * 10;
        }
    }
}
