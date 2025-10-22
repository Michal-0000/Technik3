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

namespace Combo2
{
    public class Item
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
    }

    public partial class MainWindow : Window
    {
        public List<Item> Dane { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Dane = new List<Item>
            {
                new Item{Nazwa = "Java", Opis = "To jest opis do Javy"},
                new Item{Nazwa = "Python", Opis = "A to ten cały python niby jest"},
                new Item{Nazwa = "C#", Opis = "C# bo komus sie ++++ nie chcialo pisac"}
            };
            DataContext = this;
        }
        private void cbMoj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item selection = (Item)cbMoj.SelectedItem;
            if (selection != null)
            {
                MessageBox.Show(selection.Opis);
            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searched = search.Text;
            if (string.IsNullOrEmpty(searched)) cbMoj.ItemsSource = Dane;
            List<Item> filtered = Dane.Where(x => x.Nazwa.Contains(searched, StringComparison.OrdinalIgnoreCase)).ToList();
            cbMoj.ItemsSource = filtered;
        }
    }
}