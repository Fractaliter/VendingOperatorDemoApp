using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
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

        public async Task<IEnumerable<UserRole>> GetRolesForUser(int userId)
        {
              return await _dbContext.UserRoles
             .Include(ur => ur.Role)  // Make sure the Role is included
             .Where(ur => ur.UserId == userId)
             .ToListAsync();  // This will materialize the query
        }

        public async Task<bool> UserHasRole(int userId, int roleId)
        {
            return await _dbContext.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
        public  PagedResult<UserWithRolesViewModel>GetUsersWithRoles(string? name, int page)
        {
            int pageSize = 5;
            var users =  _dbContext.Users
               .Select(u => new UserWithRolesViewModel
               {
                   Id = u.Id,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Username = u.Username,
                   Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == u.Id)
                .Select(ur => new UserRoleViewModel
                {
                    RoleId = ur.RoleId,
                    RoleName = _dbContext.Roles.FirstOrDefault(r => r.RoleId == ur.RoleId).Name
                }).ToList()
               })
               .GetPaged(page, pageSize);


            return users;
        }
    }
}
