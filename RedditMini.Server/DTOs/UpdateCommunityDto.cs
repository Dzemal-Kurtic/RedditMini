using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record UpdateCommunityDto(
    [MaxLength(500)] string? Description
    );
