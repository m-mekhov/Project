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
using TestLibrary;
using TestDataLoadLibrary;


namespace Project
{
    public partial class PositivityTest : Form
    {
        OptTest Test;

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
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var id = radioButton1.Checked ? 0 : 1;
            Test.Answer(id);

            if (button2.Text == "Завершить")
            {
                EndVisible();

                var res = Test.GetResult();
                int HoB = Test.Parameters[Parameter.PmB] + Test.Parameters[Parameter.PvB];
                int B = Test.Parameters[Parameter.PmB] + Test.Parameters[Parameter.PvB] + Test.Parameters[Parameter.PsB];
                int G = Test.Parameters[Parameter.PmG] + Test.Parameters[Parameter.PvG] + Test.Parameters[Parameter.PsG];
                int result = G - B;

                label3.Text = String.Format("Результат: \n PmB: {0}, {1} \n PmG: {2}, {3} \n PvB: {4}, {5} \n PvG: {6} {7} \n HoB: {8}, {9} \n PsB: {10}, {11} \n PsG {12}, {13} \n B: {14}, {15} \n G: {16}, {17} \n Разность G и B: {18}, {19} ",
                Test.Parameters[Parameter.PmB], res["PmB"],
                Test.Parameters[Parameter.PmG], res["PmG"],
                Test.Parameters[Parameter.PvB], res["PvB"],
                Test.Parameters[Parameter.PvG], res["PvG"],
                HoB, res["HoB"],
                Test.Parameters[Parameter.PsB], res["PsB"],
                Test.Parameters[Parameter.PsG], res["PsG"],
                B, res["B"],
                G, res["G"],
                result, res["result"]);
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
        private void button4_Click(object sender, EventArgs e)
        {
            Decoding d = new Decoding();
            d.Show();
        }
        public void Switching_status(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Focus();
        }
        public void Start()
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);
            var questions = new List<OptQuestion>();

            try
            {
                questions = OptQuestionLoader.LoadQuest(2, Directory.GetCurrentDirectory() + @"\Positivity test.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка загрузки файла с вопросами");
            }

            Test = new OptTest()
            {
                Questions = questions,
                CurrentQuestionId = 0,
            };




            Question();
        }
        public void Question()
        {
            var question = Test.Questions[Test.CurrentQuestionId];
            label2.Text = question.QuestionText;
            label1.Text = String.Format("Номер вопроса: {0}/{1}", Test.CurrentQuestionId + 1, Test.Questions.Count);
            radioButton1.Text = question.Answers[0];
            radioButton2.Text = question.Answers[1];


            if (Test.Questions.Count == Test.CurrentQuestionId + 1)
            {
                button2.Text = "Завершить";

            }
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
    }
}
