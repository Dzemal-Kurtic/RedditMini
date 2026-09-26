using RedditMini.Server.DTOs;
using RedditMini.Server.Models;

namespace RedditMini.Server.Mappings;

public static class CommunityMappers
{
    public static CommunityDto ToCommunityDto(this Community community, int postCount)
    {
        return new CommunityDto(
            community.Id,
            community.Name,
            community.Description,
            community.CreatedAt,
            postCount
            );
    }
}
