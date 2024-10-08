using VendingOperator.Client.Shared;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface IUserService
    {
        User User {get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<PagedResult<User>> GetUsers(string? name, string page);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<List<UserRoleViewModel>> GetUserRoles(int userId); // New method to fetch roles
        Task<PagedResult<UserRoleViewModel>> GetUserWithRoles(string? name, string page);
        Task AssignRoleToUser(int userId, int roleId);
        Task RemoveRoleFromUser(int userId, int roleId);
    }
}