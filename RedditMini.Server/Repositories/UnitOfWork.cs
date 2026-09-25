using RedditMini.Server.Data;

namespace RedditMini.Server.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly RedditMiniDbContext _dbContext;
    public UnitOfWork(RedditMiniDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
