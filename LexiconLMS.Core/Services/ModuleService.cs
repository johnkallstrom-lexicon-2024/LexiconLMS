namespace LexiconLMS.Core.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            var modules = await _unitOfWork.ModuleRepository.GetListAsync();
            return modules;
        }

        public async Task<Module?> GetModuleByIdAsync(int id)
        {
            var module = await _unitOfWork.ModuleRepository.GetByIdAsync(id);
            return module;
        }

        public async Task<Module> CreateModuleAsync(Module module)
        {
            if (module is null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var createdModule = await _unitOfWork.ModuleRepository.CreateAsync(module);
            await _unitOfWork.SaveAsync();

            return createdModule;
        }

        public async Task UpdateModuleAsync(Module module)
        {
            if (module is null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            _unitOfWork.ModuleRepository.Update(module);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteModuleAsync(Module module)
        {
            if (module is null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            _unitOfWork.ModuleRepository.Delete(module);
            await _unitOfWork.SaveAsync();
        }
    }
}
