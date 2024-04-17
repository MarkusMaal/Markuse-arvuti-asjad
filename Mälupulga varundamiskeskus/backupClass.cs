using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Mälupulga_varundamiskeskus
{
    public partial class backupClass : Form
    {
        public bool stuff = false;
        public bool config = true;
        public bool misc = true;
        public bool batch = false;
        public bool yumi = false;
        public bool log = false;
        public char letter = 'K';
        public string location = "";
        string current = "prepare";
        int count = 2;
        public backupClass()
        {
            InitializeComponent();
        }

        private void BackupClass_Resize(object sender, EventArgs e)
        {
            if (this.Height < 270)
            {
                logText.Visible = false;
                logContent.Visible = false;
            } else
            {
                logText.Visible = true;
                logContent.Visible = true;
            }
        }

        private void BackupClass_Load(object sender, EventArgs e)
        {
            logContent.AppendText("Tere tulemast varundamiskeskusesse!");
            logContent.AppendText(Environment.NewLine);
            logContent.AppendText(Environment.NewLine);
            logContent.AppendText("Varundamiseks valiti järgmised üksused:");
            logContent.AppendText(Environment.NewLine);
            count = 2;
            if (stuff) { count++; logContent.AppendText("Markuse asjad"); logContent.AppendText(Environment.NewLine); }
            if (batch) { count++; logContent.AppendText("Pakkfailid"); logContent.AppendText(Environment.NewLine); }
            if (yumi) { count++; logContent.AppendText("YUMI ja operatsioonsüsteemid"); logContent.AppendText(Environment.NewLine); }
            logContent.AppendText("Autorun ja muud failid"); logContent.AppendText(Environment.NewLine);
            logContent.AppendText("Kontrollandmed ja konfiguratsioon"); logContent.AppendText(Environment.NewLine);
            logContent.AppendText("-------------------------------------------"); logContent.AppendText(Environment.NewLine);
            logContent.AppendText("Algab varundamine..."); logContent.AppendText(Environment.NewLine);
            progressBar2.Maximum = count;
            NextTask();
        }


        void NextTask()
        {
            countCheck.Enabled = false;
            label4.Text = progressBar2.Value.ToString() + " toimingut " + count.ToString() + "-st on valmis";
            if (progressBar2.Value != progressBar2.Maximum)
            { 
                progressBar2.Value += 1;
            }
            if (config == true)
            {
                //konfiguratsioon ja kontrollfailide toiming
                config = false;
                label3.Text = "Praegu: Konfiguratsioonifailide varundamine";
                logContent.AppendText("Mälupulga juurkonfiguratsiooni varundamine..."); logContent.AppendText(Environment.NewLine);
                LaunchBatch("backup", letter.ToString() + ":\\E_INFO", "E_INFO");
                logContent.AppendText("Mälupulga lisanduva konfiguratsiooni varundamine..."); logContent.AppendText(Environment.NewLine);
                LaunchBatch("backup", letter.ToString() + ":\\NTFS", "E_INFO");
                LaunchBatch("backup", letter.ToString() + ":\\PortableInstall", "PortableInstall");
                NextTask();
                return;
            }
            else if (misc == true)
            {
                //muude asjade ja autorun toiming
                misc = false;
                label3.Text = "Praegu: Muude failide ja autoruni kopeerimine";
                logContent.AppendText("Autoruni varundamine..."); logContent.AppendText(Environment.NewLine);
                File.Copy(letter.ToString() + ":\\autorun.inf", location + "\\autorun.inf");
                File.Copy(letter.ToString() + ":\\mas_flash.ico", location + "\\mas_flash.ico");
                logContent.AppendText("Muude failide varundamine..."); logContent.AppendText(Environment.NewLine);
                NextTask();
                return;
            }
            else if (stuff == true)
            {
                //markuse asjade toiming
                stuff = false;
                label3.Text = "Praegu: Markuse asjade varundamine";
                logContent.AppendText("Failide lugemine..."); logContent.AppendText(Environment.NewLine);
                LaunchBatch("count", letter.ToString() + ":\\markuse asjad", "markuse asjad");
                current = "stuff";
                countCheck.Enabled = true;
                return;
            }
            else if (batch == true)
            {
                //pakkfailide toiming
                batch = false;
                label3.Text = "Praegu: Pakkfailide varundamine";
                logContent.AppendText("Failide lugemine..."); logContent.AppendText(Environment.NewLine);
                LaunchBatch("count", letter.ToString() + ":\\Pakkfailid", "Pakkfailid");
                current = "batch";
                countCheck.Enabled = true;
                return;
            }
            else if (yumi == true)
            {
                //YUMI toiming
                yumi = false;
                label3.Text = "Praegu: YUMI ja operatsioonsüsteemide varundamine";
                logContent.AppendText("Failide lugemine..."); logContent.AppendText(Environment.NewLine);
                LaunchBatch("count", letter.ToString() + ":\\multiboot", "multiboot");
                current = "yumi";
                countCheck.Enabled = true;
                return;
            } else
            {
                //valmis
                label3.Text = "Varundamine viidi lõpule";
                logContent.AppendText("Valmis");
                current = "done";
                button1.Text = "Sule";
            }
        }

        void LaunchBatch (string action, string fromlocation, string to)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_filelog.txt")) { File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_filelog.txt"); }
            if (!File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc.bat"))
            {
                File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc.bat", Properties.Resources.bc, Encoding.ASCII);
            }
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc.bat";
            p.StartInfo.Arguments = action + " " + fromlocation.Replace(" ", "+") + " " + location.Replace(" ", "+") + "\\" + to.Replace(" ", "+");
            p.Start();
        }

        private void CountCheck_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_countlog.txt"))
            {
                try { 
                string[] lines = File.ReadAllLines(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_countlog.txt");
                progressBar1.Maximum = lines.Length - 1;
                if (current == "stuff")
                {
                    logContent.AppendText("Markuse asjade varundamine..."); logContent.AppendText(Environment.NewLine);
                    LaunchBatch("backup", letter.ToString() + ":\\markuse asjad", "markuse asjad");
                    countCheck.Enabled = false;
                    progressCheck.Enabled = true;
                }
                else if (current == "batch")
                {
                    logContent.AppendText("Pakkfailide varundamine..."); logContent.AppendText(Environment.NewLine);
                    LaunchBatch("backup", letter.ToString() + ":\\Pakkfailid", "Pakkfailid");
                    countCheck.Enabled = false;
                    progressCheck.Enabled = true;
                }
                else if (current == "yumi")
                {
                    logContent.AppendText("YUMI varundamine..."); logContent.AppendText(Environment.NewLine);
                    LaunchBatch("backup", letter.ToString() + ":\\multiboot", "multiboot");
                    countCheck.Enabled = false;
                    progressCheck.Enabled = true;
                }
                }
                catch
                {

                }
            }
        }

        private void ProgressCheck_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_filelog.txt"))
            {
                try
                { 
                    string[] lines = File.ReadAllLines(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\bc_filelog.txt");
                    progressBar1.Value = lines.Length - 1;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        progressBar1.Value = 0;
                        progressBar1.Maximum = 100;
                        progressCheck.Enabled = false;
                        NextTask();
                    }
                }
                catch
                {

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Peata")
            {
                if (MessageBox.Show("Varundamine on veel pooleli ning kui peatate selle toimingu, ei viida varundamist lõpule.", "Peata varundamine?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
