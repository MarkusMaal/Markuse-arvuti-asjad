using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Markuse_arvuti_lukustamissüsteem
{
    /// <summary>
    /// Interaction logic for QuickActions.xaml
    /// </summary>
    public partial class QuickActions : Window
    {
        public string action = "nothing";
        internal Color scheme = Color.FromArgb(255, 255, 255, 255);
        internal Color textScheme = Color.FromArgb(255, 0, 0, 0);
        string masRoot = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\";
        public QuickActions()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "shutdown";
            p.StartInfo.Arguments = "/s /t 0";
            p.Start();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "shutdown";
            p.StartInfo.Arguments = "/r /t 0";
            p.Start();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LockWorkStation();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.action = "chpass";
            this.Close();
        }
        private void LoadTheme()
        {
            if (Directory.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + "\\.mas\\"))
            {
                masRoot = Environment.GetEnvironmentVariable("USERPROFILE") + "\\.mas\\";
            }
            string[] colors = File.ReadAllText(masRoot + "scheme.cfg").Split(";")[0].Split(":");
            string[] colors2 = File.ReadAllText(masRoot + "scheme.cfg").Split(";")[1].Split(":");
            this.scheme = Color.FromArgb(255, byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]));
            this.textScheme = Color.FromArgb(255, byte.Parse(colors2[0]), byte.Parse(colors2[1]), byte.Parse(colors2[2]));
            this.Background = new SolidColorBrush(scheme);
            this.Foreground = new SolidColorBrush(textScheme);
            this.ShutdownButton.Background = new SolidColorBrush(scheme);
            this.ShutdownButton.Foreground = new SolidColorBrush(textScheme);
            this.RestartButton.Background = new SolidColorBrush(scheme);
            this.RestartButton.Foreground = new SolidColorBrush(textScheme);
            this.SwitchButton.Background = new SolidColorBrush(scheme);
            this.SwitchButton.Foreground = new SolidColorBrush(textScheme);
            this.ChPassButton.Background = new SolidColorBrush(scheme);
            this.ChPassButton.Foreground = new SolidColorBrush(textScheme);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTheme();
        }
    }
}
