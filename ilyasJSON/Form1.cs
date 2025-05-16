using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ilyasJSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Name = textBox1.Text,
                Age = (int)numericUpDown1.Value,
                Email = textBox2.Text
            };
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText("users.json", json);
            MessageBox.Show("Данные сохранены");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("user.json")) 
            {
                string jsom = File.ReadAllText("users.json");
                User user = JsonConvert.DeserializeObject<User>(jsom);
                textBox1.Text = user.Name;
                numericUpDown1.Value = user.Age;
                textBox2.Text = user.Email;
                MessageBox.Show("Данные загружены");
            }
            else
            {
                MessageBox.Show("Файл не найден");
            }
        }
    }
}
