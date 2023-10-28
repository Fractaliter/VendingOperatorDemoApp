using VendingOperator.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace VendingOperator.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Upload> Uploads => Set<Upload>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<VendingMachine> VendingMachines => Set<VendingMachine>();
    }
}