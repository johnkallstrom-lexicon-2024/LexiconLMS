using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Repository;

namespace LexiconLMS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return await userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return await userRepository.GetAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            await userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            await userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            await userRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }


}
