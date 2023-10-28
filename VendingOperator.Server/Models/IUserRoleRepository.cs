using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface IUserRoleRepository
    {
        Task AssignRoleToUser(int userId, int roleId);
        Task<IEnumerable<Role>> GetRolesForUser(int userId);
        Task<bool> UserHasRole(int userId, int roleId);
    }
}