namespace LexiconLMS.Core.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseModel>> GetCoursesAsync();
        Task<CourseModel> GetCourseByIdAsync(int id);
    }
}