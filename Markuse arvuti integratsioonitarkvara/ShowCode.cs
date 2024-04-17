using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Markuse_arvuti_integratsioonitarkvara
{
    public partial class ShowCode : Form
    {
        internal Color bg = Color.Black;
        internal Color fg = Color.White;
        private string devType = null;
        private string devIP = null;
        private int timeLeft = 80;
        public ShowCode()
        {
            InitializeComponent();
        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void ShowCode_Load(object sender, EventArgs e)
        {
            this.BackColor = bg;
            this.ForeColor = fg;
            string[] log_content;
            string fileName = @"C:\mas\maia\request_permission.maia";
            if (File.Exists(@"C:\mas\maia\request_permission.mai"))
            {
                fileName = @"C:\mas\maia\request_permission.mai";
            }
            log_content = File.ReadAllText(fileName).Split(';');
            devType = log_content[0];
            devIP = log_content[1];
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            string code = "";
            for (int i = 0; i < 8; i++)
            {
                code += chars[r.Next(0, chars.Length)];
            }
            codeLabel.Text = code;
            File.WriteAllText(string.Format(@"C:\mas\maia\{0}.{1}.maia", devType, devIP.Replace(".", "_")), GetHashString(devType + "__" + code));
            File.Delete(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(string.Format(@"C:\mas\maia\{0}.{1}.maia", devType, devIP.Replace(".", "_")));
            this.Close();
        }

        private void waitForClose_Tick(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\mas\maia\close_popup.maia"))
            {
                File.Delete(string.Format(@"C:\mas\maia\{0}.{1}.maia", devType, devIP.Replace(".", "_")));
                File.Delete(@"C:\mas\maia\close_popup.maia");
                this.Close();
            } else
            {
                timeLeft -= 1;
                timerLabel.Text = timeLeft.ToString();
                if (timeLeft == 0)
                {
                    File.Delete(string.Format(@"C:\mas\maia\{0}.{1}.maia", devType, devIP.Replace(".", "_")));
                    this.Close();
                }
            }
        }
    }
}
