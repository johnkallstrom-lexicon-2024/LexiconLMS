namespace LexiconLMS.Core.Entities
{
    public class Activity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd} {EndDate:yyyy-MM-dd}";

        // Navigation properties
        public int ModuleId { get; set; }
        public Module Module { get; set; } = default!;
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
