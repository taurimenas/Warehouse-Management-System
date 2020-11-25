using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Warehouse_Management_System.Models;
using Warehouse_Management_System.DataAccess;
using Warehouse_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using static Warehouse_Management_System.SampleData.DataGenerator;

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
            if (clients.Count == 0)
            {
                var clientData = ClientData();
                await _context.AddRangeAsync(clientData);
                await _context.SaveChangesAsync();

                var generatedClients = await _context.Clients.ToListAsync();
                var stockData = StockData(generatedClients);
                for (int i = 0; i < 5; i++)
                {
                    stockData.AddRange(StockData(generatedClients));
                }
                await _context.AddRangeAsync(stockData);
                await _context.SaveChangesAsync();

                clients = await _context.Clients
                                        .Include(client => client.Stocks)
                                        .ToListAsync();
                _logger.LogInformation("Created Sample Data.");
            }

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

        public async Task<IActionResult> Report()
        {
            var clients = await _context.Clients
                                        .Include(client => client.Stocks)
                                        .OrderByDescending(client => client.Stocks.Count)
                                        .ToListAsync();

            var stocks = await _context.Stocks
                                        .ToListAsync();

            var groups = stocks.GroupBy(stock => stock.WarehouseSector);

            var count = groups.Count();

            groups.Select(st => new Stock
            {
                WarehouseSector = st.FirstOrDefault().WarehouseSector,
                Weight = st.Sum(c => c.Weight)
            });

            var filteredStocks = stocks.OrderByDescending(s => s.Weight).Take(5).ToList();

            var sectors = new List<byte>();
            var sectorsWeights = new List<int>();

            foreach (var st in filteredStocks)
            {
                sectors.Add(st.WarehouseSector);
                sectorsWeights.Add(st.Weight);
            }

            var reportPage = new WarehouseStockReportViewModel()
            {
                Clients = clients.Take(5).ToList(), // Should be in constants file
                Sectors = sectors,
                SectorWeights = sectorsWeights
            };

            return View(reportPage);
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
