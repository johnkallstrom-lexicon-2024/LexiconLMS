using LexiconLMS.Core.Parameters;

namespace LexiconLMS.Core.Interfaces
{
    public interface IUserService
    {
        Task<Result<string>> LoginUserAsync(string email, string password);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersAsync(UserQueryParams parameters);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<string>> GetUserRolesAsync(User user);
    }
}
