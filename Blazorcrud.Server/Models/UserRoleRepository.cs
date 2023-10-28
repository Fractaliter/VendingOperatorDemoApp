using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Blazorcrud.Shared.Models;

namespace Blazorcrud.Server.Models
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AssignRoleToUser(int userId, int roleId)
        {
            _dbContext.UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesForUser(int userId)
        {
            var roleIds = await _dbContext.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .ToListAsync();

            // Retrieve the corresponding roles based on the role IDs
            var roles = await _dbContext.Roles
                .Where(r => roleIds.Contains(r.RoleId))
                .ToListAsync();

            return roles;
        }

        public async Task<bool> UserHasRole(int userId, int roleId)
        {
            return await _dbContext.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
    }
}
