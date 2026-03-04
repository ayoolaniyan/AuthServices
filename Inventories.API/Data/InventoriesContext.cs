using Microsoft.EntityFrameworkCore;
using Inventories.API.Models;

namespace Inventories.API.Data
{
    public class InventoriesContext : DbContext
    {
        public InventoriesContext (DbContextOptions<InventoriesContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        
    }
}
