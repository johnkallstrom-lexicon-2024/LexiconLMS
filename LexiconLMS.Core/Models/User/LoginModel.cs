namespace LexiconLMS.Core.Models.User
{
    public record LoginModel
    {
        [Required]
        public string Email { get; init; } = default!;

        [Required]
        public string Password { get; init; } = default!;
    }
}
