using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Markuse_arvuti_integratsioonitarkvara
{
    public partial class StartingVM : Form
    {
        public StartingVM()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Style != ProgressBarStyle.Marquee)
            {
                progressBar1.Value += 1;
            }
            if (progressBar1.Value == 50)
            {
                label2.Text = "Windowsi käivitamine...";
            }
            else if (progressBar1.Value == 250)
            {
                label2.Text = "Peaaegu valmis...";
            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                label2.Text = "See võtab oodatust kauem aega...";
            }
            if (File.Exists(@"D:\Jagatud\VM_started.log"))
            {
                File.Delete(@"D:\Jagatud\VM_started.log");
                this.Close();
            }
        }

        private void StartingVM_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void StartingVM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();
        }

        private void StartingVM_Shown(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                pictureBox1.BackColor = this.BackColor;
                label1.BackColor = this.BackColor;
                label2.BackColor = this.BackColor;
                Bitmap ei;
                ei = (Bitmap)Bitmap.FromFile(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\bg_login.png", false);
                this.BackgroundImage = ei;
            }
        }
    }
}
