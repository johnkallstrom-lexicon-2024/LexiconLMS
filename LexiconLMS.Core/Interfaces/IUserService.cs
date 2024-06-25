namespace LexiconLMS.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<int> CreateUserAsync(User user, string password, string[] roles);
    }
}
