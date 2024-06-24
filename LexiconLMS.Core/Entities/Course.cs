using LexiconLMS.Core.Identity;

namespace LexiconLMS.Core.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public required string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public required string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(3);

        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd}";

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
