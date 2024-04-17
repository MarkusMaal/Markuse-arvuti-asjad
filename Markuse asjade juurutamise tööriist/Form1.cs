using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using System.IO;

namespace Markuse_asjade_juurutamise_tööriist
{
    public partial class Form1 : Form
    {

        private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        int rootimg = 1;
        string action = "collect";
        string flashID = ":";
        bool canClose = false;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.Width < 574)
            {
                label1.Visible = false;
                label2.Visible = false;
            }
            if (this.Width < 400)
            {
                pictureBox1.Visible = false;
            }
            System.Media.SoundPlayer plr = new System.Media.SoundPlayer(Properties.Resources.root_bg_begin);
            plr.Play();
        }

        private void rootImageTimer_Tick(object sender, EventArgs e)
        {
            if (rootimg == 1)
            {
                pictureBox2.Image = Properties.Resources.root_root_1;
            }
            else if (rootimg == 2)
            {
                pictureBox2.Image = Properties.Resources.root_root_2;
            }
            else if (rootimg == 3)
            {
                pictureBox2.Image = Properties.Resources.root_root_3;
            }
            else if (rootimg == 4)
            {
                pictureBox2.Image = Properties.Resources.root_root_4;
            }
            else if (rootimg == 5)
            {
                pictureBox2.Image = Properties.Resources.root_root_5;
            }
            else if (rootimg == 6)
            {
                pictureBox2.Image = Properties.Resources.root_root_6;
            }
            else if (rootimg == 7)
            {
                pictureBox2.Image = Properties.Resources.root_root_7;
            }
            else if (rootimg == 8)
            {
                pictureBox2.Image = Properties.Resources.root_root_8;
            }
            else if (rootimg == 9)
            {
                pictureBox2.Image = Properties.Resources.root_root_9;
            }
            else if (rootimg == 10)
            {
                pictureBox2.Image = Properties.Resources.root_root_10;
            }
            else if (rootimg == 11)
            {
                pictureBox2.Image = Properties.Resources.root_root_11;
            }
            else if (rootimg == 12)
            {
                pictureBox2.Image = Properties.Resources.root_root_12;
            }
            rootimg++;
            if (rootimg > 12)
            {
                rootimg = 1;
            }
        }

        private void musicLoop_Tick(object sender, EventArgs e)
        {
            musicLoop.Interval = 54094;
            System.Media.SoundPlayer plr = new System.Media.SoundPlayer(Properties.Resources.root_bg_loop);
            plr.Play();
        }

        private void actionWaitTimer_Tick(object sender, EventArgs e)
        {
            if (action == "collect")
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas"))
                {
                    if (Verifile() == true)
                    {
                        action = "flash";
                        return;
                    }
                    else
                    {
                        actionWaitTimer.Enabled = false;
                        MessageBox.Show("See arvuti ei ole õigesti juurutatud. Selleks, et arvutit juurutada on vaja Markuse arvuti asjad desinstallida. Selleks kustutage kaust " + Environment.GetEnvironmentVariable("HOMEDRIVE") + ":\\mas", "Arvutit ei saa juurutada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        actionWaitTimer.Enabled = true;
                        canClose = true;
                        this.Close();
                    }
                } else
                {
                    action = "flash_r";
                    return;
                }
            }
            else if (action == "flash")
            {
                actionWaitTimer.Enabled = false;
                if (MessageBox.Show("Markuse arvuti asjad on juba paigaldatud. Kas soovite selle asemel luua sõrmejälje Markuse mälupulgale, et juurutada teist arvutit?", "Arvuti on juba juurutatud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    foreach (string letter in letters)
                    {
                        if (letter + ":" != Environment.GetEnvironmentVariable("HOMEDRIVE"))
                        { 
                            if (File.Exists(letter + ":\\E_INFO\\edition.txt"))
                            {
                                flashID = letter + ":";
                            }
                        }
                    }
                    action = "flash_w";
                } else
                {
                    MessageBox.Show("Programm sulgub nüüd.", "Muudatusi ei tehtud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    canClose = true;
                    this.Close();
                }
                actionWaitTimer.Enabled = true;
            }
            else if (action == "flash_r")
            {
                string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                foreach (string letter in letters)
                {
                    if (letter + ":" != Environment.GetEnvironmentVariable("HOMEDRIVE"))
                    {
                        if (File.Exists(letter + ":\\E_INFO\\edition.txt"))
                        {
                            flashID = letter + ":";
                        }
                    }
                }
                action = "decrypt";
                pictureBox2.Image = Properties.Resources.root_idc_key;
                label3.Text = "Andmete dekrüptimine...";
            }
            else if (action == "flash_w")
            {
                if (!Directory.Exists(flashID + "\\E_INFO\\ROOT_INF"))
                {
                    Directory.CreateDirectory(flashID + "\\E_INFO\\ROOT_INF");
                } else
                {
                    actionWaitTimer.Enabled = false;
                    if (MessageBox.Show("Sõrmejälg on juba eelnevalt loodud. Kas soovite selle üle kirjutada?", "Markuse asjade juurutamise tööriist", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    { 
                        Directory.Delete(flashID + "\\E_INFO\\ROOT_INF", true);
                        Directory.CreateDirectory(flashID + "\\E_INFO\\ROOT_INF");
                    } else
                    {
                        MessageBox.Show("Juurutamise tööriist sulgub, kuna tegum nurjus. P: Sõrmejälge ei saa luua", "Markuse asjade juurutamise tööriist peab sulguma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canClose = true;
                        this.Close();
                    }
                    MessageBox.Show(GetSerialFromDrive(flashID));
                    action = "end";
                    actionWaitTimer.Enabled = true;
                }
            }
        }

        //hangi seerianumber
        public static string GetSerialFromDrive(string letter)
        {
            try
            {
                using (var partitions = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + letter +
                    "'} WHERE ResultClass=Win32_DiskPartition"))
                {
                    foreach (var partition in partitions.Get())
                    {
                        using (var drives = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                                partition["DeviceID"] +
                                "'} WHERE ResultClass=Win32_DiskDrive"))
                        {
                            foreach (var drive in drives.Get())
                            {
                                return (string)drive["SerialNumber"];
                            }
                        }
                    }
                }
            }
            catch
            {
                return "<error>";
            }
            return "<unknown>";
        }

        static void WriteFile()
        {
            string verificatable = q();
            string[] sar = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt").ToString().Split('\n');
            string ns = "";
            for (int i = 0; i < sar.Length - 1; i++)
            {
                ns += sar[i].ToString() + "\n";
            }
            System.IO.File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\edition.txt", ns + verificatable, Encoding.ASCII);

        }
        static bool Verifile()
        {
            string verificatable = q();
            string[] savedstr = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt").ToString().Split('\n');
            string sttr = savedstr[savedstr.Length - 1];
            if (verificatable == sttr)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string q()
        {
            string gg = "CPI" + ff();
            string pp = j(y(System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt")));

            return (h(pp + j(gg.Substring(1, gg.Length - 2) + gg.Substring(0, 1) + gg.Substring(gg.Length - 1, 1))).ToLower() + j(uu()).ToLower() + j(b)).ToLower();
        }

        static string y(string s)
        {
            string[] sar = s.Split('\n');
            string ns = "";
            for (int i = 0; i < sar.Length - 3; i++)
            {
                ns += sar[i].ToString() + "\n";
            }
            return ns;
        }
        static string uu()
        {
            using (ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))

            using (ManagementObjectCollection moc = o.Get())

            {

                StringBuilder t = new StringBuilder();
                foreach (ManagementObject mo in moc)

                {

                    string[] BIOSVersions = (string[])mo["BIOSVersion"];
                    foreach (string version in BIOSVersions)
                    {
                        t.AppendLine(string.Format("{0}", version));
                    }

                }
                return t.ToString().Split('\n')[0].ToString();
            }
        }

        public static string ff()
        {
            string l = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (l == "")
                {
                    l = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return l;
        }
        public static string j(string z)
        {
            SHA1 cx = SHA1.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        public static string h(string z)
        {
            MD5 cx = MD5.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        static public string b
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in aa.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        private void checkEnable_Tick(object sender, EventArgs e)
        {
            if (actionWaitTimer.Enabled == false)
            {
                pictureBox2.Visible = false;
                label3.Visible = false;
            } else
            {
                pictureBox2.Visible = true;
                label3.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose == false)
            {
                e.Cancel = true;
            } else if (canClose == true)
            {
                e.Cancel = false;
            }
        }
    }
}
