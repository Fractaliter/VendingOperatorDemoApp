using Blazorcrud.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazorcrud.Server.Models
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRole(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> GetRole(int roleId)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        // You can add more async methods for role management as needed.
    }
}
