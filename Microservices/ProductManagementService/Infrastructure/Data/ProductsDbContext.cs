using Microsoft.EntityFrameworkCore;
using ProductManagementService.Domain.Models;

namespace ProductManagementService.Infrastructure.Data
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}