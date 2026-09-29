using RedditMini.Server.Models;

namespace RedditMini.Server.Repositories;

public record CommunityWithPostCount(Community Community, int PostCount);

