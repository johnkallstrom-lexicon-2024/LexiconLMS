namespace LexiconLMS.Core.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadTime { get; set; }

        public string SearchableString => $"{Name} {Description}";

        public int? UserId { get; set; }
        public User User { get; set; } = default!;

        public int? CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public int? ModuleId { get; set; }
        public Module Module { get; set; } = default!;

        public int? ActivityId { get; set; }
        public Activity Activity { get; set; } = default!;
    }
}
