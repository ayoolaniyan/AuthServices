using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class InventoriesContext : DbContext
    {
        public InventoriesContext (DbContextOptions<InventoriesContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory.API.Models.Inventory> Inventories { get; set; }
        
    }
}
