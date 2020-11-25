using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Entities
{
    public class Stock
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public byte WarehouseSector { get; set; } = 1;
        [Required]
        public DateTime PlacingDate { get; set; } = DateTime.UtcNow;

        public Client Client { get; set; }
    }
}
