namespace RedditMini.Server.DTOs;

public record PostDto(
    int Id, 
    string Title,
    string Content,
    DateTime CreatedAt,
    int CommunityId,
    string CommunityName
    );
