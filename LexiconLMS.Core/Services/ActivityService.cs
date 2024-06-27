
namespace LexiconLMS.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync()
        {
            var activites = await _unitOfWork.ActivityRepository.GetListAsync();
            return activites;
        }

        public async Task<Activity?> GetActivityByIdAsync(int id)
        {
            var activity = await _unitOfWork.ActivityRepository.GetByIdAsync(id);
            return activity;
        }

        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            var createdActivity = await _unitOfWork.ActivityRepository.CreateAsync(activity);
            await _unitOfWork.SaveAsync();

            return createdActivity;
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            _unitOfWork.ActivityRepository.Update(activity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            _unitOfWork.ActivityRepository.Delete(activity);
            await _unitOfWork.SaveAsync();
        }
    }
}
