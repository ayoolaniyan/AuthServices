using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventories.Client.Models;

namespace Inventories.Client.ApiService
{
    public class InventoryApiService : IInventoryApiService
    {
        public Task<Inventory> CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInventory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            var inventoryList = new List<Inventory>();
            inventoryList.Add(
                new Inventory
                {
                    Id = 1,
                    Genre = "Comedy",
                    Title = "Tulsa King",
                    Rating = "9.0",
                    ImageUrl = "images/src",
                    ReleaseDate = DateTime.Now,
                    Owner = "Selvester"
                }
            );
            return await Task.FromResult(inventoryList);
        }

        public Task<Inventory> GetInventory(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> UpdateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
