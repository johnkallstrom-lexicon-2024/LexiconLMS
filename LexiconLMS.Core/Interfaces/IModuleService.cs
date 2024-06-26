using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Interfaces
{
    public interface IModuleService
    {
        Task AddModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<Module?> GetModuleAsync(int id);
        Task UpdateModuleAsync(Module module);
    }
}