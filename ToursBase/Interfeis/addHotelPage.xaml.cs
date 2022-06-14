using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.IO;
using ToursBase.BD;
using ToursBase.Class;
using ToursBase.Interfeis;
using ToursBase.Avtorizeichen;


namespace ToursBase.Interfeis
{
   
    public partial class addHotelPage : Page
    {
        public addHotelPage()
        {
            InitializeComponent();

            countryComboBox.SelectedValuePath = "Code";
            countryComboBox.DisplayMemberPath = "Name";
            countryComboBox.ItemsSource = appConnect.Model1.Country.ToList();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotel hotel = new Hotel
                {
                    Name = nameHotelTextBox.Text,
                    CountOfStars = Convert.ToInt32(countStarsTextBox.Text),
                    CountryCode = Convert.ToInt32(countryComboBox.SelectedIndex + 1),
                };

                appConnect.Model1.Hotel.Add(hotel);
                appConnect.Model1.SaveChanges();
                MessageBox.Show("Отель добавлен");
                appFrame.mainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
