using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using System;
using dataLayer;
using businessLayer;
using entityLayer;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace publicLayer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultUserAndRoles();
            SeedVehicleCategories();
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);


            // Configure the application for cookie-based authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30), 
                SlidingExpiration = true
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }

        private void CreateDefaultUserAndRoles()
        {
            // Create the DbContext instance
            using (var context = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                // Check if the Admin role exists; if not, create it
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Check if the User role exists; if not, create it
                if (!roleManager.RoleExists("User"))
                {
                    var role = new IdentityRole("User");
                    roleManager.Create(role);
                }

                // Seed the default Admin user
                if (userManager.FindByName("admin@rentcar.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "admin@rentcar.com",
                        Email = "admin@rentcar.com",
                        FirstName = "Admin",
                        LastName = "User"
                    };

                    string password = "Admin@123"; // Default password
                    var result = userManager.Create(user, password);

                    // If the user is created successfully, assign the Admin role
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }

                // Seed a default regular user
                if (userManager.FindByName("user@example.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "user@example.com",
                        Email = "user@example.com",
                        FirstName = "Regular",
                        LastName = "User"
                    };

                    string password = "User@123"; // Default password
                    var result = userManager.Create(user, password);

                    // If the user is created successfully, assign the User role
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "User");
                    }
                }

                // You can seed more users if needed
            }
        }

        private void SeedVehicleCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                if (!context.VehicleCategories.Any())
                {
                    context.VehicleCategories.AddRange(new[]
                    {
                        new VehicleCategory { CategoryName = "Sedan" },
                        new VehicleCategory { CategoryName = "SUV" },
                        new VehicleCategory { CategoryName = "Hatchback" },
                        new VehicleCategory { CategoryName = "Convertible" },
                        new VehicleCategory { CategoryName = "Pickup" }
                    });

                    context.SaveChanges(); // Guardamos los cambios
                }
            }
        }
    }
}