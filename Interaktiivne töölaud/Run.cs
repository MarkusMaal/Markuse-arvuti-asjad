using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interaktiivne_töölaud
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.ToLower().StartsWith("explorer"))
            { 
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void Run_Load(object sender, EventArgs e)
        {
            this.Location = new Point(5, Screen.PrimaryScreen.WorkingArea.Height - Height);
        }
    }
}
