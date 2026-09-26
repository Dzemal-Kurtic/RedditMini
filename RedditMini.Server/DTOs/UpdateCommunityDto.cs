using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record UpdateCommunityDto(
    [property: MaxLength(500)] string? Description
    );
