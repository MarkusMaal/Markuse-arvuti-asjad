using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Markuse_arvuti_integratsioonitarkvara
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Splash spl = new Splash();
        public static bool croot = false;
        public static bool showsplash = true;
        public static bool another = false;
        public static bool isGuest = !(System.IO.File.GetAccessControl("C:\\mas\\edition.txt").GetOwner(typeof(System.Security.Principal.NTAccount)).Value.ToString() == Environment.MachineName + "\\" + Environment.UserName);

        // Teise tuuma muutujad
        public static bool flashconnected = false;
        public static string flashletter = "A:";
        public static bool opticalconnect = false;
        public static string opticalname = "";

        [STAThread]
        static void Main(string[] args)
        {
            if (isGuest || (Environment.UserName == "Administrator"))
            {
                MessageBox.Show("Markuse arvuti integratsioonitarkvara ei toimi külaliskontodel.");
                return;
            }
            if (args.Length > 0) { 
                if (args.Contains("/root"))
                {
                    if (!args.Contains("/q")) { MessageBox.Show("Juurutamisprotseduuri alustamine..."); }
                    if (System.IO.Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas"))
                    {
                        if (!args.Contains("/q")) { MessageBox.Show("Viga: Arvuti on edukalt juurutatud."); }
                        if (!args.Contains("/q")) { MessageBox.Show("Selleks, et süsteemi taasjuurutada, kasutage palun /reroot argumenti"); }
                        Process pr = new Process();
                        pr.StartInfo.FileName = "taskkill.exe";
                        pr.StartInfo.Arguments = "/f /im \"Markuse arvuti integratsioonitarkvara.exe\"";
                        pr.StartInfo.CreateNoWindow = true;
                        pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pr.Start();
                        return;
                    } else
                    {
                        MessageBox.Show("Hetkel ei saa integratsiooniprogrammi kaudu arvutit algusest peale juurutada.");
                    }
                }
                if (args.Contains("/reroot"))
                {
                    foreach (Process p in Process.GetProcesses())
                    {
                        if (p.ProcessName == "JTR.exe" || p.ProcessName == "JTR.EXE" || p.ProcessName == "JTR")
                        { 
                            croot = true;
                        }
                    }
                    if (!croot)
                    { 
                        MessageBox.Show("Juurutamiseks kasutage taasjuurutamise tööriista. Ilma taasjuurutamise tööriistata juurutamine võib põhjustada kriitilisi probleeme.", "Ei saa taasjuurutada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    croot = false;
                }
            }
            int i = 0;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("Markuse arvuti integratsioonitarkvara") || p.ProcessName == "Markuse arvuti integratsioonitarkvara.EXE" || p.ProcessName == "Markuse arvuti integratsioonitarkvara")
                {
                    i++;
                }
            }
            if (i > 2)
            {
                MessageBox.Show("Markuse arvuti integratsiooniprogramm on juba avatud", "Tõrge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                croot = true;
                another = true;
            }
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
