using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingOperator.Shared.Models
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } // Indicates if the role is assigned to the user
    }

}
