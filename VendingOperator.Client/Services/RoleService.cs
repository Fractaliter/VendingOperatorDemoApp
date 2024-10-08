using Azure;
using VendingOperator.Client.Shared;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public class RoleService : IRoleService
    {
        private IHttpService _httpService;

        public RoleService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        // Call the API to fetch all roles
        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            return await _httpService.Get<List<RoleViewModel>>("api/role/getallroles");
        }
    }

}
