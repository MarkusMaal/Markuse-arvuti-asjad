using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Markuse_arvuti_integratsioonitarkvara
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (System.IO.Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\masv"))
                {
                    //label1.Text = "markuse virtuaalarvuti asjad";
                    pictureBox1.Image = Properties.Resources.mas_vpc_full;
                }
                else if (!System.IO.Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas"))
                {
                    //label1.Text = "markuse asjad muudele seadmetele";
                }
                else
                {
                    //label1.Text = "markuse arvuti asjad";
                }
            }
        }
    }
}
