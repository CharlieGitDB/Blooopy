using Blooopy.Data;
using Microsoft.EntityFrameworkCore;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeed(DbContextOptions<BlooopContext> options, int count)
    {
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<BlooopContext>(options)
            .UseLoggerFactory(factory);

        using var context = new BlooopContext(builder.Options);

        if (await context.Database.EnsureCreatedAsync())
        {
            var seed = new SeedBlooops();
            await seed.SeedDatabaseWithBlooops(context, count);
        }
    }
}