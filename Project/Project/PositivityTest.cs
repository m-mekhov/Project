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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Project
{
    public partial class PositivityTest : Form
    {
        StreamReader Read;
        int question_count;
        int PmB; // постоянство плохих событий
        int PmG; // постоянство хороших событий
        int PvB; // пространственное распространение плохих событий
        int PvG; // пространственное распространение хороших событий
        int HoB; // коэффициент надежды
        int PsB; // персонализация плохого
        int PsG; // персонализация хорошего
        int B; // итог по неблагоприятным событиям
        int G; // итог по благоприятным событиям
        int result;

        public PositivityTest()
        {
            InitializeComponent();
        }

        private void PositivityTest_Load(object sender, EventArgs e)
        {
            button2.Text = "Следующий вопрос";
            button1.Text = "Выход";
            radioButton1.CheckedChanged += new EventHandler(Switching_status);
            radioButton2.CheckedChanged += new EventHandler(Switching_status);

            Start();
        }
        public void Switching_status(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Focus();
        }
        public void Start()
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);

            try
            {
                Read = new StreamReader(Directory.GetCurrentDirectory() + @"\Positivity test.txt", encoding);

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
            label2.Text = Read.ReadLine();
            label1.Text = String.Format("Номер вопроса: {0}/48", question_count);
            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();

            radioButton1.Checked = true;
            radioButton2.Checked = false;

            question_count = question_count + 1;

            if (Read.EndOfStream == true) button2.Text = "Завершить";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "Следующий вопрос")
            {
                Count();
                Question();
            }

            if (button2.Text == "Завершить")
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Text = String.Format("Результат: {0} {1} {2} {3}", HoB, B, G, result);
            }
        }
        public void Count()
        {
            if (question_count == 5 || question_count == 13 || question_count == 20 || question_count == 21 || question_count == 29 || question_count == 33 || question_count == 42 || question_count == 46)
            {
                if (radioButton1.Checked == true)
                {
                    PmB = PmB + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PmB = PmB + 0;
                }
            }
            if (question_count == 2 || question_count == 10 || question_count == 14 || question_count == 15 || question_count == 24 || question_count == 26 || question_count == 38 || question_count == 40)
            {
                if(radioButton1.Checked == true)
                {
                    PmG = PmG + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PmG= PmG + 0;
                }
            }
            if (question_count == 8 || question_count == 16 || question_count == 17 || question_count == 18 || question_count == 22 || question_count == 32 || question_count == 44 || question_count == 48)
            {
                if (radioButton1.Checked == true)
                {
                    PvB = PvB + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PvB = PvB + 0;
                }
            }    
            if (question_count == 6 || question_count == 7 || question_count == 28 || question_count == 31 || question_count == 34 || question_count == 35 || question_count == 37 || question_count == 43)
            {
                if (radioButton1.Checked == true)
                {
                    PvG = PvG + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PvG = PvG + 0;
                }
            }
            if(question_count == 3 || question_count == 9 || question_count == 19 || question_count == 25 || question_count == 30 || question_count == 39 || question_count == 41 || question_count == 47)
            {
                if (radioButton1.Checked == true)
                {
                    PsB = PsB + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PsB = PsB + 0;
                }
            }
            if(question_count == 1 || question_count == 4 || question_count == 11 || question_count == 12 || question_count == 23 || question_count == 27 || question_count == 36 || question_count == 45)
            {
                if(radioButton1.Checked == true)
                {
                    PsG = PsG + 1;
                }
                else if(radioButton2.Checked == true)
                {
                    PsG = PsG + 0;
                }
            }
            HoB = PmB + PvB; // 16
            B = PmB + PvB + PsB; // 24
            G = PmG + PvG + PsG; // 23
            result = G - B; // -1
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
