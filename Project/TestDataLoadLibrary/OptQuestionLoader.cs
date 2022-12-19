using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestLibrary;

namespace TestDataLoadLibrary
{
    public class OptQuestionLoader
    {
        public static List<OptQuestion> LoadQuest(int answerAmount, string fileName)
        {
            var encoding = System.Text.Encoding.GetEncoding(65001);
            var questions = new List<OptQuestion>();

            using (var sr = new StreamReader(fileName, encoding))
            {
                while (!sr.EndOfStream)
                {
                    var question = new OptQuestion();
                    question.Answers = new List<string>();

                    question.QuestionText = sr.ReadLine();

                    for (int i = 0; i < answerAmount; i++)
                    {
                        question.Answers.Add(sr.ReadLine());
                    }

                    var param = sr.ReadLine();
                    switch (param)
                    {
                        case "PmB":
                            question.param = Parameter.PmB;
                            break;
                        case "PmG":
                            question.param = Parameter.PmG;
                            break;
                        case "PvB":
                            question.param = Parameter.PvB;
                            break;
                        case "PvG":
                            question.param = Parameter.PvG;
                            break;
                        case "PsB":
                            question.param = Parameter.PsB;
                            break;
                        case "PsG":
                            question.param = Parameter.PsG;
                            break;
                    }

                    questions.Add(question);
                    question = new OptQuestion();
                }
            }

            return questions;
        }
    }
}
