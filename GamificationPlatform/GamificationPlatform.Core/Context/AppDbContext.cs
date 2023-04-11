using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Core.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<User> User { get; set; }
    public DbSet<Badge> Badge { get; set; }
    public DbSet<InProgressBadge> InProgressBadge { get; set; }
}