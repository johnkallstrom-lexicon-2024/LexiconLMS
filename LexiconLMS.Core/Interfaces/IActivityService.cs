using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Services
{
    public interface IActivityService
    {
        Task AddActivityAsync(Activity activity);
        Task DeleteActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> FindActivitiesAsync(string searchString);
        Task<Activity?> GetActivityAsync(int id);
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        Task UpdateActivityAsync(Activity activity);
    }
}