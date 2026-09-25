using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record CreatePostDto(
    [property: Required, MaxLength(300)] string Title,
    [property: Required] string Content,
    [property: Range(1, int.MaxValue)] int CommunityId
    );
