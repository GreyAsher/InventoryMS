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
using InventoryMS.View;

namespace InventoryMS.View
{
    /// <summary>
    /// Interaction logic for ProductCategoryUserControl.xaml
    /// </summary>
    public partial class ProductCategoryUserControl : UserControl
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ProductCategoryUserControl()
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>
            {
                new Category { Id = 1, Name = "Electronics", Description = "Gadgets & devices" },
                new Category { Id = 2, Name = "Clothing", Description = "Men & Women apparel" }
            };
            dgCategories.ItemsSource = Categories;
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                int newId = Categories.Count + 1;
                Categories.Add(new Category
                {
                    Id = newId,
                    Name = txtCategoryName.Text,
                    Description = txtDescription.Text
                });
                txtCategoryName.Clear();
                txtDescription.Clear();
            }
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category selectedCategory)
            {
                txtCategoryName.Text = selectedCategory.Name;
                txtDescription.Text = selectedCategory.Description;
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category selectedCategory)
            {
                Categories.Remove(selectedCategory);
            }
        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}


