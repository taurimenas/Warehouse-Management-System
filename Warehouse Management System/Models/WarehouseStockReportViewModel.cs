using System.Collections.Generic;
using Warehouse_Management_System.Entities;

namespace Warehouse_Management_System.Models
{
    public class WarehouseStockReportViewModel
    {
        public List<Client> Clients { get; set; }
        public List<byte> Sectors { get; set; }
        public List<int> SectorWeights { get; set; }
    }
}
