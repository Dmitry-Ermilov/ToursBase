using System;
using System.Windows;
using ToursBase.BD;
using ToursBase.Class;
using ToursBase.Interfeis;
using ToursBase.Avtorizeichen;


namespace ToursBase
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            appConnect.Model1 = new ToursBaseEntities();
            appFrame.mainFrame = mainFrame;
            appFrame.mainFrame.Navigate(new buttonPage());

           // OpenPage(pages.login);

        }

        public enum pages
        {
            login,
            regin
        }

        void OpenPage(pages pages)
        {
            if(pages == pages.login)
            {
                mainFrame.Navigate(new login(this));
            }
            else if(pages == pages.regin)
            {
                mainFrame.Navigate(new regin(this));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            appFrame.mainFrame.GoBack();
        }

        private void mainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                back.Visibility = Visibility.Visible;
            }
            else
            {
                back.Visibility = Visibility.Hidden;
            }
        }
    }
}
