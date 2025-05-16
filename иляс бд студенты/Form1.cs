using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sueta.models;

namespace sueta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new StudentContext()) 
            {
                var newStudent = new Student
                {
                    NAME = textBox1.Text,
                    Age = (int)numericUpDown1.Value,
                    GroupName = textBox2.Text
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                MessageBox.Show("Студент добавлен!");
                LoadStudents();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
        private void LoadStudents()
        {
            listBox1.Items.Clear();
            using (var context = new StudentContext()) 
            {
                var students = context.Students.ToList();
                foreach (var student in students) 
                {
                    listBox1.Items.Add($"{student.Id}: {student.NAME}, Возраст: {student.Age}, Группа: {student.GroupName}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                var selectedStudent = listBox1.SelectedItem.ToString().Split(':')[0];
                using (var context = new StudentContext())
                {
                    var studentToUpdate = context.Students.Find(int.Parse(selectedStudent));
                    if (studentToUpdate != null) 
                    {
                        studentToUpdate.Age = (int)numericUpDown1.Value;
                        context.SaveChanges();
                        MessageBox.Show("Данные студента обновлены!");
                        LoadStudents();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) 
            {
                var selectedStudent = listBox1.SelectedItem.ToString().Split(':')[0];
                using (var context = new StudentContext())
                {
                    var studentToDelete = context.Students.Find(int.Parse(selectedStudent));
                    if (studentToDelete != null) 
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Студент удален!");
                        LoadStudents();
                    }
                }
            }
        }
    }
}
