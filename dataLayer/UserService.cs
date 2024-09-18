using entityLayer;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace dataLayer
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
