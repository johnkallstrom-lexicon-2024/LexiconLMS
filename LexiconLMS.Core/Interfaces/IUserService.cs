using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<IEnumerable<Document>> GetAllDocuments(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<Course?> GetCourseAsync(int courseId);
        Task<User?> GetUserAsync(int id);
        Task UpdateUserAsync(User user);
    }
}