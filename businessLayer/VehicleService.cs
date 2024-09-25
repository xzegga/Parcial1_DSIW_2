using dataLayer;
using entityLayer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace businessLayer
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly PermissionHelper _permissionHelper;

        public VehicleService(VehicleRepository vehicleRepository, PermissionHelper permissionHelper)
        {
            _vehicleRepository = vehicleRepository;
            _permissionHelper = permissionHelper;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle GetVehicleById(int id, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                return _vehicleRepository.GetById(id);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para acceder a este vehículo.");
            }
        }

        public void AddVehicle(Vehicle vehicle, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleRepository.Add(vehicle);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para agregar un nuevo vehículo.");
            }
        }

        public void UpdateVehicle(Vehicle vehicle, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleRepository.Update(vehicle);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar este vehículo.");
            }
        }

        public void DeleteVehicle(int id, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleRepository.Delete(id);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar este vehículo.");
            }
        }

        public string ConvertToJson(Vehicle vehicle)
        {
            return JsonConvert.SerializeObject(vehicle);
        }
    }
}
