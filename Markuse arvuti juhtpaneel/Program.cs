using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Markuse_arvuti_juhtpaneel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static controlForm cf = new controlForm();
        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas";
        readonly public static string[] whitelistedHashes = { "B881FBAB5E73D3984F2914FAEA743334D1B94DFFE98E8E1C4C8C412088D2C9C2" };
        [STAThread]
        static void Main()
        {
            if (!CheckVerifileTamper())
            {
                return;
            }
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(cf);
        }


        private static bool CheckVerifileTamper()
        {
            if (!File.Exists(Program.root + "\\verifile2.jar"))
            {
                MessageBox.Show("Verifile 2.0 tarkvara (verifile2.jar) ei ole Markuse asjade juurkaustas.\n\nVeakood: VF_MISSING", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string hash = "";
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(Program.root + "\\verifile2.jar"))
                {
                    hash = BitConverter.ToString(sha256.ComputeHash(stream));
                }
            }
            if (!Program.whitelistedHashes.Contains(hash.Replace("-", "")))
            {
                MessageBox.Show("Arvuti püsivuskontrolli käivitamine nurjus. Põhjus: Verifile 2.0 räsi ei ole sobiv.", "Markuse asjad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
