namespace LexiconLMS.Core.Models.User
{
    public class UserCreateModel : BaseModel
    {
        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        public string? UserName { get; set; }
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; } = default!;

        public List<string> Roles { get; set; } = [];
        public int? CourseId { get; set; }
    }
}