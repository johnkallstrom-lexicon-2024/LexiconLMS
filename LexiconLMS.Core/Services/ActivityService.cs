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
                .AsNoTracking()
                .Include(a => a.Documents)
                .ToListAsync();
        }

        public async Task<Activity?> GetActivityAsync(int id)
        {
            return await _activityRepository.Entities
                .AsNoTracking()
                .Include(a => a.Documents)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Module?> GetModuleAsync(int id)
        {
            return await _activityRepository.Entities?
                .AsNoTracking()?
                .Where(a => a.Id == id)?
                .Select(a => a.Module)?
                .FirstOrDefaultAsync()!;
        }

        public async Task<IEnumerable<Activity>> FindActivitiesAsync(string searchString)
        {
            return await _activityRepository.Entities
                .AsNoTracking()
                .Include(a => a.Documents)
                .Where(a => a.Name.Contains(searchString))
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> FindActivitiesAsync(Expression<Func<Activity, bool>> predicate)
        {
            return await _activityRepository.Entities
                .AsNoTracking()
                .Include(a => a.Documents)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddActivityAsync(Activity activity)
        {
            await _activityRepository.AddAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
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
