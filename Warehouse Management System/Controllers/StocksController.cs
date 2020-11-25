using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse_Management_System.DataAccess;
using Warehouse_Management_System.Entities;

namespace Warehouse_Management_System.Controllers
{
    public class StocksController : Controller
    {
        private readonly ILogger<StocksController> _logger;
        private readonly WarehouseContext _context;

        public StocksController(WarehouseContext context, ILogger<StocksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Create(int id)
        {
            TempData["Id"] = id;
            _logger.LogInformation($"Creating stock for client id= {id}.");
            return View(new Stock() { ClientId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,WarehouseSector,PlacingDate")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _ = long.TryParse(TempData["Id"].ToString(), out long clientId);
                stock.ClientId = clientId;
                stock.Client = await _context.Clients
                    .FirstOrDefaultAsync(client => client.Id == stock.ClientId);
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientId }); ;
            }
            return View(stock);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                _logger.LogError("Stock id not found.");
                return NotFound();
            }

            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                _logger.LogError("Stock not found.");
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName", stock.ClientId);
            return View(stock);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ClientId,Id,Name,WarehouseSector,PlacingDate")] Stock stock)
        {
            if (id != stock.Id)
            {
                _logger.LogError("Stock id not found.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Id))
                    {
                        _logger.LogError("Stock does not exist.");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName", stock.ClientId);
            return View(stock);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(long id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
