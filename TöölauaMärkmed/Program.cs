using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TöölauaMärkmed
{
    static class Program
    {
        public static int activeindex = 1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!args.Contains("-s"))
            { 
                Application.Run(new Note());
            } else
            {
                string[] configs = File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\mas.cnf").Split(';');
                if (configs.Length > 2)
                {
                    if (configs[2] == "true")
                    {
                        File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + @"\mas\noteopen.txt", "");
                        Application.Run(new Note());
                    } else
                    {
                        return;
                    }
                }
            }
        }
    }
}
