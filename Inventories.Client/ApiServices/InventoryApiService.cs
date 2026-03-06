using Duende.IdentityModel.Client;
using Inventories.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;

namespace Inventories.Client.ApiServices
{
    public class InventoryApiService : IInventoryApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InventoryApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            var httpClient = _httpClientFactory.CreateClient("InventoryAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Inventories");

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

        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            if (metaDataResponse.IsError) 
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }

            var accessToken = await _httpContextAccessor
                .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userInfoResponse = await idpClient.GetUserInfoAsync(
               new UserInfoRequest
               {
                   Address = metaDataResponse.UserInfoEndpoint,
                   Token = accessToken
               });
            
            if (userInfoResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while getting user info");
            }

            var userInfoDictionary = new Dictionary<string, string>();

            foreach (var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }

            return new UserInfoViewModel(userInfoDictionary);
        }
    }
}
