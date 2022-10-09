using System.Diagnostics;
using Blooopy.Models;
using Microsoft.EntityFrameworkCore;

namespace Blooopy.Data;

public class BlooopContext : DbContext
{
    public BlooopContext(DbContextOptions<BlooopContext> options) : base(options)
    {
        Debug.WriteLine($"{ContextId} context created");
    }

    public DbSet<Blooop>? Blooops { get; set; }
    public DbSet<Comment>? Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Blooop)
            .WithMany(b => b.Comments)
            .HasForeignKey(b => b.BlooopId);

        modelBuilder.Entity<Blooop>()
            .HasMany(b => b.Comments)
            .WithOne(c => c.Blooop)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

    public override void Dispose()
    {
        Debug.Write($"{ContextId} context disposed");
        base.Dispose();
    }

    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}