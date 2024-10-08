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
        public async Task<IActionResult> AssignRoleToUser(int userId, int roleId)
        {
            // Get the user and role asynchronously
            var user = await _userRepository.GetUser(userId);
            var role = await _roleRepository.GetRole(roleId);

            // Check if both user and role exist
            if (user != null && role != null)
            {
                // Assign the role asynchronously
                await _userRoleRepository.AssignRoleToUser(userId, roleId);
                return Ok("Role assigned to user successfully.");
            }

            // If either user or role is not found, return a 404
            return NotFound("User or role not found.");
        }

        [HttpGet("user/roles/{userId}")]
        public async Task<IActionResult> GetRolesForUser(int userId)
        {
            var roles = await _userRoleRepository.GetRolesForUser(userId);

            if (roles == null || !roles.Any())
            {
                return Ok(new List<UserRoleViewModel>()); // Return an empty list
            }

            // Return a list of UserRoleViewModel instead of an anonymous object
            var roleViewModels = roles.Select(ur => new UserRoleViewModel
            {
                RoleId = ur.RoleId,
                RoleName = ur.Role.Name
            }).ToList();

            return Ok(roleViewModels);
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
        [HttpDelete("user/deleterole")]
        public IActionResult RemoveRoleFromUser(int userId,int roleId)
        {
            var deleteRoleFromUser = _userRoleRepository.RemoveRoleFromUser(userId, roleId);
           return Ok(deleteRoleFromUser);
        }
    }
}
