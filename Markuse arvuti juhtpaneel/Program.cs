using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Markuse_arvuti_juhtpaneel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static controlForm cf = new controlForm();
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(cf);
        }
    }
}
