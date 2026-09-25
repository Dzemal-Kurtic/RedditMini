using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetByCommunityAsync(int communityId, int pageNumber = 1, int pageSize = 20);
    Task<int> CountByCommunityAsync(int communityId);
}
