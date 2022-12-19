using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public enum Parameter
    {
        PmB, // постоянство плохих событий
        PmG, // постоянство хороших событий
        PvB, // пространственное распространение плохих событий
        PvG, // пространственное распространение хороших событий
        PsB, // персонализация плохого
        PsG  // персонализация хорошего
    }
    public class OptTest
    {
        public List<OptQuestion> Questions { get; set; }
        public Dictionary<Parameter, int> Parameters = new Dictionary<Parameter, int>()
        {
            {Parameter.PmB, 0},
            {Parameter.PmG, 0},
            {Parameter.PvB, 0},
            {Parameter.PvG, 0},
            {Parameter.PsB, 0},
            {Parameter.PsG, 0}

        };
        public int CurrentQuestionId { get; set; }

        public void Answer(int id)
        {
            if (id == 0)
            {
                var param = Questions[CurrentQuestionId].param;
                Parameters[param]++;
            }
            CurrentQuestionId++;
        }

        public Dictionary<string, string> GetResult()
        {
            int HoB = Parameters[Parameter.PmB] + Parameters[Parameter.PvB];
            int B = Parameters[Parameter.PmB] + Parameters[Parameter.PvB] + Parameters[Parameter.PsB];
            int G = Parameters[Parameter.PmG] + Parameters[Parameter.PvG] + Parameters[Parameter.PsG];
            int result = G - B;

            return new Dictionary<string, string>()
            {
                { "PmB", Rez_PmB(Parameters[Parameter.PmB]) },
                { "PmG", Rez_PmG(Parameters[Parameter.PmG]) },
                { "PvB", Rez_PvB(Parameters[Parameter.PvB]) },
                { "PvG", Rez_PvG(Parameters[Parameter.PvG]) },
                { "HoB", Rez_HoB(HoB) },
                { "PsB", Rez_PsB(Parameters[Parameter.PsB]) },
                { "PsG", Rez_PsG(Parameters[Parameter.PsG]) },
                { "B", Rez_B(B) },
                { "G", Rez_G(G) },
                { "result", Rez_result(result) }
            };
        }

        public string Rez_PmB(int PmB)
        {
            if ((PmB == 0 || PmB == 1))
            {
                return "Вы весьма оптимистичны по этому параметру";
            }
            else if ((PmB == 2) || (PmB == 3))
            {
                return "Умеренно оптимистичны";
            }
            else if (PmB == 4)
            {
                return "Нечто промежуточное";
            }
            else if ((PmB == 5) || (PmB == 6))
            {
                return "Вполне пессимистичны";
            }

            return "Крайне пессимистичны";
         
        }
        public string Rez_PmG(int PmG)
        {
            if (PmG >= 0 && PmG <= 3)
            {
                return "Весьма пессимистичная";
            }
            else if (PmG == 4 || PmG == 5)
            {
                return "Умеренно пессимистичная";
            }
            else if (PmG == 6)
            {
                return "Умеррено оптимистичная оценка";
            }

            return "Вы очень оптимистично настроены";

        }
        public string Rez_PvB(int PvB)
        {
            if (PvB == 0 || PvB == 1)
            {
                return "Очень оптимистично";
            }
            else if (PvB == 2 || PvB == 3)
            {
                return "Умеренно оптимистично";
            }
            else if (PvB == 4)
            {
                return "Средний показатель";
            }
            else if (PvB == 5 || PvB == 6)
            {
                return "Умеренно пессимистично";
            }

            return "Весьма пессимистично";

        }
        public string Rez_PvG(int PvG)
        {
            if (PvG >= 0 && PvG <= 2)
            {
                return "Весьма пессимистично";
            }
            else if (PvG == 3)
            {
                return "Умеренно пессимистично";
            }
            else if (PvG == 4 || PvG == 5)
            {
                return "Промежуточная ситуация";
            }
            else if (PvG == 6)
            {
                return "Умеренно оптимистично";
            }

            return "Весьма оптимистично";

        }
        public string Rez_HoB(int HoB)
        {
            if (HoB >= 0 && HoB <= 2)
            {
                return "Вы преисполнены надежд";
            }
            else if (HoB >= 3 && HoB <= 6)
            {
                return "Умеренные надежды";
            }
            else if (HoB == 7 || HoB == 8)
            {
                return "Промежуточная ситуация";
            }
            else if (HoB >= 9 && HoB <= 11)
            {
                return "Вы умеренно безнадежны";
            }

            return "Вы абсолютно безнадежны";

        }
        public string Rez_PsB(int PsB)
        {
            if (PsB == 0 || PsB == 1)
            {
                return "Указывает на очень высокую самооценку";
            }
            else if (PsB == 2 || PsB == 3)
            {
                return "Умеренная самооценка";
            }
            else if (PsB == 4)
            {
                return "Средняя";
            }
            else if (PsB == 5 || PsB == 6)
            {
                return "Умеренно низкая самооценка";
            }

            return "Очень низкая самооценка";

        }
        public string Rez_PsG(int PsG)
        {
            if (PsG >= 0 || PsG <= 2)
            {
                return "Очень пессимистичная";
            }
            else if (PsG == 3)
            {
                return "Умеренно пессимистичная";
            }
            else if (PsG == 4 || PsG == 5)
            {
                return "Промежуточная оценка";
            }
            else if (PsG == 6)
            {
                return "Умеренно оптимистичная оценка";
            }

            return "Очень оптимистичная оценка";

        }
        public string Rez_B(int B)
        {
            if (B >= 0 && B < 6)
            {
                return "Вы замечательно оптимистичны";
            }
            else if (B >= 6 && B <= 9)
            {
                return "Вы умеренно оптимистичны";
            }
            else if (B == 10 || B == 11)
            {
                return "Промежуточные значения";
            }
            else if (B >= 12 && B <= 14)
            {
                return "Умеренно пессимистичны";
            }

            return "Обратитесь к врачу";

        }
        public string Rez_G(int G)
        {
            if (G >= 17 && G <= 19)
            {
                return "Ваше мышление умеренно оптимистично";
            }
            else if (G >= 14 && G <= 16)
            {
                return "Промежуточные значения";
            }
            else if (G >= 11 && G <= 13)
            {
                return "Вы рассуждаете вполне оптимистично";
            }
            else if (G < 10)
            {
                return "Глубокий пессимизм";
            }

            return "Вы относитесь к хорошим событиям весьма оптимистично";

        }
        public string Rez_result(int result)
        {
            if (result <= 0)
            {
                return "Вы весьма пессимистичны";
            }
            else if (result == 1 || result == 2)
            {
                return "Умеренно пессимистичны";
            }
            else if (result >= 3 && result <= 5)
            {
                return "Промежуточные значения";
            }
            else if (result >= 6 && result <= 8)
            {
                return "Вы умеренно оптимистичны";
            }

            return "Вы весьма оптимистичны в широком диапазоне условий";

        }
    }
}
