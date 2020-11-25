using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse_Management_System.Entities
{
    public class Client
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(24)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(24)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }
        [Required]
        public ClientType Type { get; set; }

        public List<Stock> Stocks { get; set; }
    }

    public enum ClientType
    {
        Regular,
        Loyal
    }
}
