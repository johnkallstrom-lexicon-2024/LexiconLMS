using LexiconLMS.Core.Parameters;

namespace LexiconLMS.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersAsync(UserQueryParams parameters);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<string>> GetUserRolesAsync(User user);
    }
}
