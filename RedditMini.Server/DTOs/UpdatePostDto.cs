using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record UpdatePostDto(
    [Required] string Content
    );
