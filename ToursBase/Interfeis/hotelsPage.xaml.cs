using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToursBase.BD;
using ToursBase.Class;
using ToursBase.Interfeis;

namespace ToursBase.Interfeis
{ 
    public partial class hotelsPage : Page
    {
        int currentPages = 1, countPage = 5, maxPage;
        List<Hotel> hotelList;

        public hotelsPage()
        {
            InitializeComponent();

            filteringNameCountry.SelectedValuePath = "Code";
            filteringNameCountry.DisplayMemberPath = "Name";
            filteringNameCountry.ItemsSource = appConnect.Model1.Country.ToList();

            hotelsList.ItemsSource = appConnect.Model1.Hotel.ToList();

            pageInformation();
        }

        private void addHotel_Click(object sender, RoutedEventArgs e)
        {
            appFrame.mainFrame.Navigate(new addHotelPage());
        }

        private void deleteHotel_Click(object sender, RoutedEventArgs e)
        {
            var delete = hotelsList.SelectedItems.Cast<Hotel>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить выбраные {delete.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    appConnect.Model1.Hotel.RemoveRange(delete);
                    appConnect.Model1.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    hotelsList.ItemsSource = appConnect.Model1.Hotel.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void searchNameHotel_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                hotelsList.ItemsSource = appConnect.Model1.Hotel.Where(x => x.Name.Contains(searchNameHotel.Text)).ToList();
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                appConnect.Model1.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                hotelsList.ItemsSource = appConnect.Model1.Hotel.ToList();
            }
        }

        private void filteringNameCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int filtr = Convert.ToInt32(filteringNameCountry.SelectedValue);
            hotelsList.ItemsSource = appConnect.Model1.Hotel.Where(x => x.CountryCode == filtr).ToList();
            hotelsList.SelectedIndex = 0;
        }
     
        private void sortingNameHotel_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int index = sortingNameHotel.SelectedIndex;

            try
            {
                switch (index)
                {

                    case 0:
                        hotelsList.ItemsSource = appConnect.Model1.Hotel.ToList();
                        break;

                    case 1:
                        hotelsList.ItemsSource = appConnect.Model1.Hotel.OrderBy(x => x.Name).ToList();
                        break;

                    case 2:
                        hotelsList.ItemsSource = appConnect.Model1.Hotel.OrderByDescending(x => x.Name).ToList();
                        break;

                    default:
                        hotelsList.ItemsSource = appConnect.Model1.Hotel.ToList();
                        break;

                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backTheEnd_Click(object sender, RoutedEventArgs e)
        {
            currentPages = 1;
            pageInformation();

            backTheEnd.IsEnabled = false;
            back.IsEnabled = false;
            next.IsEnabled = true;
            nextTheEnd.IsEnabled = true;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            currentPages--;
            pageInformation();

            if(currentPages == 1)
            {
                backTheEnd.IsEnabled = false;
                back.IsEnabled = false;
            }
          
            next.IsEnabled = true;
            nextTheEnd.IsEnabled = true;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            currentPages++;
            pageInformation();

            if (currentPages == maxPage)
            {
                next.IsEnabled = false;
                nextTheEnd.IsEnabled = false;
            }
            backTheEnd.IsEnabled = true;
            back.IsEnabled = true;
           
        }
        
        private void nextTheEnd_Click(object sender, RoutedEventArgs e)
        {
            currentPages = maxPage;
            pageInformation();

            backTheEnd.IsEnabled = true;
            back.IsEnabled = true;
            next.IsEnabled = false;
            nextTheEnd.IsEnabled = false;
        }

        private void pageInformation()
        {
            try
            {
                hotelList = appConnect.Model1.Hotel.ToList();
                maxPage = (int)Math.Ceiling(hotelList.Count * 1.0 / countPage);
                hotelsList.ItemsSource = hotelList.Skip((currentPages - 1) * countPage).Take(countPage);
                countPagesLabel.Content = $"{currentPages}/{maxPage}";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            appFrame.mainFrame.Navigate(new editPage((sender as Button).DataContext as Hotel));
        }
    }
}
