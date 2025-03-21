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
using Microsoft.Win32;
using System.Net;
using System.Globalization;
using System.Diagnostics;

namespace Markuse_asjade_juurutamise_tööriist
{
    public partial class Form1 : Form
    {

        private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        int rootimg = 1;
        string action = "collect";
        string flashID = ":";
        string cdrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
        string[] E_INFO;
        protected string mep = "https://markusmaal.ee/mas_db/api.php";
        bool canClose = false;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey wineKey = Registry.LocalMachine.OpenSubKey(@"Software\Wine", false);
            if (wineKey != null)
            {
                musicLoop.Enabled = false;
                actionWaitTimer.Enabled = false;
                MessageBox.Show("Markuse arvuti asjade juurutamistarkvara ei käivitu Wine all. Palun käivitage see programm Windows-is.");
                canClose = true;
                this.Close();
                return;
            }
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\verifile2.dat"))
            {
                musicLoop.Enabled = false;
                actionWaitTimer.Enabled = false;
                if (MessageBox.Show("See arvuti on juba juurutatud Verifile 2.0 räsiga. See programm ei ole võimeline neid räsisid genereerima. Enne kui jätkate, avage Verifile 2.0 käivitades käsureal:\n\njava -jar \"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\verifile.jar\" -w\n\nSeejärel vajutage \"Jah\", et jätkata. Vajutage \"Ei\", et toiming katkestada. Pärast programmi sulgemist, looge uus fail nimega \"vf2.done\" Markuse asjade juurkausta, et Verifile 2.0 uuesti sulgeda.", "Tähelepanu!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    canClose = true;
                    this.Close();
                    return;
                }
                actionWaitTimer.Enabled = true;
                musicLoop.Enabled = true;
            }

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
            else if (action == "decrypt")
            {
                pictureBox2.Image = null;
                label3.Text = "";
                if (!File.Exists(flashID + "\\E_INFO\\ROOT_INF\\verify.dat"))
                {
                    string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    foreach (string letter in letters)
                    {
                        if (letter + ":" != Environment.GetEnvironmentVariable("HOMEDRIVE"))
                        {
                            if (File.Exists(letter + ":\\E_INFO\\ROOT_INF\\verify.dat"))
                            {
                                flashID = letter + ":";
                            }
                        }
                    }
                }
                if (File.Exists(flashID + "\\E_INFO\\edition.cmd")) {
                    string pass_phrase = File.ReadAllText(flashID + "\\E_INFO\\edition.cmd").ToLower();
                    string flash_serial = GetSerialFromDrive(flashID);
                    string verifyData = File.ReadAllText(flashID + "\\E_INFO\\ROOT_INF\\verify.dat", Encoding.BigEndianUnicode);
                    actionWaitTimer.Enabled = false;
                    string claimed_serial = StringCipher.Decrypt(verifyData, pass_phrase);
                    if (claimed_serial != flash_serial)
                    {
                        MessageBox.Show("Sõrmejälg on vale. Võimalik, et kopeerisite verify.dat faili ühelt mälupulgalt teisele ning ei uuendanud sõrmejälge. Programm sulgub nüüd.\n\n" + claimed_serial + " != " + flash_serial, "Markuse asjade juurutamise tööriist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canClose = true;
                        this.Close();
                    }
                } else
                {
                    actionWaitTimer.Enabled = false;
                    MessageBox.Show("Sõrmejäljega Markuse mälupulka ei leitud. Programm sulgub nüüd.", "Markuse asjade juurutamise tööriist peab sulguma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    canClose = true;
                    this.Close();
                }
                actionWaitTimer.Enabled = false;
                label5.Text = "Etapp 2: Juurutamine";
                this.Hide();
                Setup setup = new Setup();
                if (setup.ShowDialog() == DialogResult.OK)
                {
                    label4.Visible = true;
                    this.label1.Text = setup.stuffLabel.Text;
                    if (!Directory.Exists(cdrive + @"\mas"))
                    {
                        Directory.CreateDirectory(cdrive + @"\mas");
                    }
                    string latest_edition = "";
                    string edition = setup.basicPlusRadioButton.Checked ? "Basic+" : "Pro";
                    using (WebClient client = new WebClient())
                    {
                        latest_edition = client.DownloadString(mep + "?latest_version&edition_info");
                    }
                    dynamic latest_version = System.Web.Helpers.Json.Decode(latest_edition);
                    CultureInfo ci = CultureInfo.InstalledUICulture;
                    E_INFO = new string[12] {
                        "[Edition_info]",
                        edition,
                        latest_version.VERSION,
                        latest_version.BUILD + (setup.vpc ? "b" : "a"),
                        "Yes",
                        Environment.UserName,
                        ci.Name,
                        Environment.OSVersion.Version.Major + "." + Environment.OSVersion.Version.Minor,
                        ((edition == "Pro") ? "IP-" : "") + (setup.TSCheck.Checked ? "IT-" : "") + (setup.WXCheck.Checked ? "WX-" : "") + (setup.RMCheck.Checked ? "RM-" : "") +
                        (setup.CSCheck.Checked ? "CS-" : "") + (setup.RDCheck.Checked ? "RD-" : "") + (setup.LTCheck.Checked ? "LT-" : "") + (setup.LTCheck.Checked ? "GP-" : "") +
                        "TS-MM",
                        latest_version.PIN,
                        latest_version.NAME,
                        "",
                    };
                    rootImageTimer.Enabled = true;
                    label3.Visible = true;
                    pictureBox2.Visible = true;
                    label3.Text = "Palun oota...";
                    this.Show();
                    action = "root";
                    actionWaitTimer.Enabled = true;
                }
                else
                {
                    canClose = true;
                    this.Close();
                }
            }
            else if (action == "root")
            {
                actionWaitTimer.Enabled = false;
                File.WriteAllText(cdrive + @"\mas\edition.txt", string.Join("\n", E_INFO));
                File.WriteAllText(cdrive + @"\mas\edition_1.txt", string.Join(";", E_INFO));
                File.WriteAllText(cdrive + @"\mas\mas.cnf", "true;false;false;");
                actionWaitTimer.Enabled = true;
                action = "root2";
            }
            else if (action == "root2")
            {
                actionWaitTimer.Enabled = false;
                WriteFile();
                actionWaitTimer.Enabled = true;
                action = "dloadapps";
            } else if (action == "dloadapps")
            {
                actionWaitTimer.Enabled = false;
                Directory.CreateDirectory(cdrive + @"\mas\Markuse asjad");

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(mep + "?dload=JTR.exe", cdrive + @"\mas\Markuse asjad\JTR.exe");
                    client.DownloadFile(mep + "?dload=FlashUnlock.exe", cdrive + @"\mas\Markuse asjad\FlashUnlock.exe");
                    File.Copy(cdrive + @"\mas\Markuse asjad\FlashUnlock.exe", cdrive + @"\mas\FlashUnlock.exe");
                    client.DownloadFile(mep + "?dload=Markuse arvuti juhtpaneel.exe", cdrive + @"\mas\Markuse asjad\Markuse arvuti juhtpaneel.exe");
                }
                action = "organize_data";
                actionWaitTimer.Enabled = true;
            }
            else if (action == "organize_data")
            {
                actionWaitTimer.Enabled = false;
                File.Copy(cdrive + @"\mas\Markuse asjad\Markuse arvuti juhtpaneel.exe", cdrive + @"\mas\Markuse asjad\cpanel.exe");
                using (WebClient client = new WebClient())
                {
                    if (E_INFO[1] == "Pro")
                    {
                        client.DownloadFile(mep + "?dload=TöölauaMärkmed.exe", cdrive + @"\mas\Markuse asjad\TöölauaMärkmed.exe");
                        Directory.CreateDirectory(cdrive + @"\mas\notes");
                        File.WriteAllText(cdrive + @"\mas\notes\note_1_y.txt", "");
                        File.WriteAllText(cdrive + @"\mas\notes\.setting_note_1.meta", "0;0;195;163;");
                        File.WriteAllBytes(cdrive + @"\mas\MarkuStation.exe", Properties.Resources.MarkuStation);
                        File.WriteAllText(cdrive + @"\mas\ms_display.txt", "extend\r\n");
                        File.WriteAllText(cdrive + @"\mas\ms_exec.txt", "* MarkuStation käivitaja loetelu (ärge eemaldage/lisage semikooloneid)*;\n\n");
                        File.WriteAllText(cdrive + @"\mas\ms_games.txt", "* MarkuStation mängude loetelu *\n\n");
                        File.WriteAllText(cdrive + @"\mas\itstart.bat", Properties.Resources.itstart);
                        File.WriteAllText(cdrive + @"\mas\game_optimize.bat", Properties.Resources.game_optimize);
                        File.WriteAllText(cdrive + @"\mas\game_preoptimize.bat", Properties.Resources.game_preoptimize);
                        File.WriteAllText(cdrive + @"\mas\game_restore.bat", Properties.Resources.game_restore);
                        File.WriteAllText(cdrive + @"\mas\finalize_install.bat", Properties.Resources.finalize_install);
                    }
                }
                File.WriteAllText(cdrive + @"\mas\servicestart.bat", Properties.Resources.servicestart);
                File.WriteAllText(cdrive + @"\mas\startup_optimize.bat", Properties.Resources.startup_optimize);
                File.WriteAllText(cdrive + @"\mas\setting.txt", "true\ntrue\ntrue");
                File.WriteAllText(cdrive + @"\mas\remas.bat", Properties.Resources.remas);
                File.WriteAllText(cdrive + @"\mas\redoexp.cmd", Properties.Resources.redoexp);
                File.WriteAllText(cdrive + @"\mas\settings2.sf", "AutoRun=false");
                File.WriteAllText(cdrive + @"\mas\settings.sf", "NightMode=No;");

                action = "dloadapps2";
                actionWaitTimer.Enabled = true;
            } else if (action == "dloadapps2")
            {
                actionWaitTimer.Enabled = false;
                using (WebClient client = new WebClient())
                {
                    if (E_INFO[1] == "Pro")
                    {
                        client.DownloadFile(mep + "?dload=Markuse arvuti integratsioonitarkvara.exe", cdrive + @"\mas\Markuse asjad\Markuse arvuti integratsioonitarkvara.exe");

                        if (E_INFO[8].Contains("TS"))
                        {
                            client.DownloadFile(mep + "?dload=Interaktiivne töölaud.exe", cdrive + @"\mas\Markuse asjad\Interaktiivne töölaud.exe");
                            File.WriteAllBytes(cdrive + @"\mas\Uue aasta vastuvõtja.exe", Properties.Resources.Uue_aasta_vastuvõtja);
                            Directory.CreateDirectory(cdrive + @"\mas\backgrounds");
                            Directory.CreateDirectory(cdrive + @"\mas\songs");
                        }
                        if (E_INFO[8].Contains("RM"))
                        {
                            File.WriteAllBytes(cdrive + @"\mas\Markuse asjad töölaud_2.0.rmskin", Properties.Resources.Markuse_asjad_töölaud_2_0);
                        }
                    }
                }
                action = "finalize";
                actionWaitTimer.Enabled = true;
            } else if (action == "finalize")
            {
                Bitmap bg_common = Properties.Resources.bg_common;
                Bitmap bg_desktop = Properties.Resources.bg_desktop;
                Bitmap bg_login = Properties.Resources.bg_login ;
                Bitmap bg_uncommon = Properties.Resources.bg_uncommon;
                File.WriteAllBytes(cdrive + @"\mas\update_bg.ps1", Properties.Resources.update_bg);
                File.WriteAllText(cdrive + @"\mas\organize_desktop.bat", Properties.Resources.organize_desktop);
                File.WriteAllText(cdrive + @"\mas\info.bat", Properties.Resources.info);
                bg_common.Save(cdrive + @"\mas\bg_common.png");
                bg_desktop.Save(cdrive + @"\mas\bg_desktop.png");
                bg_login.Save(cdrive + @"\mas\bg_login.png");
                bg_uncommon.Save(cdrive + @"\mas\bg_uncommon.png");
                Directory.CreateDirectory(cdrive + @"\mas\desktop_default");
                Directory.CreateDirectory(cdrive + @"\mas\desktop_default\icons1");
                Directory.CreateDirectory(cdrive + @"\mas\desktop_default\icons2");
                Directory.CreateDirectory(cdrive + @"\mas\Markuse kaustad avaleht");
                File.WriteAllBytes(cdrive + @"\mas\ChangeWallpaper.exe", Properties.Resources.ChangeWallpaper);
                File.WriteAllText(cdrive + @"\mas\accentcolor.txt", "White");
                Process p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = "/k move \"%userprofile%\\Desktop\\*\" \"%HOMEDRIVE%\\mas\\desktop_default\\icons2\" & rd /s /q \"%userprofile%\\Desktop\" & mklink /j \"%USERPROFILE%\\Desktop\" \"%HOMEDRIVE%\\mas\\desktop_default\\icons1\"";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                action = "rootend";
            }
            else if (action == "rootend")
            {
                label5.Text = "Valmis";
                actionWaitTimer.Enabled = false;
                pictureBox2.Visible = false;
                label3.Visible = false;
                rootImageTimer.Enabled = false;
                MessageBox.Show("Arvuti juuurutati edukalt!", "Markuse asjade juurutamise tööriist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                canClose = true;
                this.Close();
            }
            else if (action == "flash_w")
            {
                if (!Directory.Exists(flashID + "\\E_INFO\\ROOT_INF"))
                {
                    if (flashID == ":")
                    {
                        actionWaitTimer.Enabled = false;
                        MessageBox.Show("Ühtegi Markuse mälupulka ei leitud. Programm sulgub nüüd.", "Markuse asjade juurutamise tööriist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canClose = true;
                        this.Close();
                        return;
                    }
                    else
                    {
                        Directory.CreateDirectory(flashID + "\\E_INFO\\ROOT_INF");
                    }
                }
                actionWaitTimer.Enabled = false;
                if (File.Exists(flashID + "\\E_INBFO\\ROOT_INF\\verify.dat"))
                {
                    if (MessageBox.Show("Sõrmejälg on juba eelnevalt loodud. Kas soovite selle üle kirjutada?", "Markuse asjade juurutamise tööriist", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Directory.Delete(flashID + "\\E_INFO\\ROOT_INF", true);
                        Directory.CreateDirectory(flashID + "\\E_INFO\\ROOT_INF");
                    }
                    else
                    {
                        MessageBox.Show("Juurutamise tööriist sulgub, kuna tegum nurjus. P: Sõrmejälge ei saa luua", "Markuse asjade juurutamise tööriist peab sulguma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canClose = true;
                        this.Close();
                        return;
                    }
                }
                string pass_phrase = File.ReadAllText(flashID + "\\E_INFO\\edition.cmd", Encoding.ASCII).ToLower();
                string unique_code = StringCipher.Encrypt(GetSerialFromDrive(flashID), pass_phrase);
                File.WriteAllText(flashID + "\\E_INFO\\ROOT_INF\\verify.dat", unique_code, Encoding.BigEndianUnicode);
                MessageBox.Show("Sõrmejälg loodi edukalt " + flashID + " kettale.", "Markuse asjade juurutamise tööriist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                canClose = true;
                this.Close();
                // action = "end";
                // actionWaitTimer.Enabled = true;
                
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

        // krüpti/dekrüpti
        // https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
        public static class StringCipher
        {
            // This constant is used to determine the keysize of the encryption algorithm in bits.
            // We divide this by 8 within the code below to get the equivalent number of bytes.
            private const int Keysize = 256;

            // This constant determines the number of iterations for the password bytes generation function.
            private const int DerivationIterations = 1445;

            public static string Encrypt(string plainText, string passPhrase)
            {
                // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
                // so that the same Salt and IV values can be used when decrypting.  
                var saltStringBytes = Generate256BitsOfRandomEntropy();
                var ivStringBytes = Generate256BitsOfRandomEntropy();
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.ISO10126;
                        using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                    var cipherTextBytes = saltStringBytes;
                                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                // Get the complete stream of bytes that represent:
                // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.ISO10126;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
                                {
                                    return streamReader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }

            private static byte[] Generate256BitsOfRandomEntropy()
            {
                var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    // Fill the array with cryptographically secure random bytes.
                    rngCsp.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }
    }
}
