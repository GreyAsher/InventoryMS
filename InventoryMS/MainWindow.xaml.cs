using System.Windows;
using System.Windows.Input;
using InventoryMS.View;
using InventoryMS.View.ProductManagement;
using InventoryMS.View.SalesAndCostumers;
using InventoryMS.View.SupplierAndPurchaseOrders;
using InventoryMS.View.ReportAndAnalytics;


namespace InventoryMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load Dashboard automatically when app starts
            MainContent.Content = new DashboardUserControl();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();

            }
        }
       
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1000;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DashboardUserControl(); // Load the UserControl
        }

        private void OpenUserManagement(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UserManageUserControl(); // Load the UserControl
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductUserControl();
        }
        
        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SupplierUserControl();
        }
        
        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SalesUserControl();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductCategoryUserControl();
        }

        private void StockManagement_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockManageUserControl();
        }

        private void OrderPurchase_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new OrderPurchaseUserControl();
        }
        private void CostumerButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CostumerUserControl();
        }
        private void InvoiceReceipt_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InvoiceReceiptsUserControl();
        }
        private void StockReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockReportsUserControl();
        }
        private void SalesReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SalesReportUserControl();
        }
        private void PurchaseReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PurchaseReportUserControl();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SettingsUserControl();
        }
    }
}
