using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = _unitOfWork.GetRepository<User>() ?? throw new RepositoryNotFoundException("User");
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.Entities.AsNoTracking().ToListAsync();
        }

        public async Task<Course?> GetCourseAsync(int courseId)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>() ?? throw new RepositoryNotFoundException("Course");
            return await courseRepository.Entities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<IEnumerable<Document>> GetAllDocuments(int userId)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>() ?? throw new RepositoryNotFoundException("Document");
            return await documentRepository.Entities
                .Where(d => d.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _userRepository.Entities.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
