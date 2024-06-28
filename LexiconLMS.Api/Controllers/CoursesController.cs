namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(_mapper.Map<IEnumerable<CourseListModel>>(courses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CourseModel>(course));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseCreateModel model)
        {
            var course = _mapper.Map<Course>(model);
            var createdCourse = await _courseService.CreateCourseAsync(course);

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, [FromBody] CourseUpdateModel model)
        {
            var existingCourse = await _courseService.GetCourseByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse = _mapper.Map(source: model, destination: existingCourse);
            await _courseService.UpdateCourseAsync(existingCourse);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(course);

            return NoContent();
        }
    }
}
