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
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(24)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = new DateTime(1990, 1, 1);
        [Required]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Display(Name = "Phone number", Prompt = "+370")]
        public string PhoneNumber { get; set; } = "+370";
        [Required]
        public ClientType Type { get; set; } = ClientType.Regular;

        public List<Stock> Stocks { get; set; }
    }

    public enum ClientType
    {
        Regular,
        Loyal
    }
}
