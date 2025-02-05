using POSSystem.Core.Entities;

namespace POSSystem.Core.Interfaces;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int id);
}
