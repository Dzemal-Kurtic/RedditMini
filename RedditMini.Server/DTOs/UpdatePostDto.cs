using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record UpdatePostDto(
    [property: Required] string Content
    );
