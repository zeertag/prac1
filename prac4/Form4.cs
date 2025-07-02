using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prac4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Текстовый редактор";
            //openFileDialog1.FileName = @"C:\Users\taras\OneDrive\Рабочий стол\data.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.UTF8))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
                textBox1.Modified = false;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\nФайл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save();
            }
        }

        private void Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding(1251)))
                {
                    writer.Write(textBox1.Text);
                }
                textBox1.Modified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textBox1.Modified)
                return;

            var result = MessageBox.Show("Текст был изменён.\nСохранить изменения?", "Простой редактор",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.No)
                return;

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (result == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
