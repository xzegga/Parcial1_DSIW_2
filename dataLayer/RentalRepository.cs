using entityLayer;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace dataLayer
{
    public class RentalRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las reservaciones
        public IEnumerable<Rental> GetAll()
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .ToList();
        }

        // Obtener una reservación por ID
        public Rental GetById(int id)
        {
            return _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.RentalId == id);
        }

        // Agregar una nueva reservación
        public void Add(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        // Actualizar una reservación existente
        public void Update(Rental rental)
        {
            _context.Entry(rental).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar una reservación por ID
        public void Delete(int id)
        {
            var rental = _context.Rentals.Find(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }
        }
    }
}
