using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course?> GetCourseAsync(int id);
        Task<IEnumerable<Document>> GetDocumentsAsync(int courseId);
        Task<IEnumerable<Module>> GetModulesAsync(int courseId);
        Task<IEnumerable<User>> GetStudentsAsync(Course course);
        Task<IEnumerable<User>> GetStudentsAsync(int courseId);
        Task<IEnumerable<Module>> GetModulesAsync(Course course);
        Task<IEnumerable<Course>> FindCoursesAsync(string searchString);
        Task AddCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
    }
}