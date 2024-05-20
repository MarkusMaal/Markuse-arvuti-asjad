using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Markuse_asjade_juurutamise_tööriist
{
    public partial class Setup : Form
    {
        bool laptop = false;
        public bool vpc = false;



        public Setup()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            bool isRunningOnBattery = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline;
            if (isRunningOnBattery)
            {
                stuffLabel.Text = "markuse sülearvuti asjad";
                laptop = true;
            }
            string winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            WXCheck.Checked = winver.Contains("Windows 10") || winver.Contains("Windows 11") || winver.Contains("Windows 12") || winver.Contains("Windows 13") || winver.Contains("Windows 14") || winver.Contains("Windows 15");
            GPCheck.Checked = winver.ToUpper().Contains("PRO") || winver.ToUpper().Contains("ENTERPRISE") || winver.ToUpper().Contains("ULTIMATE");
            RMCheck.Checked = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Rainmeter");
            CSCheck.Checked = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\StartAllBack") || Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Open-Shell") || Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Classic-Shell");
            LTCheck.Checked = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\LiveTuner");
            RMCheck.Enabled = !RMCheck.Checked;
            CSCheck.Enabled = !CSCheck.Checked;
            LTCheck.Enabled = !LTCheck.Checked;
        }

        private void proRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            maiaCheck.Checked = proRadioButton.Checked;
            itCheck.Checked = proRadioButton.Checked;
            noteCheck.Checked = proRadioButton.Checked;
            optCheck.Checked = proRadioButton.Checked;

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            maiaCheck.Checked = proRadioButton.Checked;
            itCheck.Checked = proRadioButton.Checked;
            noteCheck.Checked = proRadioButton.Checked;
            optCheck.Checked = proRadioButton.Checked;
        }

        private void Setup_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void basicPlusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            optPanel.Visible = !basicPlusRadioButton.Checked;
        }

        private void blinkyTimer_Tick(object sender, EventArgs e)
        {
            if (label4.ForeColor == System.Drawing.Color.Black)
            {
                label4.ForeColor = Color.Red;
            } else
            {
                label4.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
