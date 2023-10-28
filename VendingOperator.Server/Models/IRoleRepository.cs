using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface IRoleRepository
    {
        Task AddRole(Role role);
        Task<Role> GetRole(int roleId);
        Task<IEnumerable<Role>> GetRoles();
    }
}