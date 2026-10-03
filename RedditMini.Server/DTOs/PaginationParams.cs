using System.ComponentModel.DataAnnotations;

namespace RedditMini.Server.DTOs;

public record PaginationParams
{
    public const int MaxPageSize = 100;

    [Range(1, int.MaxValue)]
    public int PageNumber { get; init; } = 1;

    [Range(1, MaxPageSize)]
    public int PageSize { get; init; } = 20;
}