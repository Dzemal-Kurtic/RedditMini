using RedditMini.Server.DTOs;

namespace RedditMini.Server.Services;

public interface ICommunityService
{
    Task<IEnumerable<CommunityDto>> GetAllAsync();
    Task<CommunityDto?> GetByIdAsync(int id);
    Task<CommunityDto> CreateAsync(CreateCommunityDto createCommunityDto);
    Task<CommunityDto?> UpdateAsync(int id, UpdateCommunityDto updateCommunityDto);
}
