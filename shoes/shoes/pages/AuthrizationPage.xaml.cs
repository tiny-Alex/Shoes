using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using shoes.Connect;
using shoes.pages;

namespace shoes.pages
{
    /// <summary>
    /// Логика взаимодействия для AuthrizationPage.xaml
    /// </summary>
    public partial class AuthrizationPage : Page
    {
        public AuthrizationPage()
        {
            InitializeComponent();
            App.mainWindow.TitleTb.Text = "Страница авторизации";
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            App.authorizationUser = Connection.connect.User.FirstOrDefault(x => x.Login == LoginTb.Text && x.Password == PassTb.Password);
            if (App.authorizationUser != null)
            {
                MessageBox.Show("Авторизация прошла успешно");
                NavigationService.Navigate(new ProductList());

            }
            else
            {
                MessageBox.Show("Авторизация прошла успешно");
            }
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductList());

        }
    }
}