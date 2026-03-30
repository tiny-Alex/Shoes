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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {

        public ProductList()
        {
            InitializeComponent();
            ProductLst.ItemsSource=Connection.connect.Product.ToList();
            App.mainWindow.TitleTb.Text = "Список товаров";
            FilterCombo.ItemsSource = Connection.connect.Product.ToList();
            FilterCombo.ItemsSource = Connection.connect.Category.ToList();
            FilterCombo.SelectedValuePath = "Id";

        }

        private void FilterProduct()
        {

            var products = Connection.connect.Product.ToList();
          
            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                string searchText = SearchBox.Text.Trim();
                products = products.Where(p =>
                    p.Name != null &&
                    p.Name.ToLower().Contains(searchText)
                ).ToList();
            }

            if (FilterCombo.SelectedItem is Category type)
            {
                products = products.Where(p => p.Category_Id == type.Id).ToList();
            }

            ProductLst.ItemsSource = products;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEdirProductsPage(new Product()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var productEdit = ProductLst.SelectedItem as Product;
            if (productEdit != null)
            {
                NavigationService.Navigate(new AddEdirProductsPage(productEdit));
            }
            else
            {
                MessageBox.Show("Не выбран продукт для редактирования");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var productDelete = ProductLst.SelectedItem as Product;
            if (productDelete != null)
            {
                Connection.connect.Product.Remove(productDelete);
                Connection.connect.SaveChanges();
                ProductLst.ItemsSource = Connection.connect.Product.ToList();
                MessageBox.Show("Продукт удален");
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления");
            }
        }

        private void SearchBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            FilterProduct();
        }

        private void FilterCombo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            FilterProduct();
        }

        private void ClearFilterBtn_Click_1(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            FilterCombo.SelectedIndex = -1;
            FilterProduct();
        }
    }
}
