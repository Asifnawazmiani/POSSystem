namespace POSSystem.Core.Interfaces;

public interface IBaseRepository<T> where T : class
{
    // Basic CRUD Operations
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

    // Save Changes (could also use Unit of Work separately)
    Task SaveAsync();
}