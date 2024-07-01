using Microsoft.EntityFrameworkCore;
using UserManagementService.Domain.Models;

namespace UserManagementService.Infrastructure.Data
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}