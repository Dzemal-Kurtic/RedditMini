using RedditMini.Server.DTOs;
using RedditMini.Server.Models;

namespace RedditMini.Server.Mappings;

public static class PostMappers
{
    public static PostDto ToPostDto(this Post post, string communityName)
    {
        return new PostDto(
            post.Id,
            post.Title,
            post.Content,
            post.CreatedAt,
            post.CommunityId,
            communityName
            );
    }
}
