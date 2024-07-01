using LexiconLMS.Api.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace LexiconLMS.Api.Controllers
{
    //[IsAuthorized]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IModuleService _moduleService;
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService, IMapper mapper, IModuleService moduleService)
        {
            _activityService = activityService;
            _mapper = mapper;
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _activityService.GetActivitiesAsync();
            return Ok(_mapper.Map<IEnumerable<ActivityTrimModel>>(activities));
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
            var module = await _moduleService.GetModuleByIdAsync(model.ModuleId);
            if (module is null)
            {
                return BadRequest(new { Message = $"No module with id {model.ModuleId} exists" });
            }

            var activity = _mapper.Map<Activity>(model);
            var createdActivity = await _activityService.CreateActivityAsync(activity);

            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, createdActivity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] ActivityUpdateModel model)
        {
            var module = await _moduleService.GetModuleByIdAsync(model.ModuleId);
            if (module is null)
            {
                return BadRequest(new { Message = $"No module with id {model.ModuleId} exists" });
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
