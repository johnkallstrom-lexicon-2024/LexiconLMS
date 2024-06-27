namespace LexiconLMS.Core.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<Module?> GetModuleByIdAsync(int id);
        Task<Module> CreateModuleAsync(Module module);
        Task UpdateModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
    }
}