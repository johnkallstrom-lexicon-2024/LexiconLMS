using LexiconLMS.Core.Parameters;

namespace LexiconLMS.Core.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivitiesAsync();
        Task<IEnumerable<Activity>> GetActivitiesAsync(ActivityQueryParams parameters);
        Task<Activity?> GetActivityByIdAsync(int id);
        Task<Activity> CreateActivityAsync(Activity activity);
        Task UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesOfModuleIdAsync(int id);
    }
}