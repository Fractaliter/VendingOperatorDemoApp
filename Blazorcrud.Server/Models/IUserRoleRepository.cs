using Blazorcrud.Shared.Models;

namespace Blazorcrud.Server.Models
{
    public interface IUserRoleRepository
    {
        Task AssignRoleToUser(int userId, int roleId);
        Task<IEnumerable<Role>> GetRolesForUser(int userId);
        Task<bool> UserHasRole(int userId, int roleId);
    }
}