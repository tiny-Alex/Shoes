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

namespace shoes.pages
{
    /// <summary>
    /// Логика взаимодействия для AddEdirProductsPage.xaml
    /// </summary>
    public partial class AddEdirProductsPage : Page
    {
        Product product;
        public AddEdirProductsPage(Product _product = null)
        {
            InitializeComponent();
            if (_product == null)
                product = new Product();
            else
                product = _product;

            this.DataContext = product;

            categoryTb.ItemsSource = Connection.connect.Category.ToList();
            EzCB.ItemsSource = Connection.connect.Unit.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (product.Article == null)
                    Connection.connect.Product.Add(product);

                Connection.connect.SaveChanges();
                MessageBox.Show("Сохранено");
                NavigationService.Navigate(new ProductList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
