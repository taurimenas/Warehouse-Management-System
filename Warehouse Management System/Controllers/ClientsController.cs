using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse_Management_System.DataAccess;
using Warehouse_Management_System.Entities;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly WarehouseContext _context;

        public ClientsController(WarehouseContext context, ILogger<ClientsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                _logger.LogError("Client id not found.");
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);

            var stocks = await _context.Stocks
                .Where(stock => stock.Client.Id == id)
                .ToListAsync();

            if (client == null)
            {
                _logger.LogError("Client not found.");
                return NotFound();
            }

            var clientPage = new ClientViewModel()
            {
                Client = client,
                Stocks = stocks
            };

            return View(clientPage);
        }

        public IActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,PhoneNumber,Type")] Client client)
        {
            if (ModelState.IsValid)
            {

                var clients = await _context.Clients.ToListAsync();

                foreach (var c in clients)
                {
                    if (c.FirstName == client.FirstName && c.LastName == client.LastName && c.DateOfBirth == client.DateOfBirth)
                    {
                        TempData["ErrorMessage"] = "This client already exists.";
                        _logger.LogWarning("Client not created. This client already exists.");
                        return View(client);
                    }
                }

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                _logger.LogError("Client id not found.");
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                _logger.LogError("Client not found.");
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,DateOfBirth,PhoneNumber,Type")] Client client)
        {
            if (id != client.Id)
            {
                _logger.LogError("Client id not found.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        _logger.LogError("Client not found.");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                _logger.LogError("Client id not found.");
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                _logger.LogError("Client not found.");
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ClientExists(long id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
