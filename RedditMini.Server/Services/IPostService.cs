using RedditMini.Server.DTOs;

namespace RedditMini.Server.Services;

public interface IPostService
{
    Task<PostDto?> GetByIdAsync(int id);
    Task<PagedResult<PostDto>?> GetByCommunityAsync(int communityId, int pageNumber = 1, int pageSize = 20);
    Task<PostDto> CreateAsync(CreatePostDto createPostDto);
    Task<PostDto?> UpdateAsync(int id, UpdatePostDto updatePostDto);
    Task<bool> DeleteAsync(int id);
}
