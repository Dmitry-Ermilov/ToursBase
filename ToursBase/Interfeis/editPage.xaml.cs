using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToursBase.BD;
using ToursBase.Class;


namespace ToursBase.Interfeis
{
    public partial class editPage : Page
    {
        public editPage(Hotel hotel)
        {
            InitializeComponent();

            hotelsDataGrid.ItemsSource = appConnect.Model1.Hotel.Where(x => x.Id == hotel.Id).ToList();
        }

        private void save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            appConnect.Model1.SaveChanges();
            MessageBox.Show("Данные сохранены");
        }
    }
}
