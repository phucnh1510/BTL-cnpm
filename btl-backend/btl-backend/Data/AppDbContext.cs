using Microsoft.EntityFrameworkCore;
using btl_backend.Models;

namespace btl_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Problem> Problems => Set<Problem>();
    public DbSet<Submission> Submissions => Set<Submission>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Discussion> Discussions => Set<Discussion>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Classes)
            .WithMany(c => c.Users);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Problems)
            .WithMany(p => p.Classes);

        modelBuilder.Entity<Problem>()
            .HasMany(p => p.Topics)
            .WithMany(t => t.Problems);

        modelBuilder.Entity<Submission>()
            .HasOne(s => s.Problem)
            .WithMany(p => p.Submissions)
            .HasForeignKey(s => s.ProblemId);

        modelBuilder.Entity<Submission>()
            .HasOne(s => s.User)
            .WithMany(u => u.Submissions)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<Discussion>()
            .HasOne(d => d.Author)
            .WithMany(u => u.Discussions)
            .HasForeignKey(d => d.AuthorId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Discussion)
            .WithMany(d => d.Comments)
            .HasForeignKey(c => c.DiscussionId);
    }
}