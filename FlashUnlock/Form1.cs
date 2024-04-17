using System;
using System.Collections.Generic;
using System.Management;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Net;

namespace FlashUnlock
{
    public partial class Form1 : Form
    {
        bool authenticated = false;
        List<Filler> fillers = new List<Filler>();
        string DeviceAuthID = "";
        string cdrive = Path.GetPathRoot(Environment.SystemDirectory);
        int[] theme_data;
        int[] bg_data;
        bool dev_listen_ids = false;
        bool dev_killswitch = false;
        bool disable_post_unlock = false;
        bool first_time = true;
        List<String> last_devices = new List<String>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                theme_data = File.ReadAllText(cdrive + "\\mas\\scheme.cfg").Split(';')[1].Split(':').Take(3).Select(int.Parse).ToArray();
                bg_data = File.ReadAllText(cdrive + "\\mas\\scheme.cfg").Split(';')[0].Split(':').Take(3).Select(int.Parse).ToArray();
                this.ForeColor = Color.FromArgb(theme_data[0], theme_data[1], theme_data[2]);
                this.BackColor = Color.FromArgb(bg_data[0], bg_data[1], bg_data[2]);
                this.BackgroundImage = Image.FromFile(string.Format("{0}\\mas\\bg_common.png", cdrive));
            } catch
            {
                MessageBox.Show("See ei ole Markuse asjade süsteemi nõutele vastav arvuti.", "Programm ei tööta selles arvutis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (File.Exists(string.Format("{0}\\mas\\flash_authenticate", cdrive)))
            {
                DeviceAuthID = File.ReadAllText(string.Format("{0}\\mas\\flash_authenticate", cdrive));
                flashFinder.Enabled = true;
                this.Hide();
            }
            else
            {
                this.Hide();
                MessageBox.Show("Ühtegi mälupulka pole kalibreeritud. Palun valige järgmisest menüüst mälupulk, mida soovite kasutada", "Ei saa lukustada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FlashDevices fd = new FlashDevices();

                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DeviceAuthID = File.ReadAllText(string.Format("{0}\\mas\\flash_authenticate", cdrive));
                    flashFinder.Enabled = true;
                }
                else
                {
                    this.Close();
                }
            }
            if (Screen.AllScreens.Length > 1)
            {
                for (int i = 0; i < Screen.AllScreens.Length - 1; i++)
                {
                    fillers.Add(new Filler());
                    fillers[i].ForeColor = this.ForeColor;
                    fillers[i].BackColor = this.BackColor;
                    fillers[i].label1.Text = "Ekraan " + (i + 2).ToString() + " lukustatud";
                    fillers[i].BackgroundImage = this.BackgroundImage;
                }
            }
        }

        private void flashFinder_Tick(object sender, EventArgs e)
        {
            ManagementObjectSearcher device_searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            authenticated = false;
            bool skip_devs = false;
            List<string> new_devices = new List<string>();
            foreach (ManagementObject usb_device in device_searcher.Get())
            {
                new_devices.Add(usb_device.Properties["DeviceID"].Value.ToString().Split('\\')[2]);
                if (usb_device.Properties["DeviceID"].Value.ToString().Split('\\')[2] == DeviceAuthID)
                {
                    authenticated = true;
                    Cursor.Show();
                    if (fillers.Count > 0)
                    {
                        foreach (Filler filler in fillers)
                        {
                            if (filler.Visible)
                            {
                                filler.Hide();
                            }
                        }
                    }
                    this.Hide();
                }
            }
            killTaskmgr.Enabled = !authenticated;
            if (!authenticated)
            {
                this.Show();
                Cursor.Position = new Point(0, 0);
                Cursor.Hide();

                if (fillers.Count > 0)
                {
                    for (int i = 0; i < fillers.Count; i++ )
                    {
                        Filler filler = fillers[i];
                        if (!filler.Visible)
                        {
                            filler.Location = Screen.AllScreens[i+1].WorkingArea.Location;
                            filler.Show();
                        }
                    }
                }
                var processes = Process.GetProcessesByName("explorer");
                if (processes.Length > 0)
                {
                    Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
                }
                clockLabel.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" +  DateTime.Now.Minute.ToString().PadLeft(2, '0');
                if (first_time || !dev_killswitch)
                {
                    label1.Text = "Autentimiseks sisestage Markuse mälupulk...";
                }
                if ((new_devices.Count > last_devices.Count) && (last_devices.Count > 0))
                {
                    label1.Text = "Vale seade, proovige uuesti";
                    last_devices.Clear();
                    foreach (string device in new_devices)
                    {
                        last_devices.Add(device);
                    }
                } else if ((last_devices.Count == 0) || (last_devices.Count > new_devices.Count))
                {
                    if (last_devices.Count > new_devices.Count)
                    {
                        label1.Text = "Eemaldasite seadme";
                    }
                    last_devices.Clear();
                    foreach (string device in new_devices)
                    {
                        last_devices.Add(device);
                    }
                }
                first_time = false;
            } else
            {
                label1.Text = "Lahti lukustamine...";
                var processes = Process.GetProcessesByName("explorer");
                if (processes.Length == 0)
                {
                    Process.Start(@"C:\Windows\explorer.exe");
                }
                if (disable_post_unlock)
                {
                    this.Close();
                }
            }
            if (File.Exists(@"C:\mas\stop_authenticate") && authenticated)
            {
                File.Delete(@"C:\mas\stop_authenticate");
                this.Close();
            } else if (File.Exists(@"C:\mas\stop_authenticate"))
            {
                label1.Text = "Mälupulga lukustust ei saa välja lülitada enne autentimist!";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!authenticated)
            {
                e.Cancel = true;
            }
        }

        private void killTaskmgr_Tick(object sender, EventArgs e)
        {
            var taskmgrs = Process.GetProcessesByName("Taskmgr");
            if (taskmgrs.Length > 0)
            {
                Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM Taskmgr.exe");
            }
            this.TopMost = !this.TopMost;
            this.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) && dev_killswitch)
            {
                killTaskmgr.Enabled = false;
                this.TopMost = false;
                this.SendToBack();
                label1.Text = "Arendaja režiim aktiveeriti";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                label1.Text = "Te ei ole arendaja, killswitchi ignoreeriti";
            }
            else if (e.KeyCode == Keys.M)
            {
                label1.Text = GetLocalIPAddress();
            }
            else if (e.KeyCode == Keys.T)
            {
                if (killTaskmgr.Enabled)
                {
                    label1.Text = "Tegumihalduri blokk on aktiivne";
                }
                else
                {
                    label1.Text = "Tegumihalduri blokk pole aktiivne";
                }
            } else if (e.KeyCode == Keys.E)
            {
                var processes = Process.GetProcessesByName("explorer");
                if (processes.Length == 0)
                {
                    label1.Text = "Windowsi liides on peatatud";
                } else
                {
                    label1.Text = "Windowsi liides on avatud";
                }
            } else if (e.KeyCode == Keys.D)
            {
                if (disable_post_unlock)
                {
                    label1.Text = "Tavaline avamismeetod";
                }
                else
                {
                    label1.Text = "Keela pärast avamist";
                }
                disable_post_unlock = !disable_post_unlock;
            }
        }

        public static string GetLocalIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return "IP aadress: " + localIP;
        }
    }
}
