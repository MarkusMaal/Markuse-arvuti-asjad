using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TöölauaMärkmed
{
    public partial class Note : Form
    {
        public int currentindex = 1;
        public string colorcode = "y";
        bool drag = false;
        int mousex;
        int mousey;
        public bool loader = true;
        bool nodelete = true;
        bool canclose = false;
        public static event Microsoft.Win32.SessionEndingEventHandler SessionEnding;

        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;
        public Note()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            if (currentindex != 1) { 
                if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                {
                    File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    File.Delete(@"C:\mas\notes\.setting_note_" + currentindex.ToString() + ".meta");
                }
            }
            this.Close();
        }

        private void Note_Load(object sender, EventArgs e)
        {
            if (loader) { firstTimer.Enabled = true; }
            if (colorcode == "y") { kollaneToolStripMenuItem.PerformClick(); }
            if (colorcode == "g") { rohelineToolStripMenuItem.PerformClick(); }
            if (colorcode == "b") { sinineToolStripMenuItem.PerformClick(); }
            if (colorcode == "w") { valgeToolStripMenuItem.PerformClick(); }
            if (colorcode == "gr") { hallToolStripMenuItem.PerformClick(); }
            if (colorcode == "r") { punaneToolStripMenuItem.PerformClick(); }
            if (colorcode == "l") { lillaToolStripMenuItem.PerformClick(); }
            if (colorcode == "br") { pruunToolStripMenuItem.PerformClick(); }
            label1.Text = "Märkmik " + currentindex.ToString();
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = Cursor.Position.X - this.Left;
            mousey = Cursor.Position.Y - this.Top;
            drag = true;
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            File.WriteAllText(@"C:\mas\notes\.setting_note_" + currentindex.ToString() + ".meta", this.Location.X.ToString() + ";" + this.Location.Y.ToString() + ";" + this.Size.Width.ToString() + ";" + this.Size.Height.ToString() + ";");
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mousey;
                this.Left = Cursor.Position.X - mousex;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            resizeTimer.Enabled = true;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            resizeTimer.Enabled = false;
            File.WriteAllText(@"C:\mas\notes\.setting_note_" + currentindex.ToString() + ".meta", this.Location.X.ToString() + ";" + this.Location.Y.ToString() + ";" + this.Size.Width.ToString() + ";" + this.Size.Height.ToString() + ";");
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            int xform = Cursor.Position.X - this.Location.X;
            int yform = Cursor.Position.Y - this.Location.Y;
            this.Size = new Size(xform, yform);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            { 
                label1.Text = "Märkmik " + currentindex.ToString() + " - " + textBox1.Text.Split('\n')[0].ToString();
            }
            else
            {
                label1.Text = "Märkmik " + currentindex.ToString();
            }
            string[] allcodes = { "y", "r", "g", "b", "gr", "br", "l" };
            foreach (string code in allcodes)
            {
                if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + code + ".txt"))
                {
                    try
                    { 
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + code + ".txt");
                    } catch { }
                }
            }
            File.WriteAllText(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode +".txt", textBox1.Text);
        }

        private void MuudaTaustavärviToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MuudaKirjatüüpiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noteFont.Font = textBox1.Font;
            if (noteFont.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = noteFont.Font;
            }
        }

        private void KollaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleGoldenrod;
            textBox1.BackColor = Color.PaleGoldenrod;
            UncheckColorChoices();
            kollaneToolStripMenuItem.Checked = true;
            if (this.colorcode == "y")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            else { nodelete = false; }
            this.colorcode = "y";
            InvertTitle();
        }

        private void InvertTitle()
        {
            label1.BackColor = Color.FromArgb(255 - this.BackColor.R, 255 - this.BackColor.G, 255 - this.BackColor.B);
        }

        private void PunaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightCoral;
            textBox1.BackColor = Color.LightCoral;
            UncheckColorChoices();
            punaneToolStripMenuItem.Checked = true;
            if (this.colorcode == "r")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            else { nodelete = false; }
            this.colorcode = "r";
            InvertTitle();
        }

        private void RohelineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleGreen;
            textBox1.BackColor = Color.PaleGreen;
            UncheckColorChoices();
            rohelineToolStripMenuItem.Checked = true;
            if (this.colorcode == "g")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            else { nodelete = false; }
            this.colorcode = "g";
            InvertTitle();
        }

        void UncheckColorChoices()
        {
            kollaneToolStripMenuItem.Checked = false;
            punaneToolStripMenuItem.Checked = false;
            rohelineToolStripMenuItem.Checked = false;
            sinineToolStripMenuItem.Checked = false;
            hallToolStripMenuItem.Checked = false;
            lillaToolStripMenuItem.Checked = false;
            valgeToolStripMenuItem.Checked = false;
            pruunToolStripMenuItem.Checked = false;
        }

        private void SinineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            textBox1.BackColor = Color.LightBlue;
            UncheckColorChoices();
            sinineToolStripMenuItem.Checked = true;
            if (this.colorcode == "b")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            this.colorcode = "b";
            InvertTitle();
        }

        private void ValgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            UncheckColorChoices();
            valgeToolStripMenuItem.Checked = true;

            if (this.colorcode == "w")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            this.colorcode = "w";
            InvertTitle();
        }

        private void HallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            textBox1.BackColor = Color.LightGray;
            UncheckColorChoices();
            hallToolStripMenuItem.Checked = true;
            if (this.colorcode == "gr")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            this.colorcode = "gr";
            InvertTitle();
        }

        private void PruunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Tan;
            textBox1.BackColor = Color.Tan;
            UncheckColorChoices();
            pruunToolStripMenuItem.Checked = true;
            if (this.colorcode == "br")
            {
                if (nodelete == false)
                { 
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            this.colorcode = "br";
            InvertTitle();
        }

        private void LillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Thistle;
            textBox1.BackColor = Color.Thistle;
            UncheckColorChoices();
            lillaToolStripMenuItem.Checked = true;
            if (this.colorcode == "l")
            {
                if (nodelete == false)
                {
                    if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                    {
                        File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    }
                }
                nodelete = false;
            }
            this.colorcode = "l";
            InvertTitle();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Note newnote = new Note();
            Program.activeindex += 1;
            newnote.currentindex = Program.activeindex;
            newnote.loader = false;
            newnote.Show();
        }

        private void Label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Green;
            label3.BackColor = Color.Lime;
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Green;
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Maroon;
            label2.BackColor = Color.Red;
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Maroon;
        }

        private void FirstTimer_Tick(object sender, EventArgs e)
        {

            foreach (string filename in Directory.GetFiles(@"C:\mas\notes"))
            {
                if (filename.Contains(".setting"))
                {
                    continue;
                }
                if (filename.Contains("note_"))
                {
                    int fileindex = Convert.ToInt32(filename.Split('_')[1].Replace(".txt", ""));
                    string colortype = filename.Split('_')[2].ToString().Replace(".txt", "");
                    string[] points = File.ReadAllText(@"C:\mas\notes\.setting_note_" + fileindex.ToString() + ".meta").Trim().Split(';');
                    if (fileindex == 1)
                    {
                        colorcode = colortype;
                        textBox1.Text = File.ReadAllText(@"C:\mas\notes\note_" + fileindex.ToString() + "_" + colortype + ".txt");
                        textBox1.Select(0, 0);
                        this.Location = new Point(Convert.ToInt32(points[0]), Convert.ToInt32(points[1]));
                        this.Size = new Size(Convert.ToInt32(points[2]), Convert.ToInt32(points[3]));
                    }
                    else
                    {
                        Note newnote = new Note();
                        newnote.colorcode = colortype;
                        newnote.currentindex = fileindex;
                        newnote.loader = false;
                        newnote.Location = new Point(Convert.ToInt32(points[0]), Convert.ToInt32(points[1]));
                        newnote.Size = new Size(Convert.ToInt32(points[2]), Convert.ToInt32(points[3]));
                        if (fileindex > Program.activeindex) { Program.activeindex = fileindex; }
                        newnote.textBox1.Text = File.ReadAllText(@"C:\mas\notes\note_" + fileindex.ToString() + "_" + colortype + ".txt");
                        newnote.textBox1.Select(0, 0);
                        newnote.Show();
                    }
                }
            }
            nodelete = true;
            if (colorcode == "y") { kollaneToolStripMenuItem.PerformClick(); }
            if (colorcode == "g") { rohelineToolStripMenuItem.PerformClick(); }
            if (colorcode == "b") { sinineToolStripMenuItem.PerformClick(); }
            if (colorcode == "w") { valgeToolStripMenuItem.PerformClick(); }
            if (colorcode == "gr") { hallToolStripMenuItem.PerformClick(); }
            if (colorcode == "r") { punaneToolStripMenuItem.PerformClick(); }
            if (colorcode == "l") { lillaToolStripMenuItem.PerformClick(); }
            if (colorcode == "br") { pruunToolStripMenuItem.PerformClick(); }
            nodelete = false;
            firstTimer.Enabled = false;
        }

        private void Note_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown)
            {
                canclose = true;
            }
            if (currentindex == 1)
            { 
                if (canclose)
                {
                    e.Cancel = false;
                }
                if (!canclose)
                {
                    e.Cancel = true;
                    MessageBox.Show("Esimest märget ei saa kustutada. Et programm sulgeda, kasutage vastavat valikut arvuti integratsiooniprogrammis.", "Kustutamine ebaõnnestus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                e.Cancel = false;
            }
               
        }

        private void CheckClose_Tick(object sender, EventArgs e)
        {
            if (File.Exists("C:\\mas\\closenote.log"))
            {
                if (currentindex == 1)
                { 
                    canclose = true;
                    File.Delete(@"C:\mas\closenote.log");
                    this.Close();
                }
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                systemShutdown = true;
            }

            // If this is WM_QUERYENDSESSION, the closing event should be  
            // raised in the base WndProc.  
            base.WndProc(ref m);

        } //WndProc   

        private void UusMärgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note newnote = new Note();
            Program.activeindex += 1;
            newnote.currentindex = Program.activeindex;
            newnote.loader = false;
            newnote.Show();
        }

        private void KustutaSeeMärgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentindex != 1)
            {
                if (File.Exists(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt"))
                {
                    File.Delete(@"C:\mas\notes\note_" + currentindex.ToString() + "_" + colorcode + ".txt");
                    File.Delete(@"C:\mas\notes\.setting_note_" + currentindex.ToString() + ".meta");
                }
            }
            this.Close();
        }

        private void Checkirunning_Tick(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\mas\irunning.log"))
            {
                this.TopMost = true;
                noirunning.Enabled = true;
                checkirunning.Enabled = false;
            }
        }

        private void Noirunning_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\mas\irunning.log"))
            {
                this.TopMost = false;
                checkirunning.Enabled = true;
                noirunning.Enabled = false;
            }
        }
    }
}
