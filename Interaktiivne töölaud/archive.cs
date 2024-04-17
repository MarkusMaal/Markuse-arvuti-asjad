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
namespace Interaktiivne_töölaud
{
    public partial class archive : Form
    {
        public archive()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.officeroom.label1.Text = "Kaust töölaud";
            if (Environment.UserName != "Külaline")
            {
                if (!System.IO.File.Exists(Environment.GetEnvironmentVariable("USERPROFILE").ToString() + "\\Desktop\\Peida need töölauaikoonid.lnk"))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\organize_desktop.bat";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    Program.officeroom.webBrowser1.Visible = false;
                    Program.officeroom.PreloadTimer.Enabled = true;
                    Program.officeroom.label1.Text = "Palun oota...";
                }
            }
            Program.officeroom.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.officeroom.LoadFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Minu dokumendid", Program.officeroom);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.officeroom.LoadFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Google arhiivid", "Google+ arhiiv", Program.officeroom);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            string specialdrive = "C:";
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            foreach (char letter in letters)
            {
                if (System.IO.Directory.Exists(letter.ToString() + ":\\.userdata"))
                {
                    specialdrive = letter.ToString() + ":";
                }
            }
            Program.officeroom.LoadFolder(specialdrive + "\\Varukoopiad", "Varukoopiad", Program.officeroom);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.officeroom.LoadFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Pildid", Program.officeroom);
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            string specialdrive = "C:";
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            foreach (char letter in letters)
            {
                if (System.IO.Directory.Exists(letter.ToString() + ":\\.userdata"))
                {
                    specialdrive = letter.ToString() + ":";
                }
            }
            Program.officeroom.LoadFolder(specialdrive + "\\Markuse videod", "Markuse videod", Program.officeroom);
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            if (Environment.UserName == "Külaline")
            {
                button6.Visible = false;
                button3.Visible = false;
                button2.Visible = false;
            }
            foreach (System.IO.DriveInfo di in System.IO.DriveInfo.GetDrives())
            {
                if (di.IsReady == true)
                {
                    listView1.Items.Add(di.RootDirectory.Name.Replace("\\", ""));
                    if (di.VolumeLabel != "")
                    {
                        if (di.DriveType == System.IO.DriveType.CDRom)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Optiline)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Fixed)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel.Replace("MARKUSPULK", "Markuse mälupulk") + " (Sisemine)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Removable)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel.Replace("MARKUSPULK", "Markuse mälupulk") + " (Eemaldatav)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Network)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Võrk)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Ram)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Mälu)");
                        }
                        else
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Muu)");
                        }
                    } else
                    {
                        if (di.DriveType == System.IO.DriveType.CDRom)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu optiline meedium");
                        }
                        else if (di.DriveType == System.IO.DriveType.Fixed)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu siseketas");
                        }
                        else if (di.DriveType == System.IO.DriveType.Removable)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu irdketas");
                        }
                        else if (di.DriveType == System.IO.DriveType.Network)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu võrgudraiv");
                        }
                        else if (di.DriveType == System.IO.DriveType.Ram)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu mäludraiv");
                        }
                        else
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu tundmatu draiv");
                        }
                    }
                    if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024 / 1024, 2).ToString() + " TB");
                    }
                    else if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024, 1).ToString() + " GB");
                    }
                    else if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024, 2).ToString() + " MB");
                    }
                    else
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024, 2).ToString() + " KB");
                    }
                }
            }
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            this.Hide();
            if (listView1.SelectedItems[0].SubItems[1].Text.Contains(" ("))
            { 
                Program.officeroom.LoadFolder(listView1.SelectedItems[0].Text + "\\", listView1.SelectedItems[0].SubItems[1].Text.Split('(')[0] + "(" + listView1.SelectedItems[0].SubItems[0].Text + ")", Program.officeroom);
            } else
            {
                Program.officeroom.LoadFolder(listView1.SelectedItems[0].Text + "\\", listView1.SelectedItems[0].SubItems[1].Text + " (" + listView1.SelectedItems[0].SubItems[0].Text + ")", Program.officeroom);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int n = 0;
            if (listView1.SelectedItems.Count > 0)
            { 
                n = listView1.SelectedItems[0].Index;
            }
            listView1.Items.Clear();
            foreach (System.IO.DriveInfo di in System.IO.DriveInfo.GetDrives())
            {
                if (di.IsReady == true)
                {
                    listView1.Items.Add(di.RootDirectory.Name.Replace("\\", ""));
                    if (di.VolumeLabel != "")
                    {
                        if (di.DriveType == System.IO.DriveType.CDRom)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Optiline)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Fixed)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel.Replace("MARKUSPULK", "Markuse mälupulk") + " (Sisemine)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Removable)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel.Replace("MARKUSPULK", "Markuse mälupulk") + " (Eemaldatav)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Network)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Võrk)");
                        }
                        else if (di.DriveType == System.IO.DriveType.Ram)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Mälu)");
                        }
                        else
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(di.VolumeLabel + " (Muu)");
                        }
                    }
                    else
                    {
                        if (di.DriveType == System.IO.DriveType.CDRom)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu optiline meedium");
                        }
                        else if (di.DriveType == System.IO.DriveType.Fixed)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu siseketas");
                        }
                        else if (di.DriveType == System.IO.DriveType.Removable)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu irdketas");
                        }
                        else if (di.DriveType == System.IO.DriveType.Network)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu võrgudraiv");
                        }
                        else if (di.DriveType == System.IO.DriveType.Ram)
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu mäludraiv");
                        }
                        else
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add("Nimetu tundmatu draiv");
                        }
                    }
                    if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024 / 1024, 2).ToString() + " TB");
                    }
                    else if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024 / 1024, 1).ToString() + " GB");
                    }
                    else if (Convert.ToDouble(di.TotalSize.ToString()) / 1024 >= 1024)
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024 / 1024, 2).ToString() + " MB");
                    }
                    else
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(Math.Round(Convert.ToDouble(di.TotalSize.ToString()) / 1024, 2).ToString() + " KB");
                    }
                }
            }
            listView1.Items[n].Selected = true;
            listView1.Items[n].Focused = true;
            listView1.EnsureVisible(n);
        }

        private void Archive_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
            listView1.Visible = true;
        }

        private void ListView1_MouseLeave(object sender, EventArgs e)
        {
            listView1.Visible = false;
        }

        private void Archive_MouseMove(object sender, MouseEventArgs e)
        {
            listView1.Visible = false;
        }

        private void desktopLevel_Tick(object sender, EventArgs e)
        {
            if (this.Visible) { this.SendToBack(); }
        }
    }
}
