using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface IUserRoleRepository
    {
        Task AssignRoleToUser(int userId, int roleId);
        Task<IEnumerable<UserRole>> GetRolesForUser(int userId);
        Task<bool> UserHasRole(int userId, int roleId);
        PagedResult<UserWithRolesViewModel> GetUsersWithRoles(string? name, int page);
    }
}