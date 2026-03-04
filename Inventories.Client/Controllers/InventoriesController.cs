using Microsoft.AspNetCore.Mvc;
using Inventories.Client.ApiService;
using Inventories.Client.Models;

namespace Inventories.Client.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoryApiService _inventoryApiService;

        public InventoriesController(InventoryApiService inventoryApiService)
        {
            _inventoryApiService = inventoryApiService ?? throw new ArgumentNullException(nameof(inventoryApiService));
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            return View(await _inventoryApiService.GetInventories());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            // var inventory = await _context.Inventory
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (inventory == null)
            // {
            //     return NotFound();
            // }

            return View();
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Inventory inventory)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(inventory);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction(nameof(Index));
            // }
            return View();
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            // var inventory = await _context.Inventory.FindAsync(id);
            // if (inventory == null)
            // {
            //     return NotFound();
            // }
            return View();
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Inventory inventory)
        {
            // if (id != inventory.Id)
            // {
            //     return NotFound();
            // }

            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(inventory);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!InventoryExists(inventory.Id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            return View();
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            // var inventory = await _context.Inventory
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (inventory == null)
            // {
            //     return NotFound();
            // }

            return View();
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
            // var inventory = await _context.Inventory.FindAsync(id);
            // if (inventory != null)
            // {
            //     _context.Inventory.Remove(inventory);
            // }

            // await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            // return _context.Inventory.Any(e => e.Id == id);
            return true;
        }
    }
}
