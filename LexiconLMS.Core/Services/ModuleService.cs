namespace LexiconLMS.Core.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Module> _moduleRepository;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _moduleRepository = _unitOfWork.GetRepository<Module>() ?? throw new RepositoryNotFoundException("Module");
        }
    }
}
