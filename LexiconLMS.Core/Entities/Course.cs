using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [MinLength(length: 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(length: 3)]
        public string Description { get; set; } = string.Empty;
                
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Computed property
        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd}";

        // Navigation properties
        public User? Teacher { get; set; }
        public ICollection<User> Students { get; set; } = new List<User>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
