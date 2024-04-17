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
using System.IO;

namespace Interaktiivne_töölaud
{
    public partial class Inside : Form
    {
        public Inside()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.firstform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Program.isGuest)
            {
                Program.officeroom.LoadFolder(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Markuse kaustad", "Minu dokumendid", Program.officeroom);
            }
            else
            {
                Program.officeroom.LoadFolder(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Külalise failid", Program.officeroom);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("wmplayer.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sleep();
        }

        private void sleep()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sleep();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sleep();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.officeroom.label1.Text = "Kaust töölaud";
            if (!Program.isGuest)
            { 
                if (!File.Exists(Environment.GetEnvironmentVariable("USERPROFILE").ToString() + "\\Desktop\\Peida need töölauaikoonid.lnk"))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\organize_desktop.bat";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    Program.officeroom.webBrowser1.Visible = false;
                    Program.officeroom.PreloadTimer.Enabled = true;
                    Program.officeroom.label1.Text = "Palun oota...";
                }
            }
            Program.officeroom.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.winroom.Show();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            { 
                File.WriteAllText("C:\\mas\\opencontext.log", "");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists("C:\\mas\\foldersignal.log"))
            {
                timer1.Enabled = false;
                File.Delete("C:\\mas\\foldersignal.log");
                Program.officeroom.Show();
                Program.officeroom.label1.Text = "Failihaldur";
                this.Hide();
            }
            else if (File.Exists("C:\\mas\\closing.log"))
            {
                File.Delete("C:\\mas\\closing.log");
                Program.firstform.Exit();
            }
        }

        private void Inside_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Inside_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                button10.Visible = false;
            }
            if (Program.isGuest)
            {
                pictureBox1.Visible = false;
                button11.Visible = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "chrome.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p.Start();
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }
    }
}
