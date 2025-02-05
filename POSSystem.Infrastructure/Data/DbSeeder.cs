using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POSSystem.Core.Entities;
using System.Data;

namespace POSSystem.Infrastructure.Data;

public static class DbSeeder
{
    public static void Seed(POSSystemDbContext context, ILogger logger)
    {
        using var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable);
        try
        {
            logger.LogInformation("Applying pending migrations...");
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                logger.LogInformation("Starting database seeding...");

                // Must seed FIRST: Roles → Employees → Locations
                var roles = SeedRoles(context, logger);
                var employees = SeedEmployees(context, roles, logger);
                var locations = SeedLocationsAndTerminals(context, logger);

                // Then seed dependent entities
                var categories = SeedCategories(context, logger);
                var products = SeedProducts(context, categories, logger);
                SeedInventory(context, products, locations, logger);
                var customers = SeedCustomers(context, logger);
                SeedSales(context, employees, customers, products, logger);

                transaction.Commit();
                logger.LogInformation("Database seeded successfully!");
            }
            else
            {
                logger.LogInformation("Database already contains data - skipping seeding.");
            }
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            logger.LogError(ex, "Database seeding failed!");
            throw;
        }
    }

    private static List<Role> SeedRoles(POSSystemDbContext context, ILogger logger)
    {
        logger.LogInformation("Seeding roles...");

        var roles = new List<Role>
        {
            new() { Name = "Admin" },
            new() { Name = "Cashier" }
        };

        context.Roles.AddRange(roles);
        context.SaveChanges();
        return roles;
    }

    private static List<Employee> SeedEmployees(
        POSSystemDbContext context,
        List<Role> roles,
        ILogger logger)
    {
        logger.LogInformation("Seeding employees...");

        var employees = new List<Employee>
        {
            new()
            {
                UserId = "REPLACE_WITH_ADMIN_USER_ID", // From ASP.NET Identity
                RoleId = roles.First(r => r.Name == "Admin").RoleId,
                HireDate = DateTime.UtcNow
            },
            new()
            {
                UserId = "REPLACE_WITH_CASHIER_USER_ID", // From ASP.NET Identity
                RoleId = roles.First(r => r.Name == "Cashier").RoleId,
                HireDate = DateTime.UtcNow
            }
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
        return employees;
    }

    private static List<Location> SeedLocationsAndTerminals(
        POSSystemDbContext context,
        ILogger logger)
    {
        logger.LogInformation("Seeding locations and terminals...");

        var locations = new List<Location>
        {
            new()
            {
                Name = "Main Store",
                Address = "123 Retail Street, Cityville",
                Terminals = new List<Terminal>
                {
                    new() { Name = "Terminal 1", IsActive = true },
                    new() { Name = "Terminal 2", IsActive = true }
                }
            }
        };

        context.Locations.AddRange(locations);
        context.SaveChanges();
        return locations;
    }

    private static List<Category> SeedCategories(
        POSSystemDbContext context,
        ILogger logger)
    {
        logger.LogInformation("Seeding categories...");

        var categories = new List<Category>
        {
            new() { Name = "Electronics" },
            new() { Name = "Laptops", ParentCategoryId = 1 },
            new() { Name = "Accessories" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();
        return categories;
    }

    private static List<Product> SeedProducts(
        POSSystemDbContext context,
        List<Category> categories,
        ILogger logger)
    {
        logger.LogInformation("Seeding products...");

        var products = new List<Product>
        {
            new()
            {
                SKU = "LP-1001",
                Name = "Premium Laptop",
                Description = "16GB RAM, 1TB SSD",
                Price = 1299.99m,
                Cost = 899.99m,
                CategoryId = categories.First(c => c.Name == "Laptops").CategoryId,
                IsActive = true
            },
            new()
            {
                SKU = "AC-2001",
                Name = "Wireless Mouse",
                Description = "Ergonomic design",
                Price = 29.99m,
                Cost = 12.50m,
                CategoryId = categories.First(c => c.Name == "Accessories").CategoryId,
                IsActive = true
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
        return products;
    }

    private static void SeedInventory(
        POSSystemDbContext context,
        List<Product> products,
        List<Location> locations,
        ILogger logger)
    {
        logger.LogInformation("Seeding inventory...");

        var inventory = products.Select(product => new Inventory
        {
            ProductId = product.ProductId,
            LocationId = locations.First().LocationId,
            Quantity = 50,
            ReorderThreshold = 10,
            LastStocked = DateTime.UtcNow
        }).ToList();

        context.Inventories.AddRange(inventory);
        context.SaveChanges();
    }

    private static List<Customer> SeedCustomers(
        POSSystemDbContext context,
        ILogger logger)
    {
        logger.LogInformation("Seeding customers...");

        var customers = new List<Customer>
        {
            new()
            {
                Email = "john.doe@example.com",
                Phone = "555-123-4567",
                FirstName = "John",
                LastName = "Doe",
                LoyaltyPoints = 100
            }
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();
        return customers;
    }

    private static void SeedSales(
        POSSystemDbContext context,
        List<Employee> employees,
        List<Customer> customers,
        List<Product> products,
        ILogger logger)
    {
        logger.LogInformation("Seeding sales...");

        var sale = new Sale
        {
            TerminalId = context.Terminals.First().TerminalId,
            EmployeeId = employees.First().EmployeeId,
            CustomerId = customers.First().CustomerId,
            Subtotal = products.Sum(p => p.Price),
            Tax = products.Sum(p => p.Price) * 0.07m,
            Total = products.Sum(p => p.Price) * 1.07m,
            PaymentMethod = "Credit",
            PaymentStatus = "Completed",
            SaleDetails = products.Select(p => new SaleDetail
            {
                ProductId = p.ProductId,
                Quantity = 1,
                UnitPrice = p.Price,
                Discount = 0
            }).ToList()
        };

        context.Sales.Add(sale);
        context.SaveChanges();
    }
}