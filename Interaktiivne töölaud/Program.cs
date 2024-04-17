using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interaktiivne_töölaud
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool isGuest = !(System.IO.File.GetAccessControl("C:\\mas\\edition.txt").GetOwner(typeof(System.Security.Principal.NTAccount)).Value.ToString() == Environment.MachineName + "\\" + Environment.UserName);
        public static Inside inroom = new Inside();
        public static Form1 firstform = new Form1();
        public static Office officeroom = new Office();
        public static archive archiveroom = new archive();
        public static Windows winroom = new Windows();
        public static Playground play = new Playground();
        [STAThread]
        static void Main()
        {
            Application.Run(firstform);
        }
    }
}
