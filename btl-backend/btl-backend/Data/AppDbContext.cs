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
    public DbSet<TestCase> TestCases => Set<TestCase>();
    public DbSet<Topic> Topics => Set<Topic>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Class)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.ClassId);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Problems)
            .WithMany(p => p.Classes);

        modelBuilder.Entity<Problem>()
            .HasMany(p => p.Topics)
            .WithMany(t => t.Problems);

        modelBuilder.Entity<Problem>()
            .HasMany(p => p.TestCases)
            .WithOne(tc => tc.Problem);

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