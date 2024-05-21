using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Management;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;

namespace Markuse_arvuti_integratsioonitarkvara
{
    public partial class Form1 : Form
    {

        const int SW_HIDE = 0;
        int devint = 0;
        static string letter = "K:";
        bool dev = false;
        string edition = "Pro";
        string version = "0.0";
        string build = "A00000a";
        string name = "Alpha";
        static Random rnd = new Random();
        //juhuslik PIN kood genereeritakse turvalisuse pärast
        string pin = rnd.Next(0, 9).ToString() + rnd.Next(0, 9).ToString() + rnd.Next(0, 9).ToString() + rnd.Next(0, 9).ToString();
        string[] features = { "IT", "TS", "MM" };
        string[] specialevents;
        bool willlaunch = false;
        bool externalAccess = true;
        Thread secthread = new Thread(new ThreadStart(loopyloop));
        Thread cdthread = new Thread(new ThreadStart(cdloop));
        Thread vmthread = new Thread(new ThreadStart(vmloop));

        public Form1()
        {
            InitializeComponent();
        }

        public static void vmloop()
        {
            while (true)
            {
                string finalout = "";
                if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\MAS.COM"))
                {
                    using (var fs = new FileStream(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\MAS.COM", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        finalout = sr.ReadToEnd();
                    }
                }
                if (finalout != "")
                {
                    string[] ss = finalout.Split('\n');
                    if (ss[ss.Length - 2].ToString().StartsWith("ping:"))
                    {
                        Dummy dummywindow = new Dummy();
                        MessageBox.Show(dummywindow, ss[ss.Length - 2].Replace("ping:", "").ToString(), "Sõnum virtuaalarvutilt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (ss[ss.Length - 2].ToString().StartsWith("sync_wallpaper"))
                    {
                        try
                        {
                            File.Copy(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\bg_desktop.png", @"D:\Jagatud\s_1.png");
                            File.Copy(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\bg_login.png", @"D:\Jagatud\s_2.png");
                            File.Copy(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\bg_uncommon.png", @"D:\Jagatud\s_3.png");
                        }
                        catch
                        {

                        }
                    }
                    else if (ss[ss.Length - 2].ToString().StartsWith("get_hostinfo"))
                    {
                        try
                        {
                            File.Copy(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\edition.txt", @"D:\Jagatud\hostinfo");
                        }
                        catch { }
                    }
                }
                else
                {
                    
                }
                Thread.Sleep(1000);
            }
        }

        public static void cdloop()
        {
            while (true)
            {
                foreach (DriveInfo di in DriveInfo.GetDrives())
                {
                    if (di.DriveType == DriveType.CDRom)
                    {
                        if (di.IsReady)
                        {
                            Program.opticalconnect = true;
                            Program.opticalname = di.VolumeLabel;
                        }
                        else
                        {
                            Program.opticalconnect = false;
                        }
                    }
                }
                Thread.Sleep(3000);
            }
        }

        public static void loopyloop()
        {
            while (true)
            {
                bool willlaunch = true;
                string txt = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\settings2.sf");
                string autorun = txt.Split('=')[1].ToString();
                bool ar = false;
                if (autorun == "true")
                {
                    ar = true;
                }
                else if (autorun == "false")
                {
                    ar = false;
                }
                string s = GetLetter();
                if (s != "")
                {
                    if (!Program.flashconnected)
                    {
                        if (willlaunch)
                        {
                            if (ar)
                            {
                                willlaunch = false;
                                if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\running.log"))
                                {
                                    File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\running.log");
                                }
                                string drv;
                                drv = "bad";
                                if (File.Exists("A:\\E_INFO\\edition.txt")) { drv = "A"; }
                                if (File.Exists("B:\\E_INFO\\edition.txt")) { drv = "B"; }
                                if (File.Exists("C:\\E_INFO\\edition.txt")) { drv = "C"; }
                                if (File.Exists("D:\\E_INFO\\edition.txt")) { drv = "D"; }
                                if (File.Exists("E:\\E_INFO\\edition.txt")) { drv = "E"; }
                                if (File.Exists("F:\\E_INFO\\edition.txt")) { drv = "F"; }
                                if (File.Exists("G:\\E_INFO\\edition.txt")) { drv = "G"; }
                                if (File.Exists("H:\\E_INFO\\edition.txt")) { drv = "H"; }
                                if (File.Exists("I:\\E_INFO\\edition.txt")) { drv = "I"; }
                                if (File.Exists("J:\\E_INFO\\edition.txt")) { drv = "J"; }
                                if (File.Exists("K:\\E_INFO\\edition.txt")) { drv = "K"; }
                                if (File.Exists("L:\\E_INFO\\edition.txt")) { drv = "L"; }
                                if (File.Exists("M:\\E_INFO\\edition.txt")) { drv = "M"; }
                                if (File.Exists("N:\\E_INFO\\edition.txt")) { drv = "N"; }
                                if (File.Exists("O:\\E_INFO\\edition.txt")) { drv = "O"; }
                                if (File.Exists("P:\\E_INFO\\edition.txt")) { drv = "P"; }
                                if (File.Exists("Q:\\E_INFO\\edition.txt")) { drv = "Q"; }
                                if (File.Exists("R:\\E_INFO\\edition.txt")) { drv = "R"; }
                                if (File.Exists("S:\\E_INFO\\edition.txt")) { drv = "S"; }
                                if (File.Exists("T:\\E_INFO\\edition.txt")) { drv = "T"; }
                                if (File.Exists("U:\\E_INFO\\edition.txt")) { drv = "U"; }
                                if (File.Exists("V:\\E_INFO\\edition.txt")) { drv = "V"; }
                                if (File.Exists("W:\\E_INFO\\edition.txt")) { drv = "W"; }
                                if (File.Exists("X:\\E_INFO\\edition.txt")) { drv = "X"; }
                                if (File.Exists("Y:\\E_INFO\\edition.txt")) { drv = "Y"; }
                                if (File.Exists("Z:\\E_INFO\\edition.txt")) { drv = "Z"; }
                                if (drv != "bad")
                                {
                                    File.Copy(drv + ":\\Markuse mälupulk\\Markuse mälupulk\\bin\\Debug\\Markuse mälupulk.exe", "C:\\mas\\Mälupulk.exe", true);
                                }
                                else
                                {
                                    MessageBox.Show("Ei saanud kopeerida ajakohast versiooni Markuse mälupulgalt", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                if (File.Exists("C:\\mas\\Mälupulk.exe"))
                                {
                                    Process.Start("C:\\mas\\Mälupulk.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Programmi käivitumine ebaõnnestus.\nPõhjus: Faili ei leitud", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            Program.flashconnected = true;
                        }
                    }
                }
                if (s == "")
                {
                    Program.flashconnected = false;
                    willlaunch = true;
                }
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vmthread.Start();
            if (Program.another == true)
            {
                this.Close();
            }
            if(!Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas"))
            {
                MessageBox.Show("Markuse arvuti asjade integratsiooniprogramm töötab ainult järgnevates Markuse arvuti asjade väljaannetes:\nUltimate, Pro, Premium, Basic+\n\nKui te näete seda veateadet Markuse arvutis, millel on üks nendest väljaannetest, proovige süsteem juurutada, kasutades /root argumenti.\n\nProgramm sulgub nüüd.", "Tegu ei ole juurutatud Markuse arvutiga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Process pr = new Process();
                pr.StartInfo.FileName = "taskkill.exe";
                pr.StartInfo.Arguments = "/f /im \"Markuse arvuti integratsioonitarkvara.exe\"";
                pr.StartInfo.CreateNoWindow = true;
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pr.Start();
                return;
            } else
            {
                if (Verifile() == false)
                {
                    MessageBox.Show("Programm tuvastas, et see arvuti ei ole õigesti juurutatud. Palun juurutage arvuti uuesti Markuse arvuti juurutamistarkvaraga.\nTehniline info: Unikaalne juurutamise ID ei ühti juurutamisfaili ja/või süsteemi riistvara konfiguratsiooniga\nProgramm sulgub nüüd.", "Probleem arvutiga", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close();
                    Process pr = new Process();
                    pr.StartInfo.FileName = "taskkill.exe";
                    pr.StartInfo.Arguments = "/f /im \"Markuse arvuti integratsioonitarkvara.exe\"";
                    pr.StartInfo.CreateNoWindow = true;
                    pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pr.Start();
                    return;
                }
            }
            try
            { 
            if(File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt")) {  }
            } catch
            {
                MessageBox.Show("Markuse arvuti integratsiooniandmed on rikutud. Palun taasjuurutada süsteem kasutades \reroot argumenti", "edition.txt on rikutud!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Viga: edition.txt on rikutud");
                this.Close();
                Process pr = new Process();
                pr.StartInfo.FileName = "taskkill.exe";
                pr.StartInfo.Arguments = "/f /im \"Markuse arvuti integratsioonitarkvara.exe\"";
                pr.StartInfo.CreateNoWindow = true;
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pr.Start();
                return;
            }
            if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\masv"))
            {
                käivitaVirtuaalarvutiToolStripMenuItem.Visible = false;
            }
            if (!Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\masv"))
            {
                sünkroniseeriVersioonToolStripMenuItem.Visible = false;
            }
            lukustaToolStripMenuItem.Visible = File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\Markuse asjad\\Markuse arvuti lukustamissüsteem.exe");
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\noteopen.txt"))
            {
                avaTöölauamärkmedToolStripMenuItem.Text = "Sulge töölauamärkmed";
            }
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\scheme.cfg"))
            {
                LoadTheme();
            }
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\events.txt"))
            {
                string fcont = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\events.txt");
                specialevents = fcont.Split(';');
            }
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\mas.cnf"))
            {
                string[] incontent = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\mas.cnf").Split(';');
                //kas lubada avateade
                Program.showsplash = Convert.ToBoolean(incontent[0].ToString());
                //kas lubada erisündmused
                if (incontent[1].ToString() == "false")
                {
                    specialevents = null;
                }
            }
            if (Program.showsplash == true)
            { 
                if (Program.croot == false) { Program.spl.Show(); }
            }
            else
            {
                CheckFlashTimer.Interval = 10;
            }
            if (Program.croot == false) { this.Hide(); }
            if (Program.croot == true)
            {
                this.WindowState = FormWindowState.Normal;
                TeateIkoon1.Visible = false;
            }
            letter = GetLetter();
            GetEdition(premiumUltimateToolStripMenuItem);
            GetUsers(eemaldaKasutajaToolStripMenuItem);
            GetUsers(avaKasutajaKaustToolStripMenuItem);
            Process p = new Process();
            p.StartInfo.WorkingDirectory = "C:\\mas";
            p.StartInfo.FileName = "C:\\mas\\ChangeWallpaper.exe";
            p.StartInfo.Arguments = "C:\\mas\\bg_desktop.png";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\mas.cfg"))
            {
                string[] attribs = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\mas.cfg").Split(';');
                if (attribs.Length > 2)
                {
                    if (attribs[2] == "true")
                    {
                        avaTöölauamärkmedToolStripMenuItem.Text = "Sulge töölauamärkmed";
                    }
                }
            }
            secthread.Start();
            cdthread.Start();
            käivitaVirtuaalarvutiToolStripMenuItem.Visible = Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\vpc");
            if (File.Exists("C:\\mas\\maia\\server.py"))
            {
                p = new Process();
                p.StartInfo.WorkingDirectory = "C:\\mas\\maia";
                p.StartInfo.FileName = "python.exe";
                p.StartInfo.Arguments = "C:\\mas\\maia\\server.py";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                mAIAServeriHaldamineToolStripMenuItem.Visible = true;
            }
        }

        private static string GetLetter()
        {
            string letter = "";
            if (Directory.Exists("A:\\E_INFO")) { letter = "A:"; }
            if (Directory.Exists("B:\\E_INFO")) { letter = "B:"; }
            if (Directory.Exists("C:\\E_INFO")) { letter = "C:"; }
            if (Directory.Exists("D:\\E_INFO")) { letter = "D:"; }
            if (Directory.Exists("E:\\E_INFO")) { letter = "E:"; }
            if (Directory.Exists("F:\\E_INFO")) { letter = "F:"; }
            if (Directory.Exists("G:\\E_INFO")) { letter = "G:"; }
            if (Directory.Exists("H:\\E_INFO")) { letter = "H:"; }
            if (Directory.Exists("I:\\E_INFO")) { letter = "I:"; }
            if (Directory.Exists("J:\\E_INFO")) { letter = "J:"; }
            if (Directory.Exists("K:\\E_INFO")) { letter = "K:"; }
            if (Directory.Exists("L:\\E_INFO")) { letter = "L:"; }
            if (Directory.Exists("M:\\E_INFO")) { letter = "M:"; }
            if (Directory.Exists("N:\\E_INFO")) { letter = "N:"; }
            if (Directory.Exists("O:\\E_INFO")) { letter = "O:"; }
            if (Directory.Exists("P:\\E_INFO")) { letter = "P:"; }
            if (Directory.Exists("Q:\\E_INFO")) { letter = "Q:"; }
            if (Directory.Exists("R:\\E_INFO")) { letter = "R:"; }
            if (Directory.Exists("S:\\E_INFO")) { letter = "S:"; }
            if (Directory.Exists("T:\\E_INFO")) { letter = "T:"; }
            if (Directory.Exists("U:\\E_INFO")) { letter = "U:"; }
            if (Directory.Exists("V:\\E_INFO")) { letter = "V:"; }
            if (Directory.Exists("W:\\E_INFO")) { letter = "W:"; }
            if (Directory.Exists("X:\\E_INFO")) { letter = "X:"; }
            if (Directory.Exists("Y:\\E_INFO")) { letter = "Y:"; }
            if (Directory.Exists("Z:\\E_INFO")) { letter = "Z:"; }
            return letter;
        }

        private void GetEdition(ToolStripMenuItem ctrl)
        {
            string txt = "";
            if (File.Exists(letter + "\\E_INFO\\edition.txt")) { txt = File.ReadAllText(letter + "\\E_INFO\\edition.txt", Encoding.GetEncoding(1252)); }
            if (txt == "Premium")
            {
                ctrl.Text = "Premium -> Ultimate";
            }
            else if (txt == "Ultimate")
            {
                ctrl.Text = "Premium <- Ultimate";
            }
            else
            {
                ctrl.Visible = false;
            }
        }
        private void GetUsers(ToolStripMenuItem t)
        {
            t.DropDownItems.Clear();
            if (!Directory.Exists(letter + "\\markuse asjad\\markuse asjad"))
            {
                return;
            }
            foreach (DirectoryInfo de in new DirectoryInfo(letter + "\\markuse asjad\\markuse asjad").GetDirectories())
            {
                string a = de.Name.Replace(letter + "\\markuse asjad\\markuse asjad\\", "");
                if (a == "Mine")
                {
                    continue;
                }
                else if (a == "_Template")
                {
                    continue;
                }
                else
                {
                    t.DropDownItems.Add(a, Properties.Resources.folder1);
                }
            }
        }

        private void AvaKasutajaKaustToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string item = e.ClickedItem.ToString();
            if (File.Exists("C:\\mas\\irunning.log"))
            {
                Process p = new Process();
                p.StartInfo.FileName = "explorer.exe";
                p.StartInfo.Arguments = letter + "\\markuse asjad\\markuse asjad\\" + item;
                p.Start();
            }
            else
            {
                File.WriteAllText("C:\\mas\\foldersignal.log", "");
                File.WriteAllText("C:\\mas\\path.txt", letter + "\\markuse asjad\\markuse asjad\\" + item);
            }
        }

        private void eemaldaKasutajaToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (MessageBox.Show("Kas olete kindel, et soovite kustutada kasutaja " + e.ClickedItem.ToString() + " metaandmed ja failid?", "Kasutajakonto kustutamine", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                MessageBox.Show("töötab");
            }
            else
            {
                MessageBox.Show("kasutaja klõpsas ei");
            }
        }

        private void premiumUltimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = letter + "\\E_INFO\\convert.bat";
            p.StartInfo.WorkingDirectory = letter + "\\E_INFO";
            p.StartInfo.Arguments = "--bypassnote";
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }

        private void käivitaUniversaalprogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\running.log"))
            {
                File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\running.log");
            }
            Process p = new Process();
            p.StartInfo.FileName = letter + "\\Markuse mälupulk\\Markuse mälupulk\\bin\\Debug\\Markuse mälupulk.exe";
            p.StartInfo.WorkingDirectory = letter + "\\Markuse mälupulk\\Markuse mälupulk\\bin\\Debug";
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string feats = "IP-";
                NameBox.Text = NameBox.Text.Replace("ä", "2").Replace("õ", "?").Replace("ü", "_y_").Replace("ö", "9");
                if (ITBox.Checked == true) { feats += "IT-"; }
                if (WXBox.Checked == true) { feats += "WX-"; }
                if (GPBox.Checked == true) { feats += "GP-"; }
                if (DXBox.Checked == true) { feats += "RM-"; }
                if (CSBox.Checked == true) { feats += "CS-"; }
                if (RDBox.Checked == true) { feats += "RD-"; }
                if (LTBox.Checked == true) { feats += "LT-"; }
                if (TSMMBox.Checked == true) { feats += "TS-MM"; }
                string rooter = Environment.GetEnvironmentVariable("USERNAME").ToString();
                string win = Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString();
                //if (File.Exists("\\mas\\edition.bak")) { File.Delete("\\mas\\edition.bak"); }
                //File.Move("\\mas\\edition.txt", "\\mas\\edition.bak");
                File.WriteAllText("\\mas\\edition.txt", "[Edition_info]\n" + edition + "\n" + version + "\n" + build + "\nYes\n" + rooter + "\net-EE\n" + win + "\n" + feats + "\n" + pin + "\n" + name + "\n<null>", Encoding.GetEncoding(1252));
                File.WriteAllText("\\mas\\edition_1.txt", "[Edition_info];" + edition + ";" + version + ";" + build + ";Yes;" + rooter + ";et-EE;" + win + ";" + feats + ";" + pin + ";" + name + "\n;[this file is for backwards compatibility with legacy programs]", Encoding.GetEncoding(1252));
                if (Program.croot == false) { MessageBox.Show("Juurutusteave salvestati edukalt. Juurutamise lõpuleviimiseks genereerige juurutamise ID juurutamise tööriistaga.", "Juurutamise protsess õnnestus", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Juurutusteabe salvestamine nurjus\n\n{0}\n\n{1}", ex.Message, ex.StackTrace), "Juurutamise protsess ebaõnnestus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Program.croot) { Close(); }
        }

        private void WriteDesktopINI(string folder, string iconfile, int value, string foldertype)
        {
            string multilinestring = "[.ShellClassInfo]" +
                "\nIconResource=" + iconfile + "," + value.ToString() +
                "\nIconFile=" + iconfile +
                "\nIconIndex=" + value.ToString() +
                "\n[ViewState]" +
                "\nMode=" +
                "\nVid=" +
                "\nFolderType=" + foldertype;
            File.WriteAllText(folder, multilinestring, Encoding.ASCII);
        }

        private void looUusKasutajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionBox.Text = "";
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void avaMarkuseKaustadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            if (!File.Exists("C:\\mas\\irunning.log"))
            { 
                foreach (DriveInfo di in DriveInfo.GetDrives())
                {
                    if (Directory.Exists(di.RootDirectory.Name + "\\.userdata"))
                    {
                        Process.Start(di.RootDirectory.Name + "\\Sisene.lnk");
                    }
                }
            } else
            {
                File.WriteAllText("C:\\mas\\foldersignal.log", "");

                foreach (DriveInfo di in DriveInfo.GetDrives())
                {
                    if (Directory.Exists(di.RootDirectory.Name + "\\.userdata"))
                    {
                        File.WriteAllText("C:\\mas\\path.txt", di.RootDirectory.Name);
                    }
                }
            }
        }

        private void käivitaProjektITSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            if (!File.Exists("C:\\mas\\irunning.log"))
            { 
                Process.Start(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\itstart.bat");
            } else
            {
                Process p = new Process();
                p.StartInfo.FileName = "C:\\mas\\redoexp.cmd";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                File.WriteAllText("C:\\mas\\closing.log", "");
                if (File.Exists(@"C:\mas\noteopen.txt"))
                {
                    File.Delete(@"C:\mas\noteopen.txt");
                    File.WriteAllText(@"C:\mas\closenote.log", "See fail saadab töölauamärkmete rakendusele käskluse sulgeda. Kui te näete seda teksti, palun kustutage see fail.");
                    avaTöölauamärkmedToolStripMenuItem.Text = "Ava töölauamärkmed";
                }
            }
        }

        private void teaveMarkuseAsjadeKohtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            Process.Start(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\Markuse asjad\\Markuse arvuti juhtpaneel.exe");
        }

        private void looSüsteemiTaastepunktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas soovite luua käsitsi taastepunkti tänasele kuupäevale? Enne alustamist oleks soovitatav sulgeda kõik muud rakendused.", "Taastepunkti loomine", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Process p = new Process();
                p.StartInfo.FileName = "POWERSHELL.EXE";
                p.StartInfo.Arguments = "-ExecutionPolicy Bypass -Command \"Checkpoint - Computer - Description \\\"Käsitsi seatud taastepunkt\\\" -RestorePointType \\\"MODIFY_SETTINGS\\\"\"";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32";
                p.Start();
            }
            else
            {
                MessageBox.Show("Muudatusi ei tehtud", "Taastepunkti loomine katkestati kasutaja poolt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void kuvaKõikTöölauaikoonidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kuvaKõikTöölauaikoonidToolStripMenuItem.Text == "Kuva kõik töölauaikoonid")
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Peida need töölaua&ikoonid";
            }
            else
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Kuva kõik töölaua&ikoonid";
            }
            Process p = new Process();
            p.StartInfo.FileName = "C:\\mas\\organize_desktop.bat";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        private bool IconType() { return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString() + "\\Desktop\\Peida need töölauaikoonid.lnk"); }

        private void TeateIkoon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IconType())
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Peida need töölauaikoonid";
            }
            else if (!IconType())
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Kuva kõik töölauaikoonid";
            }
        }

        private void TeateIkoon1_Click(object sender, EventArgs e)
        {
            if (IconType())
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Peida need töölauaikoonid";
            }
            else if (!IconType())
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Text = "Kuva kõik töölauaikoonid";
            }
            if (dev == true)
            {
                juurutaSeeArvutiToolStripMenuItem.Visible = true;
            }
            else
            {
                juurutaSeeArvutiToolStripMenuItem.Visible = false;
            }
        }

        private void CheckFlashTimer_Tick(object sender, EventArgs e)
        {
            if (CheckFlashTimer.Interval == 10)
            {
                CheckFlashTimer.Interval = 5000;
            }

            // Kontrolli sekundaartuumade staatust
            if (Program.flashconnected)
            {
                markuseMälupulkToolStripMenuItem.Enabled = true;
                markuseMälupulkToolStripMenuItem.Text = "Markuse &mälupulk";
            }
            else
            {
                markuseMälupulkToolStripMenuItem.Enabled = false;
                markuseMälupulkToolStripMenuItem.Text = "Markuse &mälupulka pole sisestatud";
            }

            if (Program.opticalconnect)
            {
                avaOptilineAndmekandjaToolStripMenuItem.Visible = true;
                avaOptilineAndmekandjaToolStripMenuItem.Text = "Optiline andmekandja: " + Program.opticalname;
            }
            else
            {
                avaOptilineAndmekandjaToolStripMenuItem.Visible = false;
            }

            // Kontrolli kas kõik töölauaikoonid on nähtavad
            if (!File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\irunning.log"))
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.Visible = Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\desktop_default");
            }

            if (File.Exists(@"D:\Jagatud\close_vm.log"))
            {
                EndVM evm = new EndVM();
                evm.BackColor = avaMarkuseKaustadToolStripMenuItem.BackColor;
                evm.ForeColor = avaMarkuseKaustadToolStripMenuItem.ForeColor;
                evm.ShowDialog();
                evm.Dispose();
                if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\MAS.COM")) { File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\MAS.COM"); }
                if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\WINDOWS.COM")) { File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\WINDOWS.COM"); }
            }
            // Kontrolli funktsioonide olemasolu programmi käivitamisel
            if (CheckFlashTimer.Interval == 5000)
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("USERPROFILE").ToString() + "\\markuse kaustad"))
                {
                    avaMarkuseKaustadToolStripMenuItem.Visible = true;
                }
                else
                {
                    avaMarkuseKaustadToolStripMenuItem.Visible = false;
                }

                if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\Markuse asjad\\Interaktiivne töölaud"))
                {
                    käivitaProjektITSToolStripMenuItem.Visible = true;
                }
                else
                {
                    käivitaProjektITSToolStripMenuItem.Visible = false;
                }
                if (!File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\MarkuStation.exe"))
                {
                    käivitaMarkuStationToolStripMenuItem.Visible = false;
                }
                else if (!File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\MarkuStation.exe"))
                {
                    if (!Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\masv"))
                    {
                        käivitaMarkuStationToolStripMenuItem.Visible = true;
                    }
                }
            }
            TeateIkoon1.Visible = true;
            Program.spl.Close();
            //erisündmused
            try
            {
                if ((specialevents != null) && (specialevents.Length > 0))
                {
                    //käi läbi erisündmuste massiivist
                    foreach (string element in specialevents)
                    {
                        //loo alamelemendid
                        string[] subelements = element.Split('-');
                        //loo kp elemendid
                        string[] dateelements = { subelements[0].ToString(), subelements[1].ToString(), subelements[2].ToString() };
                        //kui kp pole sama, siis ignoreeri
                        if (!(dateelements[0].ToString() == DateTime.Today.Day.ToString() && dateelements[0].ToString() == DateTime.Today.Month.ToString() && dateelements[2].ToString() == DateTime.Today.Year.ToString()))
                        {
                            continue;
                        }
                        //loo kellaaja elemendid
                        string[] timestamp = { subelements[3].ToString(), subelements[4].ToString(), subelements[5].ToString() };
                        //kui kellaaeg varasem, siis ignoreeri
                        if (!(Convert.ToInt32(timestamp[0].ToString()) >= DateTime.Now.Hour && Convert.ToInt32(timestamp[1].ToString()) >= DateTime.Now.Minute && Convert.ToInt32(timestamp[2].ToString()) >= DateTime.Now.Second))
                        {
                            continue;
                        }
                        //leia failinimi
                        string file = subelements[6].ToString();
                        //leia binraarne muutuja
                        bool willclose = Convert.ToBoolean(subelements[7].ToString());
                        //loo protsess
                        Process p = new Process();
                        p.StartInfo.FileName = file;
                        p.StartInfo.Arguments = subelements[8].ToString();
                        p.Start();
                        //sulge programm kui willclose on tõene
                        if (willclose)
                        {
                            Program.croot = true;
                            this.Close();
                        }
                        //eemalda elemendid specialevent massiivist
                        specialevents = null;
                    }
                }
            }
            catch { }
            if (File.Exists("C:\\mas\\runfile.log"))
            {
                List<string> s = new List<string>();
                using (FileStream fs = new FileStream("C:\\mas\\runfile.log",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (sr.Peek() >= 0) // reading the old data
                        {
                            s.Add(sr.ReadLine());
                        }
                    }
                }
                File.Delete("C:\\mas\\runfile.log");
                Process p = new Process();
                p.StartInfo.FileName = s[0];
                if (s.Count > 1) { p.StartInfo.Arguments = s[1]; }
                if (s.Count > 2) { p.StartInfo.WorkingDirectory = s[2]; }
                if (s.Count > 3)
                {
                    if (s[3] == "hidden")
                    {
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    else if (s[3] == "maximized")
                    {
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    }
                    else if (s[3] == "minimized")
                    {
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    }
                    else
                    {
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    }
                }
                p.Start();
            }
        }

        private void DevTimer_Tick(object sender, EventArgs e)
        {
            devint++;
            if (devint == 70)
            {
                System.Media.SystemSounds.Exclamation.Play();
                TaskMenu1.Close();
                if (dev == true)
                {
                    dev = false;
                    return;
                }
                dev = true;
            }
        }

        private void markuseMälupulkToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            //DevTimer.Enabled = true;
        }

        private void markuseMälupulkToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            //DevTimer.Enabled = false;
            //devint = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible == true)
            {
                if (Program.croot == true) { e.Cancel = false; }
                if (Program.croot == false) { 
                    this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            s = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252));
            string[] attribs = s.Split('\n');
            edition = attribs[1].ToString();
            version = attribs[2].ToString();
            build = attribs[3].ToString();
            pin = attribs[9].ToString();
            features = attribs[8].Split('-');
            name = attribs[10].ToString();
            Reloadvalues();
        }

        private void Reloadvalues()
        {
            string s;
            s = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252));
            string[] attribs = s.Split('\n');
            edition = attribs[1].ToString();
            version = attribs[2].ToString();
            build = attribs[3].ToString();
            pin = attribs[9].ToString();
            features = attribs[8].Split('-');
            name = attribs[10].ToString();
            if (edition == "Pro")
            {
                EditionBox.SelectedIndex = 1;
            }
            else if (edition == "Ultimate")
            {
                EditionBox.SelectedIndex = 0;
            }
            else if (edition == "Premium")
            {
                EditionBox.SelectedIndex = 2;
            }
            else
            {
                EditionBox.SelectedIndex = 3;
            }
            VersionBox.Text = version;
            BuildBox.Text = build;
            NameBox.Text = name;
            label11.Text = "PIN kood: " + pin + " (automaatne väli)";
            label7.Text = "Juurutaja: " + Environment.GetEnvironmentVariable("USERNAME").ToString() + " (automaatne väli)";
            label9.Text = "Windowsi versioon: " + Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString() + " (automaatne väli)";
            DXBox.Checked = false;
            ITBox.Checked = false;
            WXBox.Checked = false;
            GPBox.Checked = false;
            CSBox.Checked = false;
            RDBox.Checked = false;
            LTBox.Checked = false;
            foreach (string element in features)
            {
                if (element == "DX")
                {
                    DXBox.Checked = true;
                }
                else if (element == "IT")
                {
                    ITBox.Checked = true;
                }
                else if (element == "WX")
                {
                    WXBox.Checked = true;
                }
                else if (element == "GP")
                {
                    GPBox.Checked = true;
                }
                else if (element == "CS")
                {
                    CSBox.Checked = true;
                }
                else if (element == "RD")
                {
                    RDBox.Checked = true;
                }
                else if (element == "LT")
                {
                    LTBox.Checked = true;
                }
            }

        }

