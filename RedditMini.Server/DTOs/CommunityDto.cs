namespace RedditMini.Server.DTOs;

public record CommunityDto(
    int Id, 
    string Name,
    string? Description,
    DateTime CreatedAt,
    int PostCount
    );

