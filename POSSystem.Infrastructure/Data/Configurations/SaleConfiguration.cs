using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POSSystem.Core.Entities;

namespace POSSystem.Infrastructure.Data.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.SaleId);

        // Configure decimal precision for financial fields  
        builder.Property(s => s.Subtotal)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        builder.Property(s => s.Tax)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        builder.Property(s => s.Total)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        // ... rest of the configuration (relationships, etc.)  
    }
}