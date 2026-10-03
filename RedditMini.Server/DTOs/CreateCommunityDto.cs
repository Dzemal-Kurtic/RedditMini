using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record CreateCommunityDto(
    [Required, MaxLength(50)] string Name,
    [MaxLength(500)] string? Description
    );
