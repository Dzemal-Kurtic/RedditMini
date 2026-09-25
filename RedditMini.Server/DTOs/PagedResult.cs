namespace RedditMini.Server.DTOs;

public record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int PageNumber, int PageSize)
{
    public int TotalPages => (PageSize - 1 + TotalCount) / PageSize;
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
