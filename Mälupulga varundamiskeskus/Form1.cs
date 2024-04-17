using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mälupulga_varundamiskeskus
{
    public partial class Form1 : Form
    {
        backupClass bc = new backupClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char letter in alphabet)
            {
                if (System.IO.File.Exists(letter.ToString() + ":\\E_INFO\\edition.txt"))
                {
                    bc.letter = letter;
                }
            }
        }

        private void WhatStuff_CheckedChanged(object sender, EventArgs e)
        {
            bc.stuff = whatStuff.Checked;
        }

        private void WhatBatch_CheckedChanged(object sender, EventArgs e)
        {
            bc.batch = whatBatch.Checked;
        }

        private void WhatYUMI_CheckedChanged(object sender, EventArgs e)
        {
            bc.yumi = whatYUMI.Checked;
        }

        private void WhereBrowse_Click(object sender, EventArgs e)
        {
            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                whereLocation.Text = browseDialog.SelectedPath;
            }
        }

        private void WhereLocation_TextChanged(object sender, EventArgs e)
        {
            bc.location = browseDialog.SelectedPath;
        }

        private void MainStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            bc.ShowDialog();
            this.Show();
        }
    }
}
