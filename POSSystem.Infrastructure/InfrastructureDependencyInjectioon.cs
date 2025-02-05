using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSSystem.Core.Interfaces;
using POSSystem.Infrastructure.Data;
using POSSystem.Infrastructure.Repositories;
using POSSystem.Infrastructure.Services;

namespace POSSystem.Infrastructure;

public static class InfrastructureDependencyInjectioon
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Database Configuration  
        services.AddDbContext<POSSystemDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("POSSystemConnection"))
        );

        // Repositories  
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
