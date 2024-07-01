namespace LexiconLMS.Core.Results
{
    public interface IResult
    {
        public bool Success { get; }
        public List<string> Errors { get; }
    }

    public interface IResult<TValue>
    {
        public bool Success { get; }
        public List<string> Errors { get; }
        public TValue Value { get; }
    }
}
