using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public interface ICommunityRepository : IRepository<Community>
{
    Task<Community?> GetByNameAsync(string name);
    Task<bool> NameExistsAsync(string name);
}
