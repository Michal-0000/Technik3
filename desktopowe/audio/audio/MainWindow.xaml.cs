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

namespace audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer audioPlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOtworz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki dźwiękowe (*.mp3;*.wav)|*.mp3;*.wav";
            if (openFileDialog.ShowDialog() == true)
            {
                audioPlayer.Stop();
                audioPlayer.Open(new Uri(openFileDialog.FileName));
                audioPlayer.Stop();
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            audioPlayer.Stop();
        }
    }
}