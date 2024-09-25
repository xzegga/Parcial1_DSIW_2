using entityLayer;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace dataLayer
{
    public class VehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los vehículos
        public IEnumerable<Vehicle> GetAll()
        {
            return _context.Vehicles.Include(v => v.VehicleCategory).ToList();
        }

        // Obtener un vehículo por ID
        public Vehicle GetById(int id)
        {
            return _context.Vehicles.Include(v => v.VehicleCategory).FirstOrDefault(v => v.VehicleId == id);
        }

        // Agregar un nuevo vehículo
        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        // Actualizar un vehículo existente
        public void Update(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar un vehículo por ID
        public void Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }
    }
}
