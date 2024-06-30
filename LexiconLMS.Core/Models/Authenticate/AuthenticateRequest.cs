namespace LexiconLMS.Core.Models.Authenticate
{
    public class AuthenticateRequest : BaseModel
    {
        [Required(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a correct password")]
        public string Password { get; set; } = default!;
    }
}
