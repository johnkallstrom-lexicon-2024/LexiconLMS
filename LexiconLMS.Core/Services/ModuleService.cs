using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Module> _moduleRepository;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _moduleRepository = _unitOfWork.GetRepository<Module>() ?? throw new RepositoryNotFoundException("Module");
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            return await _moduleRepository.Entities.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Module>> GetModulesAsync(int courseId)
        {
            return await _moduleRepository.Entities
                .Where(m => m.CourseId == courseId)
                .Include(m => m.Activities)
                .Include(m => m.Documents)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(int moduleId)
        {
            var module = await _moduleRepository.Entities
                .Where(m => m.Id == moduleId)
                .Include(m => m.Activities)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return module?.Activities ?? Enumerable.Empty<Activity>();
        }

        public async Task<IEnumerable<Document>> GetDocumentsByModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.Entities
                .Where(m => m.Id == moduleId)
                .Include(m => m.Documents)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return module?.Documents ?? Enumerable.Empty<Document>();
        }

        public async Task<Module?> GetModuleAsync(int id)
        {
            return await _moduleRepository.Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Module>> FindModulesAsync(string searchString)
        {
            return await _moduleRepository.Entities
                .Where(m => m.SearchableString.Contains(searchString))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddModuleAsync(Module module)
        {
            await _moduleRepository.AddAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateModuleAsync(Module module)
        {
            await _moduleRepository.UpdateAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(Module module)
        {
            await _moduleRepository.DeleteAsync(module);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
