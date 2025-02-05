using Microsoft.EntityFrameworkCore;
using POSSystem.Core.Entities;
using POSSystem.Core.Interfaces;
using POSSystem.Infrastructure.Data;

namespace POSSystem.Infrastructure.Repositories;

public class ProductRepository(POSSystemDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }
}
