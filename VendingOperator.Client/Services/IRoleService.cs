using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAllRoles();
    }

}
