using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Repository;

namespace LexiconLMS.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            return await activityRepository.GetAllAsync();
        }

        public async Task<Activity?> GetActivityAsync(int id)
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            return await activityRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Activity>> FindActivitiesAsync(string searchString)
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            return await activityRepository.FindAsync(a => a.SearchableString.Contains(searchString));
        }

        public async Task AddActivityAsync(Activity activity)
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            await activityRepository.AddAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            await activityRepository.UpdateAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            var activityRepository = _unitOfWork.GetRepository<Activity>();
            await activityRepository.DeleteAsync(activity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
