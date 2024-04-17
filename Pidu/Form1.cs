using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pidu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            label5.Text = "Järgmise aastani on jäänud";
            bool leap = false;
            int monthdays = 31;
            if (DateTime.Today.Year % 4 == 0) { leap = true; }
            if (DateTime.Today.Month == 1 || DateTime.Today.Month == 3 || DateTime.Today.Month == 5 || DateTime.Today.Month == 7 || DateTime.Today.Month == 8 || DateTime.Today.Month == 10 || DateTime.Today.Month == 12) { monthdays = 31; }
            if (DateTime.Today.Month == 4 || DateTime.Today.Month == 6 || DateTime.Today.Month == 9 || DateTime.Today.Month == 11) { monthdays = 30; }
            if (DateTime.Today.Month == 2)
            {
                if (leap)
                {
                    monthdays = 29;
                } else
                {
                    monthdays = 28;
                }
            }
            months.Text = (12 - DateTime.Today.Month).ToString();
            if (months.Text == "1") { monthLabel.Text = "kuu"; } else { monthLabel.Text = "kuud"; }
            days.Text = (monthdays - DateTime.Today.Day).ToString();
            if (days.Text == "1") { dayLabel.Text = "päev"; } else { dayLabel.Text = "päeva"; }
            hours.Text = (23 - DateTime.Now.Hour).ToString();
            if (hours.Text == "1") { hourLabel.Text = "tund"; } else { hourLabel.Text = "tundi"; }
            minutes.Text = (59 - DateTime.Now.Minute).ToString();
            if (minutes.Text == "1") { minuteLabel.Text = "minut"; } else { minuteLabel.Text = "minutit"; }
            seconds.Text = (59 - DateTime.Now.Second).ToString();
            if (seconds.Text == "1") { secondLabel.Text = "sekund"; } else { secondLabel.Text = "sekundit"; }
        }
    }
}
