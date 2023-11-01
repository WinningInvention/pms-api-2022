using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace pms_core_api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {

            using (var scope = webApp.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate(); // Apply pending migrations
            }
            return webApp;

        }
    }
}
