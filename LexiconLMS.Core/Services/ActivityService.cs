using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LexiconLMS.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Activity> _activityRepository;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _activityRepository = _unitOfWork.GetRepository<Activity>() ?? throw new RepositoryNotFoundException("Activity");
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync()
        {
            return await _activityRepository.Entities
                .Include(a => a.Documents)
                .ToListAsync();
        }

        public async Task<Activity?> GetActivityAsync(int id)
        {
            return await _activityRepository.Entities
                .Include(a => a.Documents)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Activity>> FindActivitiesAsync(string searchString)
        {
            return await _activityRepository.Entities
                .Include(a => a.Documents)
                .Where(a => a.Name.Contains(searchString))
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> FindActivitiesAsync(Expression<Func<Activity, bool>> predicate)
        {
            // Consider adding .Include(a => a.Documents) if related documents are needed
            return await _activityRepository.FindAsync(predicate);
        }

        public async Task AddActivityAsync(Activity activity)
        {
            // Consider adding validation here
            activity.Created = DateTime.UtcNow;
            activity.LastModified = DateTime.UtcNow;
            await _activityRepository.AddAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            // Consider adding validation here
            activity.LastModified = DateTime.UtcNow;
            await _activityRepository.UpdateAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            await _activityRepository.DeleteAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
