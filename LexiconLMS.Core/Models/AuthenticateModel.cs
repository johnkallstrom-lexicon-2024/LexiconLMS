namespace LexiconLMS.Core.Models
{
    public record AuthenticateModel
    {
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
    }
}
