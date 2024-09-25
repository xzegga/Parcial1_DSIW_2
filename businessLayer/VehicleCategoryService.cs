using dataLayer;
using entityLayer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json; // Para la conversión a JSON
using System;
using System.Collections.Generic;

namespace businessLayer
{
    public class VehicleCategoryService
    {
        private readonly VehicleCategoryRepository _vehicleCategoryRepository;
        private readonly PermissionHelper _permissionHelper; // Usamos el helper de permisos

        public VehicleCategoryService(VehicleCategoryRepository vehicleCategoryRepository, PermissionHelper permissionHelper)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
            _permissionHelper = permissionHelper; // Inyectamos el helper de permisos
        }

        public IEnumerable<VehicleCategory> GetAllCategories()
        {
            return _vehicleCategoryRepository.GetAll();
        }

        public VehicleCategory GetCategoryById(int id)
        {
            return _vehicleCategoryRepository.GetById(id);
        }


        public void AddCategory(VehicleCategory vehicleCategory, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleCategoryRepository.Add(vehicleCategory);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para agregar una nueva categoría.");
            }
        }

        public void UpdateCategory(VehicleCategory vehicleCategory, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleCategoryRepository.Update(vehicleCategory);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar esta categoría.");
            }
        }

        public void DeleteCategory(int id, string userId)
        {
            if (_permissionHelper.HasPermission(userId))
            {
                _vehicleCategoryRepository.Delete(id);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar esta categoría.");
            }
        }

        public string ConvertToJson(VehicleCategory vehicleCategory)
        {
            return JsonConvert.SerializeObject(vehicleCategory);
        }

    }
}
