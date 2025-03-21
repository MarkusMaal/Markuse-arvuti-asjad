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
using System.Net;
using System.Security.Cryptography;
using System.Management;
using System.Globalization;

namespace Markuse_arvuti_juhtpaneel
{
    public partial class controlForm : Form
    {
        string last = "";
        bool ultimate = false;
        string ver;
        string build;
        string name;
        string feature;
        string root;
        bool rooting = false;
        bool laptop = false;
        string lang;
        string content;
        int mousex = 0;
        int mousey = 0;
        string version = "1.05";
        string whatnew = "+ Taustapilt arvuti juhtpaneelis";
        static pageSelect tabControl1 = new pageSelect();
        ListBox locationList = new ListBox();
        public controlForm()
        {
            InitializeComponent();
            newText.Text = whatnew;
        }

        private void controlForm_Load(object sender, EventArgs e)
        {
            Boolean isRunningOnBattery =
              (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus ==
               PowerLineStatus.Offline);

            if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\masv"))
            {
                stuffLabel.Text = "markuse virtuaalarvuti juhtpaneel";
                this.Text = "Markuse virtuaalarvuti juhtpaneel";
            }
            else if (isRunningOnBattery)
            {
                stuffLabel.Text = "markuse sülearvuti juhtpaneel";
                this.Text = "Markuse sülearvuti juhtpaneel";
                laptop = true;
            }
            string devPrefix = "Markuse arvuti asjade";
            if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\masv"))
            {
                devPrefix = "Markuse virtuaalarvuti asjade";
            }
            else if (laptop)
            {
                devPrefix = "Markuse sülearvuti asjade";
            }
            if (File.Exists(Program.root + "\\edition.txt"))
            {

                switch (Verifile2())
                {
                    case "VERIFIED":
                        break;
                    case "FOREIGN":
                        MessageBox.Show("See programm töötab ainult Markuse arvutis.\n\nVeakood: VF_FOREIGN", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case "FAILED":
                        MessageBox.Show("Verifile püsivuskontrolli läbimine nurjus.\n\nVeakood: VF_FAILED", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case "TAMPERED":
                        MessageBox.Show("See arvuti pole õigesti juurutatud. Seda võis põhjustada hiljutine riistvaramuudatus. Palun kasutage juurutamiseks Markuse asjade juurutamistööriista.\n\nVeakood: VF_TAMPERED", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case "LEGACY":
                        MessageBox.Show("See arvuti on juurutatud vana juurutamistööriistaga. Palun juurutage arvuti uuesti uue juurutamistarkvaraga.\n\nVeakood: VF_LEGACY", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                }
                if (Verifile())
                { 
                    verLabel.Text = "versioon " + version;
                    LoadTheme();
                } else
                {
                    MessageBox.Show(devPrefix + " tarkvara ei ole õigesti juurutatud. Palun juurutage seade kasutades juurutamise tööriista.", "Valesti juurutatud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            if (File.Exists(Program.root + "\\mas.cnf"))
            {
                string[] cnfs = File.ReadAllText(Program.root + "\\mas.cnf").Split(';');
                if (cnfs[0].ToString() == "true")
                {
                    checkBox1.Checked = true;
                }
                if (cnfs[1].ToString() == "true")
                {
                    checkBox2.Checked = true;
                }
                if (cnfs[2].ToString() == "true")
                {
                    checkBox3.Checked = true;
                }
                if (File.Exists(Program.root + @"\irunning.log"))
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    closeButton.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(devPrefix + " tarkvara ei ole juurutatud. Palun juurutage seade kasutades juurutamise tööriista.", "Markuse asjade tarkvara pole paigaldatud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void LoadTheme()
        {
            try
            { 
                string[] bgfg = File.ReadAllText(Program.root + "\\scheme.cfg").Split(';');
                string[] bgs = bgfg[0].ToString().Split(':');
                string[] fgs = bgfg[1].ToString().Split(':');
                Applytheme(Color.FromArgb(Convert.ToInt32(bgs[0].ToString()), Convert.ToInt32(bgs[1].ToString()), Convert.ToInt32(bgs[2].ToString())), Color.FromArgb(Convert.ToInt32(fgs[0].ToString()), Convert.ToInt32(fgs[1].ToString()), Convert.ToInt32(fgs[2].ToString())));
                if (this.BackgroundImage == null)
                {
                    Image img = Image.FromFile(Program.root + "\\bg_common.png");
                    this.BackgroundImage = img;
                }
            }
            catch (OutOfMemoryException)
            {
                System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
                this.BackgroundImage = null;
            }
            catch { }
        }

        void Applytheme(Color bg, Color fg)
        {
            foreach (Control m in pageSelect_2.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in pageSelect_3.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in pageSelect_1.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in pageSelect_2.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in pageSelect_3.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox1.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox2.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox4.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox3.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox5.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in groupBox6.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in gameGroup.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control m in addGroup.Controls)
            {
                m.BackColor = bg;
                m.ForeColor = fg;
            }
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.BackColor = bg;
                    c.ForeColor = fg;
                }
                if (c is ComboBox)
                {
                    c.BackColor = bg;
                    c.ForeColor = fg;
                }
            }
            this.BackColor = bg;
            this.ForeColor = fg;
            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            if (listBox1.Items.Count > 0) { setcolour(); }
            locationBox.BackColor = Color.White;
            locationBox.ForeColor = Color.Black;
            nameBox.BackColor = Color.White;
            nameBox.ForeColor = Color.Black;

        }

        private void nameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                locationList.SelectedIndex = nameList.SelectedIndex;
            }
            catch
            {
            }
        }

        private void locationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nameList.SelectedIndex = locationList.SelectedIndex;
            }
            catch
            {
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string file = File.ReadAllLines(Program.root + "\\ms_display.txt")[0];
            switch (file)
            {
                case "internal":
                    comboBox1.SelectedIndex = 1;
                    break;
                case "external":
                    comboBox1.SelectedIndex = 2;
                    break;
                case "extend":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "clone":
                    comboBox1.SelectedIndex = 3;
                    break;
            }
            file = File.ReadAllText(Program.root + "\\setting.txt");
            nameList.Items.Clear();
            nameList.Items.AddRange(file.Split('\n'));
            nameList.SelectedIndex = 0;
            string cursel;
            cursel = nameList.SelectedItem.ToString();
            if (cursel == "true") { creepCheck.Checked = true; }
            if (cursel == "false") { creepCheck.Checked = false; }
            nameList.SelectedIndex = 1;
            cursel = nameList.SelectedItem.ToString();
            if (cursel == "true") { specialCheck.Checked = true; }
            if (cursel == "false") { specialCheck.Checked = false; }
            nameList.SelectedIndex = 2;
            cursel = nameList.SelectedItem.ToString();
            if (cursel == "true") { introCheck.Checked = true; }
            if (cursel == "false") { introCheck.Checked = false; }
            file = File.ReadAllText(Program.root + "\\ms_games.txt");
            file = file.Substring(0, file.Length - 2);
            nameList.Items.Clear();
            nameList.Items.AddRange(file.Split('\n'));
            file = File.ReadAllText(Program.root + "\\ms_exec.txt");
            file = file.Substring(0, file.Length - 2);
            locationList.Items.Clear();
            locationList.Items.AddRange(file.Split('\n'));
            nameList.SelectedIndex = 1;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Nimi", 150);
            listView1.Columns.Add("Asukoht", 600);
            int i;
            Random r = new Random();
            int seed = r.Next(0, 999999999);
            for (i = 1; i <= locationList.Items.Count - 1; i++)
            {
                r = new Random(seed);
                locationList.SelectedIndex = i;
                nameList.SelectedIndex = i;
                ListViewItem item = new ListViewItem();
                item.Text = nameList.SelectedItem.ToString();
                item.SubItems.Add(locationList.SelectedItem.ToString());
                item.ImageIndex = r.Next(0, 13);
                listView1.Items.Add(item);
                seed++;
            }
        }

        private void locationList_MouseDown(object sender, MouseEventArgs e)
        {
            nameList.SelectedIndex = locationList.SelectedIndex;
        }

        private void nameList_MouseDown(object sender, MouseEventArgs e)
        {
            locationList.SelectedIndex = nameList.SelectedIndex;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult dlg = openExecutable.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                locationBox.Text = openExecutable.FileName.ToString();
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            nameList.Items.Add(nameBox.Text);
            locationList.Items.Add(locationBox.Text + ";");
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Nimi", 150);
            listView1.Columns.Add("Asukoht", 600);
            int i;
            for (i = 1; i <= locationList.Items.Count - 1; i++)
            {
                locationList.SelectedIndex = i;
                nameList.SelectedIndex = i;
                ListViewItem item = new ListViewItem();
                item.Text = nameList.SelectedItem.ToString();
                item.SubItems.Add(locationList.SelectedItem.ToString());
                item.ImageIndex = new Random().Next(0, 13);
                System.Threading.Thread.Sleep(10);
                listView1.Items.Add(item);
            }
        }

        private void locationList_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mousex != Cursor.Position.X)
                {
                    if (mousey != Cursor.Position.Y)
                    {
                        toolTip1.Show(locationList.SelectedItem.ToString(), locationList, 500);
                        mousex = Cursor.Position.X;
                        mousey = Cursor.Position.Y;
                    }
                }
            }
            catch
            {
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string scrntype = "extend";
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    scrntype = "internal";
                    break;
                case 2:
                    scrntype = "external";
                    break;
                case 3:
                    scrntype = "clone";
                    break;
                default:
                    break;
            }
            File.WriteAllText(Program.root + @"\ms_display.txt", scrntype + Environment.NewLine);
            StringBuilder builder = new StringBuilder();
            foreach (string val in nameList.Items)
            {
                if(val=="") goto skipappendage;
                builder.Append(val);
                builder.Append("\n");
            skipappendage: ;
            }
            tempBox.Text = builder.ToString();
            tempBox.Text = tempBox.Text + "\n";
            File.WriteAllText(Program.root + "\\ms_games.txt", tempBox.Text, Encoding.UTF8);
            tempBox.Text = "";
            builder = null;
            builder = new StringBuilder();
            foreach (string val in locationList.Items)
            {
                if (val == "") goto skipappendsage;
                builder.Append(val);
                builder.Append("\n");
            skipappendsage: ;
            }
            tempBox.Text = builder.ToString();
            tempBox.Text = tempBox.Text + "\n";
            File.WriteAllText(Program.root + "\\ms_exec.txt", tempBox.Text, Encoding.UTF8);
            tempBox.Text = "";
            if (creepCheck.Checked == true) { tempBox.Text = "true"; }
            if (creepCheck.Checked == false) { tempBox.Text = "false"; }
            if (specialCheck.Checked == true) { tempBox.Text = tempBox.Text + "\ntrue"; }
            if (specialCheck.Checked == false) { tempBox.Text = tempBox.Text + "\nfalse"; }
            if (introCheck.Checked == true) { tempBox.Text = tempBox.Text + "\ntrue"; }
            if (introCheck.Checked == false) { tempBox.Text = tempBox.Text + "\nfalse"; }
            File.WriteAllText(Program.root + "\\setting.txt", tempBox.Text);
            tempBox.Text = "";
        }

        private void boostButton_Click(object sender, EventArgs e)
        {
            Process.Start(Program.root + "\\boost.vbs");
        }

        private void startMS_Click(object sender, EventArgs e)
        {
            Process.Start(Program.root + "\\MarkuStation.exe");
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void boostButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Määrab kõrge resursside kasutusega rakenduse prioriteedid madalaks, parandades seadme kiirust (boost.vbs).";
        }

        private void boostButton_MouseLeave(object sender, EventArgs e)
        {
            infoLabel.Text = "Siin kuvatakse teave, kui liigutate kursori teatud nupu peale.";
        }

        private void screenButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Teeb praegusest ekraanist kuvatõmmise ja salvestab selle piltide teeki.";
        }

        private void screenasButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Teeb praegusest ekraanist kuvatõmmise ja kuvab salvestamise dialoogi, kus saate valida kausta kuhu salvestada, faili nime ja formaadi.";
        }

