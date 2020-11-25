using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Management_System.Entities
{
    public class Stock
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public byte WarehouseSector { get; set; }
        [Required]
        public DateTime PlacingDate { get; set; }

        public Client Client { get; set; }
    }
}
