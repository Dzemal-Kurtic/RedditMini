using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Data;
using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(RedditMiniDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<int> CountByCommunityAsync(int communityId)
    {
        return await _set.CountAsync(p => p.CommunityId == communityId);
    }

    public async Task<IEnumerable<Post>> GetByCommunityAsync(int communityId, int pageNumber = 1, int pageSize = 20)
    {
        return await _set.AsNoTracking().Where(p => p.CommunityId == communityId)
                  .OrderByDescending(p => p.CreatedAt)
                  .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize)
                  .ToListAsync();
    }
}
