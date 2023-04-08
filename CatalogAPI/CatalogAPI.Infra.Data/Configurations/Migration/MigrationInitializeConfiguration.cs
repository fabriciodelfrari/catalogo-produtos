using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogAPI.Infra.Data.Configurations.Migration
{
    public static class MigrationInitializeConfiguration
    {
        public static void UseMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DbContext>();

            context.Database.Migrate();
        }
    }
}
