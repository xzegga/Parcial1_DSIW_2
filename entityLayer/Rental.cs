using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class Rental
    {
        public int RentalId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalPrice { get; set; }

        // Relación con el cliente
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Relación con el vehículo
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Status { get; set; }
    }
}
