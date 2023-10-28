using Blazorcrud.Server.Models;
using Blazorcrud.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blazorcrud.Server.Controllers
{

    [Route("api")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserRoleRepository _userRoleRepository;

        public UserRolesController(UserRepository userRepository, RoleRepository roleRepository, UserRoleRepository userRoleRepository)
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
        public IActionResult GetRolesForUser(int userId)
        {
            var roles = _userRoleRepository.GetRolesForUser(userId);
            return Ok(roles);
        }

        [HttpGet("user/hasrole")]
        public IActionResult UserHasRole(int userId, int roleId)
        {
            var hasRole = _userRoleRepository.UserHasRole(userId, roleId);
            return Ok(hasRole);
        }
    }
}
