using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Models;

namespace RedditMini.Server.Data;

public static class SeedData
{
    public static void Seed(DbContext context)
    {
        if (context.Set<Community>().Any())
        {
            return;
        }
        context.Set<Community>().AddRange(BuildCommunities());
        context.SaveChanges();
    }

    public static async Task SeedAsync(DbContext context, CancellationToken cancellationToken = default)
    {
        if (await context.Set<Community>().AnyAsync(cancellationToken))
        {
            return;
        }

        context.Set<Community>().AddRange(BuildCommunities());
        await context.SaveChangesAsync(cancellationToken);
    }

    private static List<Community> BuildCommunities()
    {
        var now = DateTime.UtcNow;

        (string Name, string Description)[] seedCommunities =
        [
            ("csharp", "The C# language, runtime and tooling."),
            ("dotnet", "Everything .NET: ASP.NET Core, EF Core, MAUI."),
            ("efcore", "Entity Framework Core questions and patterns."),
            ("react", "React, hooks and the wider ecosystem."),
            ("typescript", "Types, generics and compiler settings."),
            ("sqlserver", "T-SQL, indexes and query plans."),
            ("webdev", "Frontend, backend and everything between."),
            ("devops", "CI/CD, containers and deployment."),
            ("learnprogramming", "Beginner questions welcome."),
            ("showoff", "Share what you built.")
        ];

        var communities = seedCommunities
            .Select((c, i) => new Community
            {
                Name = c.Name,
                Description = c.Description,
                CreatedAt = now.AddDays(-30 + i)
            })
            .ToList();

        (int CommunityIndex, string Title, string Content)[] seedPosts =
        [
            (0, "Records vs classes: when do you actually reach for a record?",
                "I default to records for DTOs and classes for entities. Is that the right line to draw?"),
            (0, "Primary constructors are growing on me",
                "Started out hating them, now half my services use them. Anyone else turn around on this?"),
            (0, "What's your favourite underused LINQ method?",
                "Mine is Chunk. Saved me writing a manual batching loop more than once."),
            (0, "Nullable reference types: worth enabling on an existing project?",
                "Inherited a solution with it off. Is the warning cleanup worth the effort?"),
            (1, "Minimal APIs or controllers for a new project?",
                "Controllers feel more structured but minimal APIs are less ceremony. What drives your choice?"),
            (1, "How do you structure a service layer without it becoming passthroughs?",
                "Half my service methods just forward to the repository. Is that a smell or just early days?"),
            (1, "ProblemDetails is underrated",
                "Switched to a global exception handler returning ProblemDetails and my client code got simpler."),
            (2, "AsNoTracking: when does it actually matter?",
                "I know it skips change tracking, but what size of result set before you notice?"),
            (2, "Should repositories call SaveChanges?",
                "Settled on a separate unit of work since every repository shares one DbContext."),
            (3, "useEffect dependency arrays still catch me out",
                "Specifically when the dependency is an object. What's the pattern you reach for?")
        ];

        foreach (var (index, title, content) in seedPosts)
        {
            communities[index].Posts.Add(new Post
            {
                Title = title,
                Content = content,
                CreatedAt = now.AddHours(-seedPosts.Length + communities[index].Posts.Count)
            });
        }

        return communities;
    }
}
