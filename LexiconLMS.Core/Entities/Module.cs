using LexiconLMS.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Core.Entities
{
    [DateOrder("StartDate", "EndDate")]
    public class Module : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Computed property
        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd} {EndDate:yyyy-MM-dd}";

        // Navigation properties
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
