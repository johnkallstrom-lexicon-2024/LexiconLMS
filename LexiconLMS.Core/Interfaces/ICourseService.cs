using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Services
{
    public interface ICourseService
    {
        Task AddCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task<IEnumerable<Course>> FindCoursesAsync(string searchString);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseAsync(int id);
        Task UpdateCourseAsync(Course course);
    }
}