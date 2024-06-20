namespace LexiconLMS.Core.Entities
{
    public class Activity : BaseEntity
    {
        [Required]
        [MinLength(length: 3)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MinLength(length: 3)]
        public string Description { get; set; } = string.Empty;
        
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Computed property
        public string SearchableString => $"{Name} {Description} {StartDate:yyyy-MM-dd} {EndDate:yyyy-MM-dd}";

        // Navigation properties
        public int ModuleId { get; set; }
        public Module Module { get; set; } = new Module();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
