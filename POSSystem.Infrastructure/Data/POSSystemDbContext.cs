using Microsoft.EntityFrameworkCore;
using POSSystem.Core.Entities;

namespace POSSystem.Infrastructure.Data;

public class POSSystemDbContext(DbContextOptions<POSSystemDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Terminal> Terminals => Set<Terminal>();
    public DbSet<Role> Roles => Set<Role>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entity configurations  
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(POSSystemDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
