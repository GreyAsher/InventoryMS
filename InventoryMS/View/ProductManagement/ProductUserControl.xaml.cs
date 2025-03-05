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
using InventoryMS.View;


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
            List<Product> products = new List<Product>
{
            new Product { ProductID = 1, Name = "Porcelain Vase", Category = "Decor", Price = 49.99m, Stock = 10, ImagePath="Images/vase.jpg" },
            new Product { ProductID = 2, Name = "Tea Set", Category = "Kitchen", Price = 29.99m, Stock = 3, ImagePath="Images/teaset.jpg" },
            new Product { ProductID = 3, Name = "Porcelain Plate", Category = "Tableware", Price = 15.99m, Stock = 0, ImagePath="Images/plate.jpg" }
};
            ProductDataGrid.ItemsSource = products;

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open Add Product Form");
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                MessageBox.Show($"Editing: {selectedProduct.Name}");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
        }

    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; } // Path to product image
    }

}

