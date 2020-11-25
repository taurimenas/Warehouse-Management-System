using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_Management_System.Entities;

namespace Warehouse_Management_System.ViewModels
{
    public class HomeViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Client first name")]
        public string ClientFirstName { get; set; }
        [Display(Name = "Client last name")]
        public string ClientLastName { get; set; }
        [Display(Name = "Stock quantity")]
        public int StockQuantity { get; set; }
    }
}
