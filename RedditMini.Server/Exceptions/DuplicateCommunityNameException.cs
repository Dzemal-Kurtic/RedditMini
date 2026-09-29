namespace RedditMini.Server.Exceptions;

public sealed class DuplicateCommunityNameException : Exception
{
    public string Name { get; }

    public DuplicateCommunityNameException(string name) : base($"The name '{name}' is already taken")
    {
        Name = name;
    }
}
