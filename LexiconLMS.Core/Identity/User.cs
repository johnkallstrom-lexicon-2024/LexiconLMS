using Microsoft.AspNetCore.Identity;
using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Identity
{
    public class User : BaseIdentityEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Role { get; set; } = default!;

        public override string? NormalizedUserName
        {
            get => {
                if (string.IsNullOrWhiteSpace(base.NormalizedUserName))
                {
                    base.NormalizedUserName = $"{FirstName.ToUpperInvariant()} {LastName.ToUpperInvariant()}";
                }
                return base.NormalizedUserName;
            }
            set => base.NormalizedUserName = value;
        }

        // Navigation properties
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
