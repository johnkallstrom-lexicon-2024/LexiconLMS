namespace LexiconLMS.Core.Parameters
{
    public class UserQueryParams : IQueryParams
    {
        public string? SearchTerm { get; set; }
        public string? Role { get; set; }
    }
}
