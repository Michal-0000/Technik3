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
    /// Logika interakcji dla klasy PageAdres.xaml
    /// </summary>
    public partial class PageAdres : Page
    {
        MainWindow main;
        public PageAdres(MainWindow mainWindow)
        {
            InitializeComponent();
            this.main = mainWindow;
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ImieNazwisko.Text) ||
               string.IsNullOrWhiteSpace(Ulica.Text) ||
               string.IsNullOrWhiteSpace(Kod.Text) ||
               string.IsNullOrWhiteSpace(Miasto.Text))
            {
                MessageBox.Show("Należy wypełnic wszystkie pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Adres adres = new Adres(ImieNazwisko.Text, Ulica.Text, Kod.Text, Miasto.Text);

            main.frame.Navigate(new PageWybor(main, adres));
        }
    }

    public struct Adres
    {
        public string imieNazwisko;
        public string ulica;
        public string kod;
        public string miasto;

        public Adres(string imie, string ulica, string kod, string miasto)
        {
            this.imieNazwisko = imie;
            this.ulica = ulica;
            this.kod = kod;
            this.miasto = miasto;
        }
    }

}
