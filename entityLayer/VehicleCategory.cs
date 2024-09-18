using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class VehicleCategory
    {
        public int VehicleCategoryId { get; set; }
        public string CategoryName { get; set; } // SUV, Sedan, Hatchback, etc.

        // Relación con los vehículos
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
