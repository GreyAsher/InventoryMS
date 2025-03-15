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
using System.Data.SqlClient;
using InventoryMS.Model;
using InventoryMS.Repositories;
using InventoryMS.View;
using InventoryMS.Data;


namespace InventoryMS.View
{
    /// <summary>
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {

        private readonly ProductRepository _productRepository;


        //public ObservableCollection<Product> Products { get; set; }

        public ProductUserControl()
        {
            InitializeComponent();
            //InventoryDBContext context = new InventoryDBContext();
            //ProductDataGrid.ItemsSource = context.Products.ToList();
            _productRepository = new ProductRepository();
            LoadProducts();

            // Sample data
            /*List<Product> products = new List<Product>
{
            new Product { ProductID = 1, ProductName = "Porcelain Vase", Category = "Decor", Price = 49.99m, Stock = 10, ImagePath="Images/vase.jpg" },
            new Product { ProductID = 2, ProductName = "Tea Set", Category = "Kitchen", Price = 29.99m, Stock = 3, ImagePath="Images/teaset.jpg" },
            new Product { ProductID = 3, ProductName = "Porcelain Plate", Category = "Tableware", Price = 15.99m, Stock = 0, ImagePath="Images/plate.jpg" }
};
            ProductDataGrid.ItemsSource = products;*/

        }

        private async void LoadProducts()
        {
            try
            {
                List<Product> products = await _productRepository.GetAllProducts();

                // ✅ DEBUGGING
                System.Diagnostics.Debug.WriteLine($"Products Retrieved: {products.Count}");

                if (products.Count > 0)
                {
                    ProductDataGrid.ItemsSource = products; // ✅ Bind data to DataGrid
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ No products retrieved from the database.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error loading products: {ex.Message}");
            }
        }

        /*private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open Add Product Form");
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                MessageBox.Show($"Editing: {selectedProduct.ProductName}");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
        }*/

    }

   /* public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductImage { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; } // Path to product image
    }
*/
}


