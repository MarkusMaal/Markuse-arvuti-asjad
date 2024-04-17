using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace FlashUnlock
{
    public partial class FlashDevices : Form
    {
        public FlashDevices()
        {
            InitializeComponent();
        }

        private void FlashDevices_Load(object sender, EventArgs e)
        {
            foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
            {
                string DevID = (string)device.GetPropertyValue("PNPDeviceID").ToString().Split('&')[3].Split('\\')[1];

                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (ManagementObject disk in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                    + partition["DeviceID"]
                                    + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        comboBox1.Items.Add(disk["Name"] + "\\ (ID: " + DevID + ")");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\mas\flash_authenticate", comboBox1.Items[comboBox1.SelectedIndex].ToString().Split('(')[1].Split(' ')[1].Replace(")", ""));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
