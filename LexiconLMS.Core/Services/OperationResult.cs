
namespace LexiconLMS.Core.Services
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message => string.Join(", ", Errors ?? Enumerable.Empty<string>());
        public IEnumerable<string> Errors { get; set; }

        public OperationResult(bool success = true)
        {
            Success = success;
            Errors = Enumerable.Empty<string>();
        }

        public OperationResult(IEnumerable<string> errors)
        {
            Success = false;
            Errors = errors;
        }

        public static OperationResult Ok() => new OperationResult(true);
        public static OperationResult Fail(IEnumerable<string> errors) => new OperationResult(errors);
    }
}
