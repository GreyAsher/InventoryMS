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
using InventoryMS.View.ProductManagement;

namespace InventoryMS.View.ProductManagement
{
    /// <summary>
    /// Interaction logic for StockManageUserControl.xaml
    /// </summary>
    public partial class StockManageUserControl : UserControl
    {
        public StockManageUserControl()
        {
            InitializeComponent();
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add stock functionality");
        }

        private void EditStock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit stock functionality");
        }

        private void DeleteStock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete stock functionality");
        }

        private void SaveStock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stock details saved");
        }
    }
}

