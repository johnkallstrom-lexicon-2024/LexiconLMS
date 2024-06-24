using System.Runtime.Serialization;

namespace LexiconLMS.Core.Exceptions
{
    public class RepositoryNotFoundException : Exception
    {
        public RepositoryNotFoundException(string? message) : base(message)
        {
        }

        public RepositoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}