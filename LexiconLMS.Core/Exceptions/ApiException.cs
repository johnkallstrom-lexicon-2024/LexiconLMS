namespace LexiconLMS.Core.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string? message) : base(message) { }
        public ApiException(string? message, Exception ex) : base(message, ex) { }
    }
}
