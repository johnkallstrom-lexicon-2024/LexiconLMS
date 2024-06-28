namespace LexiconLMS.Core.Models.User
{
    public class LoginModel : BaseModel
    {
        [Required]
        public string Email { get; init; } = default!;

        [Required]
        public string Password { get; init; } = default!;
    }
}
