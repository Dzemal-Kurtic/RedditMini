using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Models;

namespace RedditMini.Server.Data;

public class MiniRedditDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Community> Communities { get; set; }
    public MiniRedditDbContext(DbContextOptions<MiniRedditDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Community>(entity =>
        {
            entity.Property(c => c.Name)
                .HasMaxLength(50);
            entity.Property(c => c.Description)
                .HasMaxLength(500);
            entity.HasIndex(c => c.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(p => p.Title)
                .HasMaxLength(300);
        });
    }
}
