using POSSystem.Core.Entities;
using POSSystem.Core.Interfaces;

namespace POSSystem.Infrastructure.Services;

public class ProductService(IProductRepository ProductRepository) : IProductService
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await ProductRepository.GetProductByIdAsync(id);
    }
}
