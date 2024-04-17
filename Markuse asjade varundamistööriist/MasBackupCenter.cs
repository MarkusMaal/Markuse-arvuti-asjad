using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Markuse_asjade_varundamistööriist
{
    public partial class MasBackupCenter : Form
    {
        List<ListViewItem> folders = new();
        string source = "D:\\";
        string destination = "E:\\";
        int progress = 0;
        string cfile = "";
        bool end = false;
        public MasBackupCenter()
        {
            InitializeComponent();
        }

        private void CollectFolders()
        {
            int lenfolders = new DirectoryInfo(source).GetDirectories().Length;
            int i = 0;
            foreach (DirectoryInfo di in new DirectoryInfo(source).GetDirectories())
            {
                ListViewItem li = new ListViewItem();
                li.Text = di.FullName;
                li.SubItems.Add("Kaust");
                try
                {
                    long bytes = (long)0;
                    bool synced = true;
                    foreach (FileInfo fi in di.EnumerateFiles("*.*", SearchOption.AllDirectories))
                    {
                        bytes += fi.Length;
                        cfile = fi.DirectoryName;
                        if (File.Exists(destination + fi.FullName.Substring(3)))
                        {
                            FileInfo backupfile = new FileInfo(destination + fi.FullName.Substring(3));
                            if ((backupfile.Length != fi.Length) || (backupfile.LastWriteTime != fi.LastWriteTime))
                            {
                                synced = false;
                            }
                        }
                    }
                    if (synced)
                    {
                        li.BackColor = Color.Lime;
                    } else
                    {
                        li.BackColor = Color.Yellow;
                    }
                    if (!Directory.Exists(destination + di.FullName.Substring(3)))
                    {
                        li.BackColor = Color.Red;
                    }
                    li.SubItems.Add(ConvertSize(bytes));
                } catch
                {
                    i++;
                    progress = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(lenfolders)) * 100);
                    continue;
                }
                //li.BackColor = Color.Red;
                i++;
                progress = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(lenfolders)) * 100);
                folders.Add(li);
            }
            end = true;
        }

        static string ConvertSize(long bytes)
        {
            if (bytes / Math.Pow(1024, 6) >= 1)
            {
                return Math.Round(bytes / Math.Pow(1024, 6), 2).ToString() + "EB";
            }
            else if (bytes / Math.Pow(1024, 5) >= 1)
            {
                return Math.Round(bytes / Math.Pow(1024, 5), 2).ToString() + "PB";
            }
            else if (bytes / Math.Pow(1024, 4) >= 1)
            {
                return Math.Round(bytes / Math.Pow(1024, 4), 2).ToString() + "TB";
            }
            else if (bytes / Math.Pow(1024, 3) >= 1)
            {
                return Math.Round(bytes / Math.Pow(1024, 3), 2).ToString() + "GB";
            }
            else if (bytes / Math.Pow(1024, 2) >= 1)
            {
                return Math.Round(bytes / Math.Pow(1024, 2), 2).ToString() + "MB";
            }
            else if (bytes / 1024 >= 1)
            {
                return Math.Round(Convert.ToDouble(bytes) / 1024, 2).ToString() + "kB";
            } 
            else
            {
                return bytes.ToString() + " baiti";
            }
        }
        private void MasBackupCenter_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(destination))
            {
                MessageBox.Show("Varundusmeediumit pole sisestatud.\n\nMarkuse asjade varundused on salvestatud eraldi andmekandjale. Sulgege arvuti ning sisestage kõvaketas, et seda programmi kasutada.", "Varundamise tööriist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listView1.Items.Clear();
            ThreadStart ts = new ThreadStart(CollectFolders);
            Thread t = new Thread(ts);
            t.Start();
            progressUpdate.Enabled = true;
        }

        private void progressUpdate_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progress;
            label2.Text = "Kausta analüüsimine: \"" + cfile + "\"";
            if (end)
            {
                progressUpdate.Enabled = false;
                foreach (ListViewItem li in folders)
                {
                    listView1.Items.Add(li);
                }
                listView1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = false;
                button1.Enabled = true;
            }
        }
    }
}
