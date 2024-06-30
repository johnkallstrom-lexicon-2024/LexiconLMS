namespace LexiconLMS.Core.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public List<string> Errors { get; } = [];

        public Result(bool success)
        {
            Success = success;
        }

        public Result(List<string> errors)
        {
            Errors = errors;
        }

        public static Result Ok() => new Result(true);
        public static Result Fail(List<string> errors) => new Result(errors);
    }

    public class Result<TValue> : IResult<TValue>
    {
        public bool Success { get; }
        public List<string> Errors { get; } = [];
        public TValue Value { get; } = default!;

        public Result(bool success, TValue value)
        {
            Success = success;
            Value = value;
        }

        public Result(List<string> errors)
        {
            Errors = errors;
        }

        public static Result<TValue> Ok(TValue value) => new Result<TValue>(true, value);
        public static Result<TValue> Fail(List<string> errors) => new Result<TValue>(errors);
    }
}
