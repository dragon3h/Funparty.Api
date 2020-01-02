using Funparty.Api.Domain.Entities;
using Funparty.Api.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Persistence
{
    public class FunpartyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mascot> Mascots { get; set; }
        public DbSet<MascotPhoto> MascotPhotos { get; set; }

        public FunpartyDbContext(DbContextOptions<FunpartyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MascotConfiguration());
        }
    }
}