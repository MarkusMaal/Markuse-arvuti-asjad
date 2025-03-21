﻿using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Markuse_arvuti_lukustamissüsteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly bool userEnvironment = false;
        readonly string[] whitelistedHashes = { "B881FBAB5E73D3984F2914FAEA743334D1B94DFFE98E8E1C4C8C412088D2C9C2", "A0B93B23301FC596789F83249A99F507A9DA5CBA9D636E4D4F88676F530224CB", "B08AABB1ED294D8292FDCB2626D4B77C0A53CB4754F3234D8E761E413289057F", "8076CF7C156D44472420C1225B9F6ADB661E3B095E29E52E3D4E8598BB399A8F" };
        readonly bool dev = false;
        string masRoot = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\";
        Color scheme = Color.FromArgb(255, 255, 255, 255);
        Color textScheme = Color.FromArgb(255, 0, 0, 0);
        PerformanceCounter? cpuCounter = null;
        PerformanceCounter? hddCounter = null;

        int time = 0;

        bool canClose = true;
        string passHash = "";

        public MainWindow()
        {
            InitializeComponent();
            if (userEnvironment)
            {
                this.masRoot = Environment.GetEnvironmentVariable("USERPROFILE") + "\\.mas\\";
            }
            if (!CheckVerifileTamper())
            {
                return;
            }
            switch (Verifile2())
            {
                case "VERIFIED":
                    break;
                case "FOREIGN":
                    MessageBox.Show("See programm töötab ainult Markuse arvutis.\n\nVeakood: VF_FOREIGN", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    return;
                case "FAILED":
                    MessageBox.Show("Verifile püsivuskontrolli läbimine nurjus.\n\nVeakood: VF_FAILED", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    return;
                case "TAMPERED":
                    MessageBox.Show("See arvuti pole õigesti juurutatud. Seda võis põhjustada hiljutine riistvaramuudatus. Palun kasutage juurutamiseks Markuse asjade juurutamistööriista.\n\nVeakood: VF_TAMPERED", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    return;
                case "LEGACY":
                    MessageBox.Show("See arvuti on juurutatud vana juurutamistööriistaga. Palun juurutage arvuti uuesti uue juurutamistarkvaraga.\n\nVeakood: VF_LEGACY", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    return;
            }
            this.LoadTheme();
            canClose = false;
            DispatcherTimer checkLoop = new DispatcherTimer();
            checkLoop.Tick += new EventHandler(CheckLoop_Tick);
            checkLoop.Interval = new TimeSpan(0, 0, 1);
            checkLoop.Start();
            Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);
            if (!dev)
            {
                LockWorkstation();
            }
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClockTick()
        {
            if (TestModeLabel.Content.ToString().Contains(":"))
            {
                TestModeLabel.Content = DateTime.Now.Hour.ToString().PadLeft(2, '0') + " " + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            }
            else
            {
                TestModeLabel.Content = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            }
            TestModeLabel.Content = TestModeLabel.Content + string.Format(" | {0}. {1} {2}. a", DateTime.Now.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month), DateTime.Now.Year);

        }

        private void CheckLoop_Tick(object sender, EventArgs e)
        {
            ClockTick();

            if (cpuCounter == null)
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            }

            int percCpu = Convert.ToInt32(cpuCounter.NextValue());

            long phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            long tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;

            int percHdd = Convert.ToInt32(hddCounter.NextValue());

            int percMem = Convert.ToInt32(percentOccupied);
            if (percCpu < 25)
            {
                CpuContainer.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else if ((percCpu < 75) && (percCpu >= 25))
            {
                CpuContainer.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            else
            {
                CpuContainer.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            if (percMem < 50)
            {
                RamContainer.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else if ((percMem < 75) && (percMem >= 50))
            {
                RamContainer.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            else
            {
                RamContainer.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            if (percHdd < 50)
            {
                HddContainer.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else if ((percHdd < 75) && (percHdd >= 50))
            {
                HddContainer.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            else
            {
                HddContainer.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            CpuContainer.ToolTip = string.Format("Protsessori kasutus: {0}%", percCpu);
            RamContainer.ToolTip = string.Format("Operatiivmälu kasutus: {0}%", percMem);
            HddContainer.ToolTip = string.Format("Püsimälu kasutus: {0}%", percHdd);
            time++;
            if (time == 30)
            {
                time = 0;
                switch (this.CenterText.Content)
                {
                    case "Arvuti lukustatud. Vajutage sisestusklahvi, et avada!":
                        this.CenterText.Content = "All paremal nurgas näete resursside kasutust ja hiirekursoriga peale liikudes täpseid numbreid";
                        break;
                    case "All paremal nurgas näete resursside kasutust ja hiirekursoriga peale liikudes täpseid numbreid":
                        this.CenterText.Content = "Arvutit saab avada ka kasutades Markuse arvuti integratsioon arvutiga rakendust";
                        break;
                    case "Arvutit saab avada ka kasutades Markuse arvuti integratsioon arvutiga rakendust":
                        this.CenterText.Content = string.Format("Tänane kuupäev on {0}. {1} {2}. a", DateTime.Now.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month), DateTime.Now.Year);
                        break;
                    default:
                        this.CenterText.Content = "Arvuti lukustatud. Vajutage sisestusklahvi, et avada!";
                        break;
                }
            }
            string unlockPath = masRoot + "\\" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + ".unlock";
            if (File.Exists(unlockPath))
            {
                DateTime creationTime = File.GetCreationTime(unlockPath);
                DateTime currentTime = DateTime.Now;

                File.Delete(unlockPath);
                if ((currentTime - creationTime).TotalSeconds < 30)
                {
                    this.ForceQuit();
                }
            }
            unlockPath = masRoot + "\\" + DateTime.Now.Hour.ToString() + "." + (DateTime.Now.Minute - 1).ToString() + ".unlock";
            if (File.Exists(unlockPath))
            {
                DateTime creationTime = File.GetCreationTime(unlockPath);
                DateTime currentTime = DateTime.Now;

                File.Delete(unlockPath);
                if ((currentTime - creationTime).TotalSeconds < 30)
                {
                    this.ForceQuit();
                }
            }
        }

        private bool LoadTheme()
        {
            if (!File.Exists(masRoot + "scheme.cfg"))
            {
                MessageBox.Show("Arvuti ei vasta Markuse asjade standardile.\n\nVeakood: MAS_SCHEME_CFG", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return false;
            }
            if (!File.Exists(masRoot + "bg_common.png"))
            {
                MessageBox.Show("Arvuti ei vasta Markuse asjade standardile.\n\nVeakood: MAS_BG_MISSING", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return false;
            }
            string[] colors = File.ReadAllText(masRoot + "scheme.cfg").Split(";")[0].Split(":");
            string[] colors2 = File.ReadAllText(masRoot + "scheme.cfg").Split(";")[1].Split(":");
            this.scheme = Color.FromArgb(255, byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]));
            this.textScheme = Color.FromArgb(255, byte.Parse(colors2[0]), byte.Parse(colors2[1]), byte.Parse(colors2[2]));
            this.Background = new SolidColorBrush(this.scheme);
            this.Foreground = new SolidColorBrush(this.textScheme);
            this.MainWindow1.Background = new ImageBrush(new BitmapImage(new Uri(masRoot + "bg_common.png"))) { Stretch = Stretch.UniformToFill }; 
            this.BottomLabel.Foreground = new SolidColorBrush(this.textScheme);
            this.TestModeLabel.Foreground = new SolidColorBrush(this.textScheme);
            this.CenterText.Foreground = new SolidColorBrush(this.textScheme);
            this.CpuContainer.BorderBrush = new SolidColorBrush(this.textScheme);
            this.RamContainer.BorderBrush = new SolidColorBrush(this.textScheme);
            this.HddContainer.BorderBrush = new SolidColorBrush(this.textScheme);
            return true;
        }

        private bool CheckVerifileTamper()
        {
            if (!File.Exists(masRoot + "verifile2.jar"))
            {
                MessageBox.Show("Verifile 2.0 tarkvara (verifile2.jar) ei ole Markuse asjade juurkaustas.\n\nVeakood: VF_MISSING", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return false;
            }
            string hash = "";
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(masRoot + "verifile2.jar"))
                {
                    hash = BitConverter.ToString(sha256.ComputeHash(stream));
                }
            }
            if (!whitelistedHashes.Contains(hash.Replace("-", "")))
            {
                MessageBox.Show("Arvuti püsivuskontrolli käivitamine nurjus. Põhjus: Verifile 2.0 räsi ei ole sobiv.", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return false;
            }
            return true;
        }


        /// <summary>
        /// Builds a script that displays all Java binaries and versions for your system and marks it executable (Unix-like systems)
        /// </summary>
        private void BuildJavaFinder()
        {
            if (!File.Exists(masRoot + "/find_java" + (OperatingSystem.IsWindows() ? ".bat" : ".sh")))
            {

                var builder = new StringBuilder();
                using var javaFinder = new StringWriter(builder)
                {
                    NewLine = OperatingSystem.IsWindows() ? "\r\n" : "\n"
                };
                if (OperatingSystem.IsWindows())
                {
                    javaFinder.WriteLine("@echo off");
                    javaFinder.WriteLine("setlocal EnableDelayedExpansion");
                    javaFinder.WriteLine("for /f \"delims=\" %%a in ('where java') do (");
                    javaFinder.WriteLine("\tset \"javaPath=\"%%a\"\"");
                    javaFinder.WriteLine("\tfor /f \"tokens=3\" %%V in ('%%javaPath%% -version 2^>^&1 ^| findstr /i \"version\"') do (");
                    javaFinder.WriteLine("\t\tset \"version=%%V\"");
                    javaFinder.WriteLine("\t\tset \"version=!version:\"=!\"");
                    javaFinder.WriteLine("\t\techo !javaPath:\"=!:!version!");
                    javaFinder.WriteLine("\t)");
                    javaFinder.WriteLine(")");
                    javaFinder.WriteLine("endlocal");
                    javaFinder.WriteLine("exit/b");
                }
                else if (OperatingSystem.IsLinux())
                {
                    javaFinder.WriteLine("#!/usr/bin/bash");
                }
                else if (OperatingSystem.IsMacOS())
                {
                    javaFinder.WriteLine("#!/bin/bash");
                }
                if (!OperatingSystem.IsWindows())
                {
                    javaFinder.WriteLine("OLDIFS=$IFS");
                    javaFinder.WriteLine("IFS=:");
                    javaFinder.WriteLine("for dir in $PATH; do");
                    javaFinder.WriteLine("    if [[ -x \"$dir/java\" ]]; then  # Check if java exists and is executable");
                    javaFinder.WriteLine("        javaPath=\"$dir/java\"");
                    javaFinder.WriteLine("        version=$(\"$javaPath\" -version 2>&1 | awk -F '\"' '/version/ {print $2}')");
                    javaFinder.WriteLine("        echo \"$javaPath:$version\"");
                    javaFinder.WriteLine("    fi");
                    javaFinder.WriteLine("done");
                    javaFinder.WriteLine("IFS=$OLDIFS");
                }
                File.WriteAllText(masRoot + "/find_java" + (OperatingSystem.IsWindows() ? ".bat" : ".sh"), builder.ToString(), Encoding.ASCII);
                if (!OperatingSystem.IsWindows())
                {
                    File.SetUnixFileMode(masRoot + "/find_java.sh", UnixFileMode.UserRead | UnixFileMode.UserExecute | UnixFileMode.UserWrite);
                }
            }
        }

        /// <summary>
        /// Finds the latest version of Java installed on your system, since if you install the Java SE version, Verifile may not work with it.
        /// </summary>
        /// <returns>Path to the latest Java binary found on your system</returns>
        private string FindJava()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string p = culture.NumberFormat.NumberDecimalSeparator;
            string latest_version = $"0{p}0";
            string latest_path = "";
            string interpreter = OperatingSystem.IsWindows() ? "cmd" : "bash";
            if (OperatingSystem.IsWindows())
            {
                masRoot = masRoot.Replace("/", "\\");
            }
            Process pr = new()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = interpreter,
                    Arguments = (OperatingSystem.IsWindows() ? "/c " : "") + "\"" + masRoot + (OperatingSystem.IsWindows() ? "\\" : "/") + "find_java." + (OperatingSystem.IsWindows() ? "bat" : "sh") + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            pr.Start();
            while (!pr.StandardOutput.EndOfStream)
            {
                string[] path_version = (pr.StandardOutput.ReadLine() ?? ":").Replace(":\\", "_WINDRIVE\\").Split(':');
                string path = path_version[0].Replace("_WINDRIVE\\", ":\\");
                string version = path_version[1].Split('_')[0];
                version = version.Split('.')[0] + p + version.Split('.')[1];
                if (double.Parse(version, NumberStyles.Any) > double.Parse(latest_version, NumberStyles.Any))
                {
                    latest_path = path;
                    latest_version = version;
                }
            }
            return latest_path;
        }

        private string Verifile2()
        {
            BuildJavaFinder();
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FindJava(),
                    Arguments = "-jar " + masRoot + "verifile2.jar",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            p.Start();
            while (!p.StandardOutput.EndOfStream)
            {
                string line = p.StandardOutput.ReadLine() ?? "";
                return line.Split("\n")[0];
            }
            return "FAILED";
        }

        private void ForceQuit(bool skipUnlock = false)
        {
            if (!dev && !skipUnlock) {
                if (!UnlockWorkstation())
                {
                    return;
                }
            }
            this.canClose = true;
            this.Close();
        }

        private void CreatePassword()
        {
            SetPassword sp = new SetPassword();
            sp.TextBoxLabel.Content = "Parooli pole veel seadistatud, määrake uus parool";
            string pass1;
            if (sp.ShowDialog() ?? false)
            {
                pass1 = GetHashString(sp.PasswordValue.Password);
            }
            else
            {
                this.ForceQuit();
                return;
            }
            sp.Close();
            sp = new SetPassword();
            sp.TextBoxLabel.Content = "Sisestage parool uuesti";
            sp.PasswordValue.Password = "";
            string pass2;
            if (sp.ShowDialog() ?? false)
            {
                pass2 = GetHashString(sp.PasswordValue.Password);
            }
            else
            {
                this.ForceQuit();
                return;
            }
            if (pass1 != pass2)
            {
                MessageBox.Show("Paroolid ei ühti!", "Parooli seadistamine", MessageBoxButton.OK, MessageBoxImage.Error);
                ForceQuit();
                return;
            }
            passHash = pass1;
            if (File.Exists(masRoot + "pwd.dat"))
            {
                File.Delete(masRoot + "pwd.dat");
            }
            File.WriteAllBytes(masRoot + "pwd.dat", StringToByteArray(passHash));
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.DevMode.Visibility = this.dev ? Visibility.Visible : Visibility.Hidden;
            if (!File.Exists(masRoot + "pwd.dat"))
            {
                this.LockImage.Visibility = Visibility.Hidden;
                this.CenterText.Visibility = Visibility.Hidden;
                CreatePassword();
                this.LockImage.Visibility = Visibility.Visible;
                this.CenterText.Visibility = Visibility.Visible;
            } else
            {
                byte[] passData = File.ReadAllBytes(masRoot + "pwd.dat");
                StringBuilder sb = new StringBuilder();
                foreach (byte b in passData)
                    sb.Append(b.ToString("X2"));
                passHash = sb.ToString().ToLower();
            }
            ClockTick();
            if (this.Width / this.Height > 3.0)
            {
                double wide = this.Width;
                double high = this.Height;
                this.ResizeMode = ResizeMode.NoResize;
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.None;
                this.Left = wide / 4; this.Top = 0;
                this.Width = wide / 2;
                this.Height = high - 13;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            char[] revString = inputString.ToCharArray();
            Array.Reverse(revString);
            inputString = Environment.GetEnvironmentVariable("USERNAME") + "::" + new string(revString) + "::" + Environment.GetEnvironmentVariable("COMPUTERNAME");
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString().ToLower();
        }

        private void MainWindowContainer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !this.canClose;
        }

        private void MainWindowContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dev)
            {
                switch (e.Key)
                {
                    case Key.F12:
                        this.canClose = true;
                        this.Close();
                        break;
                    case Key.F11:
                        this.DevMode.Content = "Verifile staatus: " + Verifile2();
                        break;
                    case Key.F9:
                        if (this.WindowState == WindowState.Maximized)
                        {
                            this.WindowStyle = WindowStyle.SingleBorderWindow;
                            this.WindowState = WindowState.Normal;
                        }
                        else
                        {
                            this.WindowStyle = WindowStyle.None;
                            this.WindowState = WindowState.Maximized;
                        }
                        break;
                    case Key.F2:
                        string[] fileChecks = { "edition.txt", "renable.bat", "prepare.bat", "pwd.dat", "verifile2.dat", "verifile2.jar", "scheme.cfg", "bg_common.png" };
                        StringBuilder sb = new StringBuilder();
                        foreach(string filecheck in fileChecks)
                        {
                            sb.Append(filecheck).Append(" - ");
                            sb.Append(File.Exists(masRoot + filecheck) ? "OK" : "Viga!");
                            sb.AppendLine();
                        }
                        MessageBox.Show(sb.ToString(), "Failikontroll", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case Key.F3:
                        LockWorkstation();
                        break;
                    case Key.F4:
                        UnlockWorkstation();
                        break;
                    case Key.F1:
                        MessageBox.Show(
                            "Kiirklahvid:\n" +
                            "F1 - Kiirklahvid\n" +
                            "F2 - Failikontroll\n" +
                            "F3 - Katseta lukustamist\n" +
                            "F4 - Katseta töölaua avamist\n" +
                            "F9 - Muuda aknarežiimi\n" +
                            "F11 - Kuva Verifile olek\n" +
                            "F12 - Sulge aken", "Arendaja režiim", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
            if (e.Key == Key.Enter)
            {
                SetPassword sp = new SetPassword();
                sp.TextBoxLabel.Content = "Sisestage parool";
                this.LockImage.Visibility = Visibility.Hidden;
                this.CenterText.Visibility = Visibility.Hidden;
                if (sp.ShowDialog() ?? false)
                {
                    string enteredPassword = GetHashString(sp.PasswordValue.Password);
                    if (enteredPassword == passHash)
                    {
                        this.ForceQuit();
                    } else
                    {
                        MessageBox.Show("Sisestatud parool oli vale!", "Parooli sisend", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                this.LockImage.Visibility = Visibility.Visible;
                this.CenterText.Visibility = Visibility.Visible;
            } else if (e.Key == Key.Escape)
            {
                QuickActions qa = new QuickActions();
                this.LockImage.Visibility = Visibility.Hidden;
                this.CenterText.Visibility = Visibility.Hidden;
                qa.ShowDialog();
                bool correctPass = false;
                if (qa.action == "chpass")
                {
                    SetPassword sp = new SetPassword();
                    sp.TextBoxLabel.Content = "Sisestage vana parool";
                    if (sp.ShowDialog() ?? false)
                    {
                        correctPass = GetHashString(sp.PasswordValue.Password) == passHash;
                    }
                    if (!correctPass)
                    {
                        MessageBox.Show("Vale parool!", "Markuse asjad", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        CreatePassword();
                    }
                }
                this.LockImage.Visibility = Visibility.Visible;
                this.CenterText.Visibility = Visibility.Visible;
            }
        }

        private void LockWorkstation()
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = masRoot + "prepare.bat";
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = true;
                psi.Verb = "runas";

                var process = new Process();
                process.StartInfo = psi;
                process.Start();
                if (dev) { MessageBox.Show("Töölaud lukustati!", "Markuse arvuti asjad", MessageBoxButton.OK, MessageBoxImage.Information); }
            } catch (Exception ex)
            {
                if (dev) { MessageBox.Show("Töölaua lukustamine nurjus!\nVeakood: " + ex.Message, "Markuse arvuti asjad", MessageBoxButton.OK, MessageBoxImage.Error); }
                this.ForceQuit(true);
            }
        }

        private bool UnlockWorkstation()
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = masRoot + "renable.bat";
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = false;

                var process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();

                psi = new ProcessStartInfo();
                psi.FileName = Environment.GetEnvironmentVariable("SYSTEMROOT") + "\\explorer.exe";
                process = new Process();
                process.StartInfo = psi;
                process.Start();
                if (dev) { MessageBox.Show("Töölaud avati!", "Markuse arvuti asjad", MessageBoxButton.OK, MessageBoxImage.Information); }
                return true;
            } catch (Exception ex)
            {
                if (dev) { MessageBox.Show("Töölaua avamine nurjus!\nVeakood: " + ex.Message, "Markuse arvuti asjad", MessageBoxButton.OK, MessageBoxImage.Error); }
                return false;
            }
        }
    }
}

// Windows PerformanceInfo API
public static class PerformanceInfo
{
    [DllImport("psapi.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

    [StructLayout(LayoutKind.Sequential)]
    public struct PerformanceInformation
    {
        public int Size;
        public IntPtr CommitTotal;
        public IntPtr CommitLimit;
        public IntPtr CommitPeak;
        public IntPtr PhysicalTotal;
        public IntPtr PhysicalAvailable;
        public IntPtr SystemCache;
        public IntPtr KernelTotal;
        public IntPtr KernelPaged;
        public IntPtr KernelNonPaged;
        public IntPtr PageSize;
        public int HandlesCount;
        public int ProcessCount;
        public int ThreadCount;
    }

    public static Int64 GetPhysicalAvailableMemoryInMiB()
    {
        PerformanceInformation pi = new PerformanceInformation();
        if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
        {
            return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
        }
        else
        {
            return -1;
        }

    }

    public static Int64 GetTotalMemoryInMiB()
    {
        PerformanceInformation pi = new PerformanceInformation();
        if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
        {
            return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
        }
        else
        {
            return -1;
        }

    }

    public static void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
    {
        // terminate process if Windows is shutting down or logging off
        Application.Current.Shutdown();
    }
}