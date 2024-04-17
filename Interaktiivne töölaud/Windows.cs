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
    public partial class Windows : Form
    {
        bool canclose = false;
        int selindex = 0;
        private const int SW_HIDE = 0;
        private const int SW_RESTORE = 9;
        private int hWnd;

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        public Windows()
        {
            InitializeComponent();
        }

        private void Windows_Load(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("Rainmeter"))
                {
                    p.Kill();
                }
            }
            if (Screen.AllScreens.Length > 1)
            {
                button5.Visible = false;
                button11.Visible = true;
            }
            if ((DateTime.Today.Month > 2) || (DateTime.Today.Month < 12))
            {
                this.BackgroundImage = Properties.Resources.aken2;
            }
            listView1.View = View.Details;
            comboBox1.SelectedIndex = 2;
            if (Program.isGuest)
            {
                button8.Text = "Windowsi liides";
                button9.Text = "Lõpeta sessioon";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.inroom.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Protsessid tegumiribal
            listView1.Items.Clear();
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (process.MainWindowTitle.ToString() != "")
                {
                    string s = "";
                    if (process.Responding == true)
                    {
                        s = "Töötab";
                    }
                    else
                    {
                        s = "Ei reageeri";
                    }
                    //listBox1.Items.AddRange(new object[] {process.MainWindowTitle + ", " + process.WorkingSet64.ToString()});
                    listView1.Items.Add(new ListViewItem(new string[] { process.MainWindowTitle, s, process.ProcessName + ".exe" }));
                }
            }
            try
            {
                listView1.Items[selindex].Focused = true;
                listView1.Items[selindex].Selected = true;
            }
            catch
            {
                selindex -= 1;
                if (selindex < 0) { selindex = 0; }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string prname = listView1.Items[selindex].SubItems[2].ToString();
            prname = prname.Replace("ListViewSubItem", "");
            prname = prname.Replace(":", "");
            prname = prname.Replace(" ", "");
            prname = prname.Replace("}", "");
            prname = prname.Replace("{", "");
            prname = prname.Replace(".exe", "");
            Process[] p = Process.GetProcessesByName(prname);
            hWnd = (int)p[0].MainWindowHandle;
            
            ShowWindow(hWnd, 9);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selindex = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lvp = listView1.Items[selindex].SubItems[2].ToString();
            lvp = lvp.Replace("ListViewSubItem", "");
            lvp = lvp.Replace(":", "");
            lvp = lvp.Replace(" ", "");
            lvp = lvp.Replace("}", "");
            lvp = lvp.Replace("{", "");
            lvp = lvp.Replace(".exe", "");
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == lvp)
                {
                    p.CloseMainWindow();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lvp = listView1.Items[selindex].SubItems[2].ToString();
            lvp = lvp.Replace("ListViewSubItem", "");
            lvp = lvp.Replace(":", "");
            lvp = lvp.Replace(" ", "");
            lvp = lvp.Replace("}", "");
            lvp = lvp.Replace("{", "");
            lvp = lvp.Replace(".exe", "");
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == lvp)
                {
                    p.Kill();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.StandardInput.WriteLine("shutdown.exe /s");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.WaitForExit();
            Exit();
            Program.firstform.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.StandardInput.WriteLine("shutdown.exe /r");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.WaitForExit();
            Exit();
            Program.firstform.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!Program.isGuest)
            { 
                Process p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\redoexp.cmd";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                Program.firstform.Close();
                Exit();
            }
             else
            {
                if (MessageBox.Show("Windowsi kasutajaliides ei ole väga stabiilne. Kas olete kindel, et soovite jätkata?", "Windowsi liidese taastamine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\redoexp.cmd";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    Program.firstform.Close();
                    Exit();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Program.isGuest)
            {
                if (MessageBox.Show("Sessiooni lõpetamisel logitakse teie kontost välja ja kõik muudetud sätted või failid kasutaja kaustas kustutatakse. Kas olete kindel, et soovite jätkata?", "Windowsi liidese taastamine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "shutdown";
                    p.StartInfo.Arguments = "/l";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    Program.firstform.Close();
                    Exit();
                }
            } else { 
                Process.Start("C:\\mas\\Markuse asjad\\Interaktiivne töölaud.exe");
                Program.firstform.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                timer1.Interval = 100;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                timer1.Interval = 500;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                timer1.Interval = 1000;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                timer1.Interval = 2000;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                timer1.Interval = 5000;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("^%{TAB}");
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.desktopLevel.Enabled = false;
            Run r = new Run();
            DialogResult dr = r.ShowDialog();
            this.desktopLevel.Enabled = true;
            if (dr == DialogResult.OK)
            {
                try
                { 
                    Process.Start(r.textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Viga programmi käivitamisel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dr == DialogResult.No)
            {
                Program.officeroom.Show();
                this.Hide();
            }
        }

        private void Windows_FormClosing(object sender, FormClosingEventArgs e)
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

        void Exit()
        {
            canclose = true;
            this.Close();
        }

        private void PerformanceSet_Tick(object sender, EventArgs e)
        {
            bool isnetwork = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            bool isinternet = false;
            if (isnetwork)
            {
                try
                {
                    System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                    isinternet = true;
                }
                catch
                {
                    isinternet = false;
                }
            }
            if (isnetwork == false)
            {
                NetworkImage.BackColor = Color.Red;
            }
            else if (isnetwork == true)
            {
                if (isinternet == true)
                {
                    NetworkImage.BackColor = Color.Lime;
                }
                else if (isinternet == false)
                {
                    NetworkImage.BackColor = Color.Yellow;
                }
            }
            int cp1 = Convert.ToInt32(cpu1.NextValue());
            int cp2 = Convert.ToInt32(cpu2.NextValue());
            int cp3 = Convert.ToInt32(cpu3.NextValue());
            int cp4 = Convert.ToInt32(cpu4.NextValue());
            int cp5 = Convert.ToInt32(cpu5.NextValue());
            int cp6 = Convert.ToInt32(cpu6.NextValue());
            int ram0 = Convert.ToInt32((ramUsuage.NextValue() / (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory * 1024 * 1024)) * 100);
            int disk0 = Convert.ToInt32(diskUsage.NextValue());
            if (cp1 < 50) { Cpu1Image.BackColor = Color.Lime; }
            if ((cp1 >= 50) && (cp1 <= 75)) { Cpu1Image.BackColor = Color.Yellow; }
            if (cp1 > 75) { Cpu1Image.BackColor = Color.Red; }

            if (cp2 < 50) { Cpu2Image.BackColor = Color.Lime; }
            if ((cp2 >= 50) && (cp2 <= 75)) { Cpu2Image.BackColor = Color.Yellow; }
            if (cp2 > 75) { Cpu2Image.BackColor = Color.Red; }

            if (cp3 < 50) { Cpu3Image.BackColor = Color.Lime; }
            if ((cp3 >= 50) && (cp3 <= 75)) { Cpu3Image.BackColor = Color.Yellow; }
            if (cp3 > 75) { Cpu3Image.BackColor = Color.Red; }

            if (cp4 < 50) { Cpu4Image.BackColor = Color.Lime; }
            if ((cp4 >= 50) && (cp4 <= 75)) { Cpu4Image.BackColor = Color.Yellow; }
            if (cp4 > 75) { Cpu4Image.BackColor = Color.Red; }

            if (cp5 < 50) { Cpu5Image.BackColor = Color.Lime; }
            if ((cp5 >= 50) && (cp5 <= 75)) { Cpu5Image.BackColor = Color.Yellow; }
            if (cp5 > 75) { Cpu5Image.BackColor = Color.Red; }

            if (cp6 < 50) { Cpu6Image.BackColor = Color.Lime; }
            if ((cp6 >= 50) && (cp6 <= 75)) { Cpu6Image.BackColor = Color.Yellow; }
            if (cp6 > 75) { Cpu6Image.BackColor = Color.Red; }

            if (ram0 < 50) { RamImage.BackColor = Color.Lime; }
            if ((ram0 >= 50) && (ram0 <= 75)) { RamImage.BackColor = Color.Yellow; }
            if (ram0 > 75) { RamImage.BackColor = Color.Red; }

            if (disk0 < 50) { HDDImage.BackColor = Color.Lime; }
            if ((disk0 >= 50) && (disk0 <= 75)) { HDDImage.BackColor = Color.Yellow; }
            if (disk0 > 75) { HDDImage.BackColor = Color.Red; }
        }

        private void NetworkImage_MouseMove(object sender, MouseEventArgs e)
        {
            specialToolTip.ToolTipTitle = "Võrgu olek";
        }

        private void HDDImage_MouseMove(object sender, MouseEventArgs e)
        {
            specialToolTip.ToolTipTitle = "Kõvaketta olek";
        }

        private void RamImage_MouseMove(object sender, MouseEventArgs e)
        {
            specialToolTip.ToolTipTitle = "Mälu olek";
        }

        private void Cpu1Image_MouseMove(object sender, MouseEventArgs e)
        {
            specialToolTip.ToolTipTitle = "Tuuma olek";
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Peida ruumid")
            {
                button11.Text = "Taasta ruumid";
                if (Program.firstform.Visible)
                {
                    Program.firstform.Hide();
                    InfoTip.SetToolTip(button11, "Toob ruumi \"Välisuks\" tagasi teisele kuvarile");
                }
                else if (Program.archiveroom.Visible)
                {
                    Program.archiveroom.Hide();
                    InfoTip.SetToolTip(button11, "Toob ruumi \"Arhiiv\" tagasi teisele kuvarile");
                }
                else if (Program.inroom.Visible)
                {
                    Program.inroom.Hide();
                    InfoTip.SetToolTip(button11, "Toob ruumi \"Elutuba\" tagasi teisele kuvarile");
                }
                else if (Program.officeroom.Visible)
                {
                    Program.officeroom.Hide();
                    InfoTip.SetToolTip(button11, "Toob ruumi \"Töölaud\" tagasi teisele kuvarile");
                }
                else if (Program.play.Visible)
                {
                    Program.play.Hide();
                    InfoTip.SetToolTip(button11, "Toob ruumi \"Mänguväljak\" tagasi teisele kuvarile");
                }
            }
            else
            {
                button11.Text = "Peida ruumid";
                if (InfoTip.GetToolTip(button11).Contains("Välisuks"))
                {
                    Program.firstform.Show();
                }
                else if (InfoTip.GetToolTip(button11).Contains("Arhiiv"))
                {
                    Program.archiveroom.Show();
                }
                else if (InfoTip.GetToolTip(button11).Contains("Elutuba"))
                {
                    Program.inroom.Show();
                }
                else if (InfoTip.GetToolTip(button11).Contains("Töölaud"))
                {
                    Program.officeroom.Show();
                }
                else if (InfoTip.GetToolTip(button11).Contains("Mänguväljak"))
                {
                    Program.play.Show();
                }
                InfoTip.SetToolTip(button11, "Peidab teisel kuvaril olevad ruumid ning jätab alles ainult selle akna,\nSee funktsioon on saadaval kui on ühendatud vähemalt kaks kuvarit.");
            }
        }
    }
}
