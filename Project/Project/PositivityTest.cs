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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


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
        string rez_PmB, rez_PmG, rez_PvB, rez_PvG, rez_HoB, rez_PsB, rez_PsG, rez_B, rez_G, rez_res;

        public PositivityTest()
        {
            InitializeComponent();
        }

        private void PositivityTest_Load(object sender, EventArgs e)
        {
            radioButton1.CheckedChanged += new EventHandler(Switching_status);
            radioButton2.CheckedChanged += new EventHandler(Switching_status);
            
            LoadVisible();
            
            Start();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "Завершить")
            {
                EndVisible();
                
                Conclusion();
                
                label3.Text = String.Format("Результат: \n PmB: {0}, {1} \n PmG: {2}, {3} \n PvB: {4}, {5} \n PvG: {6} {7} \n HoB: {8}, {9} \n PsB: {10}, {11} \n PsG {12}, {13} \n B: {14}, {15} \n G: {16}, {17} \n Разность G и B: {18}, {19} ", PmB, rez_PmB, PmG, rez_PmG, PvB, rez_PvB, PvG, rez_PvG, HoB, rez_HoB, PsB, rez_PsB, PsG, rez_PsG, B, rez_B, G, rez_G, result, rez_res);
            }

            if (button2.Text == "Следующий вопрос")
            {
                Question();
                
                Count();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthorizationForm2 AF2 = new AuthorizationForm2();
            AF2.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" PmB - постоянство плохих событий \n PmG - постоянство хороших событий \n PvB - пространственное распространение плохих событий \n PvG - пространственное распространение хороших событий \n HoB - коэффициент надежды \n PsB - персонализация плохого \n PsG - персонализация хорошего \n B - итог по неблагоприятным событиям \n G - итог по благоприятным событиям \n Разность G и B - окончательный итог");
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
                PmB = 0; PmG = 0; PvB = 0; PvG = 0; HoB = 0; PsB = 0; PsG = 0; B = 0; G = 0;
                question_count = 0; result = 0;
                rez_PmB = ""; rez_PmG = ""; rez_PvB = ""; rez_PvG = ""; rez_HoB = ""; rez_PsB = ""; rez_PsG = ""; rez_B = ""; rez_G = ""; rez_res = "";

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
            label1.Text = String.Format("Номер вопроса: {0}/48", question_count + 1);
            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();

            question_count = question_count + 1;

            if (Read.EndOfStream == true)
            {
                button2.Text = "Завершить";

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
                if (radioButton1.Checked == true)
                {
                    PmG = PmG + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PmG = PmG + 0;
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
            if (question_count == 3 || question_count == 9 || question_count == 19 || question_count == 25 || question_count == 30 || question_count == 39 || question_count == 41 || question_count == 47)
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
            if (question_count == 1 || question_count == 4 || question_count == 11 || question_count == 12 || question_count == 23 || question_count == 27 || question_count == 36 || question_count == 45)
            {
                if (radioButton1.Checked == true)
                {
                    PsG = PsG + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    PsG = PsG + 0;
                }
            }
            HoB = PmB + PvB; // 16
            B = PmB + PvB + PsB; // 24
            G = PmG + PvG + PsG; // 23
            result = G - B; // -1
        }
        public void LoadVisible()
        {
            button3.Text = "Выбрать тест";
            button2.Text = "Следующий вопрос";
            button1.Text = "Выход";
            button3.Visible = false;
            button4.Visible = false;
            label3.Visible = false;
        }
        public void EndVisible()
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button4.Text = "Расшифровка пунктов";
            label1.Visible = false;
            label2.Visible = false;
            panel2.Visible = false;
            label3.Visible = true;
        }
        public void Conclusion()
        {
            Rez_PmB();
            Rez_PmG();
            Rez_PvB();
            Rez_PvG();
            Rez_HoB();
            Rez_PsB();
            Rez_PsG();
            Rez_B();
            Rez_G();
            Rez_result();
        }
        public void Rez_PmB()
        {
            if ((PmB == 0 || PmB == 1))
            {
                rez_PmB = "Вы весьма оптимистичны по этому параметру";
            }
            else if ((PmB == 2) || (PmB == 3))
            {
                rez_PmB = "Умеренно оптимистичны";
            }
            else if (PmB == 4)
            {
                rez_PmB = "Нечто промежуточное";
            }
            else if ((PmB == 5) || (PmB == 6))
            {
                rez_PmB = "Вполне пессимистичны";
            }
            else if ((PmB == 7) || (PmB == 8))
            {
                rez_PmB = "Крайне пессимистичны";
            }
        }
        public void Rez_PmG()
        {
            if (PmG >= 0 && PmG <= 3)
            {
                rez_PmG = "Весьма пессимистичная";
            }
            else if (PmG == 4 || PmG == 5)
            {
                rez_PmG = "Умеренно пессимистичная";
            }
            else if (PmG == 6)
            {
                rez_PmG = "Умеррено оптимистичная оценка";
            }
            else if (PmG == 7 || PmG == 8)
            {
                rez_PmG = "Вы очень оптимистично настроены";
            }
        }
        public void Rez_PvB()
        {
            if (PvB == 0 || PvB == 1)
            {
                rez_PvB = "Очень оптимистично";
            }
            else if (PvB == 2 || PvB == 3)
            {
                rez_PvB = "Умеренно оптимистично";
            }
            else if (PvB == 4)
            {
                rez_PvB = "Средний показатель";
            }
            else if (PvB == 5 || PvB == 6)
            {
                rez_PvB = "Умеренно пессимистично";
            }
            else if (PvB == 7 || PvB == 8)
            {
                rez_PvB = "Весьма пессимистично";
            }
        }
        public void Rez_PvG()
        {
            if (PvG >= 0 && PvG <= 2)
            {
                rez_PvG = "Весьма пессимистично";
            }
            else if(PvG == 3)
            {
                rez_PvG = "Умеренно пессимистично";
            }
            else if(PvG == 4 || PvG == 5)
            {
                rez_PvG = "Промежуточная ситуация";
            }
            else if(PvG == 6)
            {
                rez_PvG = "Умеренно оптимистично";
            }
            else if (PvG >= 6 && PvG <= 8)
            {
                rez_PvG = "Весьма оптимистично";
            }
        }
        public void Rez_HoB()
        {
            if(HoB >= 0 && HoB <= 2)
            {
                rez_HoB = "Вы преисполнены надежд";
            }
            else if(HoB >= 3 && HoB <= 6)
            {
                rez_HoB = "Умеренные надежды";
            }
            else if(HoB == 7 || HoB == 8)
            {
                rez_HoB = "Промежуточная ситуация";
            }
            else if(HoB >=9 && HoB<= 11)
            {
                rez_HoB = "Вы умеренно безнадежны";
            }
            else if (HoB >= 12 && HoB <= 16)
            {
                rez_HoB = "Вы абсолютно безнадежны";
            }
        }
        public void Rez_PsB()
        {
            if (PsB == 0 || PsB == 1)
            {
                rez_PsB = "Указывает на очень высокую самооценку";
            }
            else if (PsB == 2 || PsB == 3)
            {
                rez_PsB = "Умеренная самооценка";
            }
            else if (PsB == 4)
            {
                rez_PsB = "Средняя";
            }
            else if (PsB == 5 || PsB == 6)
            {
                rez_PsB = "Умеренно низкая самооценка";
            }
            else if (PsB == 7 || PsB == 8)
            {
                rez_PsB = "Очень низкая самооценка";
            }
        }
        public void Rez_PsG()
        {
            if(PsG >= 0 || PsG <= 2)
            {
                rez_PsG = "Очень пессимистичная";
            }
            else if(PsG == 3)
            {
                rez_PsG = "Умеренно пессимистичная";
            }
            else if(PsG == 4 || PsG == 5)
            {
                rez_PsG = "Промежуточная оценка";
            }
            else if (PsG == 6)
            {
                rez_PsG = "Умеренно оптимистичная оценка";
            }
            else if(PsG == 7 || PsG == 8)
            {
                rez_PsG = "Очень оптимистичная оценка";
            }
        }
        public void Rez_B()
        {
            if(B >= 0 && B < 6)
            {
                rez_B = "Вы замечательно оптимистичны";
            }
            else if(B >= 6 && B <= 9)
            {
                rez_B = "Вы умеренно оптимистичны";
            }
            else if (B == 10 || B == 11)
            {
                rez_B = "Промежуточные значения";
            }
            else if(B >= 12 && B <= 14)
            {
                rez_B = "Умеренно пессимистичны";
            }
            else if(B > 14)
            {
                rez_B = "Обратитесь к врачу";
            }
        }
        public void Rez_G()
        {
            if(G<10)
            {
                rez_G = "Глубокий пессимизм";
            }
            else if (G >= 11 && G <= 13)
            {
                rez_G = "Вы рассуждаете вполне оптимистично";
            }
            else if (G >= 14 && G<=16)
            {
                rez_G = "Промежуточные значения";
            }
            else if (G >= 17 && G <= 19)
            {
                rez_G = "Ваше мышление умеренно оптимистично";
            }
            else if (G>19)
            {
                rez_G = "Вы относитесь к хорошим событиям весьма оптимистично";
            }
        }
        public void Rez_result()
        {
            if(result <= 0)
            {
                rez_res = "Вы весьма пессимистичны";
            }
            else if (result == 1 || result == 2)
            {
                rez_res = "Умеренно пессимистичны";
            }
            else if (result >= 3 && result <=5)
            {
                rez_res = "Промежуточные значения";
            }
            else if (result >= 6 && result <= 8 )
            {
                rez_res = "Вы умеренно оптимистичны";
            }
            else if (result > 8)
            {
                rez_res = "Вы весьма оптимистичны в широком диапазоне условий";
            }    
        }
    }
}
