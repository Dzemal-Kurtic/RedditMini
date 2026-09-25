using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record CreateCommunityDto(
    [property: Required, MaxLength(50)] string Name,
    [property: MaxLength(500)] string? Description
    );
