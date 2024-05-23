using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Markuse_arvuti_integratsioonitarkvara
{
    public partial class EndVM : Form
    {
        public EndVM()
        {
            InitializeComponent();
        }

        private void EndVM_Shown(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Bitmap ei;
                ei = (Bitmap)Bitmap.FromFile(Program.root + @"\bg_login.png", false);
                this.BackgroundImage = ei;
                timer1.Enabled = true;
                pictureBox1.BackColor = this.BackColor;
                label1.BackColor = this.BackColor;
                label2.BackColor = this.BackColor;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool conts = false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("VirtualBoxVM"))
                {
                    conts = true;
                }
            }
            if (!conts)
            {
                this.Close();
            }
        }

        private void EndVM_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"D:\Jagatud\close_vm.log"))
            {
                System.IO.File.Delete(@"D:\Jagatud\close_vm.log");
            }
        }
    }
}
