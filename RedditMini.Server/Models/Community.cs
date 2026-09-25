namespace RedditMini.Server.Models;

public class Community : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Post> Posts { get; set; } = [];
}
