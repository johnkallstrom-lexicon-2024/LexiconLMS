namespace LexiconLMS.Core.Models.Authenticate
{
    public class AuthenticateRequest : BaseModel
    {
        [Required]
        public string Email { get; init; } = default!;

        [Required]
        public string Password { get; init; } = default!;
    }
}
