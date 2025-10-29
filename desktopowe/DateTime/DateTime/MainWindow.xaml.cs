using System.Globalization;
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

namespace DateTime2
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
        private void dateTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime nowaData = (DateTime)e.NewValue;
        }

        private void minimalna_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(minimalna.Text)) return;
            DateTime minDate;
            if(!DateTime.TryParseExact(minimalna.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out minDate))
                return;

            dateTimePicker.Minimum = minDate;
        }

        private void maksymalna_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(maksymalna.Text)) return;
            DateTime maxDate;
            if (!DateTime.TryParseExact(maksymalna.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out maxDate))
                return;

            dateTimePicker.Minimum = maxDate;
        }
    }

    
}