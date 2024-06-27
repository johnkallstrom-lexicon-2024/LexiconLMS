namespace LexiconLMS.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetListAsync();
            return courses;
        }


        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            return course;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var createdCourse = await _unitOfWork.CourseRepository.CreateAsync(course);
            await _unitOfWork.SaveAsync();

            return createdCourse;
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCourseAsync(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            
            _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveAsync();
        }
    }
}
