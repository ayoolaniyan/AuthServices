using Inventories.API.Data;

namespace Inventories.API
{
    public static class WebApplicationExtensions
    {
        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<InventoriesContext>();
            InventoriesContextSeed.SeedAsync(context);
        }
    }
}
