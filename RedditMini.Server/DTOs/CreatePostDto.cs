using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record CreatePostDto(
    [Required, MaxLength(300)] string Title,
    [Required] string Content,
    [Range(1, int.MaxValue)] int CommunityId
    );
