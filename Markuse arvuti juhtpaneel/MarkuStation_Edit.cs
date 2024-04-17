using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Markuse_arvuti_juhtpaneel
{
    public partial class MarkuStation_Edit : Form
    {
        public MarkuStation_Edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (locationDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = locationDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void MarkuStation_Edit_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas olete kindel, et soovite jätkata?\nSeda toimingut ei saa tagasi võtta.",
                                "Üksuse kustutamine",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes) {
                textBox1.Text = ";";
                textBox2.Text = ";";
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
