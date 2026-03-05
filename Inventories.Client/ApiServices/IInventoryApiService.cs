using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventories.Client.Models;

namespace Inventories.Client.ApiServices
{
    public interface IInventoryApiService
    {
        Task<IEnumerable<Inventory>> GetInventories();
        Task<Inventory> GetInventory(string id);
        Task<Inventory> CreateInventory(Inventory inventory);
        Task<Inventory> UpdateInventory(Inventory inventory);
        Task DeleteInventory(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
