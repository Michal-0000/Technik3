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
using System.IO;
using Path = System.IO.Path;

namespace WatkiCwiczenie9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml 35-40
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private bool isTemperatureRunning = false;
        private bool isProgressRunning = false;
        private bool isFilesRunning = false;

        private CancellationTokenSource tempCTS;
        private CancellationTokenSource progressCTS;
        private CancellationTokenSource filesCTS;

        private int createdFiles = 0;
        private int deletedFiles = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTempStart_Click(object sender, RoutedEventArgs e)
        {
            if (isTemperatureRunning) return;
            isTemperatureRunning = true;
            tempCTS = new CancellationTokenSource();
            _ = HandleTemperature();
        }

        private void btnTempStop_Click(object sender, RoutedEventArgs e)
        {
            if(!isTemperatureRunning) return;
            isTemperatureRunning = false;
            tempCTS.Cancel();
        }

        private void btnProgressStart_Click(object sender, RoutedEventArgs e)
        {
            if(isProgressRunning) return;
            isProgressRunning = true;
            progressCTS = new CancellationTokenSource();
            _ = HandleProgress();
        }

        private void btnProgressStop_Click(object sender, RoutedEventArgs e)
        {
            if(!isProgressRunning) return;
            isProgressRunning = false;
            progressCTS.Cancel();
        }

        private void btnFilesStart_Click(object sender, RoutedEventArgs e)
        {
            if(isFilesRunning) return;
            isFilesRunning = true;
            filesCTS = new CancellationTokenSource();
            _ = HandleFiles();
        }

        private void btnFilesStop_Click(object sender, RoutedEventArgs e)
        {
            if(!isFilesRunning) return;
            isFilesRunning = false;
            filesCTS.Cancel();
        }


        private async Task HandleTemperature()
        {
            while (!tempCTS.Token.IsCancellationRequested)
            {
                int temp = random.Next(25, 95);
                Dispatcher.Invoke(() => txtTemperature.Text = $"{temp} °C");
                await Task.Delay(1000);
            }
        }

        private async Task HandleProgress()
        {
            while (!progressCTS.Token.IsCancellationRequested)
            {
                double progress = random.NextDouble() * 100;
                Dispatcher.Invoke(() => progressBar.Value = progress);
                await Task.Delay(2000);
            }
        }

        private async Task HandleFiles()
        {
            while (!filesCTS.Token.IsCancellationRequested)
            {
                int filesCount = random.Next(2, 5);
                string dirPath = Path.Combine(Path.GetTempPath(), "RandomFiles");
                Directory.CreateDirectory(dirPath);

                string[] filesNames = new string[filesCount];
                for (int i = 0; i < filesCount; i++)
                {
                    filesNames[i] = $"file_{Guid.NewGuid()}.txt";
                    _ = File.WriteAllTextAsync(Path.Combine(dirPath, filesNames[i]), "Random content");
                    createdFiles++;
                }

                await Dispatcher.InvokeAsync(() =>
                {
                    txtFilesNames.Text = string.Join(Environment.NewLine, filesNames);
                    txtFilesStats.Text = $"Utworzone: {createdFiles}, Usunięte: {deletedFiles}";
                });
                await Task.Delay(1000);
                foreach (var file in filesNames)
                {
                    string filePath = Path.Combine(dirPath, file);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        deletedFiles++;
                    }
                }
                await Dispatcher.InvokeAsync(() =>
                {
                    txtFilesNames.Text = string.Join(Environment.NewLine, filesNames);
                    txtFilesStats.Text = $"Utworzone: {createdFiles}, Usunięte: {deletedFiles}";
                });
                await Task.Delay(4000);
            }
        }
    }
}