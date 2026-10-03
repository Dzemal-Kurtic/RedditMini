using Microsoft.AspNetCore.Identity;

namespace RedditMini.Server.Models;

public class AppUser : IdentityUser
{
    public List<Post> Posts { get; set; } = [];
}
