namespace LexiconLMS.Core.Entities
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; } = default!;

        public ICollection<Document> Documents { get; set; } = [];
    }
}
