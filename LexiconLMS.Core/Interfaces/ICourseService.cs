namespace LexiconLMS.Core.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseModel>> GetCoursesAsync();
    }
}