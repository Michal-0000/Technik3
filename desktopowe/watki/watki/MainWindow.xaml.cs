using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace watki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int time = 0;
        bool stopwatchRunning1, stopwatchRunning2 = false;
        CancellationTokenSource cts1, cts2;

        TimeSpan stopwatch1, stopwatch2;
        


        public MainWindow()
        {
            cts1 = new CancellationTokenSource();
            cts2 = new CancellationTokenSource();
            stopwatch1 = new TimeSpan(0);
            stopwatch2 = new TimeSpan(0);
            InitializeComponent();
        }

        


        private void btnStart1_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatchRunning1) return;
            stopwatchRunning1 = true;
            cts1 = new CancellationTokenSource();
            _ = HandleStopwatch1(cts1.Token);
        }

        private void btnStart2_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatchRunning2) return;
            stopwatchRunning2 = true;
            cts2 = new CancellationTokenSource();
            _ = HandleStopwatch2(cts2.Token);
        }

        private void btnReset2_Click(object sender, RoutedEventArgs e)
        {
            cts2.Cancel();
            stopwatch2 = new TimeSpan(0);
            txtStopwatch2.Text = "Czas: " + stopwatch2.ToString();
        }

        private void btnStop2_Click(object sender, RoutedEventArgs e)
        {
            cts2.Cancel();
        }

        private void btnReset1_Click(object sender, RoutedEventArgs e)
        {
            cts1.Cancel();
            stopwatch1 = new TimeSpan(0);
            txtStopwatch2.Text = "Czas: " + stopwatch1.ToString();
        }

        private void btnStop1_Click(object sender, RoutedEventArgs e)
        {
            cts1.Cancel();
        }

        private async Task HandleStopwatch1(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(1000);
                    stopwatch1 = stopwatch1.Add(TimeSpan.FromSeconds(1));
                    txtStopwatch1.Text = "Czas: " + stopwatch1.ToString();
                }
            }
            catch (OperationCanceledException)
            {
                stopwatchRunning1 = false;
            }
        }
        private async Task HandleStopwatch2(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(1000);
                    stopwatch2 = stopwatch2.Add(TimeSpan.FromSeconds(1));
                    txtStopwatch2.Text = "Czas: "+stopwatch2.ToString();
                }
            }
            catch (OperationCanceledException)
            {
                stopwatchRunning2 = false;
            }
        }
    }
}