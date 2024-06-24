using LexiconLMS.Core.Entities;
using System.Linq.Expressions;

namespace LexiconLMS.Core.Services
{
    public interface IActivityService
    {
        Task AddActivityAsync(Activity activity);
        Task DeleteActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> FindActivitiesAsync(string searchString);
        Task<IEnumerable<Activity>> FindActivitiesAsync(Expression<Func<Activity, bool>> predicate);
        Task<Activity?> GetActivityAsync(int id);
        Task<IEnumerable<Activity>> GetActivitiesAsync();
        Task UpdateActivityAsync(Activity activity);
    }
}