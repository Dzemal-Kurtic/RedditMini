using RedditMini.Server.DTOs;
using RedditMini.Server.Exceptions;
using RedditMini.Server.Mappings;
using RedditMini.Server.Models;
using RedditMini.Server.Repositories;

namespace RedditMini.Server.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly ICommunityRepository _communityRepository;
    private readonly IUnitOfWork _unitOfWork;
    public PostService(
        IPostRepository postRepository,
        ICommunityRepository communityRepository,
        IUnitOfWork unitOfWork
        )
    {
        _postRepository = postRepository;
        _communityRepository = communityRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<PostDto> CreateAsync(CreatePostDto createPostDto)
    {
        var community = await _communityRepository.GetByIdAsync(createPostDto.CommunityId);
        if (community is null) throw new CommunityNotFoundException(createPostDto.CommunityId);
        var post = new Post
        {
            Title = createPostDto.Title,
            Content = createPostDto.Content,
            CreatedAt = DateTime.UtcNow,
            CommunityId = community.Id
        };
        _postRepository.Add(post);
        await _unitOfWork.SaveChangesAsync();
        return post.ToPostDto(community.Name);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post is null)
        {
            return false;
        }
        _postRepository.Delete(post);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<PagedResult<PostDto>?> GetByCommunityAsync(int communityId, int pageNumber = 1, int pageSize = 20)
    {
        var community = await _communityRepository.GetByIdAsync(communityId);
        if (community is null)
        {
            return null;
        }
        var posts = await _postRepository.GetByCommunityAsync(communityId, pageNumber, pageSize);
        var totalCount = await _postRepository.CountByCommunityAsync(communityId);
        var postDtos = posts.Select(p => p.ToPostDto(community.Name)).ToList();
        return new PagedResult<PostDto>(postDtos, totalCount, pageNumber, pageSize);

    }

    public async Task<PostDto?> GetByIdAsync(int id)
    {
        var post = await _postRepository.GetWithCommunityAsync(id);
        if (post is null)
        {
            return null;
        }
        return post.ToPostDto(post.Community.Name);
    }

    public async Task<PostDto?> UpdateAsync(int id, UpdatePostDto updatePostDto)
    {
        var post = await _postRepository.GetWithCommunityAsync(id);
        if (post is null)
        {
            return null;
        }
        post.Content = updatePostDto.Content;
        await _unitOfWork.SaveChangesAsync();
        return post.ToPostDto(post.Community.Name);
    }
}
