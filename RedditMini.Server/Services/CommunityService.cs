using RedditMini.Server.DTOs;
using RedditMini.Server.Exceptions;
using RedditMini.Server.Mappings;
using RedditMini.Server.Models;
using RedditMini.Server.Repositories;

namespace RedditMini.Server.Services;

public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _communityRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CommunityService(
        ICommunityRepository communityRepository,
        IPostRepository postRepository,
        IUnitOfWork unitOfWork
        )
    {
        _communityRepository = communityRepository;
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CommunityDto> CreateAsync(CreateCommunityDto createCommunityDto)
    {
        var nameExists = await _communityRepository.NameExistsAsync(createCommunityDto.Name);
        if (nameExists)
        {
            throw new DuplicateCommunityNameException(createCommunityDto.Name);
        }
        var community = new Community
        {
            Name = createCommunityDto.Name,
            Description = createCommunityDto.Description,
            CreatedAt = DateTime.UtcNow,
        };
        _communityRepository.Add(community);
        await _unitOfWork.SaveChangesAsync();
        return community.ToCommunityDto(0);
    }

    public async Task<IEnumerable<CommunityDto>> GetAllAsync()
    {
        var communities = await _communityRepository.GetAllWithPostCountAsync();
        return communities.Select(c => c.Community.ToCommunityDto(c.PostCount));
    }

    public async Task<CommunityDto?> GetByIdAsync(int id)
    {
        var community = await _communityRepository.GetByIdAsync(id);
        if (community is null)
        {
            return null;
        }
        var postCount = await _postRepository.CountByCommunityAsync(id);
        return community.ToCommunityDto(postCount);
    }

    public async Task<CommunityDto?> UpdateAsync(int id, UpdateCommunityDto updateCommunityDto)
    {
        var community = await _communityRepository.GetByIdAsync(id);
        if (community is null)
        {
            return null;
        }
        community.Description = updateCommunityDto.Description;
        await _unitOfWork.SaveChangesAsync();
        var postCount = await _postRepository.CountByCommunityAsync(community.Id);
        return community.ToCommunityDto(postCount);
    }
}
