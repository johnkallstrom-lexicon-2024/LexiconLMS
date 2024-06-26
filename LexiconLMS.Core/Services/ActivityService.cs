using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;

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
    }
}
