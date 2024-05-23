using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Management;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace JTR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n* Taasjuurutamise tööriist *\n\nProtsessi käigus ÄRGE LÜLITAGE ARVUTIT VÄLJA EGA PEATAGE JTR.EXE VÕI JAVA.EXE PROTSESSE!\nKui juurutamine poole pealt katkestada, ei saa seda arvutit enam selle tööriistaga juurutada!\n");
            Console.WriteLine("Ettevalmistumine");
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\verifile2.jar"))
            {
                Console.WriteLine("    Verifile 2.0 märgistustööriista käivitamine...");
                Process p = new Process();
                p.StartInfo.FileName = "java";
                p.StartInfo.Arguments = "-jar \"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\verifile2.jar\" -w";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
            Console.WriteLine("    Autentimine...");
            if ((Verifile() == false))
            {
                Console.WriteLine("    Autentimine ebaõnnestus. Palun olge kindel, et programm oleks käivitatud Markuse arvutis.");
                WriteFile2();
                return;
            }
            else
            {
                Console.WriteLine("    Autentimine õnnestus");
                Console.WriteLine("    Markuse arvuti asjade integratsioonitarkvara sulgemine...");
                foreach (Process pk in Process.GetProcesses())
                {
                    if (pk.ProcessName == "Markuse arvuti integratsioonitarkvara")
                    {
                        pk.Kill();
                    }
                }
                bool isrunning = true;
                while (isrunning)
                {
                    bool chk = false;
                    foreach (Process pk in Process.GetProcesses())
                    {
                        if (pk.ProcessName == "Markuse arvuti integratsioonitarkvara")
                        {
                            chk = true;
                        }
                    }
                    if (chk == true)
                    {
                        isrunning = true;
                    }
                    else
                    {
                        isrunning = false;
                    }
                }
                Console.WriteLine("Juurutamine");
                
                Console.WriteLine("    Juurutamise akna avamine...");
                Process p = new Process();
                p.StartInfo.FileName = "C:\\mas\\Markuse asjad\\Markuse arvuti integratsioonitarkvara.exe";
                p.StartInfo.Arguments = "/reroot";
                p.Start();
                Console.WriteLine("    Kasutaja ootamine...");
                isrunning = true;
                Console.Write("Kui olete andmete sisestamise lõpetanud ja juurutamise akna sulgenud, vajutage suvalist klahvi, et jätkata . . . ");
                Console.ReadKey();
                Console.WriteLine("\r\n    Markuse asjade integratsioonitarkvara peatamine...");
                while (isrunning)
                {
                    bool chk = false;
                    foreach (Process pk in Process.GetProcesses())
                    {
                        if (pk.ProcessName == "Markuse arvuti integratsioonitarkvara")
                        {
                            pk.Kill();
                        }
                    }
                    if (chk == true)
                    {
                        isrunning = true;
                    }
                    else
                    {
                        isrunning = false;
                    }
                }
                
                Console.WriteLine("    Süsteemi juurutamise lõpetamine...");
                WriteFile();
                Console.WriteLine("Finaliseerimine...");

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\verifile2.jar"))
                {
                    WriteFile2();
                }
                Console.WriteLine("    Süsteemi olukorra kontrollimine...");
                if (Verifile() == true)
                {
                    Console.WriteLine("    Süsteemi juurutamine õnnestus");
                }
                else
                {
                    Console.WriteLine("    Süsteemi juurutamine ebaõnnestus");
                }
                Console.WriteLine("    Markuse arvuti asjade taaskäivitamine...");
                p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\remas.bat";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
            }

        }
        private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

        static void WriteFile2()
        {
            Console.WriteLine("    Verifile 2.0 märgistamine...");
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\vf2.done", "");
            while (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.mas\\vf2.done"))
            {
                Thread.Sleep(1);
            }
        }

        static void WriteFile()
        {
            string verificatable = q();
            string[] sar = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252)).ToString().Split('\n');
            string ns = "";
            for (int i = 0; i < sar.Length - 1; i++)
            {
                ns += sar[i].ToString() + "\n";
            }
            System.IO.File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\edition.txt", ns + verificatable, Encoding.GetEncoding(1252));

        }
        static bool Verifile()
        {
            string verificatable = q();
            string[] savedstr = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252)).ToString().Split('\n');
            string sttr = savedstr[savedstr.Length - 1];
            if (verificatable == sttr)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string q()
        {
            string gg = "CPI" + ff();
            string pp = j(y(System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt", Encoding.GetEncoding(1252))));

            return (h(pp + j(gg.Substring(1, gg.Length - 2) + gg.Substring(0, 1) + gg.Substring(gg.Length - 1, 1))).ToLower() + j(uu()).ToLower() + j(b)).ToLower();
        }

        static string y(string s)
        {
            string[] sar = s.Split('\n');
            string ns = "";
            for (int i = 0; i < sar.Length - 3; i++)
            {
                ns += sar[i].ToString() + "\n";
            }
            return ns;
        }
        static string uu()
        {
            using (ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))

            using (ManagementObjectCollection moc = o.Get())

            {

                StringBuilder t = new StringBuilder();
                foreach (ManagementObject mo in moc)

                {

                    string[] BIOSVersions = (string[])mo["BIOSVersion"];
                    foreach (string version in BIOSVersions)
                    {
                        t.AppendLine(string.Format("{0}", version));
                    }

                }
                return t.ToString().Split('\n')[0].ToString();
            }
        }

        public static string ff()
        {
            string l = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (l == "")
                {
                    l = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return l;
        }
        public static string j(string z)
        {
            SHA1 cx = SHA1.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        public static string h(string z)
        {
            MD5 cx = MD5.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        static public string b
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in aa.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
