using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingOperator.Client.Services;
using VendingOperator.Server.Models;

namespace VendingOperator.Server.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepo;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepo = roleRepository;
        }

        // GET: api/role/getallroles
        [HttpGet("getallroles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleRepo.GetRoles();
            return Ok(roles);
        }
    }

}
