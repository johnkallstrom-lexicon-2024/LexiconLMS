namespace LexiconLMS.Core.Repository
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}