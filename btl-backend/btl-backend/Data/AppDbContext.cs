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
    }
}