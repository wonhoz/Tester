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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LogTextBoxTester
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer ImportTimer = new System.Timers.Timer();

        private DateTime LastDateTime = DateTime.Today;

        private List<string> SystemLogs = new List<string>();
        private int LogLimit = 50;


        public MainWindow()
        {
            InitializeComponent();

            ImportTimer.Interval = 0.5 * 1000;
            ImportTimer.Elapsed += ImportTimerFunction;
            ImportTimer.Enabled = true;
        }


        public void SystemLog(string logtext)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                DateTime dateTime = DateTime.Now;
                DirectoryInfo directoryInfo = new DirectoryInfo($@"log\{dateTime.Year}\{dateTime.Month}");
                if (directoryInfo.Exists == false)
                {
                    directoryInfo.Create();
                }

                if (LastDateTime.ToString("yyyyMMdd") != dateTime.ToString("yyyyMMdd"))
                {
                    SystemLogs.Clear();
                    SystemLogTextBox.Clear();

                    LastDateTime = dateTime;
                }

                if (SystemLogs.Count > LogLimit)
                {
                    SystemLogs.RemoveAt(0);
                }

                using (StreamWriter outputFile = new StreamWriter($@"log\{dateTime.Year}\{dateTime.Month}\Log_{dateTime.ToString("yyyy-MM-dd")}.log", true))
                {
                    outputFile.WriteLine(dateTime.ToString("yyyy-MM-dd HH:mm:ss:fff ") + logtext);
                }

                SystemLogs.Add(dateTime.ToString("yyyy-MM-dd HH:mm:ss:fff ") + logtext + "\n");
                SystemLogTextBox.Clear();
                foreach (string log in SystemLogs)
                {
                    SystemLogTextBox.AppendText(log);
                }

                if (FollowTailCheckBox.IsChecked.Value)
                {
                    SystemLogTextBox.ScrollToEnd();
                    SystemLogTextBox.Select(SystemLogTextBox.Text.Length, 0);
                }
            }));
        }


        private async void ImportTimerFunction(object sender, System.Timers.ElapsedEventArgs e)
        {
            SystemLog("[INFO] ImportTimerFunction");
        }
    }
}
