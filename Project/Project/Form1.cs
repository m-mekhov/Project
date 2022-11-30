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
            if (button2.Text == "Завершить")
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                button2.Visible = false;
                label2.Visible = false;
                Conclusion();
                label1.Text= String.Format("Тестирование завершено.\n" + "Количество набранных баллов: {0}.\n" + "Вывод: {1}", balls, result);

            }


            if (button2.Text == "Следующий вопрос")
            {
                Count();
                Question();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Выйти";
            button2.Text = "Следующий вопрос";
            radioButton1.CheckedChanged += new EventHandler(Switching_status);
            radioButton2.CheckedChanged += new EventHandler(Switching_status);
            radioButton3.CheckedChanged += new EventHandler(Switching_status);
            radioButton4.CheckedChanged += new EventHandler(Switching_status);
            
            Start();
        }
        void Start()
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);

            try
            {
                Read = new StreamReader(Directory.GetCurrentDirectory() + @"\Depression test.txt", encoding);

                this.Text = "Психологический тест";

                question_count = 1;
                
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
            label2.Text = String.Format("Номер вопроса: {0}/21 {1}", question_count, balls);
            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();
            radioButton3.Text = Read.ReadLine();
            radioButton4.Text = Read.ReadLine();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            question_count = question_count + 1;


            if (Read.EndOfStream == true) button2.Text = "Завершить";
        }
        public void Switching_status(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Focus();
            RadioButton p = (RadioButton)sender;
            var t = p.Name;
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
                result = "У Вас отсутсвие депрессивных симптомов.";
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
