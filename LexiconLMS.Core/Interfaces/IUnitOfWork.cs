namespace LexiconLMS.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Activity> ActivityRepository { get; }
        public IRepository<Course> CourseRepository { get; }
        public IRepository<Document> DocumentRepository { get; }
        public IRepository<Module> ModuleRepository { get; }
        Task SaveAsync();
    }
}