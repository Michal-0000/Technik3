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

namespace Combo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbMoj.Items.Add("Python");
            cbMoj.Items.Add("Java");
            cbMoj.Items.Add("C#");

            cbMoj.SelectionChanged += cbMoj_SelectionChange;
        }

        private void cbMoj_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            string selection = cbMoj.SelectedItem.ToString();
            MessageBox.Show(selection);
        }
    }
}