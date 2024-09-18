using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string DriverLicenseNumber { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } // Relación con Identity

        // Relación con las reservas (rentals)
        public ICollection<Rental> Rentals { get; set; }
    }
}
