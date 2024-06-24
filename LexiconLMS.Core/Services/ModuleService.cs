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

        public async Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId)
        {
            return await _moduleRepository.Entities
                .AsNoTracking()
                .Where(m => m.CourseId == courseId)
                .Include(m => m.Activities)
                .Include(m => m.Documents)
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(int moduleId)
        {
            var module = await _moduleRepository.Entities
                .AsNoTracking()
                .Where(m => m.Id == moduleId)
                .Include(m => m.Activities)
                .FirstOrDefaultAsync();
            return module?.Activities ?? Enumerable.Empty<Activity>();
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync(int moduleId)
        {
            var module = await _moduleRepository.Entities
                .AsNoTracking()
                .Where(m => m.Id == moduleId)
                .Include(m => m.Documents)
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
                .AsNoTracking()
                .Where(m => m.SearchableString.Contains(searchString))
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

        public async Task<OperationResult> ValidateCourseModuleAsync(Module module, bool isEditing = false)
        {
            List<string> result = new();

            if (module.Id == 0 && isEditing)
            {
                result.Add("Module ID is required.");
            }

            if (string.IsNullOrWhiteSpace(module.Name))
            {
                result.Add("Module Name is required.");
            }

            if (module.CourseId == 0)
            {
                result.Add("Course ID is required.");
            }

            if (string.IsNullOrWhiteSpace(module.Description))
            {
                result.Add("Module Description is required.");
            }

            if (module.EndDate < module.StartDate)
            {
                result.Add("End date must be greater than start date.");
            }

            var overlappingModules = await _moduleRepository.FindAsync(c =>
                       c.CourseId == module.CourseId &&
                       c.Id != module.Id &&
                       ((module.StartDate >= c.StartDate && module.StartDate <= c.EndDate) ||
                       (module.EndDate >= c.StartDate && module.EndDate <= c.EndDate) ||
                       (module.StartDate <= c.StartDate && module.EndDate >= c.EndDate)));

            if (overlappingModules.Any())
            {
                var overlappingModule = overlappingModules.First();
                result.Add($"Module overlaps with existing module {overlappingModule.Name} with the period of {overlappingModule.StartDate} to {overlappingModule.EndDate}.");
            }

            return result.Any() ? OperationResult.Fail(result) : OperationResult.Ok();
        }
    }
}
