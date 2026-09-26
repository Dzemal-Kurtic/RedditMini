using RedditMini.Server.DTOs;
using RedditMini.Server.Models;
using RedditMini.Server.Repositories;

namespace RedditMini.Server.Services;

public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _communityRepository;
    public CommunityService(CommunityRepository communityRepository)
    {
        _communityRepository = communityRepository;
    }
    public async Task<CommunityDto> CreateAsync(CreateCommunityDto createCommunityDto)
    {
        var community = new Community{ };
        return await _communityRepository.Add(createCommunityDto);
    }

    public Task<IEnumerable<CommunityDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CommunityDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CommunityDto?> UpdateAsync(int id, UpdateCommunityDto updateCommunityDto)
    {
        throw new NotImplementedException();
    }
}
