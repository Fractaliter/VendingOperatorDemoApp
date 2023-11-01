using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingOperator.Shared.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("VendingMachine")]
        public int? VendingMachineId { get; set; }

        public VendingMachine? VendingMachine { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public Product? Product { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public User? User { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal AmountPaid { get; set; }
    }
}
