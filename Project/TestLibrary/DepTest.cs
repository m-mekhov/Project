using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public  class DepTest
    {
        public List<Question> Questions { get; set; }
        public int CurrentQuestionId { get; set; }
        public int Balls { get; set; }

        public void Answer(int b)
        {
            Balls += b;
            CurrentQuestionId++;
        }

        public string GetResult()
        {
            if (Balls >= 0 && Balls <= 9)
            {
                return "У Вас отсутствие депрессивных симптомов.";
            }
            else if (Balls >= 10 && Balls <= 15)
            {
                return "У Вас легкая депрессия.";
            }
            else if (Balls >= 16 && Balls <= 19)
            {
                return "У Вас умеренная депрессия.";
            }
            else if (Balls >= 20 && Balls <= 29)
            {
                return "У Вас выраженная депрессия.";
            }

            return "У Вас тяжёлая депрессия.";

        }
    }
}
