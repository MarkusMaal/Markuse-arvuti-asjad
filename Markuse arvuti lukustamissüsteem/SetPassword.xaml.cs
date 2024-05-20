using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for SetPassword.xaml
    /// </summary>
    public partial class SetPassword : Window
    {
        internal Color scheme = Color.FromArgb(255, 255, 255, 255);
        internal Color textScheme = Color.FromArgb(255, 0, 0, 0);
        #pragma warning disable IDE0044
        string masRoot = Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\";
        #pragma warning restore IDE0044

        public SetPassword()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void PasswordValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTheme();
            this.PasswordValue.Focus();
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
            this.TextBoxLabel.Foreground = new SolidColorBrush(textScheme);
            this.PasswordValue.Background = new SolidColorBrush(scheme);
            this.PasswordValue.Foreground = new SolidColorBrush(textScheme);
            this.CancelButton.Foreground = new SolidColorBrush(textScheme);
            this.CancelButton.Background = new SolidColorBrush(scheme);
            this.OKButton.Foreground = new SolidColorBrush(textScheme);
            this.OKButton.Background = new SolidColorBrush(scheme);
        }
    }
}
