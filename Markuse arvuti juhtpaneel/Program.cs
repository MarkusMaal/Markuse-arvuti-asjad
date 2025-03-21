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
        readonly public static string[] whitelistedHashes = { "B881FBAB5E73D3984F2914FAEA743334D1B94DFFE98E8E1C4C8C412088D2C9C2", "A0B93B23301FC596789F83249A99F507A9DA5CBA9D636E4D4F88676F530224CB", "B08AABB1ED294D8292FDCB2626D4B77C0A53CB4754F3234D8E761E413289057F", "8076CF7C156D44472420C1225B9F6ADB661E3B095E29E52E3D4E8598BB399A8F" };
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
