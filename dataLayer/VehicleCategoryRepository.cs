using entityLayer;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace dataLayer
{
    public class VehicleCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all vehicle categories
        public IEnumerable<VehicleCategory> GetAll()
        {
            return _context.VehicleCategories.ToList();
        }

        // Get a vehicle category by its ID
        public VehicleCategory GetById(int id)
        {
            return _context.VehicleCategories.Find(id);
        }

        // Add a new vehicle category
        public void Add(VehicleCategory vehicleCategory)
        {
            _context.VehicleCategories.Add(vehicleCategory);
            _context.SaveChanges();
        }

        // Update an existing vehicle category
        public void Update(VehicleCategory vehicleCategory)
        {
            _context.Entry(vehicleCategory).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete a vehicle category by ID
        public void Delete(int id)
        {
            var vehicleCategory = _context.VehicleCategories.Find(id);
            if (vehicleCategory != null)
            {
                _context.VehicleCategories.Remove(vehicleCategory);
                _context.SaveChanges();
            }
        }
    }
}
