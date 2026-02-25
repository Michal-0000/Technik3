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
    /// Logika interakcji dla klasy PagePodsumowanie.xaml
    /// </summary>
    public partial class PagePodsumowanie : Page
    {
        MainWindow main;

        public PagePodsumowanie(MainWindow mainWindow, Adres adres, Zamowienie zamowienie)
        {
            InitializeComponent();
            main = mainWindow;

            txtImie.Text = adres.imieNazwisko;
            txtUlica.Text = adres.ulica;
            txtKod.Text = adres.kod;
            txtMiasto.Text = adres.miasto;
            txtRodzaj.Text = zamowienie.rodzaj;
            txtRozmiar.Text = zamowienie.rozmiar;
            txtIlosc.Text = zamowienie.ilosc.ToString();

            
        }

        private void Zamow_Click(object sender, RoutedEventArgs e)
        {
            main.frame.Navigate(new PageAdres(main));
        }
    }
}
