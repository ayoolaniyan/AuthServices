using Inventories.Client.Models;
using Newtonsoft.Json;

namespace Inventories.Client.ApiServices
{
    public class InventoryApiService : IInventoryApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InventoryApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            var httpClient = _httpClientFactory.CreateClient("InventoryAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Inventories");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var inventoryList = JsonConvert.DeserializeObject<List<Inventory>>(content);
            
            return inventoryList;

        }

        public Task<Inventory> CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInventory(int id)
        {
            throw new NotImplementedException();
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
