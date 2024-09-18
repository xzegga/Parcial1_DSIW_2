using entityLayer;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
             : base("ConexionSql") // This must match your connection string name in Web.config
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
