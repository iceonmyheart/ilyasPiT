using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Двумерные_массивы
{
    public partial class Form1 : Form
    {
        float[,] a = new float[100, 100];
        int i, j, n, m;
        Random rand = new Random();
        //public Form1()
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);

            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    a[i, j] = rand.Next(0, 21) - 10;

                    dataGridView1[j, i].Value = Convert.ToString(a[i, j]);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Массив_с_клавиатуры = new Массив_с_клавиатуры();
            Массив_с_клавиатуры.Show();
        }
    }
}
