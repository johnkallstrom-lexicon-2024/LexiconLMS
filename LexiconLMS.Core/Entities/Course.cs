using LexiconLMS.Core.Attributes;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Entities
{
    [DateOrder("StartDate", "EndDate")]
    public class Course : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd}";

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
