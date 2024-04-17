using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Interaktiivne_töölaud
{
    public partial class Playground : Form
    {
        public Playground()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.firstform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\mas\\MarkuStation.exe");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (DateTime.Today.Month == 12)
            { 
                Process.Start("C:\\mas\\nye.exe");
            } else
            {
                MessageBox.Show("Uue aasta vastuvõtu programm töötab ainult detsembris", "Ei saa programmi avada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Playground_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }
    }
}
