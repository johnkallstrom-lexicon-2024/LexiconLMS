using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _courseRepository = _unitOfWork.GetRepository<Course>() ?? throw new RepositoryNotFoundException("Course");
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _courseRepository.Entities
                .AsNoTracking()
                .Include(c => c.Modules)
                .Include(c => c.Documents)
                .ToListAsync();
        }

        public async Task<Course?> GetCourseAsync(int id)
        {
            return await _courseRepository.Entities
                .AsNoTracking()
                .Include(c => c.Documents)
                .Include(c => c.Modules)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<User>> GetStudentsAsync(Course course)
        {
            if (course.Users == null || !course.Users.Any())
            {
                var loadedCourse = await _courseRepository.Entities
                    .AsNoTracking()
                    .Where(c => c.Id == course.Id)
                    .Include(c => c.Users)
                    .FirstOrDefaultAsync();

                return loadedCourse?.Users.ToList() ?? Enumerable.Empty<User>();
            }

            return course.Users;
        }

        public async Task<IEnumerable<User>> GetStudentsAsync(int courseId)
        {
            return await GetStudentsAsync(await _courseRepository.Entities.Where(c => c.Id == courseId)?.FirstOrDefaultAsync()!
                ?? throw new InvalidOperationException($"Course with ID {courseId} not found"));
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync(int courseId)
        {
            var courseWithDocuments = await _courseRepository.Entities
                .AsNoTracking()
                .Where(c => c.Id == courseId)
                .Include(c => c.Documents)
                .FirstOrDefaultAsync();

            return courseWithDocuments?.Documents.ToList() ?? Enumerable.Empty<Document>();
        }

        public async Task<IEnumerable<Module>> GetModulesAsync(int courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            return course?.Modules.ToList() ?? Enumerable.Empty<Module>();
        }

        public async Task<IEnumerable<Module>> GetModulesAsync(Course course)
        {
            return await Task.FromResult(course.Modules.ToList());
        }

        public async Task<IEnumerable<Course>> FindCoursesAsync(string searchString)
        {
            return await _courseRepository.FindAsync(c => c.SearchableString.Contains(searchString));
        }

        public async Task AddCourseAsync(Course course)
        {
            course.Created = DateTime.UtcNow;
            course.LastModified = DateTime.UtcNow;
            await _courseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            course.LastModified = DateTime.UtcNow;
            await _courseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Course course)
        {
            await _courseRepository.DeleteAsync(course);
            await _courseRepository.SaveChangesAsync();
        }

        public async Task<OperationResult> ValidateCourseAsync(Course course)
        {
            List<string> result = new();

            if (course.Id == 0)
            {
                result.Add("Course ID is required.");
            }

            if (string.IsNullOrWhiteSpace(course.Name))
            {
                result.Add("Course Name is required.");
            }

            if (string.IsNullOrWhiteSpace(course.Description))
            {
                result.Add("Course Description is required.");
            }

            if (course.EndDate < course.StartDate)
            {
                result.Add("End date must be greater than start date.");
            }

            var overlappingCourses = await _courseRepository.FindAsync(c =>
                           (course.StartDate >= c.StartDate && course.StartDate <= c.EndDate) ||
                           (course.EndDate >= c.StartDate && course.EndDate <= c.EndDate));

            var overlappingCourse = overlappingCourses.FirstOrDefault(c => c.Id != course.Id);
            if (overlappingCourse is not null)
            {
                result.Add($"Course overlaps with course {overlappingCourse.Name} with the period of {overlappingCourse.StartDate} to {overlappingCourse.EndDate}.");
            }

            return result.Any() ? OperationResult.Fail(result) : OperationResult.Ok();
        }
    }
}
