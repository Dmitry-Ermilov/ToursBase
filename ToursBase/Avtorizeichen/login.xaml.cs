using System;
using System.Windows;
using System.Windows.Controls;
using ToursBase.BD;
using ToursBase.Class;
using ToursBase.Interfeis;
using ToursBase.Avtorizeichen;

namespace ToursBase.Avtorizeichen
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainWindow;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
