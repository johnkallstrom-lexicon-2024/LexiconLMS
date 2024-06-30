namespace LexiconLMS.Core.Models.Authenticate
{
    public class AuthenticateRequest : BaseModel
    {
        [Required]
        public string Email { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
