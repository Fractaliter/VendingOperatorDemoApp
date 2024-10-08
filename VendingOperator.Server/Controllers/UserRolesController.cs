using VendingOperator.Server.Models;
using VendingOperator.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VendingOperator.Server.Controllers
{

    [Route("api")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRolesController(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }


        [HttpPost("role/add")]
        public IActionResult AddRole([FromBody] Role role)
        {
            _roleRepository.AddRole(role);
            return Ok("Role created successfully.");
        }

        [HttpPost("user/assignrole")]
        public IActionResult AssignRoleToUser(int userId, int roleId)
        {
            var user = _userRepository.GetUser(userId);
            var role = _roleRepository.GetRole(roleId);

            if (user != null && role != null)
            {
                _userRoleRepository.AssignRoleToUser(userId, roleId);
                return Ok("Role assigned to user successfully.");
            }

            return NotFound("User or role not found.");
        }

        [HttpGet("user/roles")]
        public async Task<IActionResult> GetRolesForUser(int userId)
        {
            var roles = await _userRoleRepository.GetRolesForUser(userId);

            if (roles == null || !roles.Any())
            {
                return NotFound("No roles found for the specified user.");
            }

            return Ok(roles.Select(ur => new
            {
                ur.RoleId,
                RoleName = ur.Role.Name
            }));
        }

        [HttpGet("user/hasrole")]
        public IActionResult UserHasRole(int userId, int roleId)
        {
            var hasRole = _userRoleRepository.UserHasRole(userId, roleId);
            return Ok(hasRole);
        }

        [HttpGet("user/withroles")]
        public IActionResult GetUsersWithRoles([FromQuery] string? name, int page)
        {
            var usersWithRoles = _userRoleRepository.GetUsersWithRoles(name, page);
            return Ok(usersWithRoles);
        }
    }
}
