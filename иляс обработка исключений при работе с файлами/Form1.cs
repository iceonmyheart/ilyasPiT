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

namespace иляс_обработка_исключений_ри_работе_с_файлами
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox1.Text;
                string content = textBox2.Text;
                System.IO.File.WriteAllText(fileName, content);
                label3.Text = "Файл успешно сохранен";
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка: Нет доступа к файлу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Ошибка при сохранении файла:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox1.Text;
                string content = System.IO.File.ReadAllText(fileName);
                textBox2.Text = content;
                label3.Text = "Файл успешно загружен!";
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Ошибка: Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(System.IO.IOException ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: "+ ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
