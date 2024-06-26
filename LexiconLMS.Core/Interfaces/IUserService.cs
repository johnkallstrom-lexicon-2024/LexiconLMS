namespace LexiconLMS.Core.Interfaces
{
    public interface IUserService
    {
        Task LoginAsync(string email, string password);
    }
}
