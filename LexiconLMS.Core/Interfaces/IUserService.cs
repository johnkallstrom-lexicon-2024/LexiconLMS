using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task UpdateUserAsync(User user);
    }
}