using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingOperator.Shared.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        // Foreign key to User
        public int UserId { get; set; }

        // Foreign key to Role
        public int RoleId { get; set; }

        // Navigation property to Role
        public Role Role { get; set; }
    }
}
