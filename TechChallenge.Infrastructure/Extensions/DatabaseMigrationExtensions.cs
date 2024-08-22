using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Data.Context;

namespace TechChallenge.Data.Extensions;

public static class DatabaseMigrationExtensions
{
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<techchallengeDbContext>();
            dbContext.MigrateAsync().GetAwaiter().GetResult();
        }

        return app;
    }
}