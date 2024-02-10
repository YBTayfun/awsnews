using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
{


    public BaseDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<BaseDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer("Server=localhost;Database=IntTechBetaDb;User Id=SA;Password=Password123;MultipleActiveResultSets=true;Encrypt=false");
        var hangfireServiceCollection = new ServiceCollection();

        hangfireServiceCollection.AddHangfire(config =>
    config.UseMemoryStorage());
        hangfireServiceCollection.AddHangfireServer();
        return new(dbContextOptionsBuilder.Options);


    }
}