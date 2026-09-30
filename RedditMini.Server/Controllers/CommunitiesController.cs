using Microsoft.AspNetCore.Mvc;
using RedditMini.Server.DTOs;
using RedditMini.Server.Services;

namespace RedditMini.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunitiesController : ControllerBase
{
    private readonly ICommunityService _communityService;
    private readonly IPostService _postService;

    public CommunitiesController(ICommunityService communityService, IPostService postService)
    {
        _communityService = communityService;
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommunityDto>>> GetAll()
    {
        var communities = await _communityService.GetAllAsync();
        return Ok(communities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<CommunityDto>> GetById(int id)
    {
        var community = await _communityService.GetByIdAsync(id);
        if (community is null)
        {
            return NotFound();
        }
        return Ok(community);
    }

    [HttpGet]
    [Route("{id}/posts")]
    public async Task<ActionResult<PagedResult<PostDto>>> GetByCommunity(int id, int pageNumber = 1, int pageSize = 20)
    {
        var pagedPostsDtos = await _postService.GetByCommunityAsync(id, pageNumber, pageSize);
        if (pagedPostsDtos is null)
        {
            return NotFound();
        }
        return Ok(pagedPostsDtos);
    }

    [HttpPost]
    public async Task<ActionResult<CommunityDto>> Create(CreateCommunityDto createCommunityDto)
    {
        var communityDto = await _communityService.CreateAsync(createCommunityDto);
        return CreatedAtAction(nameof(GetById), new { id = communityDto.Id }, communityDto);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<CommunityDto>> Update(int id, UpdateCommunityDto updateCommunityDto)
    {
        var communityDto = await _communityService.UpdateAsync(id, updateCommunityDto);
        if (communityDto is null)
        {
            return NotFound();
        }
        return Ok(communityDto);
    }
}

