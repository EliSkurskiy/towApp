using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleRepairServiceNeeds.Models
{
    public class TowInfoAddRequest
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int NumberOfTrucks { get; set; }

        [Required]
        public bool TwentyFourHours { get; set; }

    }
}