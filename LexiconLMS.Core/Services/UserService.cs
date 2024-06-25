using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }

        public async Task<OperationResult> CreateUserAsync(User user, string password, string[] roles)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            var identityResult = await _userManager.CreateAsync(user);
            if (identityResult.Succeeded)
            {
                foreach (var role in roles)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }
            else
            {
                return OperationResult.Fail(identityResult.Errors.Select(e => e.Description));
            }

            return OperationResult.Ok();
        }

        public async Task<OperationResult> UpdateUserAsync(User user, string newPassword, string[] roles)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            throw new NotImplementedException();
        }

        public async Task<OperationResult> DeleteUserAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var identityResult = await _userManager.DeleteAsync(user);
            if (!identityResult.Succeeded)
            {
                return OperationResult.Fail(identityResult.Errors.Select(x => x.Description));
            }

            return OperationResult.Ok();
        }
    }
}
