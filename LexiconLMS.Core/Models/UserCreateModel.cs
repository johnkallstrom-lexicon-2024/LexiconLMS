namespace LexiconLMS.Core.Models
{
    public record UserCreateModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }

        public List<string> Roles { get; set; } = [];
        public int? CourseId { get; set; }
    }
}