        private void juurutaSeeArvutiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reloadvalues();
            this.Visible = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void VersionBox_TextChanged(object sender, EventArgs e)
        {
            version = VersionBox.Text;
        }

        private void BuildBox_TextChanged(object sender, EventArgs e)
        {
            build = BuildBox.Text;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            name = NameBox.Text;
        }

        private void RightClickTimer_Tick(object sender, EventArgs e)
        {
            if (File.Exists("C:\\mas\\opencontext.log"))
            {
                TaskMenu1.Show(Cursor.Position);
                File.Delete("C:\\mas\\opencontext.log");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists("C:\\mas\\showabout.txt"))
            {
                File.Delete("C:\\mas\\showabout.txt");
                teaveMarkuseAsjadeKohtaToolStripMenuItem.PerformClick();
            }
            if (File.Exists(@"C:\mas\maia\request_permission.maia") || File.Exists(@"C:\mas\maia\request_permission.mai"))
            {
                if (externalAccess) { 
                    ShowCode sc = new ShowCode();
                    sc.bg = värviskeemToolStripMenuItem.BackColor;
                    sc.fg = värviskeemToolStripMenuItem.ForeColor;
                    sc.ShowDialog();
                } else
                {
                    try { File.Delete(@"C:\mas\maia\request_permission.maia"); } catch { File.Delete(@"C:\mas\maia\request_permission.mai"); }
                }
            }
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\scheme.cfg"))
            {
                LoadTheme();
            }
        }

