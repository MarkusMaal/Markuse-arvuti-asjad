using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace Markuse_arvuti_juhtpaneel
{
    public partial class Passwd : Form
    {
        int passes = 5;
        public Passwd()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (System.IO.File.Exists(Program.root + "\\‫‬‭‮‪‫‬‭‮5ke5.-‫‬‭‮‪‫‬‭‮"))
                {
                    string authkey = IncStr((textBox1.Text.Length - 126).ToString() + "M45" + String.Concat(textBox1.Text.Reverse()));
                    byte[] realkey = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(String.Concat(authkey.Reverse())));
                    string newhash = "";
                    foreach (byte b in realkey)
                    {
                        newhash += b.ToString("X2");
                    }
                    if (newhash == String.Concat(File.ReadAllText(Program.root + "\\‫‬‭‮‪‫‬‭‮5ke5.-‫‬‭‮‪‫‬‭‮").Reverse()))
                    {
                        File.WriteAllBytes(Environment.GetEnvironmentVariable("TEMP") + "\\rootimg.exe", Properties.Resources.RootImg);
                        File.WriteAllBytes(Environment.GetEnvironmentVariable("TEMP") + "\\JTR.exe", Properties.Resources.JTR);
                        File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\new.bat", Properties.Resources.startrooter);
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.GetEnvironmentVariable("TEMP") + "\\new.bat";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        Program.cf.Close();
                        this.Close();
                    } else
                    {
                        passes--;
                        label3.ForeColor = Color.Red;
                        resetColor.Enabled = true;
                        if (passes == 0)
                        {
                            textBox1.Dispose();
                            label3.Dispose();
                            MessageBox.Show("Kõik katsed on otsas. Programm sulgub nüüd.", "Paroolid ei ühti", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Program.cf.Close();
                        }
                        textBox1.Text = "";
                        label3.Text = "Teil on " + passes.ToString() + " katset õige parooli sisetamiseks. Kui sisestate vale parooli\nrohkem kui " + passes.ToString() + " korda, peate programmi taaskäivitama.";
                    }
                }
            }
        }

        static string IncStr(string host)
        {
            int inckey = 0;
            int incinckey = 1;
            string returnstring = "";
            int id = 0;
            foreach (char c in host)
            {
                char abc = c;
                for (int i = 0; i < inckey; i++)
                { 
                    abc++;
                }
                returnstring += abc.ToString();
                if ((id % 3) == 0)
                {
                    inckey++;
                } else
                {
                    inckey--;
                }
            }
            return returnstring;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetColor_Tick(object sender, EventArgs e)
        {
            resetColor.Enabled = false;
            label3.ForeColor = SystemColors.ControlText;
        }

        private void Passwd_Load(object sender, EventArgs e)
        {

        }
    }
}
