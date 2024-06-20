using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Repository;

namespace LexiconLMS.Core.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            return await moduleRepository.GetAllAsync();
        }

        public async Task<Module?> GetModuleAsync(int id)
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            return await moduleRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Module>> FindModulesAsync(string searchString)
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            return await moduleRepository.FindAsync(m => m.SearchableString.Contains(searchString));
        }

        public async Task AddModuleAsync(Module module)
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            await moduleRepository.AddAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateModuleAsync(Module module)
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            await moduleRepository.UpdateAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(Module module)
        {
            var moduleRepository = _unitOfWork.GetRepository<Module>();
            await moduleRepository.DeleteAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
