using System.Runtime.Serialization;

namespace LexiconLMS.Core.Repository
{
    [Serializable]
    internal class RepositoryNotFoundException : Exception
    {
        public RepositoryNotFoundException()
        {
        }

        public RepositoryNotFoundException(string? message) : base(message)
        {
        }

        public RepositoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RepositoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}