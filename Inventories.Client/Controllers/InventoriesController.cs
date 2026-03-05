using Microsoft.AspNetCore.Mvc;
using Inventories.Client.ApiServices;
using Inventories.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Inventories.Client.Controllers
{
    [Authorize]
    public class InventoriesController : Controller
    {
        private IInventoryApiService _inventoryApiService;

        public InventoriesController(IInventoryApiService inventoryApiService)
        {
            _inventoryApiService = inventoryApiService ?? throw new ArgumentNullException(nameof(inventoryApiService));
        }

        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _inventoryApiService.GetInventories());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Inventory inventory)
        {
            return View();
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        // POST: Inventories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Inventory inventory)
        {
            return View();
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);            
        }

        private bool InventoryExists(int id)
        {
            return true;
        }
    }
}
