using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using InventoryMS.Model;
using System.Data;

namespace InventoryMS.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InventorySMDB"].ConnectionString;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ProductID, ProductName, UnitPrice, QuantityInStock, CategoryID, SupplierID FROM Products";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            UnitPrice = reader.GetDecimal(2),
                            QuantityInStock = reader.GetInt32(3),
                            CategoryID = reader.GetInt32(4),
                            SupplierID = reader.GetInt32(5)
                        };

                        products.Add(product);

                        // ✅ DEBUG OUTPUT
                        System.Diagnostics.Debug.WriteLine($"Loaded Product: {product.ProductID} - {product.ProductName}");
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine($"Total Products Loaded: {products.Count}"); // ✅ Final Count Debug
            return products;
        }


        /*public async Task<Product> GetProductById(int id)
        {
            Product product = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT ProductID, ProductName, ProductImage, UnitPrice, QuantityInStock, CategoryID, SupplierID FROM Products WHERE ProductID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            product = new Product
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductImage = reader.IsDBNull(2) ? null : (byte[])reader[2],
                                UnitPrice = reader.GetDecimal(3),
                                QuantityInStock = reader.GetInt32(4),
                                CategoryID = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                                SupplierID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return product;
        }

        public async Task AddProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO Products (ProductName, ProductImage, UnitPrice, QuantityInStock, CategoryID, SupplierID) VALUES (@name, @image, @price, @stock, @category, @supplier)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@image", product.ProductImage ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@stock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@category", product.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@supplier", product.SupplierID ?? (object)DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "UPDATE Products SET ProductName = @name, ProductImage = @image, UnitPrice = @price, QuantityInStock = @stock, CategoryID = @category, SupplierID = @supplier WHERE ProductID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", product.ProductID);
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@image", product.ProductImage ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@stock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@category", product.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@supplier", product.SupplierID ?? (object)DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM Products WHERE ProductID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }*/
    }
}
