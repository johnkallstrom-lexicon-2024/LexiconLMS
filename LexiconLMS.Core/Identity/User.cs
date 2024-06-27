namespace LexiconLMS.Core.Identity
{
    public class User : IdentityUser<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public ICollection<Document> Documents { get; set; } = [];
    }
}
