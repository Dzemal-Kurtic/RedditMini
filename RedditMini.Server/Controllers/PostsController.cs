using Microsoft.AspNetCore.Mvc;
using RedditMini.Server.DTOs;
using RedditMini.Server.Services;

namespace RedditMini.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<PostDto>> GetById(int id)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post is null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> Create(CreatePostDto createPostDto)
    {
        var post = await _postService.CreateAsync(createPostDto);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<PostDto>> Update(int id, UpdatePostDto updatePostDto)
    {
        var post = await _postService.UpdateAsync(id, updatePostDto);
        if (post is null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _postService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
