using System;
using System.Collections.Generic;
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
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Diagnostics;
using System.Threading;

namespace SimpleTimer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer = new DispatcherTimer();
        TimeSpan _timeSpan = new TimeSpan(0);
        DateTime startDT = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += timer_Tick;
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            startDT = DateTime.Now;
            _timer.Start();

            BtnStart.IsEnabled = false;
            BtnReset.IsEnabled = false;
            BtnStop.IsEnabled = true;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            _timeSpan = new TimeSpan(0);
            startDT = DateTime.Now;
            tbTime.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds, _timeSpan.Milliseconds / 10);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timeSpan += DateTime.Now - startDT;

            BtnStart.IsEnabled = true;
            BtnReset.IsEnabled = true;
            BtnStop.IsEnabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now - startDT + _timeSpan;
            tbTime.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
        }

    }
}
