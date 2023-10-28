using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorcrud.Shared.Models
{
    public class VendingMachine
    {
        public int VendingMachineId { get; set; }
        public string VendingMachineName { get; set; } = default!;
    }
}
