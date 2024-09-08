using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtNumer_LostFocus(object sender, RoutedEventArgs e)
        {
            WyswietlObrazy(txtNumer.Text);
        }

        private void WyswietlObrazy(string numer)
        {
            string zdjeciePath = $"Zdjecia/{numer}-zdjecie.jpg";
            string odciskPath = $"Zdjecia/{numer}-odcisk.jpg";

            imgZdjecie.Source = File.Exists(zdjeciePath) ? new BitmapImage(new Uri(zdjeciePath, UriKind.Relative)) : null;
            imgOdcisk.Source = File.Exists(odciskPath) ? new BitmapImage(new Uri(odciskPath, UriKind.Relative)) : null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text) || string.IsNullOrWhiteSpace(txtNazwisko.Text))
            {
                MessageBox.Show("Wprowadź dane");
                return;
            }

            string kolorOczu = rbNiebieskie.IsChecked == true ? "niebieskie" :
                               rbZielone.IsChecked == true ? "zielone" : "piwne";

            MessageBox.Show($"{txtImie.Text} {txtNazwisko.Text} kolor oczu {kolorOczu}");
        }
    }
}
