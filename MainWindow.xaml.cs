using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShutdownApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            string timeArgs = timeList.SelectionBoxItem.ToString();
            int seconds = GetSecconds(timeArgs);
            var processInfo = new ProcessStartInfo("shutdown", $"/s /t {seconds}")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };

            MessageBox.Show($"Windows will shutdown in {timeArgs}");
            Process.Start(processInfo);
        }

        private static int GetSecconds(string time)
        {
            if (time.EndsWith("m"))
            {
                return 30 * 60;
            }
            else
            {
                int hours = int.Parse(time.Substring(0, 1));
                return hours * 60 * 60;
            }
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            var processInfo = new ProcessStartInfo("shutdown", "/a")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };

            MessageBox.Show("Shutdown aborted!");
            Process.Start(processInfo);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
