-- ===============================
--  1. Users & Roles
-- ===============================
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,  
    Username NVARCHAR(100) UNIQUE NOT NULL, 
    PasswordHash NVARCHAR(255) NOT NULL, 
    FullName NVARCHAR(255) NOT NULL, 
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Admin', 'Staff')), 
    Email NVARCHAR(255) UNIQUE NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE() 
);

-- ===============================
--  2. Customers & Suppliers
-- ===============================
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NULL,
    Phone NVARCHAR(50) NULL,
    Address NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(255) NOT NULL,
    ContactName NVARCHAR(255),
    Phone NVARCHAR(50),
    Email NVARCHAR(255),
    Address NVARCHAR(255)
);

-- ===============================
--  3. Product & Stock Management
-- ===============================
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY, 
    ProductName NVARCHAR(255) NOT NULL, 
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID),
    QuantityInStock INT DEFAULT 0, 
    ReorderLevel INT DEFAULT 10,
    UnitPrice DECIMAL(10,2) NOT NULL,
    UnitOfMeasure NVARCHAR(50),
    Barcode NVARCHAR(255) UNIQUE,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- ===============================
--  4. Orders & Sales
-- ===============================
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('Pending', 'Completed', 'Cancelled'))
);

CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    TotalPrice AS (Quantity * UnitPrice) PERSISTED
);

CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
    InvoiceDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    PaymentStatus NVARCHAR(50) CHECK (PaymentStatus IN ('Pending', 'Paid', 'Cancelled')),
    GeneratedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

-- ===============================
--  5. Stock Transactions
-- ===============================
CREATE TABLE StockManagement (
    StockID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    SupplierID INT NULL FOREIGN KEY REFERENCES Suppliers(SupplierID),
    Quantity INT NOT NULL,
    TransactionType NVARCHAR(50) CHECK (TransactionType IN ('Stock In', 'Stock Out', 'Adjustment')),
    Reason NVARCHAR(255) NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    ManagedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE InventoryTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    TransactionType NVARCHAR(50) CHECK (TransactionType IN ('Stock In', 'Stock Out')),
    TransactionDate DATETIME DEFAULT GETDATE()
);

-- ===============================
--  6. Reports & Analytics
-- ===============================
CREATE TABLE DashboardSummary (
    SummaryID INT IDENTITY(1,1) PRIMARY KEY,
    TotalSales DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalPurchases DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalOrders INT NOT NULL DEFAULT 0,
    TotalCustomers INT NOT NULL DEFAULT 0,
    TotalStock INT NOT NULL DEFAULT 0,
    LowStockProducts INT NOT NULL DEFAULT 0,
    PendingInvoices INT NOT NULL DEFAULT 0,
    ReportDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE DashboardGraphData (
    GraphID INT IDENTITY(1,1) PRIMARY KEY,
    ReportType NVARCHAR(50) CHECK (ReportType IN ('Sales', 'Purchases', 'Stock Trends')),
    ReportDate DATETIME NOT NULL FOREIGN KEY REFERENCES DashboardSummary(ReportDate),
    Value DECIMAL(10,2) NOT NULL
);

CREATE TABLE SalesReports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
    TotalSales DECIMAL(10,2) NOT NULL,
    SalesDate DATETIME DEFAULT GETDATE(),
    GeneratedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE PurchaseReports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierID INT NOT NULL FOREIGN KEY REFERENCES Suppliers(SupplierID),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    QuantityPurchased INT NOT NULL,
    PurchaseDate DATETIME DEFAULT GETDATE(),
    TotalCost DECIMAL(10,2) NOT NULL,
    GeneratedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE StockReports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    StartingStock INT NOT NULL,
    StockAdded INT DEFAULT 0,
    StockSold INT DEFAULT 0,
    CurrentStock INT NOT NULL,
    ReportDate DATETIME DEFAULT GETDATE(),
    GeneratedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

-- ===============================
--  7. Data Summaries & Alerts
-- ===============================
CREATE TABLE DailySalesSummary (
    SummaryID INT IDENTITY(1,1) PRIMARY KEY,
    SalesDate DATE NOT NULL,
    TotalSales DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalOrders INT NOT NULL DEFAULT 0,
    NewCustomers INT NOT NULL DEFAULT 0,
    GeneratedBy INT NOT NULL FOREIGN KEY REFERENCES Users(UserID)
);

CREATE TABLE MonthlyTrends (
    TrendID INT IDENTITY(1,1) PRIMARY KEY,
    MonthYear NVARCHAR(7) NOT NULL, -- Example: '2025-03'
    TotalSales DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalPurchases DECIMAL(10,2) NOT NULL DEFAULT 0,
    BestSellingProduct INT NULL FOREIGN KEY REFERENCES Products(ProductID)
);

CREATE TABLE BestSellingProducts (
    RankID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    TotalSold INT NOT NULL DEFAULT 0,
    LastUpdated DATETIME DEFAULT GETDATE()
);

CREATE TABLE LowStockAlerts (
    AlertID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    CurrentStock INT NOT NULL,
    ReorderLevel INT NOT NULL,
    AlertDate DATETIME DEFAULT GETDATE()
);
