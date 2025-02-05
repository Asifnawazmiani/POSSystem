using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Core.Entities;

namespace POSSystem.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

        // Ensure Price and Cost are configured  
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        builder.Property(p => p.Cost)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        // ... rest of the configuration  
    }
}