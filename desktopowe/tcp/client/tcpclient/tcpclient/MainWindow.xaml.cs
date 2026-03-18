using System.Net.Sockets;
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

namespace tcpclient
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

        private async Task SendBtn_Click(object sender, RoutedEventArgs e)
        {
            string  message = MessageText.Text;
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    string response = await SendMessageAsync(message);
                    ResponseText.Text = response;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problem z komunikacją: {ex.Message}");
                }
            }
        }

        private async Task<string> SendMessageAsync(string message)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 9001))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string responseMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return responseMessage;
                }
            }
        }
    }
}