using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Entities
{
    public class Stock
    {
        public long ClientId { get; set; }
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Warehouse sector")]
        [Range(1, 40)]
        public byte WarehouseSector { get; set; } = 1;
        [Required]
        [Display(Name = "Placing date")]
        [DataType(DataType.Date)]
        public DateTime PlacingDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int Weight { get; set; } = 0;

        public Client Client { get; set; }
    }
}
