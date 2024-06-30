using LexiconLMS.Core.Parameters;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(UserQueryParams parameters)
        {
            var users = Enumerable.Empty<User>();

            if (!string.IsNullOrWhiteSpace(parameters.Role))
            {
                users = await _userManager.GetUsersInRoleAsync(parameters.Role);
            }

            users = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                users = users.Where(u => parameters.SearchTerm.Contains($"{u.FirstName} {u.LastName}") || 
                parameters.SearchTerm.Contains(u.UserName) || 
                parameters.SearchTerm.Contains(u.Email));
            }

            return users.ToList();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
    }
}
