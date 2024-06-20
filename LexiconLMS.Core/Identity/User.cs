using Microsoft.AspNetCore.Identity;
using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Identity
{
    public class User : IdentityUser<int>
    {
        [Required]
        [MinLength(length: 3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(length: 3)]
        public required string LastName { get; set; } = string.Empty;

        // Computed property
        public string FullName => $"{FirstName} {LastName}";
        // TODO: Add RoleName?
        public string SearchableString => $"{FirstName} {LastName} {Email}";

        // Navigation properties
        public int CourseId { get; set; }
        public Course Course { get; set; } = new Course();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
