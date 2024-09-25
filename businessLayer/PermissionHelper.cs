using entityLayer;
using Microsoft.AspNet.Identity;

namespace businessLayer
{
    public class PermissionHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Verificación de permisos compartida para cualquier entidad
        public bool HasPermission(string userId)
        {
            // Obtener el usuario desde UserManager
            var user = _userManager.FindById(userId);
            if (user == null)
            {
                return false;
            }

            // Verificar si el usuario tiene el rol de administrador
            return _userManager.IsInRole(userId, "admin");
        }
    }
}
