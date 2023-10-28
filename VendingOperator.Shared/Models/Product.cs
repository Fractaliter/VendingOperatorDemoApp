using VendingOperator.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingOperator.Shared.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Add more properties as needed, such as product category, image URL, etc.

        // Navigation property for related data, e.g., orders or reviews
        // public ICollection<Order> Orders { get; set; }
        // public ICollection<ProductReview> Reviews { get; set; }
    }
}





