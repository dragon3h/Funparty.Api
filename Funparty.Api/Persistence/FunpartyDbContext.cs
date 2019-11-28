using Funparty.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Persistence
{
    public class FunpartyDbContext : DbContext
    {
        public FunpartyDbContext(DbContextOptions<FunpartyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}