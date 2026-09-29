using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Data;
using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public class CommunityRepository : Repository<Community>, ICommunityRepository
{
    public CommunityRepository(RedditMiniDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<Community?> GetByNameAsync(string name)
    {
        return await _set.FirstOrDefaultAsync(c => c.Name == name);
    }
    public async Task<IEnumerable<CommunityWithPostCount>> GetAllWithPostCountAsync()
    {
        return await _set
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CommunityWithPostCount(c, c.Posts.Count))
            .ToListAsync();
    }

    public async Task<bool> NameExistsAsync(string name)
    {
        return await _set.AnyAsync(c => c.Name == name);
    }
}
