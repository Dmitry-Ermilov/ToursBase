using System.Windows;
using System.Windows.Controls;
using ToursBase.BD;
using ToursBase.Class;
using ToursBase.Interfeis;

namespace ToursBase.Interfeis
{
    /// <summary>
    /// Логика взаимодействия для buttonPage.xaml
    /// </summary>
    public partial class buttonPage : Page
    {
        public buttonPage()
        {
            InitializeComponent();
        }

        private void hotel_Click(object sender, RoutedEventArgs e)
        {
            appFrame.mainFrame.Navigate( new hotelsPage());
        }
    }
}
