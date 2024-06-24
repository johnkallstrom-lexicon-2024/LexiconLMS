namespace LexiconLMS.Core.Services
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; }

        public OperationResult()
        {
            Errors = new List<string>();
        }

        public static OperationResult Ok() => new OperationResult { Success = true };
        public static OperationResult Fail(IEnumerable<string> messages) => new OperationResult { Success = false, Errors = messages };
    }
}
