using System;
using System.Collections.Generic;
using Warehouse_Management_System.Entities;

namespace Warehouse_Management_System.SampleData
{
    public static class DataGenerator
    {
        public static List<Stock> StockData(List<Client> clients)
        {
            var list = new List<Stock>
            {
                new Stock
                {
                    Name = "Carpets",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Tyles",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Bricks",
                    Weight = new Random().Next(5000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Wallpapers",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Vinyl floor",
                    Weight = new Random().Next(1200),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Vinyl plank",
                    Weight = new Random().Next(2000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Laminate",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Glue",
                    Weight = new Random().Next(500),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Panel moulding",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                },
                new Stock
                {
                    Name = "Scirting panel",
                    Weight = new Random().Next(1000),
                    ClientId = clients[new Random().Next(10)].Id,
                    WarehouseSector = (byte)new Random().Next(10)
                }
            };
            return list;
        }

        public static List<Client> ClientData()
        {
            var list = new List<Client>
            {
                new Client
                {
                    FirstName = "Darcie",
                    LastName = "Jemima",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1980, 1, 10),
                    PhoneNumber = "817-867-0805",
                },
                new Client
                {
                    FirstName = "Kellen",
                    LastName = "Mickey",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1981, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Celia",
                    LastName = "Jolene",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1985, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Lara",
                    LastName = "Dorothy",
                    Type = ClientType.Loyal,
                    DateOfBirth = new DateTime(1980, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Case",
                    LastName = "Abel",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1980, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Gordy",
                    LastName = "Biddy",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1980, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Leanora",
                    LastName = "May",
                    Type = ClientType.Loyal,
                    DateOfBirth = new DateTime(198, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Clinton",
                    LastName = "Genie",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1984, 1, 10),
                    PhoneNumber = "817-867-0805"
                },
                new Client
                {
                    FirstName = "Sunshine",
                    LastName = "Bev",
                    Type = ClientType.Loyal,
                    DateOfBirth = new DateTime(1950, 1, 10),
                    PhoneNumber = "512-207-2211"
                },
                new Client
                {
                    FirstName = "Adrienne",
                    LastName = "Sparrow",
                    Type = ClientType.Regular,
                    DateOfBirth = new DateTime(1975, 1, 10),
                    PhoneNumber = "817-867-0805"
                }
            };

            return list;
        }
    }
}
