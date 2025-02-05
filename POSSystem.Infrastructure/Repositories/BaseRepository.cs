using Microsoft.EntityFrameworkCore;
using POSSystem.Core.Interfaces;
using POSSystem.Infrastructure.Data;

namespace POSSystem.Infrastructure.Repositories;

public class BaseRepository<T>(POSSystemDbContext context) : IBaseRepository<T> where T : class
{
    protected readonly POSSystemDbContext _context = context;

    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}