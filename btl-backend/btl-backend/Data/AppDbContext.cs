using Microsoft.EntityFrameworkCore;
using btl_backend.Models;

namespace btl_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TestCase> TestCases { get; set; }
    public DbSet<Topic> Topics { get; set; }

}