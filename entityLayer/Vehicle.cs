using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string Status { get; set; } 

        // Relación con la categoría del vehículo
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }        
    }
}
