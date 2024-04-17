using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.IO;

namespace Markuse_asjade_teenus
{
    public partial class Service1 : ServiceBase
    {
        string rootdevice = Environment.GetEnvironmentVariable("HOMEDRIVE");
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Thread t = new Thread(new ThreadStart(CheckThread));
        }

        protected override void OnStop()
        {
        }

        public void CheckThread()
        {
            while (true)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName.ToLower() == "markuse arvuti integratsioonitarkvara")
                    {
                        File.WriteAllText(rootdevice + @"\mas\log.txt", "Test log. Saved at " + DateTime.Now.ToString());
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
