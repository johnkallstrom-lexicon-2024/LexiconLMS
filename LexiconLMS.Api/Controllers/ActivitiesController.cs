namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _activityService.GetActivitiesAsync();
            return Ok(_mapper.Map<IEnumerable<ActivityModel>>(activities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ActivityModel>(activity));
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = _mapper.Map<Activity>(model);

            await _activityService.CreateActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] ActivityUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingActivity = await _activityService.GetActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            existingActivity = _mapper.Map(source: model, destination: existingActivity);

            await _activityService.UpdateActivityAsync(existingActivity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityService.DeleteActivityAsync(activity);
            return NoContent();
        }

    }
}
