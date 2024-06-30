namespace LexiconLMS.Core.Results
{
    public class Result
    {
        public bool Success { get; }
        public List<string> Errors { get; } = [];

        public Result()
        {
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(List<string> errors)
        {
            Errors = errors;
        }

        public static Result Ok() => new Result(success: true);
        public static Result Fail(List<string> errors) => new Result(errors);
    }
}
