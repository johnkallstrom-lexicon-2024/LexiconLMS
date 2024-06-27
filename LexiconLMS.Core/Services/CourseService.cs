namespace LexiconLMS.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseModel>> GetCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetListAsync();
            return _mapper.Map<IEnumerable<CourseModel>>(courses);
        }


        public async Task<CourseModel> GetCourseByIdAsync(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseModel>(course);
        }

    }
}
