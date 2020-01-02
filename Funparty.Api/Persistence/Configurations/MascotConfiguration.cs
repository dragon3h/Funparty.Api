using Funparty.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funparty.Api.Persistence.Configurations
{
    public class MascotConfiguration : IEntityTypeConfiguration<Mascot>
    {
        public void Configure(EntityTypeBuilder<Mascot> builder)
        {
            builder.Property(e => e.Category).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.RentPrice).HasColumnType("decimal(18,2)").HasDefaultValue(0M);
            builder.Property(e => e.SalePrice).HasColumnType("decimal(18,2)").HasDefaultValue(0M);
        }
    }
}
