using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Services
{
    public interface IModuleService
    {
        Task AddModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
        Task<IEnumerable<Module>> FindModulesAsync(string searchString);
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<IEnumerable<Document>> GetDocumentsByModuleAsync(int moduleId);
        Task<Module?> GetModuleAsync(int id);
        Task<IEnumerable<Module>> GetModulesAsync(int courseId);
        Task UpdateModuleAsync(Module module);
        Task<IEnumerable<Activity>> GetActivitiesAsync(int moduleId);
    }
}