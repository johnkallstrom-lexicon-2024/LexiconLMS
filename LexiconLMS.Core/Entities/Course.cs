namespace LexiconLMS.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<User> Users { get; set; } = [];
        public ICollection<Document> Documents { get; set; } = [];
        public ICollection<Module> Modules { get; set; } = [];
    }
}
