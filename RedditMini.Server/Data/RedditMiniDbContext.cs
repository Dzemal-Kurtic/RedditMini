using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedditMini.Server.Models;

namespace RedditMini.Server.Data;

public class RedditMiniDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Community> Communities { get; set; } = null!;
    public RedditMiniDbContext(DbContextOptions<RedditMiniDbContext> options) : base(options)
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
            entity.HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
