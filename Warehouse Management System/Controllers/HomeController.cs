using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_Management_System.Models;
using Warehouse_Management_System.DataAccess;
using Warehouse_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Warehouse_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WarehouseContext _context;

        public HomeController(WarehouseContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients
                                        .Include(client => client.Stocks)
                                        .ToListAsync();

            var homePage = new List<HomeViewModel>();
            foreach (var client in clients)
            {
                homePage.Add(new HomeViewModel()
                {
                    Id = client.Id,
                    ClientFirstName = client.FirstName,
                    ClientLastName = client.LastName,
                    StockQuantity = client.Stocks.Count
                });
            }
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
