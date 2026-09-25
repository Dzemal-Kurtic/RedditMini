using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Data;
using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly RedditMiniDbContext _dbContext;
    protected readonly DbSet<T> _set;
    public Repository(RedditMiniDbContext dbContext)
    {
        _dbContext = dbContext;
        _set = dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _set.AnyAsync(e => e.Id == id);
    }
    public void Add(T entity)
    {
        _set.Add(entity);
    }

    public void Delete(T entity)
    {
        _set.Remove(entity);
    }

    public void Update(T entity)
    {
        _set.Update(entity);
    }
}
