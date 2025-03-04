using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using InventoryMS.Model;

namespace InventoryMS.View
{
    /// <summary>
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {

        public ObservableCollection<Product> Products { get; set; }

        public ProductUserControl()
        {
            InitializeComponent();

            // Sample data
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 1000, Stock = 50 },
                new Product { Name = "Smartphone", Category = "Mobile", Price = 700, Stock = 120 },
                new Product { Name = "Headphones", Category = "Accessories", Price = 150, Stock = 200 }
            };

            ProductGrid.ItemsSource = Products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open Add Product Form");
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                MessageBox.Show($"Editing: {selectedProduct.Name}");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

}

