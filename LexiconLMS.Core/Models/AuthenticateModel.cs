namespace LexiconLMS.Core.Models
{
    public record AuthenticateModel
    {
        [Required]
        public string Email { get; init; } = default!;

        [Required]
        public string Password { get; init; } = default!;
    }
}
