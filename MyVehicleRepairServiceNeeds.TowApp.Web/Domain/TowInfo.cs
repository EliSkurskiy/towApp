using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleRepairServiceNeeds.TowApp.Web.Domain
{
    public class TowInfo
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
      
        public string PhoneNumber { get; set; }
      
        public int NumberOfTrucks { get; set; }

        public bool TwentyFourHours { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}