        private void TaskMenu1_Opening(object sender, CancelEventArgs e)
        {
            if (File.Exists("C:\\mas\\irunning.log"))
            {
                käivitaProjektITSToolStripMenuItem.Text = "Sulge projekt ITS";
                kuvaKõikTöölauaikoonidToolStripMenuItem.Visible = false;
            } else
            {
                käivitaProjektITSToolStripMenuItem.Text = "Käivita projekt ITS";
                kuvaKõikTöölauaikoonidToolStripMenuItem.Visible = true;
            }
            bool none = true;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "FlashUnlock")
                {
                    mälupulgaLukustusToolStripMenuItem.Text = "Lülita mälupulga lukustus välja";
                    none = false;
                }
            }
            if (none)
            {
                mälupulgaLukustusToolStripMenuItem.Text = "Lülita mälupulga lukustus sisse";
            }
        }

        private void sulgeSeeMenüüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
        }

        private void valgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.White, Color.Black);
        }

        void LoadTheme()
        {
            try { 
            string[] bgfg = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\scheme.cfg").Split(';');
            string[] bgs = bgfg[0].ToString().Split(':');
            string[] fgs = bgfg[1].ToString().Split(':');
            Applytheme(Color.FromArgb(Convert.ToInt32(bgs[0].ToString()), Convert.ToInt32(bgs[1].ToString()), Convert.ToInt32(bgs[2].ToString())), Color.FromArgb(Convert.ToInt32(fgs[0].ToString()), Convert.ToInt32(fgs[1].ToString()), Convert.ToInt32(fgs[2].ToString())));
            } catch (Exception ex)
            {
                if (!((TaskMenu1.BackColor == Color.White) && (TaskMenu1.ForeColor == Color.Black)))
                { 
                    Applytheme(TaskMenu1.BackColor, TaskMenu1.ForeColor);
                }
                else
                { 
                    timer1.Enabled = false;
                    MessageBox.Show("Teema laadimine nurjus. Teemafail võib olla rikutud. Probleemi ajutiseks lahenduseks laadime süsteemiteema.\nTehniline info: " +  ex.Message + "\n" + ex.StackTrace, "Kriitiline probleem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\scheme.cfg");
                    File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\scheme.cfg", SystemColors.Menu.R.ToString() + ":" + SystemColors.Menu.G.ToString() + ":" + SystemColors.Menu.B.ToString() + ":;" + SystemColors.MenuText.R.ToString() + ":" + SystemColors.MenuText.G.ToString() + ":" + SystemColors.MenuText.B.ToString() + ":;");
                    Applytheme(SystemColors.Menu, SystemColors.MenuText);
                    timer1.Enabled = true;
                }
            }
        }

        private IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                        yield return subItem;
                }
                yield return dropDownItem;
            }
        }

        void Applytheme(Color bg, Color fg)
        {
            foreach (ToolStripItem m in TaskMenu1.Items)
            {
                if (m is ToolStripSeparator)
                {
                    continue;
                }
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (ToolStripMenuItem m in markuseMälupulkToolStripMenuItem.DropDownItems)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (ToolStripMenuItem m in avaKasutajaKaustToolStripMenuItem.DropDownItems)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (ToolStripMenuItem m in teisendamineToolStripMenuItem.DropDownItems)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control c in this.Controls)
            {
                if(c is TextBox) { 
                    c.BackColor = bg;
                    c.ForeColor = fg;
                }
                if (c is ComboBox)
                {
                    c.BackColor = bg;
                    c.ForeColor = fg;
                }
            }
            //Program.spl.BackColor = bg;
            //Program.spl.ForeColor = fg;
            this.BackColor = bg;
            this.ForeColor = fg;
            this.kasutaWindowsiTeematToolStripMenuItem.BackColor = bg;
            this.kasutaWindowsiTeematToolStripMenuItem.ForeColor = fg;
            this.kohandatudToolStripMenuItem.BackColor = bg;
            this.kohandatudToolStripMenuItem.ForeColor = fg;
            File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\scheme.cfg", bg.R.ToString() + ":" + bg.G.ToString() + ":" + bg.B.ToString() + ":;" + fg.R.ToString() + ":" + fg.G.ToString() + ":" + fg.B.ToString() + ":;");
        }


        private void öörežiimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.Black, Color.Silver);
        }

        private void sinineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.MidnightBlue, Color.White);
        }

        private void tuuleloheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.SpringGreen, Color.Black);
        }

        private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

        static bool Verifile()
        {
            string verificatable = q();
            string[] savedstr = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252)).ToString().Split('\n');
            string sttr = savedstr[savedstr.Length - 1];
            Console.WriteLine(verificatable);
            Console.WriteLine(sttr);
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
            string pp = j(y(File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252))));

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

        private void AvaTöölauamärkmedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\mas\noteopen.txt"))
            {
                File.WriteAllText(@"C:\mas\noteopen.txt", "See fail sisaldab informatsiooni töölauamärkmetega töötamiseks.");
                Process.Start(@"C:\mas\Markuse asjad\TöölauaMärkmed.exe");
                avaTöölauamärkmedToolStripMenuItem.Text = "Sulge töölauamärkmed";
            }
            else if (File.Exists(@"C:\mas\noteopen.txt"))
            {
                File.Delete(@"C:\mas\noteopen.txt");
                File.WriteAllText(@"C:\mas\closenote.log", "See fail saadab töölauamärkmete rakendusele käskluse sulgeda. Kui te näete seda teksti, palun kustutage see fail.");
                avaTöölauamärkmedToolStripMenuItem.Text = "Ava töölauamärkmed";
            }
        }

        private void KäivitaMarkuStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            Process.Start(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\MarkuStation.exe");
        }

        private void AvaOptilineAndmekandjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void KäivitaVirtuaalarvutiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string sdir = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\vpc";
            string hypervisor = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\Program Files (x86)\\VMware\\VMware Player\\vmware-kvm.exe";
            p.StartInfo.FileName = hypervisor;
            p.StartInfo.WorkingDirectory = sdir;
            p.StartInfo.Arguments = "\"Windows 11.vmx\"";
            p.Start();
            /*StartingVM svm = new StartingVM();
            svm.BackColor = avaMarkuseKaustadToolStripMenuItem.BackColor;
            svm.ForeColor = avaMarkuseKaustadToolStripMenuItem.ForeColor;
            svm.ShowDialog();
            svm.Dispose();*/
            TaskMenu1.Close();
        }

        private void SünkroniseeriVersioonToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tarkvaraPaigaldamiseRežiimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            bool redo = false;
            if (kuvaKõikTöölauaikoonidToolStripMenuItem.Text == "Kuva kõik töölauaikoonid")
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.PerformClick();
                redo = true;
            }
            WaitInstall wi = new WaitInstall();
            wi.BackColor = avaMarkuseKaustadToolStripMenuItem.BackColor;
            wi.ForeColor = avaMarkuseKaustadToolStripMenuItem.ForeColor;
            wi.ShowDialog();
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\finalize_install.bat";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
            if (redo)
            {
                kuvaKõikTöölauaikoonidToolStripMenuItem.PerformClick();
            }
        }

        private void raadiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.Green, Color.White);
        }

        private void jõuludToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.DarkRed, Color.Lime);
        }


        private void kohandatudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(kohandatudToolStripMenuItem.BackColor, kohandatudToolStripMenuItem.ForeColor);
        }

        private void värviskeemToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (ToolStripMenuItem ti in värviskeemToolStripMenuItem.DropDownItems)
            {
                if ((ti.BackColor == avaMarkuseKaustadToolStripMenuItem.BackColor) && (ti.ForeColor == avaMarkuseKaustadToolStripMenuItem.ForeColor))
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                kohandatudToolStripMenuItem.BackColor = avaMarkuseKaustadToolStripMenuItem.BackColor;
                kohandatudToolStripMenuItem.ForeColor = avaMarkuseKaustadToolStripMenuItem.ForeColor;
            }
        }

        private void avaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.CDRom)
                {
                    if (di.IsReady)
                    {
                        Process.Start(di.RootDirectory.FullName);
                    }
                    else
                    {
                        avaOptilineAndmekandjaToolStripMenuItem.Visible = false;
                    }
                }
            }
        }


        private static void open()
        {
            int ret = mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
        }

        private static void close()
        {
            int ret = mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int mciSendString(string lpstrCommand,
                                                   StringBuilder lpstrReturnString,
                                                   int uReturnLength,
                                                   IntPtr hwndCallback);


        private void väljutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.CDRom)
                {
                    if (di.IsReady)
                    {
                        open();
                    }
                    else
                    {
                        avaOptilineAndmekandjaToolStripMenuItem.Visible = false;
                    }
                }
            }
        }

        private void avaOptilineAndmekandjaToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem ti in avaOptilineAndmekandjaToolStripMenuItem.DropDownItems)
            {
                ti.BackColor = avaOptilineAndmekandjaToolStripMenuItem.BackColor;
                ti.ForeColor = avaOptilineAndmekandjaToolStripMenuItem.ForeColor;
            }
        }

        private void markuseMälupulkToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TaskMenu1.Close();
        }

        private void TaskMenu1_Opened(object sender, EventArgs e)
        {
            TaskMenu1.Focus();
        }

        private void Form1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void mälupulgaLukustusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool none = true;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "FlashUnlock")
                {
                    none = false;
                    File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\stop_authenticate", "now");
                }
            }
            if (none)
            {
                Process p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\Markuse asjad\FlashUnlock.exe";
                p.Start();
            }
            TaskMenu1.Close();
        }

        private void mAIAServeriHaldamineToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            peataToolStripMenuItem.Image = Properties.Resources._new;
            peataToolStripMenuItem.Text = "Käivita";
            avaBrauserisToolStripMenuItem.Enabled = false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "python")
                {
                    peataToolStripMenuItem.Image = Properties.Resources.failure;
                    peataToolStripMenuItem.Text = "Peata";
                    avaBrauserisToolStripMenuItem.Enabled = true;
                }
            }
            foreach (ToolStripDropDownItem tdi in mAIAServeriHaldamineToolStripMenuItem.DropDownItems)
            {
                tdi.BackColor = mAIAServeriHaldamineToolStripMenuItem.BackColor;
                tdi.ForeColor = mAIAServeriHaldamineToolStripMenuItem.ForeColor;
            }
        }

        private void avaBrauserisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://localhost:14414";
            p.Start();
        }

        private void peataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (peataToolStripMenuItem.Text == "Peata")
            {
                int pid = -1;
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName.Contains("python"))
                    {
                        pid = p.Id;
                    }
                }
                if (pid != -1) { Process.GetProcessById(pid).Kill(); }
            } else
            {
                Process p = new Process();
                p.StartInfo.WorkingDirectory = "C:\\mas\\maia";
                p.StartInfo.FileName = "python.exe";
                p.StartInfo.Arguments = "C:\\mas\\maia\\server.py";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                mAIAServeriHaldamineToolStripMenuItem.Visible = true;
            }
        }

        private void spektraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applytheme(Color.Indigo, Color.FromArgb(221, 221, 255));
        }

        private void võimaldaLigipääsuTaotlemineToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            externalAccess = võimaldaLigipääsuTaotlemineToolStripMenuItem.Checked;
        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void kasutaWindowsiTeematToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                int ColorizationColor = (int)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM", "ColorizationColor", null);
                Color foreColor = Color.White;
                Color backColorA = Color.FromArgb(ColorizationColor);
                Color backColor = Color.FromArgb(255, backColorA.R, backColorA.G, backColorA.B);
                Applytheme(backColor, foreColor);
            }
            catch
            {
                MessageBox.Show("DWM värviskeemi laadimine nurjus", "Sünkroniseeri DWM teema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lukustaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMenu1.Close();
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\Markuse asjad\\Markuse arvuti lukustamissüsteem.exe";
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
    }
}
