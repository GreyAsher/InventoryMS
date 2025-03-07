using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMS.Model;
using System.IO;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;

namespace InventoryMS.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierID { get; set; }

        public int QuantityInStock { get; set; } = 0;
        public int ReorderLevel { get; set; } = 10;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [MaxLength(50)]
        public string UnitOfMeasure { get; set; }

        [MaxLength(255)]
        public string Barcode { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public byte[] ProductImage { get; set; } // Image stored as binary data

        // Convert byte array to ImageSource for XAML binding
        [NotMapped]
        public BitmapImage ImageSource
        {
            get
            {
                if (ProductImage == null || ProductImage.Length == 0)
                    return null;

                using (var ms = new MemoryStream(ProductImage))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
        }

        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
