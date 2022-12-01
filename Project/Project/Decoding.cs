using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Decoding : Form
    {
        public Decoding()
        {
            InitializeComponent();
        }

        private void Decoding_Load(object sender, EventArgs e)
        {
            label1.Text = "Обозначения: \n PmB - постоянство плохих событий \n PmG - постоянство хороших событий \n PvB - пространственное распространение плохих событий \n PvG - пространственное распространение хороших событий \n HoB - коэффициент надежды \n PsB - персонализация плохого \n PsG - персонализация хорошего \n B - итог по неблагоприятным событиям \n G - итог по благоприятным событиям \n Разность G и B - окончательный итог";
            this.Text = "Расшифровка";
        }
    }
}
