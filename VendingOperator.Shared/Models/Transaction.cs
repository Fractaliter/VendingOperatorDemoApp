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

        [ForeignKey("Machine")]
        public int MachineId { get; set; }

        public VendingMachine Machine { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [ForeignKey("User")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal AmountPaid { get; set; }
    }
}
