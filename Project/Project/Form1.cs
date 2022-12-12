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
using System.Runtime.Remoting.Channels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Form1 : Form
    {
        int question_count;
        int balls;
        string result;

        StreamReader Read;
        public Form1()
        {
            InitializeComponent();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Count();
            if (button2.Text == "Завершить")
            {
                EndVisible();

                Conclusion();   
                
                label1.Text = String.Format("Тестирование завершено.");
                label3.Text = String.Format("Количество баллов: {0}\n" + "Результат тестирования: {1}", balls, result);
                
            }


            if (button2.Text == "Следующий вопрос")
            {
               Question();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthorizationForm2 AF2 = new AuthorizationForm2();
            AF2.Show();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.CheckedChanged += new EventHandler(Switching_status);
            radioButton2.CheckedChanged += new EventHandler(Switching_status);
            radioButton3.CheckedChanged += new EventHandler(Switching_status);
            radioButton4.CheckedChanged += new EventHandler(Switching_status);
            
            LoadVisible();

            Start();
        }
        public void LoadVisible()
        {
            button1.Text = "Выйти";
            button2.Text = "Следующий вопрос";
            label3.Visible = false;
            button3.Visible = false;
        }
        public void EndVisible()
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button3.Text = "Выбрать тест";
            label2.Visible = false;
            label3.Visible = true;
        }
        void Start()
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);

            try
            {
                Read = new StreamReader(Directory.GetCurrentDirectory() + @"\Depression test.txt", encoding);

                question_count = 1;
                balls = 0;
                result = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка загрузки файла с вопросами");
            }
            Question();
        }
        public void Question()
        {
            label1.Text = "Как вы чувствовали себя на этой неделе?";
            label2.Text = String.Format("Номер вопроса: {0}/21", question_count);
            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();
            radioButton3.Text = Read.ReadLine();
            radioButton4.Text = Read.ReadLine();

            question_count = question_count + 1;

            if (Read.EndOfStream == true)
            {
                button2.Text = "Завершить";

            }
        }
        public void Switching_status(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Focus();
        }
        public void Count()
        {
                if (radioButton1.Checked == true)
                {
                    balls = balls + 0;
                }
                else if (radioButton2.Checked == true)
                {
                    balls = balls + 1;
                }
                else if (radioButton3.Checked == true)
                {
                    balls = balls + 2;
                }
                else if (radioButton4.Checked == true)
                {
                    balls = balls + 3;
                }
        }
        public void Conclusion()
        {
            if (balls >= 0 && balls <= 9)
            {
                result = "У Вас отсутствие депрессивных симптомов.";
            }
            else if (balls >= 10 && balls <= 15)
            {
                result = "У Вас легкая депрессия.";
            }
            else if (balls >= 16 && balls <= 19)
            {
                result = "У Вас умеренная депрессия.";
            }
            else if (balls >= 20 && balls <= 29)
            {
                result = "У Вас выраженная депрессия.";
            }
            else if (balls >= 30 && balls <= 63)
            {
                result = "У Вас тяжёлая депрессия.";
            }
        }
    } 
}
