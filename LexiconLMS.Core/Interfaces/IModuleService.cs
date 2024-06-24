using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Services
{
    public interface IModuleService
    {
        Task AddModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
        Task<IEnumerable<Module>> FindModulesAsync(string searchString);
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<IEnumerable<Module>> GetCourseModulesAsync(int courseId);
        Task<Module?> GetModuleAsync(int id);
        Task<IEnumerable<Document>> GetDocumentsAsync(int moduleId);
        Task UpdateModuleAsync(Module module);
        Task<IEnumerable<Activity>> GetActivitiesAsync(int moduleId);
        Task<OperationResult> ValidateCourseModuleAsync(Module module, bool isEditing = false);
    }
}