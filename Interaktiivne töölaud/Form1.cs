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
using System.Runtime.InteropServices;

namespace Interaktiivne_töölaud
{
    public partial class Form1 : Form
    {
        bool day = false;
        bool colon = true;
        bool canclose = false;
        [DllImport("user32")]
        public static extern void LockWorkStation();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.inroom.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!Program.isGuest)
            { 
                this.Hide();
                Program.play.Show();
            } else
            {
                MessageBox.Show("Süsteemiülem on keelanud juurdepääsu mänguväljakule");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Environment.UserName != "Külaline")
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                p.StandardInput.WriteLine("shutdown.exe /l");
                p.StandardInput.Flush();
                p.StandardInput.Close();
                p.WaitForExit();
                Exit();
            }
            else
            {
                if (MessageBox.Show("Sessiooni lõpetamisel logitakse kasutajast välja ning kustutatakse kõik sessiooni jooksul toimunud muudatused. Kas olete kindel, et soovite jätkata?", "Välja logimine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    p.StandardInput.WriteLine("shutdown.exe /l");
                    p.StandardInput.Flush();
                    p.StandardInput.Close();
                    p.WaitForExit();
                    Exit();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\noteopen.log"))
            { 
                System.IO.File.Delete(@"C:\mas\noteopen.txt");
                System.IO.File.WriteAllText(@"C:\mas\closenote.log", "See fail saadab töölauamärkmete rakendusele käskluse sulgeda. Kui te näete seda teksti, palun kustutage see fail.");
            }
            this.Hide();
            if ((DateTime.Now.Hour < 16) && (DateTime.Now.Hour > 8))
            {
                this.BackgroundImage = Properties.Resources.väljast_päev;
                day = true;
            } else
            {
                this.BackgroundImage = Properties.Resources.väljast;
                day = false;
            }
            if ((DateTime.Today.Month > 2) || (DateTime.Today.Month < 12))
            {
                Program.inroom.Show();
            } else
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
            }
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            if (Screen.AllScreens.Length > 1)
            {
                Program.winroom.StartPosition = FormStartPosition.Manual;
                Program.winroom.Location = Screen.AllScreens[1].WorkingArea.Location;
                Program.winroom.Show();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int currentminute = DateTime.Now.Minute;
            string minstring = currentminute.ToString();
            if (currentminute < 10) { minstring = "0" + minstring; }
            if (colon) { label1.Text = DateTime.Now.Hour.ToString() + ":" + minstring; colon = false; }
            else if (!colon) { label1.Text = DateTime.Now.Hour.ToString() + " " + minstring; colon = true; }
            if ((DateTime.Now.Hour < 16) && (DateTime.Now.Hour > 8))
            {
                if (!day)
                {
                    this.BackgroundImage = Properties.Resources.väljast_päev;
                    day = true;
                }
            }
            else
            {
                if (day)
                {
                    this.BackgroundImage = Properties.Resources.väljast;
                    day = false;
                }
            }
            if ((DateTime.Now.Hour < 11) && (DateTime.Now.Hour > 4))
            {
                if (label1.Size != new Size(197, 30))
                {
                    label1.Size = new Size(197, 30);
                }
                label1.Text += " (hommik)";
            }
            else if ((DateTime.Now.Hour < 17) && (DateTime.Now.Hour > 10))
            {
                if (label1.Size != new Size(173, 30))
                {
                    label1.Size = new Size(173, 30);
                }
                label1.Text += " (päev)";
            }
            else if ((DateTime.Now.Hour < 23) && (DateTime.Now.Hour > 16))
            {
                if (label1.Size != new Size(168, 30))
                {
                    label1.Size = new Size(168, 30);
                }
                label1.Text += " (õhtu)";
            }
            else if ((DateTime.Now.Hour < 5) || (DateTime.Now.Hour > 22))
            {
                if (label1.Size != new Size(146, 30))
                {
                    label1.Size = new Size(146, 30);
                }
                label1.Text += " (öö)";
            }
            Program.archiveroom.label1.Text = label1.Text;
            Program.inroom.label1.Text = label1.Text;
            Program.officeroom.label2.Text = label1.Text;
            Program.play.label1.Text = label1.Text;
            Program.winroom.label2.Text = label1.Text;
            if (Program.archiveroom.label1.Size != label1.Size) { Program.archiveroom.label1.Size = label1.Size; }
            if (Program.inroom.label1.Size != label1.Size) { Program.inroom.label1.Size = label1.Size; }
            if (Program.officeroom.label2.Size != label1.Size) { Program.officeroom.label2.Size = label1.Size; }
            if (Program.play.label1.Size != label1.Size) { Program.play.label1.Size = label1.Size; }
            if (Program.winroom.label2.Size != label1.Size) { Program.winroom.label2.Size = label1.Size; }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canclose)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void Exit()
        {
            canclose = true;
            this.Close();
        }


        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }
    }
}
