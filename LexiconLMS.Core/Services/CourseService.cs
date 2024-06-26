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
    }
}
