namespace LexiconLMS.Core.Models
{
    public record UserModel
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }

        public IEnumerable<string> Roles { get; init; } = [];
    }
}
