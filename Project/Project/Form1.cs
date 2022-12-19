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
using TestLibrary;
using TestDataLoadLibrary;

namespace Project
{
    public partial class Form1 : Form
    {
        DepTest Test;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = 0;
            if (radioButton1.Checked)
            {
                b += 0;
            }
            else if (radioButton2.Checked)
            {
                b += 1;
            }
            else if (radioButton3.Checked)
            {
                b += 2;
            }
            else if (radioButton4.Checked)
            {
                b += 3;
            }

            Test.Answer(b);

            if (button2.Text == "Завершить")
            {
                EndVisible();  
                
                label1.Text = String.Format("Тестирование завершено.");
                label3.Text = String.Format("Количество баллов: {0}\n" + "Результат тестирования: {1}", Test.Balls, Test.GetResult());
                
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
            var questions = new List<Question>();

            try
            {
                
                questions = QuestionLoader.LoadQuest(4, Directory.GetCurrentDirectory() + @"\Depression test.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка загрузки файла с вопросами");
            }

            Test = new DepTest()
            {
                Questions = questions,
                CurrentQuestionId = 0,
            };

            Question();
        }
        public void Question()
        {
            label1.Text = "Как вы чувствовали себя на этой неделе?";
            label2.Text = String.Format("Номер вопроса: {0}/{1}", Test.CurrentQuestionId + 1, Test.Questions.Count);
            radioButton1.Text = Test.Questions[Test.CurrentQuestionId].Answers[0];
            radioButton2.Text = Test.Questions[Test.CurrentQuestionId].Answers[1];
            radioButton3.Text = Test.Questions[Test.CurrentQuestionId].Answers[2];
            radioButton4.Text = Test.Questions[Test.CurrentQuestionId].Answers[3];


            if (Test.Questions.Count == Test.CurrentQuestionId + 1)
            {
                button2.Text = "Завершить";

            }
        }
        public void Switching_status(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Focus();
        }
    } 
}
