using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
