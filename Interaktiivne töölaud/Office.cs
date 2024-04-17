using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interaktiivne_töölaud
{
    public partial class Office: Form
    {
        private Button button5;
        private Button button1;
        private Button button2;
        public Label label1;
        private ToolTip InfoTip;
        private IContainer components;
        private Button button3;
        private Timer NavFlash;
        public Timer PreloadTimer;
        public Label label2;
        public WebBrowser webBrowser1;

        public Office()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Office));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NavFlash = new System.Windows.Forms.Timer(this.components);
            this.PreloadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(105, 106);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1070, 807);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1216, 471);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 46);
            this.button5.TabIndex = 6;
            this.button5.Text = "→";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(157, 919);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "→";
            this.InfoTip.SetToolTip(this.button1, "Edasi");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(109, 919);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "←";
            this.InfoTip.SetToolTip(this.button2, "Tagasi");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(104, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kaust töölaud";
            // 
            // InfoTip
            // 
            this.InfoTip.AutomaticDelay = 0;
            this.InfoTip.AutoPopDelay = 10000;
            this.InfoTip.InitialDelay = 1;
            this.InfoTip.ReshowDelay = 1;
            this.InfoTip.UseAnimation = false;
            this.InfoTip.UseFading = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 471);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 46);
            this.button3.TabIndex = 11;
            this.button3.Text = "←";
            this.InfoTip.SetToolTip(this.button3, "Dokumendid ja arhiiv");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 13;
            this.InfoTip.SetToolTip(this.label2, "Kell");
            // 
            // NavFlash
            // 
            this.NavFlash.Enabled = true;
            this.NavFlash.Tick += new System.EventHandler(this.NavFlash_Tick);
            // 
            // PreloadTimer
            // 
            this.PreloadTimer.Tick += new System.EventHandler(this.PreloadTimer_Tick);
            // 
            // Office
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.töölaud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 1005);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.webBrowser1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Office";
            this.ShowInTaskbar = false;
            this.Text = "Markuse arvuti töölaud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Office_FormClosing);
            this.Load += new System.EventHandler(this.Office_Load);
            this.VisibleChanged += new System.EventHandler(this.Office_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.inroom.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward == true)
            {
                webBrowser1.GoForward();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack == true)
            {
                webBrowser1.GoBack();
            }
        }

        private void Office_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString());
        }

        public void LoadFolder(string fldr, string title, Form f)
        {
            f.Hide();
            if(this.Visible == false) { this.Show(); }
            label1.Text = title;
            webBrowser1.Navigate(fldr);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack == false)
            {
                button2.Visible =  false;
            }
            else
            {
                button2.Visible =  true;
            }
            if (webBrowser1.CanGoForward == false)
            {
                button1.Visible =  false;
            }
            else
            {
                button1.Visible =  true;
            }
        }

        private void Office_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                Program.inroom.timer1.Enabled = true;
                webBrowser1.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.archiveroom.Show();
            this.Hide();
        }

        private void NavFlash_Tick(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\path.txt")) {
                string[] s;
                s = System.IO.File.ReadAllLines(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\path.txt");
                string a;
                a = s[0].ToString();
                webBrowser1.Navigate(a);
                System.IO.File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\path.txt");
            }
        }

        private void PreloadTimer_Tick(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            label1.Text = "Kaust töölaud";
            PreloadTimer.Enabled = false;
        }

        private void Office_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }
    }
}
