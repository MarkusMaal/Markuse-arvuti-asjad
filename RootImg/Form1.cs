using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RootImg
{
    public partial class Form1 : Form
    {
        bool existprocess = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!existprocess)
            {
                e.Cancel = false;
            } else { 
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            existprocess = false;
            bool existprocessmas = false;
            timer1.Enabled = false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToLower() == "markuse arvuti integratsioonitarkvara")
                {
                    existprocessmas = true;
                }
                if (p.ProcessName.ToUpper() == "JTR")
                {
                    existprocess = true;
                }
            }
            timer1.Enabled = true;
            if (this.Visible)
            {
                if (existprocessmas)
                {
                    this.Hide();
                }
            } else
            {
                if (!existprocessmas)
                {
                    this.Show();
                }
            }
            if (!existprocess)
            {
                this.Close();
            }
        }
    }
}
