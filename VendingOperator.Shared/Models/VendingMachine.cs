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
    public class VendingMachine
    {
        [Key] // Primary Key
        public int VendingMachineId { get; set; }

        [Required]
        public string VendingMachineName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string VendingMachineStatus { get; set; }

        [Required]
        public int Capacity { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }

    }
}





