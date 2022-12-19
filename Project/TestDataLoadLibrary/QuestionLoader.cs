using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestLibrary;

namespace TestDataLoadLibrary
{
    public class QuestionLoader
    {
        public static List<Question> LoadQuest(int answerAmount, string fileName)
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);
            var questions = new List<Question>();
            
            using (var sr = new StreamReader(fileName, encoding))
            {
                while (!sr.EndOfStream)
                {
                    var question = new Question();
                    question.Answers = new List<string>();

                    for (int i = 0; i < answerAmount; i++)
                    {
                        question.Answers.Add(sr.ReadLine());
                    }
                    questions.Add(question);
                }
            }

            return questions;
        }
    }
}
