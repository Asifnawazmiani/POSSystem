using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POSSystem.Core.Entities;

namespace POSSystem.Infrastructure.Data.Configurations;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.HasKey(sd => sd.SaleDetailId);

        // Configure decimal precision for pricing  
        builder.Property(sd => sd.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        builder.Property(sd => sd.Discount)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        // ... rest of the configuration (relationships, etc.)  
    }
}