        private void flashButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab Markuse mälupulga juhtpaneeli (mälupulk).";
        }

        private void noteButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab lihtsa tekstitöötluse programmi (sharpNotepad.exe).";
        }

        private void taskButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab Windowsi tegumihalduri, millega saate vaadata avatud tegumeid, neid sulgeda, muuta nende prioriteeti ja resursside kasutust, samuti saate vaadata aktiivseid teenuseid (taustaprogramme) (taskmgr, valikuline administraator).";
        }

        private void deviceButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab seadmehalduri, millega saate vaadata seadmesse paigaldatud riistvara ning installida/uuendada draivereid (devmgmt.msc, valikuline administraator).";
        }

        private void commandButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab tarviku käsuviip (cmd, administraator).";
        }

        private void regButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab registrite redigeerija (regedit, administraator).";
        }

        private void configButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Käivitab seadme haldamise utilliidid (compmgmt.msc, administraator).";
        }

        private void startButton_MouseMove(object sender, MouseEventArgs e)
        {
            infoLabel.Text = "Avab Windowsi start menüü (Ctrl + Esc).";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^{ESC}");
        }

        private void taskButton_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void deviceButton_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void commandButton_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            Process.Start("regedit.exe");
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "compmgmt.msc";
            p.Start();
        }

        private void flashButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.root + "\\running.log"))
            {
                File.Delete(Program.root + "\\running.log");
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
                try { 
                File.Copy(drv + ":\\Markuse mälupulk\\Markuse mälupulk\\bin\\Debug\\Markuse mälupulk.exe", Program.root + "\\Mälupulk.exe", true);
                } catch
                {
                    MessageBox.Show("Ei saanud kopeerida ajakohast versiooni Markuse mälupulgalt.\nOlge kindlad, et sisestatud seade oleks kindlasti Markuse mälupulk.\nProgramm käivitub viimase salvestatud mälupulga tarkvara versiooniga...", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ei saanud kopeerida ajakohast versiooni Markuse mälupulgalt", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (File.Exists(Program.root + "\\Mälupulk.exe"))
            {
                Process.Start(Program.root + "\\Mälupulk.exe");
            }
            else
            {
                MessageBox.Show("Programmi käivitumine ebaõnnestus.\nPõhjus: Faili ei leitud", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void screenButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Cursor.Hide();
            Clipboard.Clear();
            Rectangle r = Screen.GetBounds(this);
            this.Hide();
            Bitmap b = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), r.Size);

            }
            PictureBox pb = new PictureBox();
            pb.Image = b;
            string filename;
            filename = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString() + "\\Pictures\\Kuvatõmmis-" + DateTime.Today.Date.Day + "." + DateTime.Today.Date.Month + "." + DateTime.Today.Date.Year + " " + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + "." + DateTime.Now.Millisecond.ToString() + ".png";
            pb.Image.Save(filename);
            Process.Start("explorer", "/select," + filename);
            this.Show();
            this.TopMost = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            Cursor.Show();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Hide();
            timer1.Enabled = true;
        }

        private void screenasButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void noteButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Program.root + "\\sharpNotepad.exe"))
            {
                File.WriteAllBytes(Program.root + "\\sharpNotepad.exe", Properties.Resources.sharpNotepads);
            }
            Process.Start(Program.root + "\\sharpNotepad.exe");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button10.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Cursor.Hide();
            Clipboard.Clear();
            Rectangle r = Screen.GetBounds(this);
            Bitmap b = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), r.Size);

            }
            PictureBox pb = new PictureBox();
            pb.Image = b;
            string filename;
            filename = saveFileDialog1.FileName.ToString();
            if (filename.EndsWith(".bmp")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp); }
            if (filename.EndsWith(".png")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png); }
            if (filename.EndsWith(".jpg")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg); }
            if (filename.EndsWith(".gif")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Gif); }
            if (filename.EndsWith(".tiff")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Tiff); }
            if (filename.EndsWith(".wmf")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Wmf); }
            if (filename.EndsWith(".emf")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Emf); }
            if (filename.EndsWith(".exif")) { pb.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Exif); }
            Process.Start("explorer", "/select," + filename);
            this.Show();
            this.TopMost = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            Cursor.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IP.Image = Properties.Resources.failure;
            IT.Image = Properties.Resources.failure;
            WX.Image = Properties.Resources.failure;
            IT.Image = Properties.Resources.failure;
            CS.Image = Properties.Resources.failure;
            RD.Image = Properties.Resources.failure;
            RM.Image = Properties.Resources.failure;
            TSMM.Image = Properties.Resources.failure;
            GP.Image = Properties.Resources.failure;
            LT.Image = Properties.Resources.failure;
            if (listBox1.SelectedItem.ToString() == "(basic)")
            {
                string dir;
                dir = "";
                if (Directory.Exists("B:\\Documents and Settings\\Markus")) { dir = "B"; goto ohfuckit; }
                if (Directory.Exists("C:\\Documents and Settings\\Markus")) { dir = "C"; goto ohfuckit; }
                if (Directory.Exists("D:\\Documents and Settings\\Markus")) { dir = "D"; goto ohfuckit; }
                if (Directory.Exists("E:\\Documents and Settings\\Markus")) { dir = "E"; goto ohfuckit; }
                if (Directory.Exists("F:\\Documents and Settings\\Markus")) { dir = "F"; goto ohfuckit; }
                if (Directory.Exists("G:\\Documents and Settings\\Markus")) { dir = "G"; goto ohfuckit; }
                if (Directory.Exists("H:\\Documents and Settings\\Markus")) { dir = "H"; goto ohfuckit; }
                if (Directory.Exists("I:\\Documents and Settings\\Markus")) { dir = "I"; goto ohfuckit; }
                if (Directory.Exists("J:\\Documents and Settings\\Markus")) { dir = "J"; goto ohfuckit; }
                if (Directory.Exists("K:\\Documents and Settings\\Markus")) { dir = "K"; goto ohfuckit; }
                if (Directory.Exists("L:\\Documents and Settings\\Markus")) { dir = "L"; goto ohfuckit; }
                if (Directory.Exists("M:\\Documents and Settings\\Markus")) { dir = "M"; goto ohfuckit; }
                if (Directory.Exists("N:\\Documents and Settings\\Markus")) { dir = "N"; goto ohfuckit; }
                if (Directory.Exists("O:\\Documents and Settings\\Markus")) { dir = "O"; goto ohfuckit; }
                if (Directory.Exists("P:\\Documents and Settings\\Markus")) { dir = "P"; goto ohfuckit; }
                if (Directory.Exists("Q:\\Documents and Settings\\Markus")) { dir = "Q"; goto ohfuckit; }
                if (Directory.Exists("R:\\Documents and Settings\\Markus")) { dir = "R"; goto ohfuckit; }
                if (Directory.Exists("S:\\Documents and Settings\\Markus")) { dir = "S"; goto ohfuckit; }
                if (Directory.Exists("T:\\Documents and Settings\\Markus")) { dir = "T"; goto ohfuckit; }
                if (Directory.Exists("U:\\Documents and Settings\\Markus")) { dir = "U"; goto ohfuckit; }
                if (Directory.Exists("V:\\Documents and Settings\\Markus")) { dir = "V"; goto ohfuckit; }
                if (Directory.Exists("W:\\Documents and Settings\\Markus")) { dir = "W"; goto ohfuckit; }
                if (Directory.Exists("X:\\Documents and Settings\\Markus")) { dir = "X"; goto ohfuckit; }
                if (Directory.Exists("Y:\\Documents and Settings\\Markus")) { dir = "Y"; goto ohfuckit; }
                if (Directory.Exists("Z:\\Documents and Settings\\Markus")) { dir = "Z"; goto ohfuckit; }
            ohfuckit: ;
                label1.BackColor = Color.Yellow;
                label3.Text = "Basic+";
                label4.Text = "Muutmisaeg: " + File.GetLastWriteTime(dir + ":\\Documents and Settings\\Markus").ToShortDateString() + " " + File.GetLastWriteTime(dir + ":\\Documents and Settings\\Markus").ToShortTimeString() + "\nDraiv: " + dir;
                return;
            }
            if (rooting == true) { return; }
            listBox2.Items.Clear();
            if (listBox1.SelectedItem.ToString() == "(üldine)")
            {
                if (listBox1.SelectedIndex == 0)
                {
                    label1.BackColor = Color.DarkViolet;
                    label3.Text = "Ultimate";
                    int parc = listBox1.Items.Count - 2;
                    listBox3.Items.Clear();
                    listBox3.Items.AddRange(listBox1.Items);
                looptillworksm8: ;
                    listBox3.SelectedIndex = listBox3.SelectedIndex + 1;
                    if (File.Exists(listBox3.SelectedItem.ToString() + ":\\editions.txt")) { goto finalizeparts; }
                    if (listBox3.SelectedIndex == listBox3.Items.Count - 1) { goto skipwork; }
                    goto looptillworksm8;
                finalizeparts: ;
                    string s = File.ReadAllText(listBox3.SelectedItem.ToString() + ":\\editions.txt");
                    label4.Text = "Partitsioone: " + parc.ToString() + "\nVäljaanded: " + s + "\n\nEt käivitada Basic ja Premium väljaandeid, buutige Markuse mälupulgale ja valige \"Käivita Windows XP kõvakettalt\". Seejärel valige ilmunud menüüst soovitud väljaanne.";
                skipwork: ;
                }
            }
            if (File.Exists(listBox1.SelectedItem.ToString() + ":\\sources\\boot.wim"))
            {
                label1.BackColor = Color.Lime;
                label3.Text = "Starter";
                label4.Text = "Käivita see buutides Markuse mälupulgale ja valides menüüst Markuse arvuti asjad Starter.\n\nSüsteeminõuded:\n\nMuutmälu: 256 MB (soovitatav 512 MB)\nProtsessor: 1 GHz\nVideokaart: SVGA ühilduv" + "\nMuutmisaeg: " + File.GetLastWriteTime(listBox1.SelectedItem.ToString() + ":\\sources\\boot.wim").ToShortDateString() + " " + File.GetLastWriteTime(listBox1.SelectedItem.ToString() + ":\\sources\\boot.wim").ToShortTimeString();
                return;
            }
            try
            {
                if (File.Exists(listBox1.SelectedItem.ToString() + ":\\mas\\edition.txt"))
                {
                    content = File.ReadAllText(listBox1.SelectedItem.ToString() + ":\\mas\\edition.txt", Encoding.ASCII);
                    listBox2.Items.AddRange(content.Split('\n'));
                    listBox2.SelectedIndex = 1;
                    label3.Text = listBox2.SelectedItem.ToString();
                    setcolour();
                    listBox2.SelectedIndex = 2;
                    ver = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 3;
                    build = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 4;
                    root = listBox2.SelectedItem.ToString();
                    if (root.Contains("Yes")) { root = "Jah"; }
                    else if (root.Contains("No")) { root = "Ei"; }
                    listBox2.SelectedIndex = 6;
                    lang = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 8;
                    feature = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 9;
                    string pin = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 10;
                    name = listBox2.SelectedItem.ToString();
                    listBox2.SelectedIndex = 11;
                    string fp = listBox2.SelectedItem.ToString();
                    button10.Visible = true;
                    name = name.Replace("?", "õ").Replace("2", "ä").Replace("_y_", "ü").Replace("9", "ö");
                    label4.Text = "Versioon: " + ver + "\nJärk: " + build + "\nNimi: " + name + "\nKeel: " + lang + "\nJuurutatud? : " + root.ToString() + "\nMuutmisaeg: " + File.GetLastWriteTime(listBox1.SelectedItem.ToString() + ":\\mas").ToShortDateString() + " " + File.GetLastWriteTime(listBox1.SelectedItem.ToString() + ":\\mas").ToShortTimeString() + "\nKinnituskood: " + pin + "\nSõrmejälg: " + fp;
                    // feature
                    if ((feature.Contains("TS")) && (feature.Contains("MM")))
                    {
                        TSMM.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("IP")))
                    {
                        IP.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("IT")))
                    {
                        IT.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("WX")))
                    {
                        WX.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("RD")))
                    {
                        RD.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("GP")))
                    {
                        GP.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("RM")))
                    {
                        RM.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("CS")))
                    {
                        CS.Image = Properties.Resources.success;
                    }
                    if ((feature.Contains("LT")))
                    {
                        LT.Image = Properties.Resources.success;
                    }
                }
            }
            catch
            {
            }
        }

        private void setcolour()
        {
            if (label3.Text.Contains("Basic"))
            {
                label1.BackColor = Color.Yellow;
            }
            if (label3.Text.Contains("Pro"))
            {
                label1.BackColor = Color.DeepSkyBlue;
            }
            if (label3.Text.Contains("Premium"))
            {
                label1.BackColor = Color.Red;
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tabControl1.SelectPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            tabControl1.SelectPage();
            label24.Text = "Vajutage sisestusklahvi olemasoleval üksusel, et seda muuta";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            tabControl1.SelectPage();
        }

        private bool DirExistNotReparse(string dir)
        {
            return Directory.Exists(dir) && !((new DirectoryInfo(dir).Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint);
        }

        public void PageCheck()
        {
            Font fnt = new Font(button1.Font, FontStyle.Regular);
            button1.Font = fnt;
            button1.BackColor = this.BackColor;
            button1.ForeColor = this.ForeColor;
            button2.Font = fnt;
            button2.BackColor = this.BackColor;
            button2.ForeColor = this.ForeColor;
            button3.Font = fnt;
            button3.BackColor = this.BackColor;
            button3.ForeColor = this.ForeColor;
            button5.Font = fnt;
            button5.BackColor = this.BackColor;
            button5.ForeColor = this.ForeColor;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    fnt = new Font(button1.Font, FontStyle.Bold);
                    button1.Font = fnt;
                    button1.ForeColor = this.BackColor;
                    button1.BackColor = this.ForeColor;
                    break;
                case 1:
                    fnt = new Font(button2.Font, FontStyle.Bold);
                    button2.Font = fnt;
                    button2.ForeColor = this.BackColor;
                    button2.BackColor = this.ForeColor;
                    loadButton.PerformClick();
                    break;
                case 2:
                    fnt = new Font(button3.Font, FontStyle.Bold);
                    button3.Font = fnt;
                    button3.ForeColor = this.BackColor;
                    button3.BackColor = this.ForeColor;

                    if (Directory.Exists(Program.root + "\\v"))
                    {
                        label7.Text = "Markuse virtuaalarvuti asjad";
                        goto soup;
                    }
                    else if (Directory.Exists(Program.root + "\\"))
                    {
                        if (!laptop)
                        {
                            label7.Text = "Markuse arvuti asjad";
                        } else
                        {
                            label7.Text = "Markuse sülearvuti asjad";
                        }
                    }
                soup:;
                    listBox1.SelectedIndex = 0;
                    listBox1.Items.Clear();
                    listBox1.Items.Add("(üldine)");
                    if (DirExistNotReparse("B:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("C:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("D:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("E:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("F:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("G:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("H:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("I:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("J:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("K:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("L:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("M:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("N:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("O:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("P:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("Q:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("R:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("S:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("T:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("U:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("V:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("W:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("X:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("Y:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                    if (DirExistNotReparse("Z:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckits; }
                ohfuckits:;
                    if (DirExistNotReparse("B:\\mas")) { listBox1.Items.Add("B"); }
                    if (DirExistNotReparse("C:\\mas")) { listBox1.Items.Add("C"); }
                    if (DirExistNotReparse("D:\\mas")) { listBox1.Items.Add("D"); }
                    if (DirExistNotReparse("E:\\mas")) { listBox1.Items.Add("E"); }
                    if (DirExistNotReparse("F:\\mas")) { listBox1.Items.Add("F"); }
                    if (DirExistNotReparse("G:\\mas")) { listBox1.Items.Add("G"); }
                    if (DirExistNotReparse("H:\\mas")) { listBox1.Items.Add("H"); }
                    if (DirExistNotReparse("I:\\mas")) { listBox1.Items.Add("I"); }
                    if (DirExistNotReparse("J:\\mas")) { listBox1.Items.Add("J"); }
                    if (DirExistNotReparse("K:\\mas")) { listBox1.Items.Add("K"); }
                    if (DirExistNotReparse("L:\\mas")) { listBox1.Items.Add("L"); }
                    if (DirExistNotReparse("M:\\mas")) { listBox1.Items.Add("M"); }
                    if (DirExistNotReparse("N:\\mas")) { listBox1.Items.Add("N"); }
                    if (DirExistNotReparse("O:\\mas")) { listBox1.Items.Add("O"); }
                    if (DirExistNotReparse("P:\\mas")) { listBox1.Items.Add("P"); }
                    if (DirExistNotReparse("Q:\\mas")) { listBox1.Items.Add("Q"); }
                    if (DirExistNotReparse("R:\\mas")) { listBox1.Items.Add("R"); }
                    if (DirExistNotReparse("S:\\mas")) { listBox1.Items.Add("S"); }
                    if (DirExistNotReparse("T:\\mas")) { listBox1.Items.Add("T"); }
                    if (DirExistNotReparse("U:\\mas")) { listBox1.Items.Add("U"); }
                    if (DirExistNotReparse("V:\\mas")) { listBox1.Items.Add("V"); }
                    if (DirExistNotReparse("W:\\mas")) { listBox1.Items.Add("W"); }
                    if (DirExistNotReparse("X:\\mas")) { listBox1.Items.Add("X"); }
                    if (DirExistNotReparse("Y:\\mas")) { listBox1.Items.Add("Y"); }
                    if (DirExistNotReparse("Z:\\mas")) { listBox1.Items.Add("Z"); }
                    if (File.Exists("B:\\sources\\boot.wim")) { listBox1.Items.Add("B"); }
                    if (File.Exists("C:\\sources\\boot.wim")) { listBox1.Items.Add("C"); }
                    if (File.Exists("D:\\sources\\boot.wim")) { listBox1.Items.Add("D"); }
                    if (File.Exists("E:\\sources\\boot.wim")) { listBox1.Items.Add("E"); }
                    if (File.Exists("F:\\sources\\boot.wim")) { listBox1.Items.Add("F"); }
                    if (File.Exists("G:\\sources\\boot.wim")) { listBox1.Items.Add("G"); }
                    if (File.Exists("H:\\sources\\boot.wim")) { listBox1.Items.Add("H"); }
                    if (File.Exists("I:\\sources\\boot.wim")) { listBox1.Items.Add("I"); }
                    if (File.Exists("J:\\sources\\boot.wim")) { listBox1.Items.Add("J"); }
                    if (File.Exists("K:\\sources\\boot.wim")) { listBox1.Items.Add("K"); }
                    if (File.Exists("L:\\sources\\boot.wim")) { listBox1.Items.Add("L"); }
                    if (File.Exists("M:\\sources\\boot.wim")) { listBox1.Items.Add("M"); }
                    if (File.Exists("N:\\sources\\boot.wim")) { listBox1.Items.Add("N"); }
                    if (File.Exists("O:\\sources\\boot.wim")) { listBox1.Items.Add("O"); }
                    if (File.Exists("P:\\sources\\boot.wim")) { listBox1.Items.Add("P"); }
                    if (File.Exists("Q:\\sources\\boot.wim")) { listBox1.Items.Add("Q"); }
                    if (File.Exists("R:\\sources\\boot.wim")) { listBox1.Items.Add("R"); }
                    if (File.Exists("S:\\sources\\boot.wim")) { listBox1.Items.Add("S"); }
                    if (File.Exists("T:\\sources\\boot.wim")) { listBox1.Items.Add("T"); }
                    if (File.Exists("U:\\sources\\boot.wim")) { listBox1.Items.Add("U"); }
                    if (File.Exists("V:\\sources\\boot.wim")) { listBox1.Items.Add("V"); }
                    if (File.Exists("W:\\sources\\boot.wim")) { listBox1.Items.Add("W"); }
                    if (File.Exists("X:\\sources\\boot.wim")) { listBox1.Items.Add("X"); }
                    if (File.Exists("Y:\\sources\\boot.wim")) { listBox1.Items.Add("Y"); }
                    if (File.Exists("Z:\\sources\\boot.wim")) { listBox1.Items.Add("Z"); }
                    if (Environment.UserName.Contains("markus"))
                    {
                        listBox1.Items.Clear();
                        listBox1.Visible = false;
                        mslbl.Text = "Versioon 0.4\nOriginaalne väljalase";
                        label1.Text = "Basic";
                        setcolour();
                        return;
                    }
                    if (listBox1.Items.Count > 2)
                    {
                        ultimate = true;
                    }
                    if (ultimate != true)
                    {
                        listBox1.SelectedIndex = 0;
                        listBox1.Items.Clear();
                        if (Directory.Exists("B:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("C:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("D:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("E:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("F:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("G:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("H:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("I:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("J:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("K:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("L:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("M:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("N:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("O:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("P:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("Q:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("R:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("S:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("T:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("U:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("V:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("W:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("X:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("Y:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                        if (Directory.Exists("Z:\\Documents and Settings\\Markus")) { listBox1.Items.Add("(basic)"); goto ohfuckit; }
                    ohfuckit:;
                        if (DirExistNotReparse("B:\\mas")) { listBox1.Items.Add("B"); }
                        if (DirExistNotReparse("C:\\mas")) { listBox1.Items.Add("C"); }
                        if (DirExistNotReparse("D:\\mas")) { listBox1.Items.Add("D"); }
                        if (DirExistNotReparse("E:\\mas")) { listBox1.Items.Add("E"); }
                        if (DirExistNotReparse("F:\\mas")) { listBox1.Items.Add("F"); }
                        if (DirExistNotReparse("G:\\mas")) { listBox1.Items.Add("G"); }
                        if (DirExistNotReparse("H:\\mas")) { listBox1.Items.Add("H"); }
                        if (DirExistNotReparse("I:\\mas")) { listBox1.Items.Add("I"); }
                        if (DirExistNotReparse("J:\\mas")) { listBox1.Items.Add("J"); }
                        if (DirExistNotReparse("K:\\mas")) { listBox1.Items.Add("K"); }
                        if (DirExistNotReparse("L:\\mas")) { listBox1.Items.Add("L"); }
                        if (DirExistNotReparse("M:\\mas")) { listBox1.Items.Add("M"); }
                        if (DirExistNotReparse("N:\\mas")) { listBox1.Items.Add("N"); }
                        if (DirExistNotReparse("O:\\mas")) { listBox1.Items.Add("O"); }
                        if (DirExistNotReparse("P:\\mas")) { listBox1.Items.Add("P"); }
                        if (DirExistNotReparse("Q:\\mas")) { listBox1.Items.Add("Q"); }
                        if (DirExistNotReparse("R:\\mas")) { listBox1.Items.Add("R"); }
                        if (DirExistNotReparse("S:\\mas")) { listBox1.Items.Add("S"); }
                        if (DirExistNotReparse("T:\\mas")) { listBox1.Items.Add("T"); }
                        if (DirExistNotReparse("U:\\mas")) { listBox1.Items.Add("U"); }
                        if (DirExistNotReparse("V:\\mas")) { listBox1.Items.Add("V"); }
                        if (DirExistNotReparse("W:\\mas")) { listBox1.Items.Add("W"); }
                        if (DirExistNotReparse("X:\\mas")) { listBox1.Items.Add("X"); }
                        if (DirExistNotReparse("Y:\\mas")) { listBox1.Items.Add("Y"); }
                        if (DirExistNotReparse("Z:\\mas")) { listBox1.Items.Add("Z"); }
                        if (File.Exists("B:\\sources\\boot.wim")) { listBox1.Items.Add("B"); }
                        if (File.Exists("C:\\sources\\boot.wim")) { listBox1.Items.Add("C"); }
                        if (File.Exists("D:\\sources\\boot.wim")) { listBox1.Items.Add("D"); }
                        if (File.Exists("E:\\sources\\boot.wim")) { listBox1.Items.Add("E"); }
                        if (File.Exists("F:\\sources\\boot.wim")) { listBox1.Items.Add("F"); }
                        if (File.Exists("G:\\sources\\boot.wim")) { listBox1.Items.Add("G"); }
                        if (File.Exists("H:\\sources\\boot.wim")) { listBox1.Items.Add("H"); }
                        if (File.Exists("I:\\sources\\boot.wim")) { listBox1.Items.Add("I"); }
                        if (File.Exists("J:\\sources\\boot.wim")) { listBox1.Items.Add("J"); }
                        if (File.Exists("K:\\sources\\boot.wim")) { listBox1.Items.Add("K"); }
                        if (File.Exists("L:\\sources\\boot.wim")) { listBox1.Items.Add("L"); }
                        if (File.Exists("M:\\sources\\boot.wim")) { listBox1.Items.Add("M"); }
                        if (File.Exists("N:\\sources\\boot.wim")) { listBox1.Items.Add("N"); }
                        if (File.Exists("O:\\sources\\boot.wim")) { listBox1.Items.Add("O"); }
                        if (File.Exists("P:\\sources\\boot.wim")) { listBox1.Items.Add("P"); }
                        if (File.Exists("Q:\\sources\\boot.wim")) { listBox1.Items.Add("Q"); }
                        if (File.Exists("R:\\sources\\boot.wim")) { listBox1.Items.Add("R"); }
                        if (File.Exists("S:\\sources\\boot.wim")) { listBox1.Items.Add("S"); }
                        if (File.Exists("T:\\sources\\boot.wim")) { listBox1.Items.Add("T"); }
                        if (File.Exists("U:\\sources\\boot.wim")) { listBox1.Items.Add("U"); }
                        if (File.Exists("V:\\sources\\boot.wim")) { listBox1.Items.Add("V"); }
                        if (File.Exists("W:\\sources\\boot.wim")) { listBox1.Items.Add("W"); }
                        if (File.Exists("X:\\sources\\boot.wim")) { listBox1.Items.Add("X"); }
                        if (File.Exists("Y:\\sources\\boot.wim")) { listBox1.Items.Add("Y"); }
                        if (File.Exists("Z:\\sources\\boot.wim")) { listBox1.Items.Add("Z"); }
                        if (listBox1.Items.Count == 0) { MessageBox.Show("Markuse asjad süsteemi sellest seadmest ei leitud. Et seadmeid juurutada, sisestage need Markuse arvutisse.", "Tegu pole Markuse arvutiga", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
                    }
                    try { listBox1.SelectedIndex = 1; listBox1.Visible = true; } catch { listBox1.Visible = false; }
                    listBox1.SelectedIndex = 0;
                    break;
                case 3:
                    fnt = new Font(button5.Font, FontStyle.Bold);
                    button5.Font = fnt;
                    button5.ForeColor = this.BackColor;
                    button5.BackColor = this.ForeColor;
                    if (desktopBackground.Image == null)
                    {
                        ReloadPreviews();
                    }
                    break;
                default:
                    MessageBox.Show("Probleem vahekaardi muutmisel... süüdista Erti", "Vahekaardi muutmine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        struct pageSelect
        {
            public int SelectedIndex;

            public void SelectPage()
            {
                int Selected = 0;
                Selected = this.SelectedIndex;
                foreach (Control c in Program.cf.Controls)
                {
                    if (c is Panel)
                    {
                        c.Visible = false;
                        if (c.Name == "pageSelect_" + (Selected+1).ToString())
                        {
                            c.Visible = true;
                        }
                    }
                }
                Program.cf.PageCheck();
            }
        }

        private void ReloadPreviews()
        {
            Bitmap ErrorImage = new Bitmap(640, 480);
            using (Graphics graphics = Graphics.FromImage(ErrorImage))
            {
                using (Font arialFont = new Font("Arial", 42))
                {
                    graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, 640, 480));
                    graphics.DrawString("Eelvaade pole saadaval", arialFont, Brushes.Red, new PointF(15, 200));
                }
            }

            if (File.Exists(Program.root + "\\bg_desktop.png"))
            {
                try
                {
                    desktopBackground.Image = Image.FromFile(Program.root + "\\bg_desktop.png");
                }
                catch (System.OutOfMemoryException)
                {
                    System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect();
                    desktopBackground.Image = ErrorImage;
                }
            }
            if (File.Exists(Program.root + "\\bg_login.png"))
            {
                try
                {
                    loginBackground.Image = Image.FromFile(Program.root + "\\bg_login.png");
                }
                catch (System.OutOfMemoryException)
                {
                    System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect();
                    loginBackground.Image = ErrorImage;
                }
            }
            if (File.Exists(Program.root + "\\bg_uncommon.png"))
            {
                try
                {
                    miniBackground.Image = Image.FromFile(Program.root + "\\bg_uncommon.png");
                }
                catch (System.OutOfMemoryException)
                {
                    System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect();
                    miniBackground.Image = ErrorImage;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = Program.root + "\\remas.bat";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            string devPrefix = "Markuse arvuti asjade";
            if (Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\masv"))
            {
                devPrefix = "Markuse virtuaalarvuti asjade";
            }
            else if (laptop)
            {
                devPrefix = "Markuse sülearvuti asjade";
            }
            infoLabel.Text = "Taaskäivitab "+devPrefix+" integratsiooniprogrammi ja Windows Explorer'i.";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            infoLabel.Text = "Siin kuvatakse teave, kui liigutate kursori teatud nupu peale.";
        }


        /// <summary>
        /// Builds a script that displays all Java binaries and versions for your system and marks it executable (Unix-like systems)
        /// </summary>
        private void BuildJavaFinder()
        {
            if (!File.Exists(Program.root + "/find_java.bat"))
            {

                var builder = new StringBuilder();
                var javaFinder = new StringWriter(builder)
                {
                    NewLine = "\r\n"
                };
                javaFinder.WriteLine("@echo off");
                javaFinder.WriteLine("setlocal EnableDelayedExpansion");
                javaFinder.WriteLine("for /f \"delims=\" %%a in ('where java') do (");
                javaFinder.WriteLine("\tset \"javaPath=\"%%a\"\"");
                javaFinder.WriteLine("\tfor /f \"tokens=3\" %%V in ('%%javaPath%% -version 2^>^&1 ^| findstr /i \"version\"') do (");
                javaFinder.WriteLine("\t\tset \"version=%%V\"");
                javaFinder.WriteLine("\t\tset \"version=!version:\"=!\"");
                javaFinder.WriteLine("\t\techo !javaPath:\"=!:!version!");
                javaFinder.WriteLine("\t)");
                javaFinder.WriteLine(")");
                javaFinder.WriteLine("endlocal");
                javaFinder.WriteLine("exit/b");
                File.WriteAllText(Program.root + "/find_java.bat", builder.ToString(), Encoding.ASCII);
            }
        }

        /// <summary>
        /// Finds the latest version of Java installed on your system, since if you install the Java SE version, Verifile may not work with it.
        /// </summary>
        /// <returns>Path to the latest Java binary found on your system</returns>
        private string FindJava()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string p = culture.NumberFormat.NumberDecimalSeparator;
            string latest_version = $"0{p}0";
            string latest_path = "";
            string interpreter = "cmd";
            Process pr = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = interpreter,
                    Arguments = "/c \"" + Program.root + "\\find_java.bat\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            pr.Start();
            while (!pr.StandardOutput.EndOfStream)
            {
                string[] path_version = (pr.StandardOutput.ReadLine() ?? ":").Replace(":\\", "_WINDRIVE\\").Split(':');
                string path = path_version[0].Replace("_WINDRIVE\\", ":\\");
                string version = path_version[1].Split('_')[0];
                version = version.Split('.')[0] + p + version.Split('.')[1];
                if (double.Parse(version, NumberStyles.Any) > double.Parse(latest_version, NumberStyles.Any))
                {
                    latest_path = path;
                    latest_version = version;
                }
            }
            return latest_path;
        }

        private string Verifile2()
        {
            BuildJavaFinder();
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FindJava(),
                    Arguments = "-jar " + Program.root + "\\verifile2.jar",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            p.Start();
            while (!p.StandardOutput.EndOfStream)
            {
                string line = p.StandardOutput.ReadLine() ?? "";
                return line.Split('\n')[0];
            }
            return "FAILED";
        }


        private bool Verifile()
        {
            return Verifile2() == "VERIFIED";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            tabControl1.SelectPage();
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            string saveprog = "";
            if (checkBox1.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            if (checkBox2.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            if (checkBox3.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            File.WriteAllText(Program.root + "\\mas.cnf", saveprog);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            string saveprog = "";
            if (checkBox1.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            if (checkBox2.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            if (checkBox3.Checked) { saveprog += "true;"; }
            else { saveprog += "false;"; }
            if (checkBox2.Checked) { button7.Enabled = true; }
            else { button7.Enabled = false; }
            File.WriteAllText(Program.root + "\\mas.cnf", saveprog);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            bool rng;
            rng = false;
            foreach (Process p in Process.GetProcesses())
            {
                if ((p.ProcessName == "Markuse arvuti integratsioonitarkvara.exe") || (p.ProcessName == "Markuse arvuti integratsioonitarkvara.EXE") || (p.ProcessName == "Markuse arvuti integratsioonitarkvara"))
                {
                    rng = true;
                    p.Kill();
                }
            }
            desktopBackground.Image.Dispose();
            loginBackground.Image.Dispose();
            miniBackground.Image.Dispose();
            //võta kasutusele ajutine taustapilt
            Process pr = new Process();
            pr.StartInfo.FileName = Program.root + "\\ChangeWallpaper.exe";
            pr.StartInfo.UseShellExecute = false;
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.Arguments = Program.root + "\\bg_login.png";
            pr.Start();
            pr.StartInfo.FileName = "cmd.exe";
            pr.StartInfo.Arguments = "/k move " + Program.root + "\\bg_desktop.png " + Program.root + "\\bg_desktop.temp";
            pr.Start();
            while (!File.Exists(Program.root + "\\bg_desktop.temp")) { }
            pr.StartInfo.Arguments = "/k move " + Program.root + "\\bg_uncommon.png " + Program.root + "\\bg_desktop.png";
            pr.Start();
            while (!File.Exists(Program.root + "\\bg_desktop.png")) { }
            pr.StartInfo.Arguments = "/k move " + Program.root + "\\bg_desktop.temp " + Program.root + "\\bg_uncommon.png";
            pr.Start();
            while (!File.Exists(Program.root + "\\bg_uncommon.png")) { }
            pr.StartInfo.Arguments = "";
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            pr.StartInfo.CreateNoWindow = false;
            pr.StartInfo.FileName = Program.root + "\\Markuse asjad\\Markuse arvuti integratsioonitarkvara.exe";
            pr.Start();
            ReloadPreviews();
            foreach (Process p in Process.GetProcesses())
            {
                if ((p.ProcessName == "cmd.exe") || (p.ProcessName == "cmd.EXE") || (p.ProcessName == "cmd"))
                {
                    p.Kill();
                }
                else if ((p.ProcessName == "conhost.exe") || (p.ProcessName == "conhost.EXE") || (p.ProcessName == "conhost"))
                {
                    p.Kill();
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { 
                if (File.Exists(Program.root + "\\events.txt"))
                {
                    Process.Start(Program.root + "\\events.txt");
                } else
                {
                    MessageBox.Show("Sündmuste faili ei eksisteeri", "Probleem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Ajastatud sündmused on keelatud", "Probleem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesktopBackground_DoubleClick(object sender, EventArgs e)
        {
            DesktopFunction();
           
        }
        private void DesktopFunction()
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                desktopBackground.Image.Dispose();
                foreach (Process p in Process.GetProcesses())
                {
                    if ((p.ProcessName == "Markuse arvuti integratsioonitarkvara.exe") || (p.ProcessName == "Markuse arvuti integratsioonitarkvara.EXE") || (p.ProcessName == "Markuse arvuti integratsioonitarkvara"))
                    {
                        p.Kill();
                    }
                }
                Process pr = new Process();
                pr.StartInfo.FileName = Program.root + "\\ChangeWallpaper.exe";
                pr.StartInfo.UseShellExecute = false;
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pr.StartInfo.CreateNoWindow = true;
                pr.StartInfo.Arguments = Program.root + "\\bg_login.png";
                pr.Start();
                pr.StartInfo.FileName = "cmd.exe";
                pr.StartInfo.Arguments = "/k move " + Program.root + "\\bg_desktop.png " + Program.root + "\\bg_desktop.temp";
                pr.Start();
                while (!File.Exists(Program.root + "\\bg_desktop.temp")) { }
                File.Copy(openImageDialog.FileName, Program.root + "\\bg_desktop.png");
                File.Delete(Program.root + "\\bg_desktop.temp");
                pr.StartInfo.Arguments = "";
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                pr.StartInfo.CreateNoWindow = false;
                pr.StartInfo.FileName = Program.root + "\\Markuse asjad\\Markuse arvuti integratsioonitarkvara.exe";
                pr.Start();
                if (File.Exists(Program.root + "\\bg_desktop.png"))
                {
                    desktopBackground.Image = Image.FromFile(Program.root + "\\bg_desktop.png");
                }
                foreach (Process p in Process.GetProcesses())
                {
                    if ((p.ProcessName == "cmd.exe") || (p.ProcessName == "cmd.EXE") || (p.ProcessName == "cmd"))
                    {
                        p.Kill();
                    }
                    else if ((p.ProcessName == "conhost.exe") || (p.ProcessName == "conhost.EXE") || (p.ProcessName == "conhost"))
                    {
                        p.Kill();
                    }
                }
            }
        }
        private void LoginBackground_Click(object sender, EventArgs e)
        {
            LoginFunction();
        }

        private void LoginFunction()
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                loginBackground.Image.Dispose();
                File.Delete(Program.root + "\\bg_login.png");
                File.Copy(openImageDialog.FileName, Program.root + "\\bg_login.png");
                if (File.Exists(Program.root + "\\bg_desktop.png"))
                {
                    loginBackground.Image = Image.FromFile(Program.root + "\\bg_login.png");
                }
            }
        }

        private void MiniBackground_Click(object sender, EventArgs e)
        {
            MiniFunction();
        }

        private void MiniFunction()
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                miniBackground.Image.Dispose();
                File.Delete(Program.root + "\\bg_uncommon.png");
                File.Copy(openImageDialog.FileName, Program.root + "\\bg_uncommon.png");
                if (File.Exists(Program.root + "\\bg_uncommon.png"))
                {
                    miniBackground.Image = Image.FromFile(Program.root + "\\bg_uncommon.png");
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            themeColor.Color = this.BackColor;
            if (themeColor.ShowDialog() == DialogResult.OK)
            {
                timer2.Enabled = false;
                File.WriteAllText(Program.root + "\\scheme.cfg", themeColor.Color.R.ToString() + ":" + themeColor.Color.G.ToString() + ":" + themeColor.Color.B.ToString() + ":;" + this.ForeColor.R + ":" + this.ForeColor.G + ":" + this.ForeColor.B + ":;");
                timer2.Enabled = true;
                button1.PerformClick();
                button5.PerformClick();
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            themeColor.Color = this.ForeColor;
            if (themeColor.ShowDialog() == DialogResult.OK)
            {
                timer2.Enabled = false;
                File.WriteAllText(Program.root + "\\scheme.cfg", this.BackColor.R + ":" + this.BackColor.G + ":" + this.BackColor.B + ":;" + themeColor.Color.R.ToString() + ":" + themeColor.Color.G.ToString() + ":" + themeColor.Color.B.ToString() + ":;");
                timer2.Enabled = true;
                button1.PerformClick();
                button5.PerformClick();
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            string saveprog = "";
            if (checkBox1.Checked == true) { saveprog += "true;"; }
            else if (checkBox1.Checked == false) { saveprog += "false;"; }
            if (checkBox2.Checked == true) { saveprog += "true;"; }
            else if (checkBox2.Checked == false) { saveprog += "false;"; }
            if (checkBox3.Checked == true) { saveprog += "true;"; }
            else if (checkBox3.Checked == false) { saveprog += "false;"; }
            File.WriteAllText(Program.root + "\\mas.cnf", saveprog);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (Directory.Exists(listBox1.SelectedItems[0].ToString() + @":\mas"))
            {
                Process.Start("explorer.exe", listBox1.SelectedItems[0].ToString() + @":\mas");
            }
            else
            {
                MessageBox.Show("Ei saanud kausta " + listBox1.SelectedItems[0].ToString() + @":\mas" + " avada");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start(ProgramFilesx86() + @"\GIGABYTE\@BIOS\FlashBios.exe");
        }

        static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private void pageSelect_4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Passwd p = new Passwd();
            p.Show();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            MarkuStation_Edit mse = new MarkuStation_Edit();
            mse.textBox1.Text = listView1.SelectedItems[0].Text;
            mse.textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text.Replace(";", "");
            mse.BackColor = this.BackColor;
            mse.ForeColor = this.ForeColor;
            if (mse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!((mse.textBox1.Text == ";") && ((mse.textBox2.Text == ";"))))
                {
                    listView1.SelectedItems[0].Text = mse.textBox1.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = mse.textBox2.Text + ";";
                    nameList.Items[listView1.SelectedIndices[0] + 1] = mse.textBox1.Text;
                    locationList.Items[listView1.SelectedIndices[0] + 1] = mse.textBox2.Text + ";";
                }
                else
                {
                    nameList.Items.RemoveAt(listView1.SelectedIndices[0] + 1);
                    locationList.Items.RemoveAt(listView1.SelectedIndices[0] + 1);
                    listView1.SelectedItems[0].Remove();
                }
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeys(e);
        }

        private void CheckKeys(KeyEventArgs e)
        {
            if (e.Alt == true)
            {
                label8.Text = "Töölaud (ALT + B)";
                label10.Text = "Logimisekraan (ALT + L)";
                label11.Text = "Miniversioon (ALT + M)";
                switch (e.KeyCode)
                {
                    case (Keys.B):
                        DesktopFunction();
                        break;
                    case (Keys.L):
                        LoginFunction();
                        break;
                    default:
                        MiniFunction();
                        break;
                }
            }
            else
            {
                label8.Text = "Töölaud";
                label10.Text = "Logimisekraan";
                label11.Text = "Miniversioon";
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (pageSelect_4.Visible)
            {
                CheckKeys(e);
            }
            CheckControl(e);
        }

        private void CheckControl(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Tab)
                {
                    if (e.Shift)
                    {
                        if (button1.Font.Bold)
                        {
                            button3.PerformClick();
                        }
                        else if (button3.Font.Bold)
                        {
                            button5.PerformClick();
                        }
                        else if (button5.Font.Bold)
                        {
                            button2.PerformClick();
                            label24.Text = "Vajutage sisestusklahvi olemasoleval üksusel, et seda muuta";
                        }
                        else if (button2.Font.Bold)
                        {
                            button1.PerformClick();
                        }
                    }
                    else
                    {
                        if (button1.Font.Bold)
                        {
                            button2.PerformClick();
                            label24.Text = "Vajutage sisestusklahvi olemasoleval üksusel, et seda muuta";
                        }
                        else if (button2.Font.Bold)
                        {
                            button5.PerformClick();
                        }
                        else if (button5.Font.Bold)
                        {
                            button3.PerformClick();
                        }
                        else if (button3.Font.Bold)
                        {
                            button1.PerformClick();
                        }
                    }
                }
            }
            if (e.Alt)
            {
                closeButton.Visible = false;
                button14.Visible = true;
                label25.Visible = true;
            }
            else
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    closeButton.Visible = true;
                }
                label25.Visible = false;
                button14.Visible = false;
            }
        }

        private void desktopBackground_Click(object sender, EventArgs e)
        {

        }

        private void button13_KeyDown(object sender, KeyEventArgs e)
        {
            CheckControl(e);
        }

        private void boostButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckControl(e);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckControl(e);
        }

        private void pageSelect_2_MouseMove(object sender, MouseEventArgs e)
        {
            label24.Text = "Topeltklõpsake, et muuta olemasolevat üksust.";
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            label24.Text = "Topeltklõpsake, et muuta olemasolevat üksust.";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alt - Kuva klaviatuuri otseteed\n" +
                            "Alt + F4 - Sulge aken\n" +
                            "Alt + H - Kuva kõik kiirklahvid\n" +
                            "Alt + A - Navigeeri avalehele\n" +
                            "Alt + M - Navigeeri MarkuStationi vahekaardile\n" +
                            "Alt + K - Ava konfiguratsiooni vahekaart\n" +
                            "Alt + T - Ava teabe vahekaart\n" +
                            "CTRL + TAB - Järgmine vahekaart\n" +
                            "CTRL + SHIFT + TAB - Eelmine vahekaart\n", "Kiirklahvid", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Image i = pictureBox1.BackgroundImage;
            i.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.BackgroundImage = i;
            pictureBox1.Refresh();
        }
    }
}
