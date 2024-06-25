namespace LexiconLMS.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<OperationResult> LoginWithUserNameAsync(string username, string password);
        Task<OperationResult> LoginWithEmailAsync(string email, string password);
        Task<OperationResult> CreateUserAsync(User user, string password, string[] roles);
        Task<OperationResult> UpdateUserAsync(User user, string newPassword, string[] roles);
        Task<OperationResult> DeleteUserAsync(User user);
    }
}
