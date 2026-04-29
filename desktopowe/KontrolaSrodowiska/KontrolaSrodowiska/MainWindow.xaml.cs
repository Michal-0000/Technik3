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

namespace KontrolaSrodowiska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task WilgotnoscAsync()
        {
            while (true)
            {
                int wilgotnosc = random.Next(20,81);
                if( wilgotnosc < 30 ) { }

                Dispatcher.Invoke(() =>
                {
                    txtWilgotnosc.Content = $"{wilgotnosc}%";
                    if (wilgotnosc < 30) txtWilgotnosc;
                });

                await Task.Delay(800);
            }
        }

        private async Task NawodnienieAsync()
        {
            while (true)
            {


                await Task.Delay(800);
            }
        }

        private async Task LogiAsync()
        {
            while (true)
            {


                await Task.Delay(800);
            }
        }
    }
}