using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using InventoryMS.Model;

namespace InventoryMS.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=InventoryDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StockManagement> StockManagement { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
        public DbSet<PurchaseReport> PurchaseReports { get; set; }
        public DbSet<StockReport> StockReports { get; set; }
        public DbSet<DashboardSummary> DashboardSummaries { get; set; }
        public DbSet<DashboardGraphData> DashboardGraphData { get; set; }
        public DbSet<DailySalesSummary> DailySalesSummaries { get; set; }
        public DbSet<MonthlyTrends> MonthlyTrends { get; set; }
        public DbSet<BestSellingProduct> BestSellingProducts { get; set; }
        public DbSet<LowStockAlert> LowStockAlerts { get; set; }

        
    }
}
