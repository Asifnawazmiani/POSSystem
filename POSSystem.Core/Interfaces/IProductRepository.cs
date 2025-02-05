using POSSystem.Core.Entities;

namespace POSSystem.Core.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id);
}
