using dataLayer;
using entityLayer;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace businessLayer
{
    public class RentalService
    {
        private readonly RentalRepository _rentalRepository;
        private readonly PermissionHelper _permissionHelper; 

        public RentalService(RentalRepository rentalRepository, PermissionHelper permissionHelper)
        {
            _rentalRepository = rentalRepository;
            _permissionHelper = permissionHelper;
        }

        public IEnumerable<Rental> GetAllReservations()
        {
            return _rentalRepository.GetAll();
        }

        public Rental GetReservationById(int id, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                return _rentalRepository.GetById(id);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para acceder a esta reservación.");
            }
        }

        public void AddReservation(Rental reservation, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _rentalRepository.Add(reservation);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para agregar una nueva reservación.");
            }
        }

        public void UpdateReservation(Rental reservation, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _rentalRepository.Update(reservation);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar esta reservación.");
            }
        }

        public void DeleteReservation(int id, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _rentalRepository.Delete(id);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar esta reservación.");
            }
        }

        public string ConvertToJson(Rental rental)
        {
            return JsonConvert.SerializeObject(rental);
        }
    }
}
