using System;
using System.Collections.Generic;
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

namespace ZamowieniaPizzzy
{
    /// <summary>
    /// Logika interakcji dla klasy PageWybor.xaml
    /// </summary>
    public partial class PageWybor : Page
    {
        MainWindow main;
        Adres adres;
        public PageWybor(MainWindow mainWindow, Adres adres)
        {
            InitializeComponent();
            this.adres = adres;
            main = mainWindow;
        }


        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if(rodzaj.SelectedItem == null ||
               rozmiar.SelectedItem == null ||
               !int.TryParse(Ilosc.Text, out _))
            {
                MessageBox.Show("Należy wypełnic wszystkie pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Zamowienie zamowienie = new Zamowienie(rodzaj.Text, rozmiar.Text, int.Parse(Ilosc.Text));
            main.frame.Navigate(new PagePodsumowanie(main, adres, zamowienie));

        } 
    }
    public struct Zamowienie
    {
        public string rodzaj;
        public string rozmiar;
        public int ilosc;
        public Zamowienie(string rodzaj, string rozmiar, int ilosc)
        {
            this.rodzaj = rodzaj;
            this.rozmiar = rozmiar;
            this.ilosc = ilosc;
        }
    }
}
