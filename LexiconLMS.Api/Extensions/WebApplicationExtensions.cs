using LexiconLMS.Core.Identity;
using LexiconLMS.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                var context = scope.ServiceProvider.GetRequiredService<LexiconDbContext>();

                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();

                await DatabaseInitializer.SeedAsync(context, userManager, roleManager);
            }
        }
    }
}
