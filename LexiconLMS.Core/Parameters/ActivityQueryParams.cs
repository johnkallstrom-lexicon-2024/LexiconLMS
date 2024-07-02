namespace LexiconLMS.Core.Parameters
{
    public class ActivityQueryParams : IQueryParams
    {
        public string? SearchTerm { get; set; }
        public int ModuleId { get; set; }
    }
}
