namespace RedditMini.Server.Exceptions;

public sealed class CommunityNotFoundException : Exception
{
    public int CommunityId { get; }
    public CommunityNotFoundException(int communityId) : base($"The community with id: '{communityId}' doesn't exist")
    {
        CommunityId = communityId;
    }
}
