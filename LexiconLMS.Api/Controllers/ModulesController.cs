namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IModuleService _moduleService;

        public ModulesController(IModuleService moduleService, IMapper mapper)
        {
            _moduleService = moduleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _moduleService.GetModulesAsync();
            return Ok(_mapper.Map<IEnumerable<ModuleTrimModel>>(modules));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var module = await _moduleService.GetModuleByIdAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ModuleModel>(module));
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule([FromBody] ModuleCreateModel model)
        {
            var module = _mapper.Map<Module>(model);
            var createdModule = await _moduleService.CreateModuleAsync(module);

            return CreatedAtAction(nameof(GetModuleById), new { Id = module.Id }, createdModule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, [FromBody] ModuleUpdateModel model)
        {
            var existingModule = await _moduleService.GetModuleByIdAsync(id);
            if (existingModule == null)
            {
                return NotFound();
            }

            existingModule = _mapper.Map(source: model, destination: existingModule);
            await _moduleService.UpdateModuleAsync(existingModule);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _moduleService.GetModuleByIdAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            await _moduleService.DeleteModuleAsync(module);
            return NoContent();
        }
    }
}
