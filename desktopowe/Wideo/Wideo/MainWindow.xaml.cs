using Microsoft.Win32;
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
using System.Windows.Threading;

//To DO
//1. Wideo + dzwięk
//2. Informacje o pliku filmowym lub dzwiekowym


namespace Wideo
{
    
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private List<string> videoPaths = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (VideoPlayer.NaturalDuration.HasTimeSpan)
            {
                TimelineSlider.Maximum = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                TimelineSlider.Value = VideoPlayer.Position.TotalSeconds;
                TimeText.Text = $"{VideoPlayer.Position.Minutes:D2}:{VideoPlayer.Position.Seconds:D2}/" +
                    $"{VideoPlayer.NaturalDuration.TimeSpan.Minutes:D2}:{VideoPlayer.NaturalDuration.TimeSpan.Seconds:D2}";
            }
        }

        private void LoadVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki wideo (*mpg;*mp4;*avi;*wmv)|*mpg;*mp4;*avi;*wmv",
                Multiselect = true,
            };
            if(openFileDialog.ShowDialog() == true)
            {
                foreach(string file in openFileDialog.FileNames)
                {
                    videoPaths.Add(file);
                    VideoListBox.Items.Add(System.IO.Path.GetFileName(file));
                }
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if(VideoListBox.SelectedIndex >= 0)
            {
                string selectedPath = videoPaths[VideoListBox.SelectedIndex];
                VideoPlayer.Source = new Uri(selectedPath);
                VideoPlayer.LoadedBehavior = MediaState.Manual;
                VideoPlayer.Stretch = Stretch.Uniform;
                VideoPlayer.Play();
                timer.Start();

            }
            else
            {
                MessageBox.Show("Nie wybrano pliku do odtworzenia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Stop();
            timer.Stop();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Pause();
            timer.Stop();
        }

        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoPlayer.NaturalDuration.HasTimeSpan)
            {
                VideoPlayer.Position = TimeSpan.FromSeconds(TimelineSlider.Value);
            }
        }
    }
}