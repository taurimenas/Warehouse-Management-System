using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_Management_System.Entities;

namespace Warehouse_Management_System.Models
{
    public class ClientViewModel
    {
        public Client Client { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
