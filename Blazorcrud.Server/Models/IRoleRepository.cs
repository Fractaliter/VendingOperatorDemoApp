using Blazorcrud.Shared.Models;

namespace Blazorcrud.Server.Models
{
    public interface IRoleRepository
    {
        Task AddRole(Role role);
        Task<Role> GetRole(int roleId);
        Task<IEnumerable<Role>> GetRoles();
    }
}