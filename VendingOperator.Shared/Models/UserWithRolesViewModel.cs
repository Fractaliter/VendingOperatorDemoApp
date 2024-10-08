using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingOperator.Shared.Models
{
    public class UserWithRolesViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        // List of roles
        public List<UserRoleViewModel> Roles { get; set; } = new List<UserRoleViewModel>();
    }

}
