using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Services
{
    public interface IModuleService
    {
        Task AddModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
        Task<IEnumerable<Module>> FindModulesAsync(string searchString);
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task<Module?> GetModuleAsync(int id);
        Task UpdateModuleAsync(Module module);
    }
}