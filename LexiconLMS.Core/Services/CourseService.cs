using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            return await courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetCourseAsync(int id)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            return await courseRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Course>> FindCoursesAsync(string searchString)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            return await courseRepository.FindAsync(c => c.SearchableString.Contains(searchString));
        }

        public async Task AddCourseAsync(Course course)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            await courseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            await courseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Course course)
        {
            var courseRepository = _unitOfWork.GetRepository<Course>();
            await courseRepository.DeleteAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
